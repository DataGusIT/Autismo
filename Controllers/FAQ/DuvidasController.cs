using FerramentaAutismo.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FerramentaAutismo.Controllers
{
    public class DuvidasController : Controller
    {
        // Lista estática de FAQs para uso temporário
        private static List<FAQ> _faqs = new List<FAQ>
        {
            new FAQ
            {
                Id = 1,
                Pergunta = "O que é o Transtorno do Espectro Autista (TEA)?",
                Resposta = "O Transtorno do Espectro Autista (TEA) é uma condição neurológica que afeta a comunicação, interação social e comportamento da pessoa. Caracteriza-se por desafios na comunicação social e padrões restritos de comportamento, interesses ou atividades. É chamado de 'espectro' porque se manifesta de diferentes formas e intensidades em cada pessoa.",
                Categoria = "Geral",
                Ordem = 1,
                Ativo = true,
                DataCriacao = DateTime.Now
            },
            new FAQ
            {
                Id = 2,
                Pergunta = "Quais são os sinais de autismo em crianças pequenas?",
                Resposta = "Os sinais podem incluir: pouco contato visual, dificuldade em responder ao próprio nome, atraso na fala, movimentos repetitivos (estimulação ou 'stims'), interesses muito restritos, dificuldade com mudanças na rotina, reações incomuns a estímulos sensoriais, e dificuldades na interação social com outras crianças.",
                Categoria = "Diagnóstico",
                Ordem = 2,
                Ativo = true,
                DataCriacao = DateTime.Now
            },
            new FAQ
            {
                Id = 3,
                Pergunta = "Em que idade é possível diagnosticar o autismo?",
                Resposta = "Atualmente, o autismo pode ser diagnosticado com segurança a partir dos 18 a 24 meses de idade. No entanto, muitas crianças recebem o diagnóstico mais tarde. Quanto mais cedo o diagnóstico for realizado, mais cedo a intervenção pode começar, o que geralmente leva a melhores resultados.",
                Categoria = "Diagnóstico",
                Ordem = 3,
                Ativo = true,
                DataCriacao = DateTime.Now
            },
            new FAQ
            {
                Id = 4,
                Pergunta = "O autismo tem cura?",
                Resposta = "O autismo não tem cura, pois não é uma doença, mas uma condição neurológica de desenvolvimento. No entanto, com intervenções adequadas, suporte contínuo e terapias específicas, pessoas autistas podem desenvolver habilidades, superar desafios e ter uma vida plena e satisfatória.",
                Categoria = "Tratamento",
                Ordem = 4,
                Ativo = true,
                DataCriacao = DateTime.Now
            },
            new FAQ
            {
                Id = 5,
                Pergunta = "Quais terapias são recomendadas para pessoas autistas?",
                Resposta = "Algumas terapias comumente recomendadas incluem: Análise do Comportamento Aplicada (ABA), Terapia Ocupacional, Fonoaudiologia, Terapia de Integração Sensorial, Psicoterapia, entre outras. O ideal é que o plano terapêutico seja individualizado, considerando as necessidades específicas de cada pessoa.",
                Categoria = "Tratamento",
                Ordem = 5,
                Ativo = true,
                DataCriacao = DateTime.Now
            },
            new FAQ
            {
                Id = 6,
                Pergunta = "Como posso apoiar uma pessoa autista?",
                Resposta = "Para apoiar uma pessoa autista: respeite seu espaço e tempo, seja claro na comunicação, evite ambientes muito estimulantes quando necessário, aprenda sobre suas necessidades específicas, celebre seus interesses e conquistas, e promova sua autonomia e autodeterminação. O mais importante é ouvir as necessidades individuais da pessoa.",
                Categoria = "Apoio",
                Ordem = 6,
                Ativo = true,
                DataCriacao = DateTime.Now
            },
            new FAQ
            {
                Id = 7,
                Pergunta = "O que é neurodiversidade?",
                Resposta = "Neurodiversidade é um conceito que reconhece as diferenças neurológicas como variações naturais do cérebro humano, não como déficits. Esta abordagem vê condições como autismo, TDAH, dislexia e outras como parte da diversidade humana, não como distúrbios que precisam ser 'consertados'.",
                Categoria = "Conceitos",
                Ordem = 7,
                Ativo = true,
                DataCriacao = DateTime.Now
            }
        };

        // GET: Duvidas
        public IActionResult Index()
        {
            var faqs = _faqs.Where(f => f.Ativo).OrderBy(f => f.Categoria).ThenBy(f => f.Ordem).ToList();

            // Agrupar FAQs por categoria e converter para dicionário
            var faqsPorCategoria = faqs
                .GroupBy(f => f.Categoria)
                .ToDictionary(g => g.Key, g => g.ToList());

            ViewData["Title"] = "Dúvidas Frequentes sobre Autismo";
            return View(faqsPorCategoria);
        }

        // GET: Duvidas/Detalhes/5
        public IActionResult Detalhes(int id)
        {
            var faq = _faqs.FirstOrDefault(f => f.Id == id);

            if (faq == null)
            {
                return NotFound();
            }

            return View(faq);
        }

        // Método para pesquisa de FAQs
        [HttpPost]
        public IActionResult Pesquisar(string termo)
        {
            if (string.IsNullOrWhiteSpace(termo))
            {
                return RedirectToAction(nameof(Index));
            }

            var faqs = _faqs
                .Where(f => f.Ativo &&
                      (f.Pergunta.Contains(termo) ||
                       f.Resposta.Contains(termo)))
                .OrderBy(f => f.Categoria)
                .ThenBy(f => f.Ordem)
                .ToList();

            // Agrupar FAQs por categoria e converter para dicionário
            var faqsPorCategoria = faqs
                .GroupBy(f => f.Categoria)
                .ToDictionary(g => g.Key, g => g.ToList());

            ViewData["TermoPesquisa"] = termo;
            ViewData["Title"] = $"Resultados para '{termo}' - Dúvidas Frequentes";
            return View("Index", faqsPorCategoria);
        }
    }
}
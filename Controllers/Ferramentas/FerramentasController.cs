using FerramentaAutismo.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FerramentaAutismo.Controllers
{
    public class FerramentasController : Controller
    {
        // Temporariamente usando dados estáticos até implementar o banco de dados
        private static List<Ferramenta> _ferramentas = new List<Ferramenta>
        {
            new Ferramenta
            {
                Id = 1,
                Nome = "PECS - Sistema de Comunicação por Troca de Figuras",
                Descricao = "Método de comunicação alternativa por meio de figuras que auxilia pessoas com autismo a se comunicarem de forma eficaz.",
                Tipo = "Comunicação",
                UrlAcesso = "#",
                IconeClasse = "fas fa-comment-dots",
                ImagemUrl = "/img/ferramentas/pecs.jpg",
                Classificacao = 4.8m,
                PublicoAlvo = "Crianças e adultos com dificuldades na comunicação verbal",
                EhGratuita = true
            },
            new Ferramenta
            {
                Id = 2,
                Nome = "ABA - Análise Aplicada do Comportamento",
                Descricao = "Técnica baseada em evidências científicas que foca no desenvolvimento de habilidades e redução de comportamentos desafiadores.",
                Tipo = "Comportamental",
                UrlAcesso = "#",
                IconeClasse = "fas fa-brain",
                ImagemUrl = "/img/ferramentas/aba.jpg",
                Classificacao = 4.7m,
                PublicoAlvo = "Crianças e adolescentes com TEA",
                EhGratuita = false
            },
            new Ferramenta
            {
                Id = 3,
                Nome = "Agenda Visual",
                Descricao = "Ferramenta de organização que auxilia na previsibilidade da rotina diária através de imagens ou símbolos.",
                Tipo = "Organização",
                UrlAcesso = "#",
                IconeClasse = "fas fa-calendar-alt",
                ImagemUrl = "/img/ferramentas/agenda.jpg",
                Classificacao = 4.5m,
                PublicoAlvo = "Crianças com TEA em idade escolar",
                EhGratuita = true
            },
            new Ferramenta
            {
                Id = 4,
                Nome = "Teacch - Tratamento e Educação para Autistas",
                Descricao = "Método estruturado que utiliza recursos visuais para desenvolver a independência e habilidades educacionais.",
                Tipo = "Educacional",
                UrlAcesso = "#",
                IconeClasse = "fas fa-graduation-cap",
                ImagemUrl = "/img/ferramentas/teacch.jpg",
                Classificacao = 4.6m,
                PublicoAlvo = "Estudantes com TEA",
                EhGratuita = false
            },
            new Ferramenta
            {
                Id = 5,
                Nome = "Integração Sensorial",
                Descricao = "Técnica terapêutica que ajuda a processar informações sensoriais do ambiente de forma mais eficiente.",
                Tipo = "Sensorial",
                UrlAcesso = "#",
                IconeClasse = "fas fa-hands",
                ImagemUrl = "/img/ferramentas/sensorial.jpg",
                Classificacao = 4.4m,
                PublicoAlvo = "Crianças com dificuldades de processamento sensorial",
                EhGratuita = false
            },
            new Ferramenta
            {
                Id = 6,
                Nome = "Aplicativos de CAA",
                Descricao = "Aplicativos de Comunicação Aumentativa e Alternativa que auxiliam na comunicação por meio de dispositivos eletrônicos.",
                Tipo = "Tecnologia Assistiva",
                UrlAcesso = "#",
                IconeClasse = "fas fa-mobile-alt",
                ImagemUrl = "/img/ferramentas/caa.jpg",
                Classificacao = 4.3m,
                PublicoAlvo = "Pessoas com dificuldades na comunicação verbal",
                EhGratuita = true
            }
        };

        public IActionResult Index()
        {
            var viewModel = new FerramentasViewModel
            {
                FerramentasComunicacao = _ferramentas.Where(f => f.Tipo == "Comunicação").ToList(),
                FerramentasComportamentais = _ferramentas.Where(f => f.Tipo == "Comportamental").ToList(),
                FerramentasEducacionais = _ferramentas.Where(f => f.Tipo == "Educacional").ToList(),
                FerramentasOrganizacao = _ferramentas.Where(f => f.Tipo == "Organização").ToList(),
                FerramentasSensoriais = _ferramentas.Where(f => f.Tipo == "Sensorial").ToList(),
                FerramentasTecnologicas = _ferramentas.Where(f => f.Tipo == "Tecnologia Assistiva").ToList()
            };

            return View(viewModel);
        }

        public IActionResult Detalhes(int id)
        {
            var ferramenta = _ferramentas.FirstOrDefault(f => f.Id == id);

            if (ferramenta == null)
            {
                return NotFound();
            }

            return View(ferramenta);
        }
    }
}
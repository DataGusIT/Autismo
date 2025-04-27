using FerramentaAutismo.Models;
using FerramentaAutismo.Models.Contatos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FerramentaAutismo.Controllers
{
    public class ContatosController : Controller
    {
        // Temporariamente usando dados estáticos até implementar o banco de dados
        private static List<Contato> _contatos = new List<Contato>
        {
            new Contato
            {
                Id = 1,
                Nome = "Centro de Referência em Autismo",
                Descricao = "Atendimento multidisciplinar especializado para pessoas com Transtorno do Espectro Autista, oferecendo diagnóstico, terapias e acompanhamento contínuo.",
                Tipo = "Clínica",
                WebsiteUrl = "https://www.centroautismo.com.br",
                Telefone = "(11) 3456-7890",
                Email = "contato@centroautismo.com.br",
                Endereco = "Av. Paulista, 1000",
                Cidade = "São Paulo",
                Estado = "SP",
                IconeClasse = "fas fa-hospital",
                ImagemUrl = "/img/contatos/clinica1.jpg",
                Avaliacao = 4.8m,
                AtendimentoOnline = true,
                AtendimentoPresencial = true,
                HorarioFuncionamento = "Segunda a Sexta: 8h às 18h"
            },
            new Contato
            {
                Id = 2,
                Nome = "Dra. Mariana Silva - Neuropsicóloga",
                Descricao = "Especialista em avaliação neuropsicológica e intervenções comportamentais para crianças e adolescentes com TEA.",
                Tipo = "Profissional",
                WebsiteUrl = "https://www.dramariana.com.br",
                Telefone = "(11) 98765-4321",
                Email = "dra.mariana@email.com",
                Endereco = "Rua Augusta, 500, Sala 302",
                Cidade = "São Paulo",
                Estado = "SP",
                IconeClasse = "fas fa-user-md",
                ImagemUrl = "/img/contatos/profissional1.jpg",
                Avaliacao = 4.9m,
                AtendimentoOnline = true,
                AtendimentoPresencial = true,
                HorarioFuncionamento = "Segunda, Quarta e Sexta: 9h às 17h"
            },
            new Contato
            {
                Id = 3,
                Nome = "Associação Amigos do Autismo",
                Descricao = "Organização sem fins lucrativos que promove apoio social, informativo e legal para famílias com membros no espectro autista.",
                Tipo = "Associação",
                WebsiteUrl = "https://www.amigosautismo.org.br",
                Telefone = "(11) 2345-6789",
                Email = "contato@amigosautismo.org.br",
                Endereco = "Rua dos Pinheiros, 300",
                Cidade = "São Paulo",
                Estado = "SP",
                IconeClasse = "fas fa-hands-helping",
                ImagemUrl = "/img/contatos/associacao1.jpg",
                Avaliacao = 4.7m,
                AtendimentoOnline = true,
                AtendimentoPresencial = true,
                HorarioFuncionamento = "Segunda a Sexta: 9h às 17h"
            },
            new Contato
            {
                Id = 4,
                Nome = "Escola Inclusiva Novos Horizontes",
                Descricao = "Instituição de ensino especializada em educação inclusiva com metodologias adaptadas para alunos com necessidades especiais.",
                Tipo = "Escola",
                WebsiteUrl = "https://www.escolanovoshorizontes.edu.br",
                Telefone = "(11) 3344-5566",
                Email = "contato@novoshorizontes.edu.br",
                Endereco = "Alameda Santos, 800",
                Cidade = "São Paulo",
                Estado = "SP",
                IconeClasse = "fas fa-school",
                ImagemUrl = "/img/contatos/escola1.jpg",
                Avaliacao = 4.6m,
                AtendimentoOnline = false,
                AtendimentoPresencial = true,
                HorarioFuncionamento = "Segunda a Sexta: 7h às 17h"
            },
            new Contato
            {
                Id = 5,
                Nome = "Grupo de Apoio TEAcolhe",
                Descricao = "Grupo de suporte para pais e familiares de pessoas com autismo, com encontros mensais e comunidade online de apoio mútuo.",
                Tipo = "Apoio",
                WebsiteUrl = "https://www.teacolhe.org.br",
                Telefone = "(11) 2233-4455",
                Email = "contato@teacolhe.org.br",
                Endereco = "Rua Vergueiro, 450",
                Cidade = "São Paulo",
                Estado = "SP",
                IconeClasse = "fas fa-users",
                ImagemUrl = "/img/contatos/apoio1.jpg",
                Avaliacao = 4.9m,
                AtendimentoOnline = true,
                AtendimentoPresencial = true,
                HorarioFuncionamento = "Encontros: Último sábado do mês, 14h"
            },
            new Contato
            {
                Id = 6,
                Nome = "Linha de Apoio TEA 24h",
                Descricao = "Serviço telefônico gratuito para suporte emergencial e orientação em crises relacionadas a pessoas com TEA.",
                Tipo = "Emergência",
                WebsiteUrl = "https://www.linhaapointea.org.br",
                Telefone = "0800-123-4567",
                Email = "atendimento@linhaapointea.org.br",
                Endereco = "",
                Cidade = "Atendimento Nacional",
                Estado = "",
                IconeClasse = "fas fa-phone-alt",
                ImagemUrl = "/img/contatos/emergencia1.jpg",
                Avaliacao = 4.8m,
                AtendimentoOnline = true,
                AtendimentoPresencial = false,
                HorarioFuncionamento = "24 horas, todos os dias"
            },
            new Contato
            {
                Id = 7,
                Nome = "Instituto Neurosaber",
                Descricao = "Centro especializado em diagnóstico precoce e intervenções terapêuticas baseadas em evidências para crianças com TEA.",
                Tipo = "Clínica",
                WebsiteUrl = "https://www.neurosaber.com.br",
                Telefone = "(11) 3030-4040",
                Email = "atendimento@neurosaber.com.br",
                Endereco = "Av. Brigadeiro Faria Lima, 1500",
                Cidade = "São Paulo",
                Estado = "SP",
                IconeClasse = "fas fa-brain",
                ImagemUrl = "/img/contatos/clinica2.jpg",
                Avaliacao = 4.7m,
                AtendimentoOnline = true,
                AtendimentoPresencial = true,
                HorarioFuncionamento = "Segunda a Sexta: 8h às 19h"
            },
            new Contato
            {
                Id = 8,
                Nome = "Dr. Roberto Campos - Psiquiatra Infantil",
                Descricao = "Especialista em transtornos do neurodesenvolvimento com foco em diagnóstico e tratamento médico para TEA.",
                Tipo = "Profissional",
                WebsiteUrl = "https://www.drrobertocampos.com.br",
                Telefone = "(11) 99876-5432",
                Email = "dr.roberto@email.com",
                Endereco = "Rua Oscar Freire, 700, Conj. 55",
                Cidade = "São Paulo",
                Estado = "SP",
                IconeClasse = "fas fa-stethoscope",
                ImagemUrl = "/img/contatos/profissional2.jpg",
                Avaliacao = 4.8m,
                AtendimentoOnline = true,
                AtendimentoPresencial = true,
                HorarioFuncionamento = "Terças e Quintas: 8h às 17h"
            }
        };

        public IActionResult Index()
        {
            var viewModel = new ContatosViewModel
            {
                ContatosClinicas = _contatos.Where(c => c.Tipo == "Clínica").ToList(),
                ContatosProfissionais = _contatos.Where(c => c.Tipo == "Profissional").ToList(),
                ContatosAssociacoes = _contatos.Where(c => c.Tipo == "Associação").ToList(),
                ContatosEscolas = _contatos.Where(c => c.Tipo == "Escola").ToList(),
                ContatosApoio = _contatos.Where(c => c.Tipo == "Apoio").ToList(),
                ContatosEmergencia = _contatos.Where(c => c.Tipo == "Emergência").ToList()
            };

            return View(viewModel);
        }

        public IActionResult Detalhes(int id)
        {
            var contato = _contatos.FirstOrDefault(c => c.Id == id);

            if (contato == null)
            {
                return NotFound();
            }

            return View(contato);
        }
    }
}
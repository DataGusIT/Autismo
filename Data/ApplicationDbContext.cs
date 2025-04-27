using Microsoft.EntityFrameworkCore;
using FerramentaAutismo.Models;

namespace FerramentaAutismo.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // Outros DbSets existentes...

        public DbSet<Ferramenta> Ferramentas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configurações para a entidade Ferramenta
            modelBuilder.Entity<Ferramenta>()
                .HasKey(f => f.Id);

            modelBuilder.Entity<Ferramenta>()
                .Property(f => f.Nome)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<Ferramenta>()
                .Property(f => f.Descricao)
                .IsRequired()
                .HasMaxLength(500);

            modelBuilder.Entity<Ferramenta>()
                .Property(f => f.DataCadastro)
                .HasDefaultValueSql("GETDATE()");

            // Seed de dados iniciais
            modelBuilder.Entity<Ferramenta>().HasData(
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
                    EhGratuita = true,
                    DataCadastro = System.DateTime.Now
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
                    EhGratuita = false,
                    DataCadastro = System.DateTime.Now
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
                    EhGratuita = true,
                    DataCadastro = System.DateTime.Now
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
                    EhGratuita = false,
                    DataCadastro = System.DateTime.Now
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
                    EhGratuita = false,
                    DataCadastro = System.DateTime.Now
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
                    EhGratuita = true,
                    DataCadastro = System.DateTime.Now
                }
            );
        }
    }
}
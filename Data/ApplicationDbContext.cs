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
        public DbSet<FAQ> FAQs { get; set; }
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

            // Configurações para FAQ
            modelBuilder.Entity<FAQ>()
                .HasKey(f => f.Id);

            modelBuilder.Entity<FAQ>()
                .Property(f => f.Pergunta)
                .IsRequired()
                .HasMaxLength(500);

            modelBuilder.Entity<FAQ>()
                .Property(f => f.Resposta)
                .IsRequired();

            modelBuilder.Entity<FAQ>()
                .Property(f => f.Categoria)
                .HasMaxLength(100);

            modelBuilder.Entity<FAQ>()
                .Property(f => f.DataCriacao)
                .HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<FAQ>()
                .Property(f => f.Ativo)
                .HasDefaultValue(true);

            // Seed de dados para FAQ
            // Dados iniciais para FAQ
            modelBuilder.Entity<FAQ>().HasData(
                new FAQ
                {
                    Id = 1,
                    Pergunta = "O que é o Transtorno do Espectro Autista (TEA)?",
                    Resposta = "O Transtorno do Espectro Autista (TEA) é uma condição neurológica que afeta a comunicação, interação social e comportamento da pessoa. Caracteriza-se por desafios na comunicação social e padrões restritos de comportamento, interesses ou atividades. É chamado de 'espectro' porque se manifesta de diferentes formas e intensidades em cada pessoa.",
                    Categoria = "Geral",
                    Ordem = 1
                },
                new FAQ
                {
                    Id = 2,
                    Pergunta = "Quais são os sinais de autismo em crianças pequenas?",
                    Resposta = "Os sinais podem incluir: pouco contato visual, dificuldade em responder ao próprio nome, atraso na fala, movimentos repetitivos (estimulação ou 'stims'), interesses muito restritos, dificuldade com mudanças na rotina, reações incomuns a estímulos sensoriais, e dificuldades na interação social com outras crianças.",
                    Categoria = "Diagnóstico",
                    Ordem = 2
                },
                new FAQ
                {
                    Id = 3,
                    Pergunta = "Em que idade é possível diagnosticar o autismo?",
                    Resposta = "Atualmente, o autismo pode ser diagnosticado com segurança a partir dos 18 a 24 meses de idade. No entanto, muitas crianças recebem o diagnóstico mais tarde. Quanto mais cedo o diagnóstico for realizado, mais cedo a intervenção pode começar, o que geralmente leva a melhores resultados.",
                    Categoria = "Diagnóstico",
                    Ordem = 3
                },
                new FAQ
                {
                    Id = 4,
                    Pergunta = "O autismo tem cura?",
                    Resposta = "O autismo não tem cura, pois não é uma doença, mas uma condição neurológica de desenvolvimento. No entanto, com intervenções adequadas, suporte contínuo e terapias específicas, pessoas autistas podem desenvolver habilidades, superar desafios e ter uma vida plena e satisfatória.",
                    Categoria = "Tratamento",
                    Ordem = 4
                },
                new FAQ
                {
                    Id = 5,
                    Pergunta = "Quais terapias são recomendadas para pessoas autistas?",
                    Resposta = "Algumas terapias comumente recomendadas incluem: Análise do Comportamento Aplicada (ABA), Terapia Ocupacional, Fonoaudiologia, Terapia de Integração Sensorial, Psicoterapia, entre outras. O ideal é que o plano terapêutico seja individualizado, considerando as necessidades específicas de cada pessoa.",
                    Categoria = "Tratamento",
                    Ordem = 5
                },
                new FAQ
                {
                    Id = 6,
                    Pergunta = "Como posso apoiar uma pessoa autista?",
                    Resposta = "Para apoiar uma pessoa autista: respeite seu espaço e tempo, seja claro na comunicação, evite ambientes muito estimulantes quando necessário, aprenda sobre suas necessidades específicas, celebre seus interesses e conquistas, e promova sua autonomia e autodeterminação. O mais importante é ouvir as necessidades individuais da pessoa.",
                    Categoria = "Apoio",
                    Ordem = 6
                },
                new FAQ
                {
                    Id = 7,
                    Pergunta = "O que é neurodiversidade?",
                    Resposta = "Neurodiversidade é um conceito que reconhece as diferenças neurológicas como variações naturais do cérebro humano, não como déficits. Esta abordagem vê condições como autismo, TDAH, dislexia e outras como parte da diversidade humana, não como distúrbios que precisam ser 'consertados'.",
                    Categoria = "Conceitos",
                    Ordem = 7
                }
            );
        }
    }
}
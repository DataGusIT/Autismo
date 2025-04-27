using System.Collections.Generic;

namespace FerramentaAutismo.Models.Contatos
{
    public class ContatosViewModel
    {
        public List<Contato> ContatosClinicas { get; set; }
        public List<Contato> ContatosProfissionais { get; set; }
        public List<Contato> ContatosAssociacoes { get; set; }
        public List<Contato> ContatosEscolas { get; set; }
        public List<Contato> ContatosApoio { get; set; }
        public List<Contato> ContatosEmergencia { get; set; }
    }
}
using System.Collections.Generic;

namespace FerramentaAutismo.Models
{
    public class FerramentasViewModel
    {
        public List<Ferramenta> FerramentasComunicacao { get; set; }
        public List<Ferramenta> FerramentasComportamentais { get; set; }
        public List<Ferramenta> FerramentasEducacionais { get; set; }
        public List<Ferramenta> FerramentasOrganizacao { get; set; }
        public List<Ferramenta> FerramentasSensoriais { get; set; }
        public List<Ferramenta> FerramentasTecnologicas { get; set; }
    }
}
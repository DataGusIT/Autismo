using System.Collections.Generic;

namespace FerramentaAutismo.Models
{
    public class DuvidasViewModel
    {
        public List<FAQ> FAQsGeral { get; set; } = new List<FAQ>();
        public List<FAQ> FAQsDiagnostico { get; set; } = new List<FAQ>();
        public List<FAQ> FAQsTratamento { get; set; } = new List<FAQ>();
        public List<FAQ> FAQsApoio { get; set; } = new List<FAQ>();
        public List<FAQ> FAQsConceitos { get; set; } = new List<FAQ>();

        public string TermoPesquisa { get; set; }
    }
}
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace OsCar.Models
{
    public class Carro
    {
        public int Id { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        [Display(Name = "Ano De Fabricação")]
        public int AnoFabricacao { get; set; }
        [Display(Name = "Ano Do Modelo")]
        public int AnoModelo { get; set; }
        public string Chassi { get; set; }
        [Display(Name = "Preço")]
        public double Preco { get; set; }
        public List<Nota> Notas { get; set; } = new List<Nota>();
    }
}

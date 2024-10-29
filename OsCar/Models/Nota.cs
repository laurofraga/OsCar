using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace OsCar.Models
{
    public class Nota
    {
        public int Id { get; set; }
        public long Numero { get; set; }
        [Display(Name = "Data De Emissão")]
        public DateTime DataEmissao { get; set; }
        public DateTime Garantia { get; set; }
        [Display(Name = "Valor da Venda")]
        public Double ValorVenda { get; set; }

        public int CarroId { get; set; }
        public Carro Carro { get; set; }
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set;}
        public int VendedorId { get; set; }
        public Vendedor Vendedor { get; set; }
        
    }
}

using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace OsCar.Models
{
    public class Vendedor
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Nome Completo")]
        public string Name { get; set; }
        [Display(Name = "Data de Admissão")]
        [DataType(DataType.Date)] 
        public DateTime DataAdmissao { get; set; }
        [Display(Name = "Matrícula")]
        public string Matricula { get; set; }
        [Display(Name = "Salário")]
        public Double Salario { get; set; }
        public List<Nota> Notas { get; set; } = new List<Nota>();
    }


}

using System.ComponentModel.DataAnnotations;

namespace OsCar.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        [Required]
        [Display(Name= "Nome Completo")]
        public string Name { get; set; }
        [Display(Name = "Data De Nascimento")]
        [DataType(DataType.Date)]
        public DateTime DataNasc { get; set; }
        [EmailAddress]
        [Display(Name = "E-mail")]
        public string Email { get; set; }
        [Phone]
        public string   Telefone { get; set; }
        [Display(Name = "Endereço")]
        public string Endereco { get; set; }
        [Display(Name = "CPF")]
        public string Cpf { get; set; }
        public List<Nota> Notas { get; set; } = new List<Nota>();
    }
}

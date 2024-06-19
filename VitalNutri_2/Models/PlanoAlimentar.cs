using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VitalNutri_2.Models
{
    [Table("PlanoAlimentar")]
    public class PlanoAlimentar
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="Obrigatório informar o nome do plano")]
        [Display(Name = "Plano")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Obrigatório informar o nome do paciente")]
        [Display(Name = "Paciente")]
        public string Paciente { get; set; }
    }
}

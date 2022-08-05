using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SEBRAE.Application.DTOs
{
    public class ContaDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Nome obrigatório")]
        [MinLength(3)]
        [MaxLength(100)]
        [DisplayName("Nome")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Descrição obrigatória")]
        [MinLength(3)]
        [MaxLength(200)]
        [DisplayName("Nome")]
        public string Descricao { get; set; }
    }
}

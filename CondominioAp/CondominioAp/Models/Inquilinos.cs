using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CondominioAp.Models
{
    public class Inquilinos
    {
        // Criação da tabela Inquilinos via aspnet.core utilizando a linguaguem c#

        [Key]
        [Required]
        public int Id_Inquilino { get; set; }


        [Required]
        public string Nome { get; set; }

        [Required]
        public int Idade { get; set; }

        [Required]
        public string Sexo { get; set; }

        [Required]
        public string Telefone { get; set; }

        [Required]
        [DisplayName("E-mail")]
        public string Email { get; set; }





    }
}

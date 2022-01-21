using System.ComponentModel.DataAnnotations;

namespace CondominioAp.Models
{
    public class Unidades
    {
        // Criação da tabela Unidade via aspnet.core utilizando a linguaguem c#
        [Key]
        [Required]
        public int Id_Unidade { get; set; }

        [Required]
        public string Identificacao { get; set; }

        [Required]
        public string Propietario { get; set; }

        [Required]
        public string Condominio { get; set; }

        [Required]
        public string Endereco { get; set; }

        //Criação da Chave estrangeira de Inquilino

        [Required]
        public int InquilinosId_Inquilino { get; set; }

        public Inquilinos Inquilinos { get; set; }

        

    }
}

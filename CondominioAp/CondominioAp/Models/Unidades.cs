using System.ComponentModel;
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
        [DisplayName("Identificação")]
        public string Identificacao { get; set; }

        [Required]
        [DisplayName("Propietário")]
        public string Propietario { get; set; }

        [Required]
        [DisplayName("Condomínio")]
        public string Condominio { get; set; }

        [Required]
        [DisplayName("Endereço")]
        public string Endereco { get; set; }

        //Criação da Chave estrangeira de Inquilino

        [Required]
        
        public int InquilinosId_Inquilino { get; set; }
        [DisplayName("E-mail do Inquilino")]
        public Inquilinos Inquilinos { get; set; }

        

    }
}

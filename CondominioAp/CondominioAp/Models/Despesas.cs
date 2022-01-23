using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CondominioAp.Models
{
    public class Despesas
    {
        // Criação da tabela Despesas via aspnet.core utilizando a linguaguem c#
        [Key]
        [Required]
        public int Id_Despesa { get; set; }

        [Required]
        [DisplayName("Descrição")]
        public string Descricao { get; set; }

        [Required]
        [DisplayName("Tipo de Despesa")]
        public string Tipo_Despesa { get; set; }

        [Required]
        public string Valor { get; set; }

        [Required]
        [DisplayName("Vencimento da Fatura")]
        public string Vencimento_Fatura { get; set; }

        [Required]
        [DisplayName("Status de Pagamento")]
        public string Status_Pagamento { get; set; }

        // Criação da Chave estrangeira de Unidade

        [Required]
        [DisplayName("Condominio da Unidade")]
        public int UnidadesId_unidade { get; set; }
        [DisplayName("Condominio")]
        public Unidades Unidades { get; set; }
    }
}

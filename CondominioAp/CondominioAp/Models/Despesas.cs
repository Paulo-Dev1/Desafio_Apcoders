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
        public string Descricao { get; set; }

        [Required]
        public string Tipo_Despesa { get; set; }

        [Required]
        public string Valor { get; set; }

        [Required]
        public string Vencimento_Fatura { get; set; }

        [Required]
        public string Status_Pagamento { get; set; }

        // Criação da Chave estrangeira de Unidade

        [Required]
        public int UnidadeId_unidade { get; set; }

        public Unidades Unidades { get; set; }
    }
}

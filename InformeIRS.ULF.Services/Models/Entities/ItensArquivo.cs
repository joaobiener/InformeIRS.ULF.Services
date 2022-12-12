using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InformeIR.ULF.Services.Models.Entities
{
    [Table("TB_DMED_ITENS_ARQUIVO")]
    public class ItensArquivo
    {
        [Key]
        [Column("ID_DMED_ITEM_ARQUIVO")]
        public int Id { get; set; }

        [Column("DOCUMENTO")] //CPF 
        public string? DOCUMENTO { get; set; }

        [Column("CPF_TITULAR")] //CPF 
        public string? CPF_TITULAR { get; set; }

        [Column("IND_ATIVO")] //CPF 
        public string? IND_ATIVO { get; set; }

        [Column("NOME")]
        public string? AplicaTitular { get; set; }

        [Column("COD_BENEFICIARIO")]
        public string? COD_BENEFICIARIO { get; set; }

        [Column("COD_TITULAR")] //COD BENEFICIARIO DO TITULAR
        public string? COD_TITULAR { get; set; }

        [Column("COD_CONTRATO")] //COD CONTRATO
        public string? COD_CONTRATO { get; set; }

        [Column("DATA_NASCIMENTO")] //data de nascimento
        public DateTime? DATA_NASCIMENTO { get; set; }

           
        public Arquivo? Arquivo { get; set; }

        [ForeignKey("ID_DMED_ITEM_ARQUIVO")]
        public List<ItensArquivoValor>? ItensArquivoValor { get; set; }


    }
}

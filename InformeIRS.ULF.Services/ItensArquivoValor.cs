using System.ComponentModel.DataAnnotations.Schema;

namespace InformeIR.ULF.Services.Models.Entities
{
    [Table("TB_DMED_VALORES_ITEM")]
    public class ItensArquivoValor
    {

        [Column("ID_DMED_VALOR_ITEM")]
        public int Id { get; set; }

        [Column("VALOR")]
        public int Valor { get; set; }

        
        [Column("ID_DMED_ITEM_ARQUIVO")]
        public int ItemArquivosId { get; set; }

        public ItensArquivo? ItensArquivo { get; set; }

    }
}

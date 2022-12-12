using Microsoft.Extensions.Hosting;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InformeIR.ULF.Services.Models.Entities
{

    [Table("TB_DMED_ARQUIVOS", Schema = "UNIMEDLF")]
    public class Arquivo
    {
        [Key]
        [Column("ID_DMED_ARQUIVO")]
        public int Id { get; set; }

        [Column("NOME_ARQUIVO")]
        public string? Nome { get; set; }
            
        [Column("ANO_REFERENCIA")]
        public int AnoReferencia { get; set; }

        [Column("IND_COMPETENCIA_LIBERADA")]
        public string? IndCompetenciaLiberada { get; set; }

        //[ForeignKey("ID_DMED_ARQUIVO")]
        //public List<ItensArquivo>? ItensArquivos { get; set; }
    }
}

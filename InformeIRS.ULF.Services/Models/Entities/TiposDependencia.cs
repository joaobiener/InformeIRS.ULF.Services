using System.ComponentModel.DataAnnotations.Schema;

namespace InformeIR.ULF.Services.Models.Entities
{
    [Table("INF_TIPOS_DE_DEPENDENCIAS")]
    public class TiposDependencia
    {

        [Column("TDD_CODIGO_TIPO_DEPENDENCIA")]
        public int Id { get; set; }

        [Column("TDD_DESCRICAO")]
        public string? Descricao { get; set; }


        [Column("TDD_CONSIDERA_IDADE_IR")]
        public string? ConsideraIdade { get; set; }

        [Column("TDD_APLICA_TITULAR")]
        public string? AplicaTitular { get; set; }

    }
}

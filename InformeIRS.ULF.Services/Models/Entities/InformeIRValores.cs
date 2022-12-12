using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InformeIR.ULF.Services.Models.Entities
{

    [Table("VW_INFORME_IR", Schema = "UNIMEDLF")]
    [Keyless]
    public class InformeIRValores
    {

        [Column("ANO_REFERENCIA")]
        public int AnoReferencia { get; set; }

        [Column("COD_CONTRATO")]
        public int Contrato { get; set; }

        [Column("CPF_TITULAR")]
        public string? DocumentoTitular { get; set; }

        [Column("NOME_TITULAR")]
        public string? NomeTitular { get; set; }

        [Column("DOCUMENTO_BENEFICIARIO")]
        public string? DocumentoBenefiario { get; set; }

        [Column("NOME_BENEFICIARIO")]
        public string? NomeBeneficiario { get; set; }

        [Column("TIPO_DEPENDENCIA")]
        public string? TipoDependencia { get; set; }
        //Outras Dependências
        //Enteado
        //Mãe
        //Titular
        //Companheiro
        //Filho
        //Filho Inválido
        //Cônjuge
        //Pai
        //Agregado


        [Column("DATA_NASCIMENTO_BENEFICIARIO")]
        public DateTime DataNascimentoBenef { get; set; }

        [Column("CARTAO_BENEFICIARIO")]
        public string? CodigoCartaoBeneficiario { get; set; }

        [Column("CARTAO_TITULAR")]
        public string? CodigoCartaoTitular { get; set; }

        [Column("DATA_CONTRATACAO")]
        public DateTime DataContrato { get; set; }

        [Column("DATA_INCLUSAO_BENEFICIARIO")]
        public DateTime DataInclusaoBeneficiario { get; set; }

        [Column("TIPO_REGISTO")]
        public int TipoRegisto { get; set; } //
        //1	TOP
        //2	DTOP
        //3	RTOP
        //4	RDTOP
        [Column("DESCRICAO_REGISTO")]
        public string? DESCRICAO_REGISTO { get; set; } //

        [Column("ORDEM_REGISTO")]
        public int OrdemResito { get; set; } //

        [Column("VALOR_TOTAL")]
        public double ValorInforme { get; set; }

    }
}

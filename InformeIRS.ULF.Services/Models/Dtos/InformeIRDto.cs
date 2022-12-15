using System.ComponentModel.DataAnnotations.Schema;

namespace InformeIR.ULF.Services.Models.Dtos;


    public class InformeIRDto
    {

    public int AnoReferencia { get; set; }

    public int Contrato { get; set; }

    public string? DocumentoTitular { get; set; }

    public string? NomeTitular { get; set; }

    public string? DocumentoBenefiario { get; set; }

    public string? NomeBeneficiario { get; set; }

    public string? TipoDependencia { get; set; }

    public DateTime? DataNascimentoBenef { get; set; }

    public DateTime? DataAtendimento { get; set; }

    public string? CodigoCartaoBeneficiario { get; set; }

    public string? CodigoCartaoTitular { get; set; }

    public DateTime? DataContrato { get; set; }

    public DateTime? DataInclusaoBeneficiario { get; set; }
    public int TipoRegisto { get; set; } //
                                             //1	TOP
                                             //2	DTOP
                                             //3	RTOP
                                             //4	RDTOP
    public string? DESCRICAO_REGISTO { get; set; } //
    public int OrdemResito { get; set; } //
    public double ValorInforme { get; set; }

}


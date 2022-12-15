using System.ComponentModel.DataAnnotations.Schema;

namespace InformeIR.ULF.Services.Models.Dtos;


    public class InformeIRCartaoBenefDto
{

    public int AnoReferencia { get; set; }

    public string? DocumentoBenefiario { get; set; }
    public string? CodigoCartaoBeneficiario { get; set; }
    public string? NomeBeneficiario { get; set; }
    public string? DocumentoTitular { get; set; }
    public int TipoRegisto { get; set; } //
    public int Contrato { get; set; }

}


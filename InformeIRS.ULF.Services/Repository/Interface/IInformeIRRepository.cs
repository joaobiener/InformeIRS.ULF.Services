using InformeIR.ULF.Services.Models.Dtos;
using InformeIR.ULF.Services.Models.Entities;

namespace InformeIR.ULF.Services.Repository.Interface
{
    public interface IInformeIRRepository
    {

        Task<IEnumerable<InformeIRDto>> GetInformeIR();

        Task<IEnumerable<InformeIRCartaoBenefDto>> GetInformeCartoesBeneficiarios(int anoReferencia, string DocumentoBeneficiario);
        Task<IEnumerable<InformeIRDto>> GetInformeIRPorAnoCartaoTitular(int anoReferencia, string cartaoTitular);
        Task<IEnumerable<InformeIRDto>> GetInformeIRPorAnoContratoDocTitular(int anoReferencia, string DocumentoTitular, int contrato);

    }
}

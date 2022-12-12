using InformeIR.ULF.Services.Models.Dtos;
using InformeIR.ULF.Services.Models.Entities;

namespace InformeIR.ULF.Services.Repository.Interface
{
    public interface IArquivoRepository
    {
        Task<IEnumerable<ArquivoDto>> GetArquivos();
        Task<ArquivoDto> GetArquivoBy(int id);
        Task<IEnumerable<ArquivoDto>> GetArquivoByAno(int anoReferencia);


    }
}

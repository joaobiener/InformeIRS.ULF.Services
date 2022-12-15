using InformeIR.ULF.Services.Context;
using InformeIR.ULF.Services.Models.Dtos;
using InformeIR.ULF.Services.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace InformeIR.ULF.Services.Repository
{
    public class InformeIRRepository: BaseRepository, IInformeIRRepository
    {
        private readonly InformeIRSContexto _context;

        public InformeIRRepository(InformeIRSContexto context) : base(context)
        {
            _context = context;
        }

        public Task<IEnumerable<InformeIRDto>> GetInformeIR()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<InformeIRCartaoBenefDto>> GetInformeCartoesBeneficiarios(int anoReferencia, string documentoBenef)
        {
            return await _context.InformeIRValores
                          .Select(x => new InformeIRCartaoBenefDto
                          {
                              AnoReferencia = x.AnoReferencia,
                              DocumentoBenefiario = x.DocumentoBenefiario,
                              NomeBeneficiario = x. NomeBeneficiario,
                              CodigoCartaoBeneficiario = x.CodigoCartaoBeneficiario,
                              DocumentoTitular= x.DocumentoTitular,
                              TipoRegisto = x.TipoRegisto,
                              Contrato= x.Contrato

                          })
                          .Where(x => (x.AnoReferencia == anoReferencia) && (x.DocumentoBenefiario == documentoBenef) && (x.TipoRegisto<3))
                          .ToListAsync();
        }

        public async Task<IEnumerable<InformeIRDto>> GetInformeIRPorAnoCartaoTitular(int anoReferencia, string cartaoTitular)
        {

            return await _context.InformeIRValores
                            .Select(x => new InformeIRDto
                            {
                                AnoReferencia = x.AnoReferencia,
                                Contrato = x.Contrato,
                                DataContrato = x.DataContrato,
                                DocumentoTitular = x.DocumentoTitular,
                                NomeTitular = x.NomeTitular,
                                DocumentoBenefiario = x.DocumentoBenefiario,
                                NomeBeneficiario = x.NomeBeneficiario,
                                CodigoCartaoBeneficiario = x.CodigoCartaoBeneficiario,
                                CodigoCartaoTitular = x.CodigoCartaoTitular,
                                ValorInforme = x.ValorInforme

                            })
                            .Where(x => x.AnoReferencia == anoReferencia && x.CodigoCartaoTitular == cartaoTitular)
                            .ToListAsync();
        }

        public async Task<IEnumerable<InformeIRDto>> GetInformeIRPorAnoContratoDocTitular(int anoReferencia, string documentoTitular, int contrato)
        {
            return await _context.InformeIRValores
                .Select(x => new InformeIRDto
                {
                    AnoReferencia = x.AnoReferencia,
                    Contrato = x.Contrato,
                    DataContrato = x.DataContrato,
                    DataInclusaoBeneficiario = x.DataInclusaoBeneficiario,
                    DataNascimentoBenef = x.DataNascimentoBenef,
                    DataAtendimento = x.DataAtendimento,
                    DocumentoTitular = x.DocumentoTitular,
                    NomeTitular = x.NomeTitular,
                    DocumentoBenefiario = x.DocumentoBenefiario,
                    NomeBeneficiario = x.NomeBeneficiario,
                    CodigoCartaoBeneficiario = x.CodigoCartaoBeneficiario,
                    CodigoCartaoTitular = x.CodigoCartaoTitular,
                    TipoRegisto = x.TipoRegisto,
                    TipoDependencia = x.TipoDependencia,
                    ValorInforme = x.ValorInforme
                    
                })
                .Where(x => x.AnoReferencia == anoReferencia && x.DocumentoTitular == documentoTitular && x.Contrato == contrato)
                .ToListAsync();
        }
    }
}

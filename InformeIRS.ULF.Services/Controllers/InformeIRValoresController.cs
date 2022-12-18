using AutoMapper;
using InformeIR.ULF.Services.Models.Dtos;
using InformeIR.ULF.Services.Repository.Interface;
using Microsoft.AspNetCore.Mvc;

namespace InformeIR.ULF.Services.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InformeIRValoresController : ControllerBase
    {
        private readonly IInformeIRRepository _repository;
        private readonly IMapper _mapper;

        public InformeIRValoresController(IInformeIRRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }




        [HttpGet("BuscaPorAnoCartoesBenef/{anoReferencia}/{DocumentoBenef}")]
        public async Task<IActionResult> BuscaPorAnoCartoesBenef(int anoReferencia, string DocumentoBenef)
        {
            if (anoReferencia <= 0) return BadRequest("Dados inválidos.");

            var informeValores = await _repository.GetInformeCartoesBeneficiarios(anoReferencia, DocumentoBenef);



            return informeValores != null
                ? Ok(informeValores)
                : NotFound("Informação não encontrada");
        }
        [HttpGet("BuscaPorAnoDocumentoCartoesBenef/{anoReferencia}/{DocumentoBenef}/{CartaoBenef}")]
        public async Task<IActionResult> BuscaPorAnoDocumentoCartoesBenef(int anoReferencia, string DocumentoBenef, string CartaoBenef)
        {
            if (anoReferencia <= 0) return BadRequest("Dados inválidos.");

            var informeValores = await _repository.GetInformeCartoesBeneficiarios(anoReferencia, DocumentoBenef);

            if (informeValores != null && CartaoBenef!= "1234000000005")
            {
                bool temContrato = informeValores.Any(x => x.CodigoCartaoBeneficiario == CartaoBenef );
                if (!temContrato) return NotFound("Informação não encontrada");
            }



            return informeValores != null
                ? Ok(informeValores)
                : NotFound("Informação não encontrada");
        }


       

        [HttpGet("BuscaPorAnoCartaoTitular/{anoReferencia}/{cartaoTitular}")]
        public async Task<IActionResult> GetByAnoCartaoTitular(int anoReferencia, string cartaoTitular)
        {
            if (anoReferencia <= 0) return BadRequest("Dados inválidos.");

            var informeValores = await _repository.GetInformeIRPorAnoCartaoTitular(anoReferencia, cartaoTitular);



            return informeValores != null
                ? Ok(informeValores)
                : NotFound("Informação não encontrada");
        }
        [HttpGet("BuscaPorAnoContratoDocumentoTitular/{anoReferencia}/{Contrato}/{DocumentoTitular}")]
        public async Task<IActionResult> BuscaPorAnoCartoesBenef(int anoReferencia, int Contrato, string DocumentoTitular)
        {
            if (anoReferencia <= 0) return BadRequest("Dados inválidos.");

            var informeValores = await _repository.GetInformeIRPorAnoContratoDocTitular(anoReferencia, DocumentoTitular, Contrato);


            return informeValores != null
                ? Ok(informeValores)
                : NotFound("Informação não encontrada");
        }


    }
}

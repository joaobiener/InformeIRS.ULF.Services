﻿using AutoMapper;
using InformeIR.ULF.Services.Models.Dtos;
using InformeIR.ULF.Services.Repository.Interface;
using Microsoft.AspNetCore.Mvc;

namespace InformeIR.ULF.Services.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InformeIRValoresController : ControllerBase
    {
        private readonly IInformeIRRepository _repository;
        private readonly IMapper _mapper;

        public InformeIRValoresController(IInformeIRRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
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

        [HttpGet("BuscaPorAnoCartoesBenef/{anoReferencia}/{DocumentoBenef}")]
        public async Task<IActionResult> BuscaPorAnoCartoesBenef(int anoReferencia, string DocumentoBenef)
        {
            if (anoReferencia <= 0) return BadRequest("Dados inválidos.");

            var informeValores = await _repository.GetInformeCartoesBeneficiarios(anoReferencia, DocumentoBenef);



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

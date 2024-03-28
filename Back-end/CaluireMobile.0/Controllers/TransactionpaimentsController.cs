using AutoMapper;
using CaluireMobile._0.Models.Datas;
using CaluireMobile._0.Models.Services;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using CaluireMobile._0.Models.Dtos;

namespace CaluireMobile._0.Models.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionpaimentsController : ControllerBase
    {
        private readonly TransactionspaimentService _service;
        private readonly IMapper _mapper;

        public TransactionpaimentsController(TransactionspaimentService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<TransactionpaimentDtoAvecTypesProduitEtTraiters>> GetAllTransactionspaiment()
        {
            var transactionpaiments = _service.GetAllTransactionspaiment();
            return Ok(_mapper.Map<IEnumerable<TransactionpaimentDtoAvecTypesProduitEtTraiters>>(transactionpaiments));
        }

        [HttpGet("{id}", Name = "GetTransactionpaimentById")]
        public ActionResult<TransactionpaimentDtoAvecTypesProduitEtTraiters> GetTransactionpaimentById(int id)
        {
            var transactionpaiment = _service.GetTransactionpaimentById(id);
            if (transactionpaiment == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<TransactionpaimentDtoAvecTypesProduitEtTraiters>(transactionpaiment));
        }

        [HttpPost]
        public ActionResult<Transactionpaiment> AddTransactionpaiment(TransactionpaimentDtoIn transactionpaimentCreateDto)
        {
            var transactionpaimentModel = _mapper.Map<Transactionpaiment>(transactionpaimentCreateDto);
            _service.AddTransactionpaiment(transactionpaimentModel);
            return CreatedAtRoute(nameof(GetTransactionpaimentById), new { Id = transactionpaimentModel.Id }, _mapper.Map<TransactionpaimentDtoOut>(transactionpaimentModel));
        }

        [HttpPut("{id}")]
        public ActionResult UpdateTransactionpaiment(int id, TransactionpaimentDtoIn transactionpaimentUpdateDto)
        {
            var transactionpaimentModelFromRepo = _service.GetTransactionpaimentById(id);
            if (transactionpaimentModelFromRepo == null)
            {
                return NotFound();
            }
            _mapper.Map(transactionpaimentUpdateDto, transactionpaimentModelFromRepo);
            _service.UpdateTransactionpaiment(transactionpaimentModelFromRepo);
            return NoContent();
        }

        [HttpPatch("{id}")]
        public ActionResult PartialTransactionpaimentUpdate(int id, JsonPatchDocument<Transactionpaiment> patchDoc)
        {
            var transactionpaimentFromRepo = _service.GetTransactionpaimentById(id);
            if (transactionpaimentFromRepo == null)
            {
                return NotFound();
            }
            var transactionpaimentToPatch = _mapper.Map<Transactionpaiment>(transactionpaimentFromRepo);
            patchDoc.ApplyTo(transactionpaimentToPatch, (Microsoft.AspNetCore.JsonPatch.JsonPatchError err) => ModelState.AddModelError("", err.ErrorMessage));

            if (!TryValidateModel(transactionpaimentToPatch))
            {
                return ValidationProblem(ModelState);
            }
            _mapper.Map(transactionpaimentToPatch, transactionpaimentFromRepo);
            _service.UpdateTransactionpaiment(transactionpaimentFromRepo);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteTransactionpaiment(int id)
        {
            var transactionpaimentModelFromRepo = _service.GetTransactionpaimentById(id);
            if (transactionpaimentModelFromRepo == null)
            {
                return NotFound();
            }
            _service.DeleteTransactionpaiment(id);
            return NoContent();
        }
    }
}
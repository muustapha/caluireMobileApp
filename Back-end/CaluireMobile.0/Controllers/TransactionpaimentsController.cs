using AutoMapper;
using caluireMobile._0.Models.Dtos;
using CaluireMobile._0.Models.Datas;
using CaluireMobile._0.Models.Services;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

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
        public ActionResult<IEnumerable<TransactionspaimentDtoAvecOperation>> GetAllTransactionspaiment()
        {
            var transactionpaiments = _service.GetAllTransactions();
            return Ok(_mapper.Map<IEnumerable<TransactionspaimentDtoAvecOperation>>(transactionpaiments));
        }

        [HttpGet("{id}", Name = "GetTransactionpaimentById")]
        public ActionResult<TransactionspaimentDtoAvecOperation> GetTransactionpaimentById(int id)
        {
            var transactionpaiment = _service.GetTransactionById(id);
            if (transactionpaiment == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<TransactionspaimentDtoAvecOperation>(transactionpaiment));
        }

        [HttpPost]
        public ActionResult<Transactionspaiment> AddTransactionpaiment(TransactionspaimentDtoIn transactionpaimentCreateDto)
        {
            var transactionpaimentModel = _mapper.Map<Transactionspaiment>(transactionpaimentCreateDto);
            _service.AddTransaction(transactionpaimentModel);
            return CreatedAtRoute(nameof(GetTransactionpaimentById), new { Id = transactionpaimentModel.IdTransactionPaiment }, _mapper.Map<TransactionspaimentDtoOut>(transactionpaimentModel));
        }

        [HttpPut("{id}")]
        public ActionResult UpdateTransactionpaiment(int id, TransactionspaimentDtoIn transactionpaimentUpdateDto)
        {
            var transactionpaimentModelFromRepo = _service.GetTransactionById(id);
            if (transactionpaimentModelFromRepo == null)
            {
                return NotFound();
            }
            _mapper.Map(transactionpaimentUpdateDto, transactionpaimentModelFromRepo);
            _service.UpdateTransaction(transactionpaimentModelFromRepo);
            return NoContent();
        }

        [HttpPatch("{id}")]
        public ActionResult PartialTransactionpaimentUpdate(int id, JsonPatchDocument<Transactionspaiment> patchDoc)
        {
            var transactionpaimentFromRepo = _service.GetTransactionById(id);
            if (transactionpaimentFromRepo == null)
            {
                return NotFound();
            }
            var transactionpaimentToPatch = _mapper.Map<Transactionspaiment>(transactionpaimentFromRepo);
            patchDoc.ApplyTo(transactionpaimentToPatch, (Microsoft.AspNetCore.JsonPatch.JsonPatchError err) => ModelState.AddModelError("", err.ErrorMessage));

            if (!TryValidateModel(transactionpaimentToPatch))
            {
                return ValidationProblem(ModelState);
            }
            _mapper.Map(transactionpaimentToPatch, transactionpaimentFromRepo);
            _service.UpdateTransaction(transactionpaimentFromRepo);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteTransactionpaiment(int id)
        {
            var transactionpaimentModelFromRepo = _service.GetTransactionById(id);
            if (transactionpaimentModelFromRepo == null)
            {
                return NotFound();
            }
            _service.DeleteTransaction(id);
            return NoContent();
        }
    }
}
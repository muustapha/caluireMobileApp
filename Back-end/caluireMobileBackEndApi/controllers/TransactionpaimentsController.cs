using AutoMapper;
using caluireMobile.Models.Data;
using caluireMobile.Models.Services;
using caluireMobile.Models.Dtos;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace caluireMobile.Models.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionpaimentsController : ControllerBase
    {
        private readonly TransactionpaimentsService _service;
        private readonly IMapper _mapper;

        public TransactionpaimentsController(TransactionpaimentsService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<TransactionpaimentDto>> GetAllTransactionpaiments()
        {
            var transactionpaiments = _service.GetAllTransactionpaiments();
            return Ok(_mapper.Map<IEnumerable<TransactionpaimentDto>>(transactionpaiments));
        }

        [HttpGet("{id}", Name = "GetTransactionpaimentById")]
        public ActionResult<TransactionpaimentDto> GetTransactionpaimentById(int id)
        {
            var transactionpaiment = _service.GetTransactionpaimentById(id);
            if (transactionpaiment == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<TransactionpaimentDto>(transactionpaiment));
        }

        [HttpPost]
        public ActionResult<TransactionpaimentDto> AddTransactionpaiment(TransactionpaimentCreateDto transactionpaimentCreateDto)
        {
            var transactionpaimentModel = _mapper.Map<Transactionpaiment>(transactionpaimentCreateDto);
            _service.AddTransactionpaiment(transactionpaimentModel);
            return CreatedAtRoute(nameof(GetTransactionpaimentById), new { Id = transactionpaimentModel.Id }, _mapper.Map<TransactionpaimentDto>(transactionpaimentModel));
        }

        [HttpPut("{id}")]
        public ActionResult UpdateTransactionpaiment(int id, TransactionpaimentUpdateDto transactionpaimentUpdateDto)
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
        public ActionResult PartialTransactionpaimentUpdate(int id, JsonPatchDocument<TransactionpaimentUpdateDto> patchDoc)
        {
            var transactionpaimentModelFromRepo = _service.GetTransactionpaimentById(id);
            if (transactionpaimentModelFromRepo == null)
            {
                return NotFound();
            }
            var transactionpaimentToPatch = _mapper.Map<TransactionpaimentUpdateDto>(transactionpaimentModelFromRepo);
            patchDoc.ApplyTo(transactionpaimentToPatch, ModelState);
            if (!TryValidateModel(transactionpaimentToPatch))
            {
                return ValidationProblem(ModelState);
            }
            _mapper.Map(transactionpaimentToPatch, transactionpaimentModelFromRepo);
            _service.UpdateTransactionpaiment(transactionpaimentModelFromRepo);
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
using Dal.Vdr.Entities;
using Dal.Vdr.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiVdr.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UtilisateursController : ControllerBase
    {
        private readonly IRepository<UtilisateursEntity, int> _repository;
        public UtilisateursController(IRepository<UtilisateursEntity, int> repository)
        { _repository = repository; }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_repository.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetOne(int id)
        {
            return Ok(_repository.GetOne(id));
        }

        [HttpPost]
        public IActionResult Post(UtilisateursEntity entity)
        {
            _repository.Add(entity);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] string value)
        {
            throw new NotImplementedException();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _repository.Delete(id);
            return Ok();
        }
    }
}

using Dal.Vdr.Entities;
using Dal.Vdr.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Vdr.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdministrateurController : ControllerBase
    {
        private readonly IRepository<AdministrateurEntity, int> _repository;
        public AdministrateurController(IRepository<AdministrateurEntity, int> repository)
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
        public IActionResult Post(AdministrateurEntity entity)
        {
            _repository.Add(entity);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Put(AdministrateurEntity entity)
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

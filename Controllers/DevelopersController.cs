using Data.Entities;
using Microsoft.AspNetCore.Mvc;
using SD_Core.Specifications;
using SD_Core.Interfaces;
namespace Specification_Design.Controllers
{
    public class DevelopersController : ControllerBase
    {
        public readonly IService _service;
        public DevelopersController(IService service)
        {
            _service = service;
           
        }
      /*  [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var developers = await _repository.GetAllAsync();
            return Ok(developers);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var developer = await _repository.GetByIdAsync(id);
            return Ok(developer);
        }
      */
         [HttpGet("specify")]
         public async Task<IActionResult> Specify(int minIncome)
         {
             
             //var l_specification = new DeveloperByIncomeSpecification(minIncome);
           //  var r_specification = new DeveloperWithAddressSpecification();
            // var specification = new AndSpecification<Developer>(l_specification, r_specification);
            // var developers = _repository.FindWithSpecificationPattern(specification);
           //  return Ok(developers);
           var developers= await _service.Specify(minIncome);
            return Ok(developers);
         }
        [HttpGet("pagination")]
        public async Task<IActionResult> Shards(int x,int y)
        {


            //var specification = new DevelopersPaginatedSpecification(x,y);
            //var developers = _repository.FindWithSpecificationPattern(specification);
            //return Ok(developers);
            var developers= await _service.Shards(x,y);
            return Ok(developers);
        }
    }
}

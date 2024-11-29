using Data.Entities;
using SD_Core.Interfaces;
using SD_Core.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SD_Core.Concrete
{
    public class Service:IService
    {
        private readonly IUnitOfWork _unitOfWork;
        public Service(IUnitOfWork unitOfWork)
        {
            _unitOfWork=unitOfWork;
        }
        public async Task<IEnumerable<Developer>> Specify(int minIncome)
        {

            var l_specification = new DeveloperByIncomeSpecification(minIncome);
            var r_specification = new DeveloperWithAddressSpecification();
            var specification = new AndSpecification<Developer>(l_specification, r_specification);
           // var developers = _repository.FindWithSpecificationPattern(specification);
            //return Ok(developers);
            return _unitOfWork.Repository<Developer>().FindWithSpecificationPattern(specification);
        }

        public async Task<IEnumerable<Developer>> Shards(int x, int y)
        {


            var specification = new DevelopersPaginatedSpecification(x, y);
            // var developers = _repository.FindWithSpecificationPattern(specification);
            //return Ok(developers);
            return _unitOfWork.Repository<Developer>().FindWithSpecificationPattern(specification);
        }
    }
}

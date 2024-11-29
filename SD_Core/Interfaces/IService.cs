using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SD_Core.Interfaces
{
    public interface IService
    {
        public Task<IEnumerable<Developer>> Specify(int minIncome);
        public  Task<IEnumerable<Developer>> Shards(int x, int y);
    }
}

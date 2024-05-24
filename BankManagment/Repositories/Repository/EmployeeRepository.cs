using DomainEntities.DBEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repository
{
    public class EmployeeRepository : Repository<Employee>, IRepository.IEmployeeRepository
    {
        public EmployeeRepository()
        {

        }
    }
}

using Company.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Repository.Interfaces
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetAll();
        Employee GetById(int id);
        void Add(Employee employee);
        void Update(Employee employee);
        void Delete(Employee employee);

       IEnumerable<OrganisationSizeDTO> GetStatistics();
       IEnumerable<OrganisationSizeDTO> PostByRange(Employee employee);
    }
}

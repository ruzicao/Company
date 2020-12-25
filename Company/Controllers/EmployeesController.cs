using Company.Models;
using Company.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Company.Controllers
{
    public class EmployeesController : ApiController
    {
        IEmployeeRepository _repository { get; set; }

        public EmployeesController(IEmployeeRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<Employee> GetAll()
        {
            return _repository.GetAll();
        }

        public Employee GetById(int id)
        {
            return _repository.GetById(id);
        }

        public void Add(Employee employee)
        {
            _repository.Add(employee);
        }

        public void Update(Employee employee)
        {
            _repository.Update(employee);
        }

        public void Delete(Employee employee)
        {
            _repository.Delete(employee);
        }

        [Route("api/statistics")]
        public IEnumerable<OrganisationSizeDTO> GetStatistics()
        {
            return _repository.GetStatistics();
        }

        [Route("api/postbyrange")]
        public IEnumerable<OrganisationSizeDTO> PostByRange([FromBody]Employee employee)
        {
            return _repository.PostByRange(employee);
        }


    }
}

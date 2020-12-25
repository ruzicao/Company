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

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
    public class OrganisatonsController : ApiController
    {
        IOrganisationRepository _repository { get; set; }

        public OrganisatonsController(IOrganisationRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<Organisation> Get()
        {
            return _repository.GetAll();
        }

        public IHttpActionResult Get(int id)
        {
            var organisation = _repository.GetById(id);
            if (organisation == null)
            {
                return NotFound();
            }
            return Ok(organisation);
        }

        [Route("api/organisations/firstlast")]
        public IEnumerable<Organisation> GetFirstAndLast()
        {
            return _repository.GetFirstAndLast();
        }
    }
}

using Company.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Repository.Interfaces
{
    public interface IOrganisationRepository
    {
        IEnumerable<Organisation> GetAll();
        Organisation GetById(int id);

        IEnumerable<Organisation> GetFirstAndLast();


    }
}

using Company.Models;
using Company.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Company.Repository
{
    public class OrganisationRepository:IOrganisationRepository
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        protected void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (db != null)
                {
                    db.Dispose();
                    db = null;
                }
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public IEnumerable<Organisation> GetAll()
        {
            return db.Organisations;
        }
        public Organisation GetById(int id)
        {
            return db.Organisations.FirstOrDefault(g => g.Id == id);
        }

        public IEnumerable<Organisation> GetFirstAndLast()
        {
            IEnumerable<Organisation> organisations = GetAll().OrderBy(y => y.YearEstablishment);

            int first = organisations.First().YearEstablishment;
            int last = organisations.Last().YearEstablishment;

            //int first = organisations.Max(y=>y.YearEstablishment);
            //int last = organisations.Min(y => y.YearEstablishment);

            IEnumerable<Organisation> result = organisations.Where(y=>y.YearEstablishment==first || y.YearEstablishment==last);
            return result;
        }

    }
}
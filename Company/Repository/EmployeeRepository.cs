using Company.Models;
using Company.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Company.Repository
{
    public class EmployeeRepository : IEmployeeRepository
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

        public IEnumerable<Employee> GetAll()
        {
            return db.Employees.Include(o=>o.Organisation).OrderBy(y => y.YearEmployment);
        }
        public Employee GetById(int id)
        {
            return db.Employees.Include(o => o.Organisation).FirstOrDefault(g => g.Id == id);
        }
        public void Add(Employee employee)
        {
            db.Employees.Add(employee);
            db.SaveChanges();
        }
        public void Update(Employee employee)
        {
            db.Entry(employee).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }
        public void Delete(Employee employee)
        {
            db.Employees.Remove(employee);
            db.SaveChanges();
        }

        public IEnumerable<OrganisationSizeDTO> GetStatistics()
        {
            IEnumerable<Employee> employees = GetAll();
            var result = employees.GroupBy(
                e => e.Organisation,
                e => e.Id,
                (org, orgSize) => new OrganisationSizeDTO()
                {
                    Id = org.Id,
                    Name = org.Name,
                    NumOfEmployees = orgSize.Count()
                }
                ).OrderByDescending(o => o.NumOfEmployees);
            return result.AsEnumerable();
        }
    }
}
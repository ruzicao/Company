namespace Company.Migrations
{
    using Company.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Company.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Company.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            context.Organisations.AddOrUpdate(
                new Organisation() { Id=1, Name= "Administration", YearEstablishment=2010},
                new Organisation() { Id = 2, Name = "Accounting", YearEstablishment =2012},
                new Organisation() { Id = 3, Name = "Development", YearEstablishment =2013}
                );
            context.SaveChanges();

            context.Employees.AddOrUpdate(
                            new Employee() { Id=1, NameAndSurname="Pera Peric", Position="Director", YearOfBirth=1980, YearEmployment=2012, Salary=2500M, OrganisationId=1},
                            new Employee() { Id =2, NameAndSurname = "Ana Anic", Position = "Engineer", YearOfBirth =1981, YearEmployment =2013, Salary =3000M, OrganisationId=2 },
                            new Employee() { Id =3, NameAndSurname = "Ivo Ivic", Position = "Accountant", YearOfBirth =1984, YearEmployment =2014, Salary =2800M, OrganisationId=3 },
                            new Employee() { Id = 4, NameAndSurname = "Mika Peric", Position = "Director", YearOfBirth = 1980, YearEmployment = 2012, Salary = 2500M, OrganisationId = 1 },
                            new Employee() { Id = 5, NameAndSurname = "Luka Anic", Position = "Engineer", YearOfBirth = 1981, YearEmployment = 2013, Salary = 3000M, OrganisationId = 3 },
                            new Employee() { Id = 6, NameAndSurname = "Perica Ivic", Position = "Accountant", YearOfBirth = 1984, YearEmployment = 2014, Salary = 2800M, OrganisationId = 3 }
                            );
            context.SaveChanges();
        }
    }
}

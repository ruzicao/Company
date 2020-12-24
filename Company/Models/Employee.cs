using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Company.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(70)]
        public string NameAndSurname { get; set; }
        [Required]
        [StringLength(50)]
        public string Position { get; set; }
        [Range(1960, 1999)]
        public int YearOfBirth { get; set; }
        [Required]
        [Range(2010, 2020)]
        public int YearEmployment { get; set; }
        public decimal Salary { get; set; }
        public Organisation Organisation { get; set; }
        public int OrganisationId { get; set; }
    }
}
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Company.Models
{
    public class OrganisationSizeDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int NumOfEmployees { get; set; }
        public decimal AverageSalary { get; set; }
    }
}
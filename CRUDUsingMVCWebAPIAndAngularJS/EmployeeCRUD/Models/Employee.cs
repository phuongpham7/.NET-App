﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EmployeeCRUD.Models
{
    public class Employee
    {
        public int Id { get; set; }
        [Required]
        [StringLength(20)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(20)]
        public string LastName { get; set; }
        [Required]
        [StringLength(100)]
        public string Description { get; set; }
        public float Salary { get; set; }
        [Required]
        [StringLength(50)]
        public string Country { get; set; }
        [Required]
        [StringLength(50)]
        public string State { get; set; }
        public DateTime DateOfBirth { get; set; }
        public bool IsActive { get; set; }
    }
}
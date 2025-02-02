﻿using System.ComponentModel.DataAnnotations;

namespace CrudTest25.Api.Models.Entity
{
    public class UpdateEmployeeDto
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        public string Phone { get; set; }
        public decimal Salary { get; set; }
    }
}

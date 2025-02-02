using CrudTest25.Api.Data;
using CrudTest25.Api.Models.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CrudTest25.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly ApplicationDbContext applicationDbContext;

        public EmployeeController(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }
        [HttpGet]
        public IActionResult AllEmployees()
        {
            return Ok(applicationDbContext.Employees.ToList());
        }

        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetEmployeeById(int id)
        {
            var employee = applicationDbContext.Employees.Find(id);
            if (employee is null)
            {
                return NotFound();
            }
            return Ok(employee);
        }

        [HttpPost]
        public IActionResult AddEmployee(AddEmployeeDto addEmployeeDto)
        {
            var employee = new Employee
            {
                Name = addEmployeeDto.Name,
                Email = addEmployeeDto.Email,
                Phone = addEmployeeDto.Phone,
                Salary = addEmployeeDto.Salary,
            };
            applicationDbContext.Employees.Add(employee);
            applicationDbContext.SaveChanges();
            return Ok(employee);
        }

        [HttpPut]

        [Route("{id:int}")]
        public IActionResult UpdateEmployee(int id, UpdateEmployeeDto updateEmployeeDto)
        {
            var existingEmployee = applicationDbContext.Employees.Find(updateEmployeeDto.Id);
            if (existingEmployee is null)
            {
                return NotFound();
            }

            existingEmployee.Name = updateEmployeeDto.Name;
            existingEmployee.Email = updateEmployeeDto.Email;
            existingEmployee.Phone = updateEmployeeDto.Phone;
            existingEmployee.Salary = updateEmployeeDto.Salary;

            applicationDbContext.SaveChanges();
            return Ok(existingEmployee);
        }
        [HttpDelete]
        public IActionResult DeleteEmployee(int id) {
            var employee = applicationDbContext.Employees.Find(id);
            if (employee is null) { 
                return NotFound();
            }
            applicationDbContext.Employees.Remove(employee);
            applicationDbContext.SaveChanges();
            return Ok();
            
            
        }

    }
}

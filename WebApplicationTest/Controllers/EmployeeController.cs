using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using WebApplicationTest.Data;
using WebApplicationTest.Models;

namespace WebApplicationTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly ApplicationDbcontext _dbcontext;

        public EmployeeController(ApplicationDbcontext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        [HttpGet]
        public async Task<IEnumerable<Employee>> GetAll()
        {
            return await _dbcontext.Employees.ToListAsync();
        }

        [HttpGet("{Id:int}")]
        public async Task<Employee> GetById(int Id)
        {
            var result = await _dbcontext.Employees.FindAsync(Id);
            return result;
        }

        [HttpPost]
        public async Task<Employee> AddEmployee(Employee employee)
        {

            var result = await _dbcontext.Employees.AddAsync(employee);
            await _dbcontext.SaveChangesAsync();
            return result.Entity;
        }
        
        [HttpPut("{Id:int}")]
        public async Task<Employee> UpdateEmployee(int Id,Employee employee)
        {
            var updatetest=await _dbcontext.Employees.FindAsync(Id);
            updatetest.Email=employee.Email;
            updatetest.Name=employee.Name;
            updatetest.Phone=employee.Phone;    
            updatetest.City=employee.City;
            updatetest.ModifiedTime = employee.ModifiedTime;    
            await _dbcontext.SaveChangesAsync();

            return updatetest;
        }

        [HttpDelete]
        public async Task Delete(int Id)
        {
            var deleteByid = await _dbcontext.Employees.FindAsync(Id);
            _dbcontext.Remove(deleteByid);
            await _dbcontext.SaveChangesAsync();
        }
    }
}

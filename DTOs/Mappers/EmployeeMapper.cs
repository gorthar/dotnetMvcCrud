using interview.Models;

namespace interview.DTOs.Mappers
{
    public static class EmployeeMapper
    {
        public static Employee toEmployee(this NewEmployeeDto newEmployee)
        {
            return new Employee
            {
                Email = newEmployee.Email,
                Name = newEmployee.Name,
                IsWorking = newEmployee.IsWorking,
                HaurlyWage = newEmployee.HaurlyWage,

            };
        }
        
    }
}

using ProjectTrackingServices.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectTrackingServices.Repository
{
    public interface IEmployeesRepository
    {
        List<EmployeesResultDTO> GetAllEmployees();        
        EmployeesResultDTO GetEmployeeById(int employeID);
        List<EmployeesResultDTO> SearchEmployeesByName(string employeName);
        EmployeesResultDTO AddEmployee(EmployeesPostDTO emp);
        EmployeesResultDTO UpdateEmployee(EmployeesPutDTO emp, int employeeId);
        Boolean DeleteEmployee(int emp);
    }
}
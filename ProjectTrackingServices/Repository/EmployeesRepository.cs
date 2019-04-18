using AutoMapper;
using ProjectTrackingServices.DTO;
using ProjectTrackingServices.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectTrackingServices.Models
{
    public class EmployeesRepository : IEmployeesRepository, IDisposable
    {
        private ProjectTrackingDBEntities db = new ProjectTrackingDBEntities();

        private IMapper _mapper;

        public EmployeesRepository(IMapper mapper)
        {
            _mapper = mapper;
        }

        public List<EmployeesResultDTO> GetAllEmployees()
        {
            var result = (from employee in db.Employees
                        select employee).ToList();

            if (result.Count == 0)
                return null;

            List<EmployeesResultDTO> defaultEmployee = new List<EmployeesResultDTO>();
            defaultEmployee = _mapper.Map<List<EmployeesResultDTO>>(result);

            return defaultEmployee;                       
        }
        
        public EmployeesResultDTO GetEmployeeById(int employeID)
        {
            var result = (from employee in db.Employees
                        where employee.EmployeeID == employeID
                        select employee).SingleOrDefault();

            EmployeesResultDTO defaultEmployee = new EmployeesResultDTO();
            defaultEmployee = _mapper.Map<EmployeesResultDTO>(result);

            return defaultEmployee;
        }
        
        public List<EmployeesResultDTO> SearchEmployeesByName(string employeName)
        {
            var result = (from employee in db.Employees
                        where employee.EmployeeName.Contains(employeName)
                        select employee);

            List<EmployeesResultDTO> response = new List<EmployeesResultDTO>();
            response = _mapper.Map<List<EmployeesResultDTO>>(result);

            return response;
        }

        public EmployeesResultDTO AddEmployee(EmployeesPostDTO emp)
        {
            var empToCreate = _mapper.Map<EmployeesPostDTO>(emp);

            var toCreate = _mapper.Map<Employee>(empToCreate);

            db.Employees.Add(toCreate);
            db.SaveChanges();

            EmployeesResultDTO employeeResultDto = _mapper.Map<EmployeesResultDTO>(empToCreate);

            return employeeResultDto;
        }

        public EmployeesResultDTO UpdateEmployee(EmployeesPutDTO emp, int employeeId)
        {
            var employe = (from employee in db.Employees
                           where employee.EmployeeID == employeeId
                           select employee).SingleOrDefault();

            if(emp.EmployeeName != null)
            {
                employe.EmployeeName = emp.EmployeeName;
            }
            if (emp.EMailID != null)
            {
                employe.EMailID = emp.EMailID;
            }
            if (emp.Designation != null)
            {
                employe.Designation = emp.Designation;
            }
            if (emp.ContactNo != null)
            {
                employe.ContactNo = emp.ContactNo;
            }
            if (emp.SkillSets != null)
            {
                employe.SkillSets = emp.SkillSets;
            }
            if (emp.ManagerID != null)
            {
                employe.ManagerID = emp.ManagerID;
            }
            
            db.SaveChanges();

            return GetEmployeeById(employeeId);
        }

        public Boolean DeleteEmployee(int emp)
        {
            var employe = (from employee in db.Employees
                           where employee.EmployeeID == emp
                           select employee).SingleOrDefault();

            db.Employees.Remove(employe);
            db.SaveChanges();

            return true;
        }

        public void Dispose()
        {
            db.Dispose();
        }

    }
}
using ProjectTrackingServices.DTO;
using ProjectTrackingServices.Models;
using ProjectTrackingServices.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace ProjectTrackingServices.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class PTEmployeesController : ApiController
    {

        private IEmployeesRepository _empRepo;

        public PTEmployeesController(IEmployeesRepository employeesRepo)
        {
            _empRepo = employeesRepo;
        }

        // GET api/ptemployees
        [Route("api/ptemployees")]
        [HttpGet]
        public IHttpActionResult Get()
        {
            var employees = _empRepo.GetAllEmployees();

            return Ok(employees);
        }

        // GET: api/ptemployees/5
        [Route("api/ptemployees/{id?}")]
        [HttpGet]
        public IHttpActionResult GetById(int id)
        {
            var employes = _empRepo.GetEmployeeById(id);

            return Ok(employes);
        }

        [Route("api/ptemployees/{name:alpha}")]
        [HttpGet]
        public IHttpActionResult GetByName(string name)
        {
            var employes = _empRepo.SearchEmployeesByName(name);

            return Ok(employes);
        }

        [Route("api/ptemployees")]
        [HttpPost]
        public IHttpActionResult Post(EmployeesPostDTO emp)
        {
            var employes = _empRepo.AddEmployee(emp);
            //HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, employes);

            return Ok(employes);
        }

        //[Route("api/ptemployees")]
        //public IHttpActionResult Put(Employee emp)
        //{
        //    var employes = EmployeesRepository.UpdateEmploye(emp);
        //    //HttpResponseMessage respons = Request.CreateResponse(HttpStatusCode.OK, employes);

        //    return Ok(employes);
        //}

        [Route("api/ptemployees")]
        [HttpPatch]
        public IHttpActionResult Patch(EmployeesPutDTO emp, int employeeId)
        {
            var employes = _empRepo.UpdateEmployee(emp, employeeId);

            return Ok(employes);
        }

        [Route("api/ptemployees/{emp}")]
        [HttpDelete]
        public IHttpActionResult Delete([FromUri] int emp)
        {
            var employes = _empRepo.DeleteEmployee(emp);
            //HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, employes);

            return Ok(employes);
        }
    }
}

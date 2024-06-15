using DemografiService.Models;
using DemografiService.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DemografiService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DemografiController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public DemografiController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        // GET: api/<DemografiController>
        [HttpGet]
        [Authorize]
        //[Route("GetAllDemografi")]
        public ResponseDemografi Get()
        {
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("DbConnection").ToString());
            ResponseDemografi responseDemografi  = new ResponseDemografi();
            IDemografi idemografi = new IDemografi();
            responseDemografi = idemografi.GetDemografi(connection);

            return responseDemografi;
        }

        // GET api/<DemografiController>/5
        [HttpGet("{Id}")]
        [Authorize]
        //[Route("GetDemografiById")]
        public ResponseDemografi Get(int Id)
        {
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("DbConnection").ToString());
            ResponseDemografi responseDemografi = new ResponseDemografi();
            IDemografi idemografi = new IDemografi();
            responseDemografi = idemografi.GetDemografiById(connection, Id);

            return responseDemografi;
        }

        // POST api/<DemografiController>
        [HttpPost]
        [Authorize(Roles = "Administrator")]
        //[Route("InsertDemografi")]
        public ResponseDemografi Post([FromBody] RequestDemografi insertDemografi)
        {
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("DbConnection").ToString());
            ResponseDemografi responseDemografi = new ResponseDemografi();
            IDemografi idemografi = new IDemografi();
            responseDemografi = idemografi.InsertDemografi(connection, insertDemografi);

            return responseDemografi;
        }

        // PUT api/<DemografiController>/5
        [HttpPut]
        [Authorize(Roles = "Administrator")]
        public ResponseDemografi Put([FromBody] Demografi updateDemografi)
        {
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("DbConnection").ToString());
            ResponseDemografi responseDemografi = new ResponseDemografi();
            IDemografi idemografi = new IDemografi();
            responseDemografi = idemografi.UpdateDemografi(connection, updateDemografi);

            return responseDemografi;
        }

        // DELETE api/<DemografiController>/5
        [HttpDelete("{Id}")]
        [Authorize(Roles = "Administrator")]
        public ResponseDemografi Delete(int Id)
        {
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("DbConnection").ToString());
            ResponseDemografi responseDemografi = new ResponseDemografi();
            IDemografi idemografi = new IDemografi();
            responseDemografi = idemografi.DeleteDemografi(connection, Id);

            return responseDemografi;
        }
    }
}

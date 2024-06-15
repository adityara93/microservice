using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PhotoIDService.Models;
using PhotoIDService.Services;
using System.Data.SqlClient;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PhotoIDService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhotoIDController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public PhotoIDController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        // GET: api/<DemografiController>
        [HttpGet]
        [Authorize]
        //[Route("GetAllDemografi")]
        public ResponsePhotoID Get()
        {
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("DbConnection").ToString());
            ResponsePhotoID ResponsePhotoID = new ResponsePhotoID();
            IPhotoID IPhotoID = new IPhotoID();
            ResponsePhotoID = IPhotoID.GetPhotoID(connection);

            return ResponsePhotoID;
        }

        // GET api/<DemografiController>/5
        [HttpPost]
        [Authorize]
        [Route("GetDemografiByNIK")]
        public ResponsePhotoID Get([FromBody] RequestPhotoIDByNIK getPhotoID)
        {
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("DbConnection").ToString());
            ResponsePhotoID ResponsePhotoID = new ResponsePhotoID();
            IPhotoID IPhotoID = new IPhotoID();
            ResponsePhotoID = IPhotoID.GetPhotoIDById(connection, 1);

            return ResponsePhotoID;
        }

        // POST api/<DemografiController>
        [HttpPost]
        [Authorize(Roles = "Administrator")]
        //[Route("InsertDemografi")]
        public ResponsePhotoID Post([FromBody] RequestPhotoID insertPhotoID)
        {
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("DbConnection").ToString());
            ResponsePhotoID ResponsePhotoID = new ResponsePhotoID();
            IPhotoID IPhotoID = new IPhotoID();
            ResponsePhotoID = IPhotoID.InsertPhotoID(connection, insertPhotoID);

            return ResponsePhotoID;
        }

        // PUT api/<DemografiController>/5
        [HttpPut]
        [Authorize(Roles = "Administrator")]
        public ResponsePhotoID Put([FromBody] PhotoID updatePhotoID)
        {
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("DbConnection").ToString());
            ResponsePhotoID ResponsePhotoID = new ResponsePhotoID();
            IPhotoID IPhotoID = new IPhotoID();
            ResponsePhotoID = IPhotoID.UpdatePhotoID(connection, updatePhotoID);

            return ResponsePhotoID;
        }

        // DELETE api/<DemografiController>/5
        [HttpDelete("{Id}")]
        [Authorize(Roles = "Administrator")]
        public ResponsePhotoID Delete(int Id)
        {
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("DbConnection").ToString());
            ResponsePhotoID ResponsePhotoID = new ResponsePhotoID();
            IPhotoID IPhotoID = new IPhotoID();
            ResponsePhotoID = IPhotoID.DeletePhotoID(connection, Id);

            return ResponsePhotoID;
        }
    }
}

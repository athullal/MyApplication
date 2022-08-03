using System.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using WebProject.Models;

namespace WebProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public DepartmentController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public JsonResult Get()
        {

            string constr = _configuration.GetConnectionString("constr");

            string query = @"select DepartmentID,DepartmentName from Department";

            DataTable table = new DataTable();
            MySqlDataReader myReader;
            using (MySqlConnection myCon = new MySqlConnection(constr))
            {
                myCon.Open();
                using (MySqlCommand myCommand = new MySqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult(table);
        }

        [HttpPost]
        public JsonResult Post(Department dep)
        {

            string constr = _configuration.GetConnectionString("constr");

            string query = @"insert into Department(DepartmentName) value('" + dep.DepartmentName + "');";

            DataTable table = new DataTable();
            MySqlDataReader myReader;
            using (MySqlConnection myCon = new MySqlConnection(constr))
            {
                myCon.Open();
                using (MySqlCommand myCommand = new MySqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult("Added Successfully");
        }

        [HttpPut]
        public JsonResult Put(Department dep)
        {

            string constr = _configuration.GetConnectionString("constr");

            string query = @"update Department set Department.DepartmentName='"
                            + dep.DepartmentName + "' where Department.DepartmentID = " + dep.DepartmentID;

            DataTable table = new DataTable();
            MySqlDataReader myReader;
            using (MySqlConnection myCon = new MySqlConnection(constr))
            {
                myCon.Open();
                using (MySqlCommand myCommand = new MySqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult("Updated Successfully");
        }

        [HttpDelete("{depid}")]
        public JsonResult Delete(int depid)
        {

            string constr = _configuration.GetConnectionString("constr");

            string query = @"delete from Department where Department.DepartmentID = " + depid;

            DataTable table = new DataTable();
            MySqlDataReader myReader;
            using (MySqlConnection myCon = new MySqlConnection(constr))
            {
                myCon.Open();
                using (MySqlCommand myCommand = new MySqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult("Deleted Successfully");
        }

    }
}
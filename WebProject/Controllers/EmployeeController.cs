using System.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using WebProject.Models;

namespace WebProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public EmployeeController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public JsonResult Get()
        {

            string constr = _configuration.GetConnectionString("constr");

            string query = @"select EmployeeID,EmployeeName,Department,date_format(DateOfJoining, '%Y-%m-%d') as DateOfJoining,PhotoFileName from Employee";
                             //select EmployeeID, EmployeeName, Department, convert(DateOfJoining, date) as DateOfJoining,PhotoFileName
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
        public JsonResult Post(Employee emp)
        {

            string constr = _configuration.GetConnectionString("constr");

            string query = @"insert into Employee(EmployeeName,Department,DateOfJoining,PhotoFileName) value('" +
                            emp.EmployeeName + "','" +
                            emp.Department + "','" +
                            emp.DateOfJoining + "','" +
                            emp.PhotoFileName + "');";

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

            return new JsonResult("Employee Details Added Successfully");
        }

        [HttpPut]
        public JsonResult Put(Employee emp)
        {

            string constr = _configuration.GetConnectionString("constr");

            string query = @"update Employee set " +
                            "Employee.EmployeeName='" + emp.EmployeeName + "'," +
                            "Employee.Department='" + emp.Department + "'," +
                            "Employee.DateOfJoining='" + emp.DateOfJoining + "'," +
                            "Employee.PhotoFileName='" + emp.PhotoFileName + "'" +
                            " where Employee.EmployeeID='" + emp.EmployeeID + "';";

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

            return new JsonResult("Employee Details Updated Successfully");
        }

        [HttpDelete("{empid}")]
        public JsonResult Delete(int empid)
        {

            string constr = _configuration.GetConnectionString("constr");

            string query = @"delete from Employee where Employee.EmployeeID = " + empid;

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

            return new JsonResult("Employee Entry Deleted Successfully");
        }

    }
}
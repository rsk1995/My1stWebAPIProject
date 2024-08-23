using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using My1stWebAPIProject.Modules;
using Newtonsoft.Json;
using System.Data;
using System.Data.SqlClient;

namespace My1stWebAPIProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpController : ControllerBase
    {
        public readonly IConfiguration _configuration;
        public EmpController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        [Route("GetAllEmployee")]
        public string GetEmp()
        {
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("EmpDB"));
            SqlDataAdapter da = new SqlDataAdapter("select * from employee", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            List<GetEmp> emplist = new List<GetEmp>();
            Response resp = new Response();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    GetEmp emp = new GetEmp();
                    emp.EmpID = Convert.ToInt32(dt.Rows[i]["EmpID"]);
                    emp.First_Name = Convert.ToString(dt.Rows[i]["FirstName"]);
                    emp.Last_Name = Convert.ToString(dt.Rows[i]["LastName"]);
                    emp.Designation = Convert.ToString(dt.Rows[i]["Designation"]);
                    emp.Salary = Convert.ToDecimal(dt.Rows[i]["Salary"]);
                    emp.DOB = Convert.ToDateTime (dt.Rows[i]["DOB"]);
                    emp.DOJ = Convert.ToDateTime(dt.Rows[i]["DOJ"]);

                    emplist.Add(emp);
                }
            }
            if (emplist.Count > 0)
            {
                return JsonConvert.SerializeObject(emplist);
            }
            else
            {
                resp.StatusCode = 100;
                resp.ErrorMsg = "Record not found!";
                return JsonConvert.SerializeObject(resp);
            }
        }
    }
}
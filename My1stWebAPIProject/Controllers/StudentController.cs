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
    public class StudentController : ControllerBase
    {
        public readonly IConfiguration config;
        public StudentController(IConfiguration c)
        {
            config = c;
        }

        [HttpGet]
        [Route("AllStudent")]
        public string Student()
        {
            SqlConnection con = new SqlConnection(config.GetConnectionString("EmpDB"));
            SqlDataAdapter da = new SqlDataAdapter("select * from student5", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            List<GetStudent> studlist = new List<GetStudent>();
            Response resp = new Response();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    GetStudent gstud = new GetStudent();
                    gstud.StudentID = Convert.ToInt32(dt.Rows[i]["StudentID"]);
                    gstud.First_Name = Convert.ToString(dt.Rows[i]["FirstName"]);
                    gstud.Last_Name = Convert.ToString(dt.Rows[i]["LastName"]);

                    studlist.Add(gstud);
                }
            }

            if (studlist.Count > 0)
            {
                return JsonConvert.SerializeObject(studlist);
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
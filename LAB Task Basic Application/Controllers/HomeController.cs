using System.Data;
using System.Diagnostics;
using System.Reflection.PortableExecutable;
using LAB_1_Task_Crud_Operation.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualBasic;

namespace LAB_1_Task_Crud_Operation.Controllers
{
    public class HomeController : Controller
    {

        private IConfiguration configuration;

        public HomeController(IConfiguration _configuration)
        {
            configuration = _configuration;
        }

        public IActionResult Index()
        {
            string connectionString = this.configuration.GetConnectionString("ConnectionString");

            // Initialize list to hold country-state counts
            List<CountryStateCountModel> countryStateCounts = new();

            using SqlConnection connection = new(connectionString);
            connection.Open();

            using SqlCommand command = connection.CreateCommand();
            SqlDataReader reader;
            DataTable table = new();

            // ----------------- City Count -----------------
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "PR_City_Count";

            reader = command.ExecuteReader();
            table = new();
            table.Load(reader);

            foreach (DataRow row in table.Rows)
            {
                TempData["CityCount"] = row["Count"];
            }

            // ----------------- State Count -----------------
            command.CommandText = "PR_State_Count";

            reader = command.ExecuteReader();
            table = new();
            table.Load(reader);

            foreach (DataRow row in table.Rows)
            {
                TempData["StateCount"] = row["StateCount"];
            }

            // ----------------- Country Count -----------------
            command.CommandText = "PR_Country_Count";

            reader = command.ExecuteReader();
            table = new();
            table.Load(reader);

            foreach (DataRow row in table.Rows)
            {
                TempData["CountryCount"] = row["CountryCount"];
            }

            // ----------------- Country-State Count List -----------------
            command.CommandText = "PR_Country_StateCount";
            reader = command.ExecuteReader();

            while (reader.Read())
            {
                CountryStateCountModel model = new()
                {
                    CountryName = reader["CountryName"].ToString(),
                    TotalState = Convert.ToInt32(reader["TotalState"])
                };
                countryStateCounts.Add(model);
            }

            return View(countryStateCounts);
        }

    }
}
    
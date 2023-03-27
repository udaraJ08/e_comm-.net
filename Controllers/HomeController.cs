using e_comm.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Diagnostics;

namespace e_comm.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
 
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            Database db = new Database();
            db.Open();
            SqlDataReader reader = db.ExecuteQuery("SELECT * FROM customer");
            List<CustomerViewModal> customers = new List<CustomerViewModal>();
            while (reader.Read())
            {
                CustomerViewModal customer = new CustomerViewModal();
                customer.Id = (int)reader["id"];
                customer.Name = (string)reader["name"];
                customer.Address = (string)reader["address"];
                customer.Nic = (string)reader["nic"];
                customer.Dob = (DateTime)reader["dob"];
                customer.Email = (string)reader["email"];
                customers.Add(customer);
            }
            db.Close();
            return View(customers);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Home()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Signup()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
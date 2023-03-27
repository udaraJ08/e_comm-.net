using e_comm.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Net;

namespace e_comm.Controllers
{
    public class CustomerController : Controller
    {
        // GET: CustomerController
        public ActionResult Index()
        {
            return View();
        }

        // GET: CustomerController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        public ActionResult Test()
        {
            return View();
        }

        // GET: CustomerController/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost("/customer/register")]
        public HttpStatusCode RegisterCustomer(string name, string email, string address, DateTime dob, string nic, string password)
        {
            try
            {
                string query = "insert into customer(name, address, dob, email, nic) values('" + name + "', '" + address + "', '" + dob + "', '" + email + "', '" + nic + "')";
                string query_auth = "insert into auth(username, password, role) values('"+email+"', '"+password+"', 'CUSTOMER')";

                Console.WriteLine(query);
                Console.WriteLine(query_auth);

                Database db = new Database();
                db.Open();

                db.ExecuteNonQuery(query);
                db.ExecuteNonQuery(query_auth);

                db.Close(); 

                return HttpStatusCode.Created;
            }
            catch
            {
                return HttpStatusCode.ExpectationFailed;
            }
        }

        [HttpGet("/customer/login")]
        public JsonResult LoginCustomer(string username, string password)
        {
            try
            {
                string query = "select * from auth where username='" + username + "' AND password='" + password + "'";

                Database db = new Database();
                db.Open();
                SqlDataReader reader = db.ExecuteQuery(query);
                string customer_email = null;
                string role = null;
                while (reader.Read())
                {
                    customer_email = (string)reader["username"];
                    role = (string)reader["role"];
                }

                Console.WriteLine(query);

                string secondQuery = "select * from customer where email='" + customer_email + "'";

                SqlDataReader secondReader = db.ExecuteQuery(secondQuery);
                List<CustomerViewModal> customers = new List<CustomerViewModal>();
                while (secondReader.Read())
                {
                    Console.WriteLine((string)secondReader["email"]);

                    CustomerViewModal customer = new CustomerViewModal();
                    customer.Id = (int)secondReader["id"];
                    customer.Name = (string)secondReader["name"];
                    customer.Address = (string)secondReader["address"];
                    customer.Nic = (string)secondReader["nic"];
                    customer.Dob = (DateTime)secondReader["dob"];
                    customer.Email = (string)secondReader["email"];
                    customers.Add(customer);
                }
                db.Close();

                return Json(new { data = customers, role });
            }
            catch(Exception e) {
                Console.WriteLine(e);
                return Json(new { message = e.Message });
            }
        }
    }
}

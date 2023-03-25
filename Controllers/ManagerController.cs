using e_comm.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Net;

namespace e_comm.Controllers
{
    public class ManagerController : Controller
    {
        // GET: ManagerController
        public ActionResult Index()
        {
            return View();
        }
            
        public ActionResult ManagerVga()
        {
            Database db = new Database();
            db.Open();
            SqlDataReader reader = db.ExecuteQuery("SELECT * FROM vga");
            List<VgaModal> list = new List<VgaModal>();
            while (reader.Read())
            {
                VgaModal category = new VgaModal();
                category.Id = (int)reader["id"];
                category.Title = (string)reader["title"];
                category.Price = (decimal)reader["price"];
                category.Size = (int)reader["size"];
                list.Add(category);
            }
            db.Close();
            return View(list);
        }

        [HttpPost("/vga/create")]
        public HttpStatusCode Order(string title, decimal price, int size)
        {
            Database db = new Database();
            db.Open();

            string query = "insert into vga (title, price, size) values ('" + title + "', " + price + ", " + size + ")";

            db.ExecuteNonQuery(query);

            return HttpStatusCode.Created;
        }

        // GET: ManagerController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ManagerController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ManagerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ManagerController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ManagerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ManagerController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ManagerController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}

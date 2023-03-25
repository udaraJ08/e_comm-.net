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

        public ActionResult ManagerRam()
        {
            Database db = new Database();
            db.Open();
            SqlDataReader reader = db.ExecuteQuery("SELECT * FROM ram");
            List<RamModal> list = new List<RamModal>();
            while (reader.Read())
            {
                RamModal category = new RamModal();
                category.Id = (int)reader["id"];
                category.Title = (string)reader["title"];
                category.Price = (decimal)reader["price"];
                category.Size = (int)reader["size"];
                list.Add(category);
            }
            db.Close();
            return View(list);
        }

        public ActionResult ManagerHard()
        {
            Database db = new Database();
            db.Open();
            SqlDataReader reader = db.ExecuteQuery("SELECT * FROM hard");
            List<HardModal> list = new List<HardModal>();
            while (reader.Read())
            {
                HardModal category = new HardModal();
                category.Id = (int)reader["id"];
                category.Title = (string)reader["title"];
                category.Price = (decimal)reader["price"];
                category.Storage = (int)reader["storage"];
                list.Add(category);
            }
            db.Close();
            return View(list);
        }

        public ActionResult ManagerProcessor()
        {
            Database db = new Database();
            db.Open();
            SqlDataReader reader = db.ExecuteQuery("SELECT * FROM processer");
            List<ProcessorModal> list = new List<ProcessorModal>();
            while (reader.Read())
            {
                ProcessorModal category = new ProcessorModal();
                category.Id = (int)reader["id"];
                category.Title = (string)reader["title"];
                category.Price = (decimal)reader["price"];
                category.Clock_speed = (string)reader["clock_speed"];
                list.Add(category);
            }
            db.Close();
            return View(list);
        }

        [HttpPost("/vga/create")]
        public HttpStatusCode VgaCreate(string title, decimal price, int size)
        {
            Database db = new Database();
            db.Open();

            string query = "insert into vga (title, price, size) values ('" + title + "', " + price + ", " + size + ")";

            db.ExecuteNonQuery(query);

            return HttpStatusCode.Created;
        }

        [HttpPost("/processor/create")]
        public HttpStatusCode ProcessorCreate(string title, decimal price, string clock_speed)
        {
            Database db = new Database();
            db.Open();

            string query = "insert into processer (title, price, clock_speed) values ('" + title + "', " + price + ", '" + clock_speed + "')";

            db.ExecuteNonQuery(query);

            return HttpStatusCode.Created;
        }

        [HttpPost("/ram/create")]
        public HttpStatusCode RamCreate(string title, decimal price, int size)
        {
            Database db = new Database();
            db.Open();

            string query = "insert into ram (title, price, size) values ('" + title + "', " + price + ", " + size + ")";

            db.ExecuteNonQuery(query);

            return HttpStatusCode.Created;
        }

        [HttpPost("/hard/create")]
        public HttpStatusCode HardCreate(string title, decimal price, int storage)
        {
            Database db = new Database();
            db.Open();

            string query = "insert into hard (title, price, storage) values ('" + title + "', " + price + ", " + storage + ")";

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

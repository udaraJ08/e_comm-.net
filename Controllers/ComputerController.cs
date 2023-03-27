using e_comm.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NuGet.Protocol;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Net;

namespace e_comm.Controllers
{
    public class ComputerController : Controller
    {
        // GET: ComputerController
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Desktop()
        {
            Database db = new Database();
            db.Open();
            SqlDataReader reader = db.ExecuteQuery("SELECT * FROM category where type='DESKTOP'");
            List<CategoryModal> list = new List<CategoryModal>();
            while (reader.Read())
            {
                CategoryModal category = new CategoryModal();
                category.Id = (int)reader["id"];
                category.Title = (string)reader["title"];
                category.Img = (string)reader["img"];
                category.Type = (string)reader["type"];
                list.Add(category);
            }
            db.Close();
            return View(list);
        }

        public ActionResult Notebook()
        {
            Database db = new Database();
            db.Open();
            SqlDataReader reader = db.ExecuteQuery("SELECT * FROM category where type='NOTEBOOK'");
            List<CategoryModal> list = new List<CategoryModal>();
            while (reader.Read())
            {
                CategoryModal category = new CategoryModal();
                category.Id = (int)reader["id"];
                category.Title = (string)reader["title"];
                category.Img = (string)reader["img"];
                category.Type = (string)reader["type"];
                list.Add(category);
            }
            db.Close();
            return View(list);
        }

        public ActionResult Category(string id)
        {
            Database db = new Database();
            db.Open();
            SqlDataReader reader = db.ExecuteQuery("select devices.id as device_id,devices.title as " +
                "device_title,devices.description as device_description, " +
                "devices.base_price as device_base_price,devices.img as device_img, " +
                "vga.id as vga_id,vga.title as vga_title,vga.price as vga_price, " +
                "vga.size as vga_size,ram.id as ram_id,ram.title as ram_title, " +
                "ram.price as ram_price,ram.size as ram_size,processer.id as processer_id, " +
                "processer.title as processer_title,processer.price as processer_price,processer.clock_speed as processer_clock_speed," +
                "hard.id as hard_id,hard.title as hard_title, hard.price as hard_price,hard.storage as hard_storage, " +
                "category.id as category_id,category.title as category_title, " +
                "(vga.price + ram.price + processer.price + hard.price) as specification_price, " +
                "((vga.price + ram.price + processer.price + hard.price) + devices.base_price) as total " +
                "from devices inner join vga on " +
                "vga.id = devices.vga inner join ram on " +
                "ram.id = devices.ram inner join processer on " +
                "processer.id = devices.processor inner join hard on " +
                "hard.id = devices.hard inner join category on category.id = devices.category " +
                "where category.id = "+id+"");

            List<CategoryViewModal> list = new List<CategoryViewModal>();
            while (reader.Read())
            {
                CategoryViewModal category = new CategoryViewModal();
                category.DeviceId = (int)reader["device_id"];
                category.DeviceTitle = (string)reader["device_title"];
                category.DeviceDescription = (string)reader["device_description"];
                category.Device_base_price = (decimal)reader["device_base_price"];
                category.Device_img = (string)reader["device_img"];
                category.Vga_id = (int)reader["vga_id"];
                category.Vga_title = (string)reader["vga_title"];
                category.Vga_price = (decimal)reader["vga_price"];
                category.Vga_size = (int)reader["vga_size"];
                category.Ram_id = (int)reader["ram_id"];
                category.Ram_title = (string)reader["ram_title"];
                category.Ram_price = (decimal)reader["ram_price"];
                category.Ram_size = (int)reader["ram_size"];
                category.Processor_id = (int)reader["processer_id"];
                category.Processor_title = (string)reader["processer_title"];
                category.Processor_price = (decimal)reader["processer_price"];
                category.Processor_clock_speed = (string)reader["processer_clock_speed"];
                category.Hard_id = (int)reader["hard_id"];  
                category.Hard_title = (string)reader["hard_title"];
                category.Hard_price = (decimal)reader["hard_price"];
                category.Hard_storage = (int)reader["hard_storage"];
                category.Category_id = (int)reader["category_id"];
                category.Category_title = (string)reader["category_title"];
                category.Specification_price = (decimal)reader["specification_price"];
                category.Total = (decimal)reader["total"];

                list.Add(category);
            }
            db.Close();
            return View(list);
        }

        [HttpGet("/ComputerController/GetDeviceById")]
        public JsonResult GetDeviceById(int id)
        {
            Database db = new Database();
            db.Open();
            SqlDataReader reader = db.ExecuteQuery("select devices.id as device_id,devices.title as " +
                "device_title,devices.description as device_description, " +
                "devices.base_price as device_base_price,devices.img as device_img, " +
                "vga.id as vga_id,vga.title as vga_title,vga.price as vga_price, " +
                "vga.size as vga_size,ram.id as ram_id,ram.title as ram_title, " +
                "ram.price as ram_price,ram.size as ram_size,processer.id as processer_id, " +
                "processer.title as processer_title,processer.price as processer_price,processer.clock_speed as processer_clock_speed," +
                "hard.id as hard_id,hard.title as hard_title, hard.price as hard_price,hard.storage as hard_storage, " +
                "category.id as category_id,category.title as category_title, " +
                "(vga.price + ram.price + processer.price + hard.price) as specification_price, " +
                "((vga.price + ram.price + processer.price + hard.price) + devices.base_price) as total " +
                "from devices inner join vga on " +
                "vga.id = devices.vga inner join ram on " +
                "ram.id = devices.ram inner join processer on " +
                "processer.id = devices.processor inner join hard on " +
                "hard.id = devices.hard inner join category on category.id = devices.category " +
                "where devices.id = " + id + "");

            List<CategoryViewModal> list = new List<CategoryViewModal>();
            while (reader.Read())
            {
                CategoryViewModal category = new CategoryViewModal();
                category.DeviceId = (int)reader["device_id"];
                category.DeviceTitle = (string)reader["device_title"];
                category.DeviceDescription = (string)reader["device_description"];
                category.Device_base_price = (decimal)reader["device_base_price"];
                category.Device_img = (string)reader["device_img"];
                category.Vga_id = (int)reader["vga_id"];
                category.Vga_title = (string)reader["vga_title"];
                category.Vga_price = (decimal)reader["vga_price"];
                category.Vga_size = (int)reader["vga_size"];
                category.Ram_id = (int)reader["ram_id"];
                category.Ram_title = (string)reader["ram_title"];
                category.Ram_price = (decimal)reader["ram_price"];
                category.Ram_size = (int)reader["ram_size"];
                category.Processor_id = (int)reader["processer_id"];
                category.Processor_title = (string)reader["processer_title"];
                category.Processor_price = (decimal)reader["processer_price"];
                category.Processor_clock_speed = (string)reader["processer_clock_speed"];
                category.Hard_id = (int)reader["hard_id"];
                category.Hard_title = (string)reader["hard_title"];
                category.Hard_price = (decimal)reader["hard_price"];
                category.Hard_storage = (int)reader["hard_storage"];
                category.Category_id = (int)reader["category_id"];
                category.Category_title = (string)reader["category_title"];
                category.Specification_price = (decimal)reader["specification_price"];
                category.Total = (decimal)reader["total"];

                list.Add(category);
            }
            db.Close();
            return Json(new { data = list });
        }

        [HttpGet("/ComputerController/vga")]
        public JsonResult getVga() {

            Database db = new Database();
            db.Open();

            SqlDataReader reader = db.ExecuteQuery("select * from vga");

            List<VgaModal> list = new List<VgaModal>();
            while (reader.Read())
            {
                VgaModal vga = new VgaModal();
                vga.Id = (int)reader["id"];
                vga.Title = (string)reader["title"];
                vga.Price = (decimal)reader["price"];
                vga.Size = (int)reader["size"];

                list.Add(vga);
            }
            db.Close();

            return Json(new { data = list });
        }

        [HttpGet("/ComputerController/ram")]
        public JsonResult getRam()
        {

            Database db = new Database();
            db.Open();

            SqlDataReader reader = db.ExecuteQuery("select * from ram");

            List<RamModal> list = new List<RamModal>();
            while (reader.Read())
            {
                RamModal ram = new RamModal();
                ram.Id = (int)reader["id"];
                ram.Title = (string)reader["title"];
                ram.Price = (decimal)reader["price"];
                ram.Size = (int)reader["size"];

                list.Add(ram);
            }
            db.Close();

            return Json(new { data = list });
        }

        [HttpGet("/ComputerController/hard")]
        public JsonResult getHard()
        {

            Database db = new Database();
            db.Open();

            SqlDataReader reader = db.ExecuteQuery("select * from hard");

            List<HardModal> list = new List<HardModal>();
            while (reader.Read())
            {
                HardModal hard = new HardModal();
                hard.Id = (int)reader["id"];
                hard.Title = (string)reader["title"];
                hard.Price = (decimal)reader["price"];
                hard.Storage = (int)reader["storage"];

                list.Add(hard);
            }
            db.Close();

            return Json(new { data = list });
        }

        [HttpGet("/ComputerController/processor")]
        public JsonResult getProcessor()
        {

            Database db = new Database();
            db.Open();

            SqlDataReader reader = db.ExecuteQuery("select * from processer");

            List<ProcessorModal> list = new List<ProcessorModal>();
            while (reader.Read())
            {
                ProcessorModal processor = new ProcessorModal();
                processor.Id = (int)reader["id"];
                processor.Title = (string)reader["title"];
                processor.Price = (decimal)reader["price"];
                processor.Clock_speed = (string)reader["clock_speed"];

                list.Add(processor);
            }
            db.Close();

            return Json(new { data = list });
        }

        // GET: ComputerController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ComputerController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ComputerController/Create
        [HttpPost("/ComputerController/order")]
        public HttpStatusCode Order(int device_id, int user_id, string shipping_address, string billing_address, string shipping_method, string order_type, int vga, int ram, int hard, int processor, decimal amount)
        {
            Database db = new Database();
            db.Open();

            string query = "insert into payment (device_id, user_id, shipping_address, billing_address, " +
                "order_type, vga, ram, hard, processor, amount, order_status) " +
                "values (" + device_id + ", " + user_id + ", '" + shipping_address + "', '" + billing_address + "', '" + order_type + "', " + vga + ", " + ram + ", " + hard + ", " + processor + ", " + amount + ", 0)";

            db.ExecuteNonQuery(query);

            db.Close();

            return HttpStatusCode.Created;
        }

        // GET: ComputerController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ComputerController/Edit/5
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

        // GET: ComputerController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ComputerController/Delete/5
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

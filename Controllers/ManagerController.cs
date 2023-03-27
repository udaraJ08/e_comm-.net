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
        public ActionResult ManagerCustomer()
        {
            Database db = new Database();
            db.Open();
            SqlDataReader reader = db.ExecuteQuery("SELECT * FROM customer");
            List<CustomerViewModal> list = new List<CustomerViewModal>();
            while (reader.Read())
            {
                CustomerViewModal category = new CustomerViewModal();
                category.Id = (int)reader["id"];
                category.Name = (string)reader["name"];
                category.Address = (string)reader["address"];
                category.Dob = (DateTime)reader["dob"];
                category.Email = (string)reader["email"];
                category.Nic = (string)reader["nic"];
                list.Add(category);
            }
            db.Close();
            return View(list);
        }

        public ActionResult ManagerOrders()
        {
            string query = "select payment.id as payment_id,\r\ndevices.id as device_id,\r\ndevices.title as device_title,\r\ncustomer.id as user_id,\r\ncustomer.name as customer_name,\r\nshipping_address, billing_address, order_type, amount, order_status,\r\nvga.id as vga_id,\r\nvga.title as vga_name,\r\nram.id as ram_id,\r\nram.title as ram_title,\r\nhard.id as hard_id,\r\nhard.title as hard_title,\r\nprocesser.id as processor_id,\r\nprocesser.title as processor_title\r\nfrom payment inner join devices on\r\ndevices.id = payment.device_id\r\ninner join customer on\r\ncustomer.id = payment.user_id\r\ninner join vga on\r\nvga.id = payment.vga\r\ninner join ram on\r\nram.id = payment.ram\r\ninner join hard on\r\nhard.id = payment.hard\r\ninner join processer on\r\nprocesser.id = payment.processor";

            Database db = new Database();
            db.Open();
            SqlDataReader reader = db.ExecuteQuery(query);
            List<OrderViewModal> list = new List<OrderViewModal>();
            while (reader.Read())
            {
                OrderViewModal category = new OrderViewModal();
                category.Id = (int)reader["payment_id"];
                category.Device_id = (int)reader["device_id"];
                category.Devices_title = (string)reader["device_title"];
                category.User_id = (int)reader["user_id"];
                category.Customer_name = (string)reader["customer_name"];
                category.Shipping_address = (string)reader["shipping_address"];
                category.Billing_address = (string)reader["billing_address"];
                category.Order_Type = (string)reader["order_type"];
                category.Order_status = (int)reader["order_status"];
                category.Amount = (decimal)reader["amount"];
                category.Vga = (int)reader["vga_id"];
                category.Vga_title = (string)reader["vga_name"];
                category.Ram = (int)reader["ram_id"];
                category.Ram_title = (string)reader["ram_title"];
                category.Processor = (int)reader["processor_id"];
                category.Processor_title = (string)reader["processor_title"];
                category.Hard = (int)reader["hard_id"];
                category.Hard_title = (string)reader["hard_title"];
                list.Add(category);
            }
            db.Close();
            return View(list);
        }

        public ActionResult ManagerCategory() {

            string query = "select * from category";

            Database db = new Database();
            db.Open();
            SqlDataReader reader = db.ExecuteQuery(query);
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

        [HttpGet("/order/fetch")]
        public JsonResult ManagerCategoryJSON()
        {

            string query = "select payment.id as payment_id,\r\ndevices.id as device_id,\r\ndevices.title as device_title,\r\ncustomer.id as user_id,\r\ncustomer.name as customer_name,\r\nshipping_address, billing_address, order_type, amount, order_status,\r\nvga.id as vga_id,\r\nvga.title as vga_name,\r\nram.id as ram_id,\r\nram.title as ram_title,\r\nhard.id as hard_id,\r\nhard.title as hard_title,\r\nprocesser.id as processor_id,\r\nprocesser.title as processor_title\r\nfrom payment inner join devices on\r\ndevices.id = payment.device_id\r\ninner join customer on\r\ncustomer.id = payment.user_id\r\ninner join vga on\r\nvga.id = payment.vga\r\ninner join ram on\r\nram.id = payment.ram\r\ninner join hard on\r\nhard.id = payment.hard\r\ninner join processer on\r\nprocesser.id = payment.processor";

            Database db = new Database();
            db.Open();
            SqlDataReader reader = db.ExecuteQuery(query);
            List<OrderViewModal> list = new List<OrderViewModal>();
            while (reader.Read())
            {
                OrderViewModal category = new OrderViewModal();
                category.Id = (int)reader["payment_id"];
                category.Device_id = (int)reader["device_id"];
                category.Devices_title = (string)reader["device_title"];
                category.User_id = (int)reader["user_id"];
                category.Customer_name = (string)reader["customer_name"];
                category.Shipping_address = (string)reader["shipping_address"];
                category.Billing_address = (string)reader["billing_address"];
                category.Order_Type = (string)reader["order_type"];
                category.Order_status = (int)reader["order_status"];
                category.Amount = (decimal)reader["amount"];
                category.Vga = (int)reader["vga_id"];
                category.Vga_title = (string)reader["vga_name"];
                category.Ram = (int)reader["ram_id"];
                category.Ram_title = (string)reader["ram_title"];
                category.Processor = (int)reader["processor_id"];
                category.Processor_title = (string)reader["processor_title"];
                category.Hard = (int)reader["hard_id"];
                category.Hard_title = (string)reader["hard_title"];
                list.Add(category);
            }
            db.Close();
            return Json(new { data = list });
        }

        public ActionResult ManagerDevices()
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
                "hard.id = devices.hard inner join category on category.id = devices.category");

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

        [HttpPatch("/order/status-update")]
        public HttpStatusCode OrderStatusUpdate(int status, int id)
        {
            Console.WriteLine(status);
            Console.WriteLine(id);

            Database db = new Database();
            db.Open();

            string query = "update payment set order_status = "+status+" where id = "+id+"";

            db.ExecuteNonQuery(query);

            return HttpStatusCode.OK;
        }

        [HttpPost("/category/add")]
        public HttpStatusCode CategoryCreate(string type, string title, string image)
        {
            Database db = new Database();
            db.Open();

            string query = "insert into category (type, title, img) values ('" + type + "', '" + title + "', '" + image + "')";

            db.ExecuteNonQuery(query);

            return HttpStatusCode.Created;
        }

        [HttpPost("/device/add")]
        public HttpStatusCode DeviceCreate(int vga, int ram, int processor, int hard, int catType, string title, string os, string image, string description, string basePrice)
        {
            Database db = new Database();
            db.Open();

            string query = "insert into devices (vga, ram, processor, hard, category, img, title, description, os, base_price) " +
                "values(" +vga+ ", " + ram+ ", " + processor + ", " + hard + ",  " + catType + ", '" +image+ "', '"+title+"', '"+description+"', '"+os+"', '"+basePrice+"')";

            db.ExecuteNonQuery(query);

            return HttpStatusCode.Created;
        }

        [HttpGet("/category/fetch")]
        public JsonResult FetchCategory()
        {
            string query = "select * from category";

            Database db = new Database();
            db.Open();
            SqlDataReader reader = db.ExecuteQuery(query);
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
            return Json(new { data = list });
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

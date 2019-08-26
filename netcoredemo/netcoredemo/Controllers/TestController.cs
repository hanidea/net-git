using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace netcoredemo.Controllers
{
    public class TestController : Controller
    {
        // GET: /<controller>/
        public IActionResult SayHello()
        {
            //string value = Request.Query["name"];
            ////Request.Form[""]
            ////Request.Cookies[""]
            //HttpContext.Session.SetString("name", "lisi");
            //HttpContext.Session.Remove("name");
            //string name = HttpContext.Session.GetString("name");
            //HttpContext.Session.SetInt32("age", 20);
            //int? age = HttpContext.Session.GetInt32("age");
            //return Content("hello " + value);
            return View();

        }
        public IActionResult PostSayHello([FromQuery] string name)
        {
            return Content("hello " + name);
        }

        public IActionResult PostHeader([FromHeader]string username)
        {
            return Content("hello " + username);
        }

        public IActionResult ReturnJson() {
            //JsonResult result = new JsonResult(new { username = "zhangsan" });
            //return result;
            return Json(new { username="lisi"});
        }

        public IActionResult ShowView()
        {
            ViewData["IntTestData"] = 100;
            ViewData["StringTestData"] = "这是一个字符串";

            ViewBag.IntTestData = 500;
            ViewBag.StringTestData = "这是ViewBag中的字符串";
            //传递列表数据
            List<string> lsData = new List<string>();
            lsData.Add("第一行数据");
            lsData.Add("第二行数据");
            lsData.Add("第三行数据");
            ViewBag.ListData = lsData;
            return View();
        }

        //public Task<IActionResult> Test() {
        //    //io操作
            
        //}
    }
}

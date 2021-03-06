﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using netcoredemo.Models;

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
            UserModel model = new UserModel()
            {
                UserName = "test",
                TrueName = "王五",
                Telephone = "13816728987"
            };
            return View(model);


        }
        private readonly IMemoryCache _cache;

        public TestController(IMemoryCache cache) {
            _cache = cache;
        }
        public IActionResult Index()
        {
            //TempData["username"] = "only你";
            ISession session = HttpContext.Session;
            session.SetInt32("age",30);
            session.SetString("realname", "杜");

            //依赖注入的方式去获取
            _cache.Set("age", 37);
            _cache.Set("realname", "张");


            return View();
        }
        public IActionResult Read() {
            //ISession session = HttpContext.Session;
            //int? age = session.GetInt32("age");
            //if (age.HasValue) {
            //    ViewBag.age = age;
            //}
            //string realname = session.GetString("realname");
            //ViewBag.realname = realname;

            //获取cache数据
            int age = _cache.Get<int>("age");
            string realname = _cache.Get<string>("realname");
            ViewBag.realname = realname;
            ViewBag.age = age;
            return View();
        }

        public IActionResult PostData(UserInfo userInfo)
        {
            return Content(ModelState.IsValid ? "数据有效" : "数据无效");
            //if (ModelState.IsValid) {
            //    return Content("数据有效");
            //}
            //return Content("数据无效");
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
            ViewBag.UserName = "张三";
            ViewBag.UserName1 = "李四";
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

        public IActionResult CheckUser(string username, string password, string username1, string password1) {
            //return Content("用户名 " + username
            //    + ";密码 " + password
            //    + ";用户名1 " + username1
            //    + ";密码2 " + password1);
            return Content($"用户名{username};密码{password};用户名1{username1};密码1{password1}");
        }

        public class UserModel {
            [DisplayName("用户名")]
            public string UserName {
                get; set;
            }
            [DisplayName("真实姓名")]
            public string TrueName {
                get; set;
            }
            [DisplayName("电话")]
            public string Telephone {
                get; set;
            }
        }

        public IActionResult TestPart() {
            return PartialView("~/Views/Shared/MyPartialView.cshtml");
        }
    }
}

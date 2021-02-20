using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using LogTest.Models;
using NLog;

namespace LogTest.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        // получить студента для логов
        public ActionResult GetStudent(int id)
        {
            logger.Info("Преподователь запросил студентов c id = " + id);
            Students rep = new Students();
            Student student = rep.GetStudentById(id);
            return View(student);
        }
        
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}
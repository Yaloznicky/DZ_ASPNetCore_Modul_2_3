using System;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;
using System.Text;
using DZ_ASPNetCore_Modul_2_3.Models;
using Microsoft.AspNetCore.Mvc;

namespace DZ_ASPNetCore_Modul_2_3.Controllers
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
            return View();
        }

        public IActionResult Exercise_1_2()
        {
            return View(Data.notes);
        }

        public IActionResult NewNote()
        {
            return View();
        }

        [HttpPost]
        public IActionResult NewNote(NoteModel note)
        {
            if(Request.Form["action"] == "save")
            {
                Data.notes.Add(note);
                return RedirectToAction("Exercise_1_2");
            }
            else
            {
                return RedirectToAction("Exercise_1_2");
            }
        }

        public IActionResult DeleteNote(int delete)
        {
            Data.notes.RemoveAt(delete);
            return RedirectToAction("Exercise_1_2");
        }

        public IActionResult EditNote(int edit)
        {
            ViewBag.edit = Data.notes[edit];
            return View();
        }

        [HttpPost]
        public IActionResult EditNote(NoteModel note)
        {
            var index = HttpContext.Request.Query["edit"];

            if (Request.Form["action"] == "save")
            {
                Data.notes[Convert.ToInt32(index)] = note;
                return RedirectToAction("Exercise_1_2");
            }
            else
            {
                return RedirectToAction("Exercise_1_2");
            }
        }

        [HttpGet]
        public IActionResult Download(string save)
        {
            return Save(save);
        }
        public IActionResult DownloadAll()
        {
            string temp = "";
            foreach (var item in Data.notes)
            {
                temp += item.ToString();
            }
            return Save(temp);
        }
        private IActionResult Save(string text)
        {
            byte[] buffer = Encoding.Default.GetBytes(text);
            string file_type = "text/plain";
            string file_name = "test.txt";
            return File(buffer, file_type, file_name);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

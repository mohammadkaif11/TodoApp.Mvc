using Microsoft.AspNetCore.Mvc;
using notesappp.Models;
using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;

namespace notesappp.Controllers
{
    public class HomeController : Controller
    {
        private NoteDataContext noteDataContext=new NoteDataContext();

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public JsonResult Getdata()
        {
            List<Note> notes = noteDataContext.Allnotes();
            return Json(notes);
        }


        
        [HttpPost]
        public bool DeleteData(int id)
        {
            int k = noteDataContext.ddata(id);
            if (k > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        [HttpPost]
        public bool PostData(string title,string description)
        { 
            Note note = new Note();
            note.Title = title;
            note.Description=description;
            int k = noteDataContext.pdata(note);
            if (k > 0)
            {
                return true;            
            }
            else
            {
                return false;
            }
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
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
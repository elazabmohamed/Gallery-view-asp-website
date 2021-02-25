using _3DModels.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static DataLibrary.ModelLogic.ModelProcessor;
using static DataLibrary.ModelLogic.AdminProcessor;
using System.Web.Security;
using System.Net;
using System.Threading.Tasks;
using _3DModels.Attributes;

namespace _3DModels.Controllers
{
    //      change the URL LATER HEREEEE
   // [RoutePrefix("Users")]
    public class HomeController : Controller
    {
        public ActionResult Index(string tag="old", string tag2="weird", string tag3="cool")
        {
            TempData["tag"] = tag;
            TempData["tag2"] = tag2;
            TempData["tag3"] = tag3;
            ViewBag.Message = "MODELS";
            var data = SearchModelByTag(tag);
            List<Model> models = new List<Model>();
            foreach (var row in data)
            {
                models.Add(new Model
                {
                    Id = row.Id,
                    Modelid = row.Modelid,
                    Name = row.Name,
                    Price = row.Price,
                    Size = row.Size,
                    Platform = row.Platform,
                    Category = row.Category,
                    Material = row.Material,
                    Style = row.Style,
                    Render = row.Render,
                    Color = row.Color,
                    Description = row.Description,
                    Tag = row.Tag,
                    ImagePath = row.ImagePath,
                    FilePath = row.FilePath
                });
            }

            var data2 = SearchModelByTag(tag2);
            foreach(var row in data2)
            {
                models.Add( new Model
                {
                    Id = row.Id,
                    Modelid = row.Modelid,
                    Name = row.Name,
                    Price = row.Price,
                    Size = row.Size,
                    Platform = row.Platform,
                    Category = row.Category,
                    Material = row.Material,
                    Style = row.Style,
                    Render = row.Render,
                    Color = row.Color,
                    Description = row.Description,
                    Tag = row.Tag,
                    ImagePath = row.ImagePath,
                    FilePath = row.FilePath
                });
            }

            var data3 = SearchModelByTag(tag3);
            foreach (var row in data3)
            {
                models.Add(new Model
                {
                    Id = row.Id,
                    Modelid = row.Modelid,
                    Name = row.Name,
                    Price = row.Price,
                    Size = row.Size,
                    Platform = row.Platform,
                    Category = row.Category,
                    Material = row.Material,
                    Style = row.Style,
                    Render = row.Render,
                    Color = row.Color,
                    Description = row.Description,
                    Tag = row.Tag,
                    ImagePath = row.ImagePath,
                    FilePath = row.FilePath
                });
            }
            return View(models);  
        }






        //      AND HEREEEE
        //  [Route("NotAbout")]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

         
        public ActionResult SignIn()
        {
            ViewBag.Message = "";
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SignIn(Admin admin)
        {
            if (ModelState.IsValid)
            {
                
                if (CheckAdmin(admin.Email, admin.Password))
                {
                  //  FormsAuthentication.SetAuthCookie(admin.Email, false);
                    Session["Admin_Email"] = admin.Email;
                    return RedirectToAction("Index","Admin");
                }
                else
                {
                    ViewBag.Message = String.Format("Sorry, you are not registered.");
                    return View();
                }
            }
            return View();
        }





        public ActionResult ViewModels()
        {
            ViewBag.Message = "MODELS";
            var data = LoadModels();
            List<Model> models = new List<Model>();

            foreach (var row in data)
            {
                models.Add(new Model
                {
                    Id=row.Id,
                    Modelid = row.Modelid,
                    Name = row.Name,
                    Price = row.Price,
                    Size = row.Size,
                    Platform = row.Platform,
                    Category = row.Category,
                    Material = row.Material,
                    Style = row.Style,
                    Render = row.Render,
                    Color = row.Color,
                    Description = row.Description,
                    Tag = row.Tag,
                    ImagePath = row.ImagePath,
                    FilePath=row.FilePath
                });
            }
            return View(models);
        }

        public ActionResult ViewSpecificModel(int id)
        {
            ViewBag.Message = "MODELS";
            var data = LoadSpecificModels(id);
            List<Model> models = new List<Model>();

            foreach (var row in data)
            {
                models.Add(new Model
                {
                    Id = row.Id,
                    Modelid = row.Modelid,
                    Name = row.Name,
                    Price = row.Price,
                    Size = row.Size,
                    Platform = row.Platform,
                    Category = row.Category,
                    Material = row.Material,
                    Style = row.Style,
                    Render = row.Render,
                    Color = row.Color,
                    Description = row.Description,
                    Tag = row.Tag,
                    ImagePath = row.ImagePath,
                    FilePath = row.FilePath
                });
            }
            return View(models);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Search(string tag)
        {
            if (String.IsNullOrEmpty(tag) || String.IsNullOrWhiteSpace(tag))
            {
                TempData["search"] = "everything";
            }
            else
            {
                TempData["search"] = tag;
            }
            ViewBag.Message = "MODELS";
            var data = SearchModelByTag(tag);
            List<Model> models = new List<Model>();
            foreach (var row in data)
            {
                models.Add(new Model
                {
                    Id = row.Id,
                    Modelid = row.Modelid,
                    Name = row.Name,
                    Price = row.Price,
                    Size = row.Size,
                    Platform = row.Platform,
                    Category = row.Category,
                    Material = row.Material,
                    Style = row.Style,
                    Render = row.Render,
                    Color = row.Color,
                    Description = row.Description,
                    Tag = row.Tag,
                    ImagePath = row.ImagePath,
                    FilePath = row.FilePath
                });
            }
            return View(models);
        }














/// <summary>
/// /////////////////////////////////////////////////////////////////////////////////
/// </summary>
/// <param ></param>
/// <returns></returns>
/*
public FileResult Download(string FileName, string FilePath)
{

    byte[] fileBytes = System.IO.File.ReadAllBytes(FilePath);
    return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, FileName);
    //return File(FilePath, System.Net.Mime.MediaTypeNames.Application.Octet, FileName);
}
*/


[HttpPost]
        public ActionResult Download(string FilePath)
        {

            byte[] fileBytes = GetFile(FilePath);
            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, FilePath);
        }

        byte[] GetFile(string s)
        {
            System.IO.FileStream fs = System.IO.File.OpenRead(s);
            byte[] data = new byte[fs.Length];
            int br = fs.Read(data, 0, data.Length);
            if (br != fs.Length)
                throw new System.IO.IOException(s);
            return data;
        }
        

    }
}
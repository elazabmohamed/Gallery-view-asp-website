using _3DModels.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static DataLibrary.ModelLogic.ModelProcessor;
using static DataLibrary.ModelLogic.AdminProcessor;
using System.Web.SessionState;
using _3DModels.Attributes;

namespace _3DModels.Controllers
{

    [CehckSession]


    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index(string tag = "old", string tag2 = "weird", string tag3 = "cool")
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
            foreach (var row in data2)
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


        public ActionResult ViewModels()
        {
            ViewBag.Message = "MODELS";
            var data = LoadModels();
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
                    FilePath = row.FilePath,
                });
            }
            return View(models);
        }

        
        private static Random random = new Random();
        public static string RandomString(int length)
        {
            const string chars = "0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        
        public ActionResult Models()
        {
            ViewBag.Message = "MODELS";

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Models(Model model, HttpPostedFileBase ModelImage, HttpPostedFileBase ModelFile)
        {


            // var allowedExtensions = new[] { ".JPEG ", ".JPG", ".PNG ", ".RAW" };
            //   RESTRICT FILE TYPES


            model.Modelid = int.Parse(RandomString(8));


            string CreateFolderforModel = model.Name.Trim() + "-" + model.Modelid.ToString();
            while (Directory.Exists(model.Name.Trim() + "-" + model.Modelid.ToString()))
            {
               model.Modelid = int.Parse(RandomString(8));

                CreateFolderforModel = model.Name.Trim() + "-" + model.Modelid.ToString();
            }


            

            // fetching the model's image/render



            Directory.CreateDirectory(Server.MapPath("~/Content/Models/" + CreateFolderforModel + "/Image/"));




            if (ModelImage != null && ModelImage.ContentLength > 0)
                try
                {
                    string imagePath = Path.Combine(Server.MapPath("~/Content/Models/" + CreateFolderforModel + "/Image/"),
                                               Path.GetFileName(ModelImage.FileName));

                    ModelImage.SaveAs(imagePath);
                    //Saving info to database model
                    //model.ImagePath = imagePath;

                    model.ImagePath = "/Content/Models/" + CreateFolderforModel + "/Image/" + Path.GetFileName(ModelImage.FileName);
                    ViewBag.Message = "Model's image uploaded successfully";
                }
                catch (Exception ex)
                {
                    ViewBag.Message = "ERROR:" + ex.Message.ToString();
                }
            else
            {
                ViewBag.Message = "You have not specified a file.";
            }

            /// Now fetching the actual model's file

            Directory.CreateDirectory(Server.MapPath("~/Content/Models/" + CreateFolderforModel + "/Model/"));
            if (ModelFile != null && ModelFile.ContentLength > 0)
                try
                {

                    string modelPath = Path.Combine(Server.MapPath("~/Content/Models/" + CreateFolderforModel + "/Model/"),
                                               Path.GetFileName(ModelFile.FileName));

                    ModelFile.SaveAs(modelPath);
                    //Saving info to database model
                    // model.FilePath = modelPath.ToString();

                    if (ModelFile.ContentLength < (1024 * 1024))
                    {
                        model.Size = "Less than 1 MB";
                    }
                    else
                    {
                        model.Size = String.Format("{0:0.#}", ModelFile.ContentLength / (1024 * 1024)) + "MB";

                        // model.Size = (ModelFile.ContentLength / 1024).ToString() + "MB";
                    }

                    model.FilePath = "/Content/Models/" + CreateFolderforModel + "/Model/" + Path.GetFileName(ModelFile.FileName); ;
                    model.FileName = Path.GetFileName(ModelFile.FileName);
                    ViewBag.Message = "Model uploaded successfully";
                }
                catch (Exception ex)
                {
                    ViewBag.Message = "ERROR:" + ex.Message.ToString();
                }
            else
            {
                ViewBag.Message = "You have not specified a file.";
            }


            if (ModelState.IsValid)
            {
                int recordsCreated = CreateModel(model.Modelid, model.Name,
                    model.Price, model.Size, model.Platform,
                    model.Category, model.Material, model.Style,
                    model.Render, model.Color, model.Description,
                    model.Tag, model.FileName, model.ImagePath, model.FilePath);
                return RedirectToAction("Index");
            }
            return View();
        }


        public ActionResult LogOff()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Home");

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


        public ActionResult UpdateModel()
        {
            ViewBag.Message = "UPDATE MODEL";
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateModel(int id)
        {
            Model model = new Model();
            if (ModelState.IsValid)
            {
                int recordsCreated = CreateModel(model.Modelid=id, model.Name,
                    model.Price, model.Size, model.Platform,
                    model.Category, model.Material, model.Style,
                    model.Render, model.Color, model.Description,
                    model.Tag, model.FileName, model.ImagePath, model.FilePath);
                return RedirectToAction("Index");
            }
            return View();
        }










        //          needs to get finished
        public ActionResult DeleteModelC()
        {
            ViewBag.Message = "Delete";

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteModelC(int id)
        {
            ViewSpecificModel(id);
            if (ModelState.IsValid)
            {
                DeleteModel(id);
                RedirectToAction("ViewModels", "Admin");
            }
            return View();
        }
    }
}
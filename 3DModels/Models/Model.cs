using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace _3DModels.Models
{
    public class Model
    {
        public int Id { get; set; }
        public int Modelid { get; set; }
        [Required(ErrorMessage = "You need to enter the name of the model.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "You need to enter the price.")]
        //[DataType(DataType.Currency)]
        public string Price { get; set; }

        public string Size { get; set; }

        [Required(ErrorMessage = "You need to enter the platform of the model.")]
        public string Platform { get; set; }

        [Required(ErrorMessage = "You need to enter a category for the model.")]
        public string Category { get; set; }

        [Required(ErrorMessage = "You need to enter the material of the model.")]
        public string Material { get; set; }

        [Required(ErrorMessage = "You need to enter the style of the model.")]
        public string Style { get; set; }
        [Required(ErrorMessage = "You need to enter the render of the model.")]
        public string Render { get; set; }

        [Required(ErrorMessage = "You need to enter the render of the model.")]
        public string Color { get; set; }
        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "You need to enter a description of the model.")]
        public string Description { get; set; }
        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "You need to enter at least one tag for the model.")]
        public string Tag { get; set; }

        /*
         * 
        //          NOT WORKING
        [DataType(DataType.Upload)]
        [Required(ErrorMessage = "You need to enter a render of the model.")]
        public HttpPostedFile ImageFile { get; set; }

        [Required(ErrorMessage = "You need to enter a porper URL link of the model.")]
        [DataType(DataType.Url)]
        public string FileLink { get; set; }

        */

        [Display(Name="")]
        [System.Web.Mvc.HiddenInput(DisplayValue = false)]
        public string FileName { get; set; }
        [Display(Name = "Render")]
        [System.Web.Mvc.HiddenInput(DisplayValue = false)]
        public string ImagePath { get; set; }
        [Display(Name = "Model")]
        [System.Web.Mvc.HiddenInput(DisplayValue = false)]
        public string FilePath { get; set; }


    }

}
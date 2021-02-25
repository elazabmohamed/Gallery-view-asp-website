using DataLibrary.DataAccess;
using DataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.ModelLogic
{
    public class ModelProcessor
    {
        public static int CreateModel( int modelid, string name, string price, string size,
            string platform, string category, string material, string style,
            string render, string color, string description, string tag, string fileName,
            string imagePath, string filePath)
        {
            Model data = new Model
            {
                Modelid = modelid,
                Name = name,
                Price = price,
                Size = size,
                Platform = platform,
                Category = category,
                Material = material,
                Style = style,
                Render = render,
                Color = color,
                Description = description,
                Tag = tag,
                FileName = fileName,
                ImagePath = imagePath,
                FilePath = filePath,
            };
            string sql = @"insert into dbo.Model (Modelid, Name, Price, Size, Platform, Category, Material, Style, Render, Color, Description, Tag, FileName, ImagePath, FilePath )
                         values (@Modelid, @Name, @Price, @Size, @Platform, @Category, @Material, @Style, @Render, @Color, @Description, @Tag, @FileName, @ImagePath, @FilePath);";
            return SqlDataAccess.SaveData(sql, data);
        }




        public static int UpdateModel(int modelid, string name, string price, string size,
            string platform, string category, string material, string style,
            string render, string color, string description, string tag, string fileName,
            string imagePath, string filePath)
        {
            Model data = new Model
            {
                Modelid=modelid,
                Name = name,
                Price = price,
                Size = size,
                Platform = platform,
                Category = category,
                Material = material,
                Style = style,
                Render = render,
                Color = color,
                Description = description,
                Tag = tag,
                FileName = fileName,
                ImagePath = imagePath,
                FilePath = filePath,
            };
            string sql = @"UPDATE dbo.Model SET Name='@Name', Price='@Price', Size='@Size', Platform='@Platform',
                            Category='@Category', Material='@Material', Style='@Style', Render='@Render', Color='@Color',
                            Description='@Description', Tag='@Tag', FileName='@FileName', ImagePath='@ImagePath',
                            FilePath='@FilePath' WHERE Modelid='@Modelid';";
                                                                                   
            return SqlDataAccess.SaveData(sql, data);
        }











        public static List<Model> LoadModels()
        {
            string sql = @"select Id, Modelid, Name, Price, Size, Platform, Category, Material, Style, Render, Color, Description, Tag, FileName, ImagePath, FilePath
                          from dbo.Model;";
            return SqlDataAccess.LoadData<Model>(sql);
        }

        public static List<Model> SearchModelByTag(string tag)
        {
            string sql = @"select Id, Modelid, Name, Price, Size, Platform, Category, Material, Style, Render, Color, Description, Tag, FileName, ImagePath, FilePath
                          from dbo.Model WHERE Tag LIKE'%"+tag+"%';";
            return SqlDataAccess.LoadData<Model>(sql);

        }

        public static List<Model> LoadSpecificModels(int id)
        {
            string sql = @"select Id, Modelid, Name, Price, Size, Platform, Category, Material, Style, Render, Color, Description, Tag, FileName, ImagePath, FilePath
                          from dbo.Model where ModelId='" + id + "';";
            return SqlDataAccess.LoadData<Model>(sql);
        }

        public static bool DeleteModel(int id) {

            Model data = new Model
            {
                Id = id
            };

            string sql = "DELETE FROM dbo.Model WHERE Modelid='" + data.Id + "'";
            return SqlDataAccess.DeleteModel(sql, data);
        }





    }

  



}

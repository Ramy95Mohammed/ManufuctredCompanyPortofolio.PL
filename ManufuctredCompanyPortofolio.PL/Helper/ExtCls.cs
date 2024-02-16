using ManufuctredCompanyPortofolio.PL.Models;
using System.Text.Json;


namespace ManufuctredCompanyPortofolio.PL.Helper
{
    public class ExtCls
    {
        public static List<Countries> GetCountries(IWebHostEnvironment hostingEnvironment)
        {
            var jsonData = File.ReadAllText(Path.Combine(hostingEnvironment.ContentRootPath, "wwwroot", "jsonfiles", "nationalities.json"));
            var options = JsonSerializer.Deserialize<List<Countries>>(jsonData);

            return options;
        }
        public static async Task<string> SaveImageFile(IFormFile file,IWebHostEnvironment _hostingEnvironment,string ImageName) 
        {
            if (file != null)
            {
                var uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "Files", "Images");
                var uniqueFileName = Guid.NewGuid().ToString() + "_" + file.FileName;
                var filePath = Path.Combine(uploadsFolder, uniqueFileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(fileStream);
                }
                return uniqueFileName;
            }
            else
                return ImageName;
        }
        public static void DeleteImageFile(string FileName, IWebHostEnvironment _hostingEnvironment)
        {
            if (FileName != null)
            {
                var FileNamePath = Path.Combine(_hostingEnvironment.WebRootPath, "Files", "Images", FileName);
                if (File.Exists(FileNamePath))
                    File.Delete(FileNamePath);
            }            
        }        
    }
}

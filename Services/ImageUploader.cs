using BlogSite.Models;

namespace BlogSite.Services
{
    public class ImageUploader
    {
        public async Task<string> imageUpload(BlogModel blog, IWebHostEnvironment env)
        {
            if (blog.imageFile != null)
            {
                string fileName = Path.GetFileName(blog.imageFile.FileName);
                string fileExtension = Path.GetExtension(blog.imageFile.FileName);
                fileName = fileName + DateTime.Now.ToString("y-MM-dd-mm-ss") + fileExtension;
                string path = Path.Combine(env.WebRootPath, "images",fileName);

                using (FileStream fs = new FileStream(path, FileMode.Create))
                {
                   await blog.imageFile.CopyToAsync(fs);
                }

                return fileName;
            }
            return "";
        }

    }
}

using Blog_Site_Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog_Site_Core.Data
{
    public interface IRepositoty
    {
        postModel GetPost(int id);
        List<postModel> GetAllPost(int id);
        void AddPost(postModel postModel);
        void UpdatePost(postModel postModel);
        void RemovePost(int id);

        Task<bool> SaveChangesAsync();


    }
}

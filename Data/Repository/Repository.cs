using Blog_Site_Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog_Site_Core.Data
{
    public class Repository : IRepositoty
    {
        private readonly appDbContext _ctx;
        public Repository(appDbContext ctx)
        {
            _ctx = ctx;
        }
        public void AddPost(postModel postModel)
        {
            _ctx.postModelD.Add(postModel);
        }

        public List<postModel> GetAllPost()
        {
            return _ctx.postModelD.ToList();
        }

        public postModel GetPost(int id)
        {
            return _ctx.postModelD.FirstOrDefault(p => p.Id == id);
        }

        public void RemovePost(int id)
        {
            _ctx.postModelD.Remove(GetPost(id));
        }

        public void UpdatePost(postModel postModel)
        {
            _ctx.postModelD.Update(postModel);
        }

        public async Task<bool> SaveChangesAsync()
        {
            if(await _ctx.SaveChangesAsync() > 0)
            {
                return true;
            }

            return false;
        }


    }
}

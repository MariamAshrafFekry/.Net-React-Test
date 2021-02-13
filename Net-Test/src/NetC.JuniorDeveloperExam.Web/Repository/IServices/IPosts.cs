using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetC.JuniorDeveloperExam.Web.Repository.IServices
{
    public interface IPosts
    {
        bool Add(Models.Post post);
        List<Models.Post> GetAll();
        bool SaveAll(List<Models.Post> posts);
    }
}

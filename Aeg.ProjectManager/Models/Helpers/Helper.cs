using Aeg.ProjectManager.Models.DataContext;
using System.Linq;

namespace Aeg.ProjectManager.Models
{
    public class Helper
    {
        private AegDbContext db = new AegDbContext();
        public Personel.Personel GetByUsername(string username)
        {
            return db.Personels.Where(x => x.NameSurname == username).FirstOrDefault();
        }
    }
}
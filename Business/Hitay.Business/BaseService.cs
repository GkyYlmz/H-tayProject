using Hitay.Data.Model;
using System.Linq;

namespace Hitay.Business
{
    public class BaseService
    {
        public HitayEntities Context = null;
        public BaseService(HitayEntities context)
        {
            Context = context;
        }

        protected IQueryable<T> GetQuery<T>() where T : class
        {
            return Context.Set<T>().AsNoTracking();
        }
    }
}

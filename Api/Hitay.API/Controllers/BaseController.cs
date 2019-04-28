using Hitay.Business.General;
using Hitay.Business.Infastructure;
using System.Web.Http;

namespace Hitay.API.Controllers
{
    public class BaseController : ApiController
    {
        public IGeneralService GeneralService
        {
            get
            {
                return IoC.Resolve<IGeneralService>();
            }
        }
    }
}

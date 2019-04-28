using Hitay.Business.General;
using Hitay.Business.Infastructure;

namespace Hitay.UI.Models
{
    public class BaseModel
    {
        public string ValidationMessage { get; set; }
        public string Type { get; set; }

        public IGeneralService GeneralService
        {
            get
            {
                return IoC.Resolve<IGeneralService>();
            }
        }
    }
}
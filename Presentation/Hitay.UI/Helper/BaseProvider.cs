using Hitay.Business.General;
using Hitay.Business.Infastructure;
using System;

namespace Hitay.UI.Helper
{
    public class BaseProvider : BaseMvcProvider, IDisposable
    {

        public IGeneralService GeneralService
        {
            get { return IoC.Resolve<IGeneralService>(); }
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
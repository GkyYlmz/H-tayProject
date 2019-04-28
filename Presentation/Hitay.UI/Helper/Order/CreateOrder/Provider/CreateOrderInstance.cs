using Hitay.UI.Models.Order;
using System.Web.Mvc;

namespace Hitay.UI.Helper.Order.CreateOrder.Provider
{
    public class CreateOrderInstance
    {
        public CreateOrderInstance(Controller controller, CreateOrderSubmitEnum submit)
        {
            switch (submit)
            {
                case CreateOrderSubmitEnum.Create:
                    Provider = new InsertProvider();
                    break;
            }
        }
        public IProvider<OrderCreateViewModel> Provider { get; set; }
    }
}
using Hitay.UI.Helper.Order.OrderTracking;
using Hitay.UI.Helper.Order.OrderTracking.Provider;
using Hitay.UI.Models.Order;
using System.Web.Mvc;

namespace Hitay.UI.Helper.Order
{
    public class OrderTrackingInstance
    {
        public OrderTrackingInstance(Controller controller ,OrderTrackingSubmitEnum submit)
        {
            switch (submit)
            {
                case OrderTrackingSubmitEnum.Update:
                    Provider = new UpdateProvider();
                    break;
            }
        }
        public IProvider<OrderViewModel> Provider { get; set; }
    }
}
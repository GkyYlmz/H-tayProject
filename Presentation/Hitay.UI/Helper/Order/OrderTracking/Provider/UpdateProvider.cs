using Hitay.UI.Models.Order;
using Hitay.Common.Helpers;
using Hitay.Common;

namespace Hitay.UI.Helper.Order.OrderTracking.Provider
{
    public class UpdateProvider : IProvider<OrderViewModel>
    {
        public void Execute(OrderViewModel model)
        {
            var result = HttpHelper.Get<ServiceResult<bool>>($"http://localhost:52067/api/Order/UpdateOrder?orderId={model.Id}").Result;
            if (result)
            {
                model.ValidationMessage = result ? "Başarılı" : "Başarısız";
                model.Type = result ? "success" : "error";
            }
            model.GetList();
            model.GetCountList();
        }
    }
}
using Hitay.Common;
using Hitay.Common.Helpers;
using Hitay.UI.Models.Order;

namespace Hitay.UI.Helper.Order.CreateOrder.Provider
{
    public class InsertProvider : IProvider<OrderCreateViewModel>
    {
        public void Execute(OrderCreateViewModel model)
        {
            if (model.CustomerName != null && model.CustomerName != string.Empty && model.SelectedCofeeTypeId > decimal.Zero)
            {
                var result = HttpHelper.Get<ServiceResult<bool>>($"http://localhost:52067/api/Order/CreateOrder?coffeeTypeId={model.SelectedCofeeTypeId}&customerName={model.CustomerName}&cream={model.Cream.ToBoolean()}&milk={model.Milk.ToBoolean()}&sugarTypeId={model.SelectedSugarTypeId}");

                model.ValidationMessage = result.Result ? "Başarılı" : "Başarısız";
                model.Type = result.Result ? "success" : "error";
            }
            else
            {
                model.ValidationMessage = "Alanları Doldurunuz";
                model.Type = "error";
            }
            model.GetOrder();
        }
    }
}
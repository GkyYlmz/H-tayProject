using Hitay.Common;
using Hitay.Common.Classes;
using Hitay.Common.Helpers;
using System.Collections.Generic;
using System.Linq;

namespace Hitay.UI.Models.Order
{
    public class OrderCreateViewModel : BaseModel
    {
        public List<OrderDto> OrderList { get; set; } = new List<OrderDto>();
        public List<OrderCountDto> OrderCount { get; set; } = new List<OrderCountDto>();
        public List<CoffeeTypeDto> CoffeeTypeList { get; set; }
        public List<SugarTypeDto> SugarTypeList { get; set; }
        public int SelectedCofeeTypeId { get; set; }
        public string CustomerName { get; set; }
        public int Cream { get; set; } = Int.Zero;
        public int Milk { get; set; } = Int.Zero;
        public int SelectedSugarTypeId { get; set; } = Int.One;

        public OrderCreateViewModel()
        {
            FillPage();
        }

        public void FillPage()
        {
            GetOrder();

            var orderCount = HttpHelper.Get<ServiceResult<List<OrderCountDto>>>("http://localhost:52067/api/Order/OrderCount");
            if (orderCount != null && orderCount.Result != null && orderCount.Result.Any())
            {
                OrderCount = orderCount.Result;
            }

            var cofeeTypeList = HttpHelper.Get<ServiceResult<List<CoffeeTypeDto>>>($"http://localhost:52067/api/Order/GetCofeeType");
            if (cofeeTypeList != null && cofeeTypeList.Result != null && cofeeTypeList.Result.Any())
            {
                CoffeeTypeList = cofeeTypeList.Result.ToList();
            }

            var sugarTypeList = HttpHelper.Get<ServiceResult<List<SugarTypeDto>>>($"http://localhost:52067/api/Order/GetSugarTypeList");
            if (sugarTypeList != null && sugarTypeList.Result != null && sugarTypeList.Result.Any())
            {
                SugarTypeList = sugarTypeList.Result.ToList();
            }
        }

        public void GetOrder()
        {
            var orderList = HttpHelper.Get<ServiceResult<List<OrderDto>>>($"http://localhost:52067/api/Order/GetOrderList?statusId={decimal.Zero}");
            if (orderList != null && orderList.Result != null && orderList.Result.Any())
            {
                OrderList = orderList.Result.OrderByDescending(a => a.Id).Take(5).ToList();
            }
        }
    }
}
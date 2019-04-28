using Hitay.Common;
using Hitay.Common.Classes;
using Hitay.Common.Enums;
using Hitay.Common.Helpers;
using System.Collections.Generic;
using System.Linq;

namespace Hitay.UI.Models.Order
{
    public class OrderViewModel : BaseModel
    {
        public int Id { get; set; }
        public List<OrderDto> OrderList { get; set; } = new List<OrderDto>();
        public List<OrderCountDto> OrderCount { get; set; } = new List<OrderCountDto>();

        public OrderViewModel()
        {
            FillPage();
        }

        public void FillPage()
        {
            GetList();
            GetCountList();
        }

        public void GetList()
        {
            var orderList = HttpHelper.Get<ServiceResult<List<OrderDto>>>($"http://localhost:52067/api/Order/GetOrderList?statusId={(int)OrderStatusEnum.Preparing}");
            if (orderList != null && orderList.Result != null && orderList.Result.Any())
            {
                OrderList = orderList.Result;
            }
        }

        public void GetCountList()
        {
            var orderCount = HttpHelper.Get<ServiceResult<List<OrderCountDto>>>("http://localhost:52067/api/Order/OrderCount");
            if (orderCount != null && orderCount.Result != null && orderCount.Result.Any())
            {
                OrderCount = orderCount.Result;
            }
        }
    }
}
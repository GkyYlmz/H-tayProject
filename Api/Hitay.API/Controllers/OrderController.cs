using Hitay.API.Helper;
using Hitay.Common.Enums;
using System.Net.Http;
using System.Web.Http;

namespace Hitay.API.Controllers
{
    public class OrderController : BaseController
    {
        [HttpGet]
        public HttpResponseMessage CreateOrder(int coffeeTypeId, string customerName, bool cream, bool milk, int sugarTypeId)
        {
            var result = GeneralService.InsertOrder(coffeeTypeId, customerName, cream, milk, sugarTypeId);
            return ControllerHelper.GetJsonResponseMessage(result);
        }

        [HttpGet]
        public HttpResponseMessage GetOrderList(int statusId)
        {
            var result = GeneralService.GetOrderList(statusId);
            return ControllerHelper.GetJsonResponseMessage(result);
        }

        [HttpGet]
        public HttpResponseMessage OrderCount()
        {
            var result = GeneralService.GetOrderCountByStatusGroup();
            return ControllerHelper.GetJsonResponseMessage(result);
        }

        [HttpGet]
        public HttpResponseMessage UpdateOrder(int orderId)
        {
            var result = GeneralService.UpdateOrder(orderId);
            return ControllerHelper.GetJsonResponseMessage(result);
        }
        [HttpGet]
        public HttpResponseMessage GetCofeeType()
        {
            var result = GeneralService.GetCoffeeTypeList();
            return ControllerHelper.GetJsonResponseMessage(result);
        }

        [HttpGet]
        public HttpResponseMessage GetSugarTypeList()
        {
            var result = GeneralService.GetSugarTypeList();
            return ControllerHelper.GetJsonResponseMessage(result);
        }
    }
}

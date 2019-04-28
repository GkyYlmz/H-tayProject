using Hitay.Common.Constants;
using Hitay.Common.Helpers;
using Hitay.UI.Helper.Order;
using Hitay.UI.Helper.Order.CreateOrder;
using Hitay.UI.Helper.Order.CreateOrder.Provider;
using Hitay.UI.Helper.Order.OrderTracking;
using Hitay.UI.Models.Order;
using System.Web.Mvc;

namespace Hitay.UI.Controllers
{
    public class OrderController : Controller
    {
        public ActionResult Index()
        {
            var model = new OrderViewModel();
            return View(model);
        }

        [HttpPost]
        public PartialViewResult Index(OrderViewModel model, OrderTrackingSubmitEnum submit)
        {
            var instance = new OrderTrackingInstance(this, submit);
            instance.Provider.Execute(model);

            return PartialView(PartialViewConstants.IndexPartial, model);
        }

        public ActionResult Create()
        {
            var model = new OrderCreateViewModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(OrderCreateViewModel model, CreateOrderSubmitEnum submit)
        {
            ModelState.Clear();
            var instance = new CreateOrderInstance(this, submit);
            instance.Provider.Execute(model);

            return View(PartialViewConstants.CreatePartial, model);
        }
    }
}
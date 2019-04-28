using System.Web.Mvc;

namespace Hitay.UI.Helper
{
    public class BaseMvcProvider
    {
        public Controller Controller { get; set; } 
        public ModelStateDictionary ModelState { get; set; }

        public void SetController(Controller controller)
        {
            Controller = controller;
            ModelState = Controller.ModelState;
        }
    }
}
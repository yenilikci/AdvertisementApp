using AdvertisementApp.Common;
using Microsoft.AspNetCore.Mvc;

namespace AdvertisementApp.UI.Extensions
{
    public static class ControllerExtensions
    {
        public static IActionResult ResponseRedierctAction<T>(this Controller controller, IResponse<T> response, string actionName)
        {
            if(response.ResponseType == ResponseType.NotFound) 
            {
                return controller.NotFound();
            }
            if(response.ResponseType == ResponseType.ValidationError) 
            {
                foreach (var error in response.ValidationErrors)    
                {
                    controller.ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
                return controller.View(response.Data);
            }
            return controller.RedirectToAction(actionName);
        }

        public static IActionResult ResponseView<T>(this Controller controller, IResponse<T> response) 
        {
            if(response.ResponseType == ResponseType.NotFound)
            {
                return controller.NotFound();
            }
            return controller.View(response.Data);
        }

        public static IActionResult ResponseRedirectAction(this Controller controller, IResponse response, string actionName)
        {
            if(response.ResponseType == ResponseType.NotFound) 
            {
                return controller.NotFound();
            }
            return controller.RedirectToAction(actionName);
        }
    }
}

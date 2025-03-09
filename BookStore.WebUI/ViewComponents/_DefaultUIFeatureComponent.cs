using Microsoft.AspNetCore.Mvc;

namespace BookStore.WebUI.ViewComponents
{
    public class _DefaultUIFeatureComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();  
        }
    }
}

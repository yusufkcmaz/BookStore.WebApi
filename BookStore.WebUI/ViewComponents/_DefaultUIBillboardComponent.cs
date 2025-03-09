using Microsoft.AspNetCore.Mvc;

namespace BookStore.WebUI.ViewComponents
{
    public class _DefaultUIBillboardComponent :ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();  
        }
    }
}

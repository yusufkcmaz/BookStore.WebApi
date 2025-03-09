using Microsoft.AspNetCore.Mvc;

namespace BookStore.WebUI.ViewComponents
{
    public class _DefaultUIQuotationComponent :ViewComponent

    {
        public IViewComponentResult Invoke()
        {
            return View();  
        }
    }
}

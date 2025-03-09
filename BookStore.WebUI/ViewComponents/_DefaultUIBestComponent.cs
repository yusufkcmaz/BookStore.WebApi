using Microsoft.AspNetCore.Mvc;

namespace BookStore.WebUI.ViewComponents
{
    public class _DefaultUIBestComponent :ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}

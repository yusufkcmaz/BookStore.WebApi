using Microsoft.AspNetCore.Mvc;

namespace BookStore.WebUI.ViewComponents
{
    public class _DefaultUIPopularComponent :ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();  
        }
    }
}

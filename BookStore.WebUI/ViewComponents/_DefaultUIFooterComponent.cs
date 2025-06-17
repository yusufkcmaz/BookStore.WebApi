using BookStore.BusinessLayer.Abstract;
using BookStore.EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.WebUI.ViewComponents
{
    public class _DefaultUIFooterComponent : ViewComponent
    {
        private readonly IFooterService _footerService;

        public _DefaultUIFooterComponent(IFooterService footerService)
        {
            _footerService = footerService;
        }

        public IViewComponentResult Invoke()
        {
            var footer = _footerService.TGetAll();
            return View(footer);
        }
    }
}

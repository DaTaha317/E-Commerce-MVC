using Microsoft.AspNetCore.Mvc;

namespace E_Commerce_MVC.ViewComponents
{
	public class SearchBarViewComponent : ViewComponent
	{
        public SearchBarViewComponent()
        {
            
        }

        public IViewComponentResult Invoke(SPager SearchPager)
        {
            return View(SearchPager);
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace E_Commerce_MVC.ViewComponents
{
    public class ProfileBarViewComponent : ViewComponent
    {
        public ProfileBarViewComponent()
        {
            
        }

        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}

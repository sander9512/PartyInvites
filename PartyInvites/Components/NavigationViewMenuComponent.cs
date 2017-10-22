using Microsoft.AspNetCore.Mvc;
using System.Linq;
using PartyInvites.Models;
namespace PartyInvites.Components
{
    public class NavigationMenuViewComponent : ViewComponent
    {
        private IRepository repository;
        public NavigationMenuViewComponent(IRepository repo)
        {
            repository = repo;
        }
        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedCategory = RouteData?.Values["category"];
            return View(repository.Responses
            .Select(x => x.WillAttend)
            .Distinct()
            .OrderBy(x => x));
        }
    }
}

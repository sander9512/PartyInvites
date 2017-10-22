using Microsoft.AspNetCore.Mvc;
using System;
using PartyInvites.Models;
using System.Linq;
using PartyInvites.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace PartyInvites.Controllers
{
    public class HomeController : Controller
    {
        public int PageSize = 4;
        private IRepository repo;

        public HomeController(IRepository repository)
        {
            repo = repository;
        }
        public ViewResult Index()
        {
            int hour = DateTime.Now.Hour;
            ViewBag.Greeting = hour < 12 ? "Good Morning" : "Good Afternoon";
            return View("MyView");
        }
        [HttpGet]
        public ViewResult RsvpForm()
        {
            return View();
        }

        public ViewResult FindResponse()
        {
            return View("SelectResponse");
        }

        [HttpPost]
        public ViewResult EditResponse(String Email)
        {
            GuestResponse response = repo.FindResponse(Email);
            if (response == null || response.Email == null)
            {
                return View("NullResponse");
            }
            else
            {
                return View("EditResponse", response);
            }        
            
        }

       
        [HttpPost]
        public ViewResult RsvpForm(GuestResponse guestResponse)
        {
            if (ModelState.IsValid)
            {
                repo.AddResponse(guestResponse);
                return View("Thanks", guestResponse);
            }
            else
            {
                // there is a validation error
                return View();
            }
        }
        [Authorize]
        public ViewResult ListResponses(int page = 1)
        {
            if (repo.Responses.Where(r => r.WillAttend == true).Count() == 0)
            {
                return View("Empty");
            }
            else
            {
                return View(new GuestResponseListViewModel
                {
                    Responses = repo.Responses
                    .OrderBy(p => p.Email)
                    .Skip((page - 1) * PageSize)
                    .Take(PageSize),
                    PagingInfo = new PagingInfo
                    {
                        CurrentPage = page,
                        ItemsPerPage = PageSize,
                        TotalItems =
                     repo.Responses.Count()

                    }
                });
            }
        }
        [Authorize]
        public ViewResult List(bool category, int page = 1)
      => View("ListResponses", new GuestResponseListViewModel
      {
          Responses = repo.Responses
         .Where(p => p.WillAttend == category)
         .OrderBy(p => p.Email)
         .Skip((page - 1) * PageSize)
         .Take(PageSize),
          PagingInfo = new PagingInfo
          {
              CurrentPage = page,
              ItemsPerPage = PageSize,
              TotalItems =
             repo.Responses.Where(e =>
              e.WillAttend == category).Count()

          },
      });
    }
}


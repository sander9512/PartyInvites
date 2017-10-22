using Microsoft.AspNetCore.Mvc;
using PartyInvites.Models;
using PartyInvites.Models.ViewModels;
using System;
using System.Linq;
namespace PartyInvites.Components
{
    public class ResponseSummaryViewComponent : ViewComponent
    {
        private IRepository repository;
        public ResponseSummaryViewComponent(IRepository repo)
        {
            repository = repo;
        }

         public IViewComponentResult Invoke()
                {
            return View(new ResponseSummary {
                TotalResponses = repository.Responses.Count(),
                Attendees = repository.Responses.Where(r => r.WillAttend == true).Count()
            });
         }
    }
}
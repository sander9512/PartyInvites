using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PartyInvites.Models
{
    public class GuestResponseRepository : IRepository
    {
        private ApplicationDbContext context;

        public GuestResponseRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }

        public IEnumerable<GuestResponse> Responses => context.GuestResponses;

        public bool AddResponse(GuestResponse response)
        {
            if (context.GuestResponses.Any(g => g.Email.Equals(response.Email)))
            {
                context.GuestResponses.Update(response);
            }
            else
            {
                context.GuestResponses.Add(response);
            }
            context.SaveChanges();

            return true;
        }

        public GuestResponse FindResponse(String Email)
        {
            GuestResponse response = context.GuestResponses.SingleOrDefault(g => g.Email.Equals(Email));

            return (response);
        }
    }
}

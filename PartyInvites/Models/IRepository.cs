using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PartyInvites.Models
{
    public interface IRepository
    {
        IEnumerable<GuestResponse> Responses { get; }

        bool AddResponse(GuestResponse response);

        GuestResponse FindResponse(String Email);
    }
}

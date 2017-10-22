using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PartyInvites.Models.ViewModels
{
    public class GuestResponseListViewModel
    {
        public IEnumerable<GuestResponse> Responses { get; set; }
        public PagingInfo PagingInfo { get; set; }

        public string CurrentCategory { get; set; }
    }
}

using System.Collections.Generic;

namespace PartyInvites.Models
{
    public class FakeRepository : IRepository
    {
        private static List<GuestResponse> responses = new List<GuestResponse>();

        public IEnumerable<GuestResponse> Responses
        {
            get
            {
                if (responses.Count == 0)
                {
                    SeedData();
                }
                return responses;
            }
        }
        void SeedData()
        {
            responses.Add(new GuestResponse { Name = "Test1", Email = "Test@email.com", Phone = "123453", Address = "Zundert", WillAttend = true });
            responses.Add(new GuestResponse { Name = "Test2", Email = "Test2@email.com", Phone = "123453", Address = "Zundert", WillAttend = true });
            responses.Add(new GuestResponse { Name = "Test3", Email = "Test3@email.com", Phone = "123453", Address = "Zundert", WillAttend = true });
        }

        public bool AddResponse(GuestResponse response)
        {
            responses.Add(response);
            return true;
        }

        public GuestResponse FindResponse(string Email)
        {
            GuestResponse response = responses.Find(r => r.Email.Equals(Email));
            return response;
        }
    }
}

using Microsoft.EntityFrameworkCore;

namespace PartyInvites.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) { }

        public DbSet<GuestResponse> GuestResponses { get; set; }

    }
}
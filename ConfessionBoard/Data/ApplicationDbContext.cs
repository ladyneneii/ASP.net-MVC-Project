using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ConfessionBoard.Models;

namespace ConfessionBoard.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<ConfessionBoard.Models.Confession> Confession { get; set; }
        public DbSet<ConfessionBoard.Models.Gift> Gift { get; set; }
    }
}
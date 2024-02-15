using Microsoft.EntityFrameworkCore;
using APIV1.Domain;

namespace APIV1.Persistence.Context
{
    public class APIV1Context : DbContext
    {
        public APIV1Context(DbContextOptions<APIV1Context> options) : base(options)
        {

        }
        public DbSet<Group>? Group { get; set; }

    }
}
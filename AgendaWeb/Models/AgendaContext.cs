using System.Data.Entity;

namespace AgendaWeb.Models
{
    public class AgendaContext : DbContext
    {
        public DbSet<Contact> Contacts { get; set; }

    }
}
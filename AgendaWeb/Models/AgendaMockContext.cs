using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AgendaWeb.Models
{
    public class AgendaMockContext : DbContext
    {
        public DbSet<Contact> TestContacts { get; set; }

    }
}
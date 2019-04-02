using AgendaWeb.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace AgendaWeb.Controllers
{
    public class ContactsController : ApiController
    {
        private AgendaContext context = new AgendaContext();

        public IQueryable<Contact> GetContacts()
        {
            return context.Contacts;
        }

        [ResponseType(typeof(Contact))]
        public IHttpActionResult GetContact(int id)
        {
            Contact contato = FindContact(id);

            if (contato == null)
            {
                return NotFound();
            }

            return Ok(contato);
        }


        [ResponseType(typeof(Contact))]
        public IHttpActionResult PostContact(Contact contato)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            context.Contacts.Add(contato);
            context.SaveChanges();

            return CreatedAtRoute("DefaultApi", new Contact { Id = contato.Id }, contato);
        }

        [ResponseType(typeof(Contact))]
        public IHttpActionResult PutContact(Contact contato, int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != contato.Id)
            {
                return BadRequest();
            }

            context.Entry(contato).State = EntityState.Modified;

            try
            {
                context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {

                if (!ContactExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        [ResponseType(typeof(Contact))]
        public IHttpActionResult DeleteContact(int id)
        {
            Contact contato = FindContact(id);

            if (contato == null)
            {
                return NotFound();
            }

            context.Contacts.Remove(contato);
            context.SaveChanges();

            return Ok(contato);
        }

        private bool ContactExists(int id)
        {
            return context.Contacts.Count(c => c.Id == id) > 0;
        }

        private Contact FindContact(int id)
        {
            return (from c in context.Contacts
                    where c.Id == id
                    select c).FirstOrDefault();
        }
    }
}

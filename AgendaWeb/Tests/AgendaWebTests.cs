using AgendaWeb.Controllers;
using AgendaWeb.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Web.Http.Results;

namespace AgendaWeb.Tests
{
    [TestClass]
    public class AgendaWebTests
    {
        [TestMethod]
        public void GetDeveRetornarTodosOsContatos()
        {
            AgendaContext context = new AgendaContext();
            context.Contacts.Add(new Contact
            {
                Id = 1,
                Nome = "Teste 01",
                DataNascimento = new DateTime(2010, 01, 01),
                Sexo = "Masculino",
                Idade = 9
            });
            context.Contacts.Add(new Contact
            {
                Id = 2,
                Nome = "Teste 02",
                DataNascimento = new DateTime(1990, 01, 01),
                Sexo = "Feminino",
                Idade = 29
            });

            var controller = new ContactsController();
            var resultado = controller.GetContacts();
            Assert.IsNotNull(resultado);
            Assert.AreEqual(2, resultado.Count());
        }

        [TestMethod]
        public void PostDeveRetornarOContato()
        {
            var context = new AgendaContext();
            var contato = context.Contacts.Add(new Contact
            {
                Id = 1,
                Nome = "Teste 01",
                DataNascimento = new DateTime(2010, 01, 01),
                Sexo = "Masculino",
                Idade = 9
            });
            var controller = new ContactsController();

            var resultado = controller.PostContact(contato) as CreatedAtRouteNegotiatedContentResult<Contact>;
            Assert.IsNotNull(resultado);
            Assert.AreEqual(resultado.RouteName, "DefaultApi");
            Assert.AreEqual(resultado.RouteValues["id"], resultado.Content.Id);
            Assert.AreEqual(resultado.Content.Nome, contato.Nome);
        }

        [TestMethod]
        public void PutDeveFalharQuandoIdDiferente()
        {
            var context = new AgendaContext();
            var contato = context.Contacts.Add(new Contact
            {
                Id = 1,
                Nome = "Teste 01",
                DataNascimento = new DateTime(2010, 01, 01),
                Sexo = "Masculino",
                Idade = 9
            });
            var controller = new ContactsController();

            var resultado = controller.PutContact(contato, Int32.MaxValue);
            Assert.IsInstanceOfType(resultado, typeof(BadRequestResult));
        }

    }
}
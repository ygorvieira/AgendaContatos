using System;
using System.Collections;
using System.Collections.Generic;
using AgendaWeb.Controllers;
using AgendaWeb.Migrations;
using AgendaWeb.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AgendaWebTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void GetDeveRetornarTodosOsContatos()
        {
            var controller = new ContactsController();
            var resultado = controller.GetContacts();
            var response = resultado as OkNegotiatedContentResult<IEnumerable<Contact>>;

            Assert.IsNotNull(response);
            var contatos = response.Content;
            Assert.AreEqual(1, contatos.Count());
        }
    }
}

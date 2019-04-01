using System;
using System.Collections.Generic;
using AgendaWeb.Controllers;
using AgendaWeb.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net.Http;

namespace AgendaWebTestes
{
    [TestClass]
    public class UnitTest1
    {
        private List<Contact> ListaContatos()
        {
            var contatos = new List<Contact>
            {
                new Contact
                {
                    Id = 1,
                    Nome = "Fulano",
                    DataNascimento = new DateTime(2019 - 01 - 01),
                    Sexo = "Masculino",
                    Idade = 0
                },
                new Contact
                {
                    Id = 2,
                    Nome = "Fulana",
                    DataNascimento = new DateTime(2019 - 01 - 01),
                    Sexo = "Feminino",
                    Idade = 0
                }
            };

            return contatos;
        }


        [TestMethod]
        public void GetDeveRetornarTodosOsContatos()
        {
            var testContatos = ListaContatos();
            var controller = new ContactsController();

            List<Contact> resultado = controller.GetContacts() as List<Contact>;
            Assert.AreEqual(testContatos.Count, resultado.Count);
        }
    }
}

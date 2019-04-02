# Agenda de Contatos
WebAPI + Entity Framework Code First

## Tecnologias utilizadas
.NET Framework 4.6.1

EntityFramework 6.2.0

Visual Studio 2017

## Testando o projeto
Para testar a aplicação é necessário executar a aplicação no Visual Studio, que irá subir o servidor IIS.

Em seguida, execute uma aplicação para enviar as requisições HTTP, como o Postman, ou Fiddler.

As rotas são:

**Obter todos os contatos:** GET > http://localhost:{nº da porta}/api/Contacts

**Obter um contato pelo ID:** GET > http://localhost:{nº da porta}/api/Contacts/{id}

**Inserir novo contato:** POST > http://localhost:{nº da porta}/api/Contacts

**Alterar um contato:** PUT > http://localhost:{nº da porta}/api/Contacts/{id}

**Remover um contato:** DELETE > http://localhost:{nº da porta}/api/Contacts/{id}
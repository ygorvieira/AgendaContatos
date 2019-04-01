namespace AgendaWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Contacts : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Contacts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        DataNascimento = c.DateTime(nullable: false),
                        Sexo = c.String(),
                        Idade = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Contacts");
        }

        public static int Count()
        {
            throw new NotImplementedException();
        }
    }
}

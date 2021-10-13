namespace BookStore2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Version1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Autor",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 60),
                        Livro_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Livro", t => t.Livro_Id)
                .Index(t => t.Livro_Id);
            
            CreateTable(
                "dbo.Livro",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 60),
                        ISBN = c.String(nullable: false, maxLength: 32),
                        DatadeLancamento = c.DateTime(nullable: false),
                        CategoriaId = c.Int(nullable: false),
                        Autor_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categoria", t => t.CategoriaId, cascadeDelete: true)
                .ForeignKey("dbo.Autor", t => t.Autor_Id, cascadeDelete: true)
                .Index(t => t.CategoriaId)
                .Index(t => t.Autor_Id);
            
            CreateTable(
                "dbo.Categoria",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 60),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Livro", "Autor_Id", "dbo.Autor");
            DropForeignKey("dbo.Livro", "CategoriaId", "dbo.Categoria");
            DropForeignKey("dbo.Autor", "Livro_Id", "dbo.Livro");
            DropIndex("dbo.Livro", new[] { "Autor_Id" });
            DropIndex("dbo.Livro", new[] { "CategoriaId" });
            DropIndex("dbo.Autor", new[] { "Livro_Id" });
            DropTable("dbo.Categoria");
            DropTable("dbo.Livro");
            DropTable("dbo.Autor");
        }
    }
}

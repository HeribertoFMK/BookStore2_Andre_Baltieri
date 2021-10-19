namespace BookStore2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class version1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.LivroAutor",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 60),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Livro",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 60),
                        ISBN = c.String(nullable: false, maxLength: 32),
                        DatadeLancamento = c.DateTime(nullable: false),
                        CategoriaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categoria", t => t.CategoriaId, cascadeDelete: true)
                .Index(t => t.CategoriaId);
            
            CreateTable(
                "dbo.Categoria",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 60),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AutorLivroes",
                c => new
                    {
                        Autor_Id = c.Int(nullable: false),
                        Livro_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Autor_Id, t.Livro_Id })
                .ForeignKey("dbo.LivroAutor", t => t.Autor_Id, cascadeDelete: true)
                .ForeignKey("dbo.Livro", t => t.Livro_Id, cascadeDelete: true)
                .Index(t => t.Autor_Id)
                .Index(t => t.Livro_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AutorLivroes", "Livro_Id", "dbo.Livro");
            DropForeignKey("dbo.AutorLivroes", "Autor_Id", "dbo.LivroAutor");
            DropForeignKey("dbo.Livro", "CategoriaId", "dbo.Categoria");
            DropIndex("dbo.AutorLivroes", new[] { "Livro_Id" });
            DropIndex("dbo.AutorLivroes", new[] { "Autor_Id" });
            DropIndex("dbo.Livro", new[] { "CategoriaId" });
            DropTable("dbo.AutorLivroes");
            DropTable("dbo.Categoria");
            DropTable("dbo.Livro");
            DropTable("dbo.LivroAutor");
        }
    }
}

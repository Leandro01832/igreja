namespace business.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MudancaMinisterio : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Ministerio", "CodigoMinisterio", c => c.Int(nullable: false));
            AddColumn("dbo.MudancaEstado", "Codigo", c => c.Int(nullable: false));
            CreateIndex("dbo.Ministerio", "CodigoMinisterio", unique: true, name: "CODIGOMINISTERIO");
            DropColumn("dbo.MudancaEstado", "CodigoPessoa");
        }
        
        public override void Down()
        {
            AddColumn("dbo.MudancaEstado", "CodigoPessoa", c => c.Int(nullable: false));
            DropIndex("dbo.Ministerio", "CODIGOMINISTERIO");
            DropColumn("dbo.MudancaEstado", "Codigo");
            DropColumn("dbo.Ministerio", "CodigoMinisterio");
        }
    }
}

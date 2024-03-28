namespace OgrenciBilgiKayit.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateNotlar : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Notlar", "Dersler_DersID", "dbo.Dersler");
            DropIndex("dbo.Notlar", new[] { "Dersler_DersID" });
            DropColumn("dbo.Notlar", "Dersler_DersID");

            AddForeignKey("dbo.Notlar", "ders_id", "dbo.Dersler", "DersID", cascadeDelete: true);
            CreateIndex("dbo.Notlar", "ders_id");
        }

        public override void Down()
        {
            DropIndex("dbo.Notlar", new[] { "ders_id" });
            DropForeignKey("dbo.Notlar", "ders_id", "dbo.Dersler");

            /*AddColumn("dbo.Notlar", "Dersler_DersID", c => c.Int());
            CreateIndex("dbo.Notlar", "Dersler_DersID");
            AddForeignKey("dbo.Notlar", "Dersler_DersID", "dbo.Dersler", "ders_id");*/
        }
    }
}

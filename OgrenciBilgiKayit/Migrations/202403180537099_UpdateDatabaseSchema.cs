namespace OgrenciBilgiKayit.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class UpdateDatabaseSchema : DbMigration
    {
        public override void Up()
        {
            /*CreateTable(
                "dbo.Bolumler",
                c => new
                {
                    BolumID = c.Int(nullable: false, identity: true),
                    BolumAdi = c.String(),
                })
                .PrimaryKey(t => t.BolumID);

            CreateTable(
                "dbo.Dersler",
                c => new
                {
                    DersID = c.Int(nullable: false, identity: true),
                    BolumID = c.Int(nullable: false),
                    DersKodu = c.String(),
                    DersAdi = c.String(),
                    Kredi = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.DersID)
                .ForeignKey("dbo.Bolumler", t => t.BolumID, cascadeDelete: true)
                .Index(t => t.BolumID);

                CreateTable(
                    "dbo.Notlar",
                    c => new
                    {
                        ogrenci_no = c.Int(nullable: false),
                        ders_id = c.Int(nullable: false),
                        ara_sinav1 = c.Int(nullable: false),
                        ara_sinav2 = c.Int(nullable: false),
                        final = c.Int(nullable: false),
                        Dersler_DersID = c.Int(),
                    })
                    .PrimaryKey(t => new { t.ogrenci_no, t.ders_id })
                    .ForeignKey("dbo.Dersler", t => t.Dersler_DersID)
                    .ForeignKey("dbo.Ogrenciler", t => t.ogrenci_no, cascadeDelete: true)
                    .Index(t => t.ogrenci_no)
                    .Index(t => t.Dersler_DersID);

            CreateTable(
                "dbo.Ogrenciler",
                c => new
                {
                    ogrenci_no = c.Int(nullable: false, identity: true),
                    ad = c.String(),
                    soyad = c.String(),
                    bolum = c.String(),
                    sinif = c.Int(nullable: false),
                    dogum_tarihi = c.DateTime(nullable: false),
                    cinsiyet = c.String(),
                    kayit_tarihi = c.DateTime(nullable: false),
                })
                .PrimaryKey(t => t.ogrenci_no);

            CreateTable(
                "dbo.OgrenciAtamalari",
                c => new
                {
                    AtamaID = c.Int(nullable: false, identity: true),
                    ogrenci_no = c.Int(nullable: false),
                    DersID = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.AtamaID)
                .ForeignKey("dbo.Dersler", t => t.DersID, cascadeDelete: true)
                .ForeignKey("dbo.Ogrenciler", t => t.ogrenci_no, cascadeDelete: true)
                .Index(t => t.ogrenci_no)
                .Index(t => t.DersID);*/
            Sql("INSERT INTO dbo.Bolumler (BolumAdi) VALUES ('Bilgisayar Mühendisliği')");
            Sql("INSERT INTO dbo.Bolumler (BolumAdi) VALUES ('Elektrik Elektronik Mühendisliği')");
            Sql("INSERT INTO dbo.Bolumler (BolumAdi) VALUES ('Mekatronik Mühendisliği')");
            Sql("INSERT INTO dbo.Bolumler (BolumAdi) VALUES ('Makine Mühendsiliği')");
            Sql("INSERT INTO dbo.Bolumler (BolumAdi) VALUES ('Metalurji')");
            Sql("INSERT INTO dbo.Bolumler (BolumAdi) VALUES ('İnşaat Mühendisliği')");
            Sql("INSERT INTO dbo.Bolumler (BolumAdi) VALUES ('Yazılım Mühendisliği')");
        }

        public override void Down()
        {
            DropForeignKey("dbo.OgrenciAtamalari", "ogrenci_no", "dbo.Ogrenciler");
            DropForeignKey("dbo.OgrenciAtamalari", "DersID", "dbo.Dersler");
            DropForeignKey("dbo.Notlar", "ogrenci_no", "dbo.Ogrenciler");
            DropForeignKey("dbo.Notlar", "Dersler_DersID", "dbo.Dersler");
            DropForeignKey("dbo.Dersler", "BolumID", "dbo.Bolumler");
            DropIndex("dbo.OgrenciAtamalari", new[] { "DersID" });
            DropIndex("dbo.OgrenciAtamalari", new[] { "ogrenci_no" });
            DropIndex("dbo.Notlar", new[] { "Dersler_DersID" });
            DropIndex("dbo.Notlar", new[] { "ogrenci_no" });
            DropIndex("dbo.Dersler", new[] { "BolumID" });
            DropTable("dbo.OgrenciAtamalari");
            DropTable("dbo.Ogrenciler");
            DropTable("dbo.Notlar");
            DropTable("dbo.Dersler");
            DropTable("dbo.Bolumler");
        }
    }
}

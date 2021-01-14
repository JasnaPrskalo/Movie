namespace MovieShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class PopulateGenre : DbMigration
    {
        public override void Up()
        {
            Sql("SET IDENTITY_INSERT Genres ON");
            Sql("INSERT INTO Genres (Id, Name) VALUES (1, 'Comedy')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (2, 'Action')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (3, 'Thriller')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (4, 'Family')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (5, 'Romance')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (6, 'Drama')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (7, 'Adventure')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (8, 'Crime')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (9, 'Historical')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (10, 'Fantasy')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (11, 'Mystery')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (12, 'Philosophical')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (13, 'Saga')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (14, 'Science Fiction')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (15, 'CSocial')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (16, 'Western')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (17, 'Animation')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (18, 'Social')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (19, 'Musical')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (20, 'Horror')");

















        }

        public override void Down()
        {
        }
    }
}

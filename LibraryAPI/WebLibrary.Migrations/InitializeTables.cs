using FluentMigrator;

namespace WebLibrary.Migrations
{
    [Migration(2023082100)]
    public class InitializeTables : AutoReversingMigration
    {
        public override void Up()
        {
            Create.Table("User")
                .WithColumn("Id").AsGuid().NotNullable().PrimaryKey()
                .WithColumn("FirstName").AsString(40).NotNullable()
                .WithColumn("LastName").AsString(40).NotNullable()
                .WithColumn("MiddleName").AsString(20).NotNullable()
                .WithColumn("Login").AsString(20).NotNullable()
                .WithColumn("PasswordHash").AsString(100).NotNullable();

            Create.Table("Book")
                .WithColumn("Id").AsGuid().NotNullable().PrimaryKey()
                .WithColumn("Isbn").AsString(15).NotNullable()
                .WithColumn("Title").AsString(40).NotNullable()
                .WithColumn("Genre").AsString(20).NotNullable()
                .WithColumn("Description").AsString(300).NotNullable()
                .WithColumn("Author").AsString(50).NotNullable()
                .WithColumn("BorrowedTime").AsDateTime2().Nullable()
                .WithColumn("ReturnDueTime").AsDateTime2().Nullable();

            Create.Index("IX_Book_Isbn")
                .OnTable("Book")
                .WithOptions().Unique()
                .OnColumn("Isbn").Ascending();
        }
    }
}

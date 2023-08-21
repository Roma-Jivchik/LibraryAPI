using FluentMigrator;
using WebLibrary.Domain.Entities;

namespace WebLibrary.Migrations
{
    [Migration(2023082100)]
    internal class FillingTables : Migration
    {
        private readonly List<Book> books = new()
        {
            new Book
            {
                Id = new Guid(),
                Isbn = "13641874111",
                Title = "Harry Potter and the Goblet of Fire",
                Genre = "Fantasy",
                Description = "It follows Harry Potter, a wizard in his fourth year at Hogwarts School of Witchcraft and Wizardry, and the mystery surrounding the entry of Harry's name into the Triwizard Tournament, in which he is forced to compete. The book was published in the United Kingdom by Bloomsbury and in the United States by Scholastic.",
                Author = "J. K. Rowling",
                BorrowedTime = new DateTime(2023,8,21),
                ReturnDueTime = new DateTime(2023,8,25)
            },
            new Book
            {
                Id = new Guid(),
                Isbn = "15109173709",
                Title = "CLR VIA C#",
                Genre = "Information Techology",
                Description = "Dig deep and master the intricacies of the common language runtime, C#, and . NET development. Led by programming expert Jeffrey Richter, a longtime consultant to the Microsoft . NET team - you'll gain pragmatic insights for building robust, reliable, and responsive apps and components.",
                Author = "Jeffrey Richter",
                BorrowedTime = new DateTime(2023,7,29),
                ReturnDueTime = new DateTime(2023,8,16)
            }
        };

        private readonly User user = new()
        {
            Id = new Guid(),
            FirstName = "Roman",
            LastName = "Agaev",
            MiddleName = "Aleksandrovich",
            Login = "YaYoo",
            PasswordHash = "$FORMALHASH$f162679c5ae102e642851b5ba0fb5839a026cc321388e1b5"
        };

        public override void Down()
        {
            foreach (var book in books)
            {
                Delete.FromTable("Book").Row(book);
            }

            Delete.FromTable("User").Row(user);
        }

        public override void Up()
        {
            foreach (var book in books)
            {
                Insert.IntoTable("Book").Row(book);
            }

            Insert.IntoTable("User").Row(user);
        }
    }
}

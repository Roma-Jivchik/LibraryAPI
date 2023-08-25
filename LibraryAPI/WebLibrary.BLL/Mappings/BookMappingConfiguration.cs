using Mapster;
using WebLibrary.Domain.DTOs;
using WebLibrary.Domain.Entities;
using WebLibrary.Domain.Requests.Book;
using WebLibrary.Domain.Requests.BookRequests;

namespace WebLibrary.BLL.Mappings
{
    internal class BookMappingConfiguration : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<Book, BookDto>()
                .RequireDestinationMemberSource(true);

            config.NewConfig<CreateBookRequest, Book>()
                .RequireDestinationMemberSource(true)
                .Ignore(_ => _.Id);

            config.NewConfig<UpdateBookRequest, Book>()
                .RequireDestinationMemberSource(true);
        }
    }
}

using ElectronicLibrary.DataAccessLayer.Models;

namespace ElectronicLibrary.DataAccessLayer.Infrastructure.Interfaces
{
    public interface IUnitOfWork
    {
        IRepository<Book> BookRepository { get; }
        IRepository<Author> AuthorRepository { get; }
        IRepository<BookCatalogue> BookCatalogueRepository { get; }
        IRepository<Genre> GenreRepository { get; }
        IRepository<User> UserRepository { get; }
        IRepository<Vote> VoteRepository { get; }
        IRepository<Comment> CommentRepository { get; }
        void Save();
    }
}

namespace DAL.RepositoryPattern.Repositories
{
    using System;
    using DAL.Model;
    using DAL.RepositoryPattern.Interfaces;
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly LibraryContext libraryContext;

        private IRepository<Book> bookRepository;
        private IRepository<Author> authorRepository;
        private IRepository<BookCatalogue> bookCatalogueRepository;
        private IRepository<Genre> genreRepository;
        private IRepository<User> userRepository;
        private IRepository<Vote> voteRepository;
        private IRepository<Comment> commentRepository;

        public IRepository<Book> BookRepository => bookRepository ?? (bookRepository = new GenericRepository<Book>(libraryContext));
        public IRepository<Author> AuthorRepository => authorRepository ?? (authorRepository = new GenericRepository<Author>(libraryContext));
        public IRepository<BookCatalogue> BookCatalogueRepository => bookCatalogueRepository ?? (bookCatalogueRepository = new GenericRepository<BookCatalogue>(libraryContext));
        public IRepository<Genre> GenreRepository => genreRepository ?? (genreRepository = new GenericRepository<Genre>(libraryContext));
        public IRepository<User> UserRepository => userRepository ?? (userRepository = new GenericRepository<User>(libraryContext));
        public IRepository<Vote> VoteRepository => voteRepository ?? (voteRepository = new GenericRepository<Vote>(libraryContext));
        public IRepository<Comment> CommentRepository => commentRepository ?? (commentRepository = new GenericRepository<Comment>(libraryContext));

        public UnitOfWork(LibraryContext context)
        {
            libraryContext = context;
        }
        public void Save()
        {
            libraryContext.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    libraryContext.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}

using System;
using ElectronicLibrary.DataAccessLayer.Model;
using ElectronicLibrary.DataAccessLayer.RepositoryPattern.Interfaces;

namespace ElectronicLibrary.DataAccessLayer.RepositoryPattern.Repositories
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly LibraryContext _libraryContext;

        private IRepository<Book> _bookRepository;
        private IRepository<Author> _authorRepository;
        private IRepository<BookCatalogue> _bookCatalogueRepository;
        private IRepository<Genre> _genreRepository;
        private IRepository<User> _userRepository;
        private IRepository<Vote> _voteRepository;
        private IRepository<Comment> _commentRepository;

        public IRepository<Book> BookRepository => _bookRepository ?? (_bookRepository = new GenericRepository<Book>(_libraryContext));
        public IRepository<Author> AuthorRepository => _authorRepository ?? (_authorRepository = new GenericRepository<Author>(_libraryContext));
        public IRepository<BookCatalogue> BookCatalogueRepository => _bookCatalogueRepository ?? (_bookCatalogueRepository = new GenericRepository<BookCatalogue>(_libraryContext));
        public IRepository<Genre> GenreRepository => _genreRepository ?? (_genreRepository = new GenericRepository<Genre>(_libraryContext));
        public IRepository<User> UserRepository => _userRepository ?? (_userRepository = new GenericRepository<User>(_libraryContext));
        public IRepository<Vote> VoteRepository => _voteRepository ?? (_voteRepository = new GenericRepository<Vote>(_libraryContext));
        public IRepository<Comment> CommentRepository => _commentRepository ?? (_commentRepository = new GenericRepository<Comment>(_libraryContext));

        public UnitOfWork(LibraryContext context)
        {
            _libraryContext = context;
        }
        public void Save()
        {
            _libraryContext.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _libraryContext.Dispose();
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

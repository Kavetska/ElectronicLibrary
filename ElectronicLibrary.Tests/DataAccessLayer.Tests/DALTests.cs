using System;
using System.Collections.Generic;
using System.Linq;
using ElectronicLibrary.DataAccessLayer;
using ElectronicLibrary.DataAccessLayer.Infrastructure.Repositories;
using ElectronicLibrary.DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using NUnit.Framework;

namespace ElectronicLibrary.Tests.DataAccessLayer.Tests
{
    public class DALTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void User_IsAdded_ToInMemoryDatabase()
        {
            var serviceProvider = new ServiceCollection()
                .AddEntityFrameworkInMemoryDatabase()
                .BuildServiceProvider();

            var options = new DbContextOptionsBuilder<LibraryContext>()
                .UseInMemoryDatabase("Add_writes_to_database")
                .ConfigureWarnings(w => w.Ignore(InMemoryEventId.TransactionIgnoredWarning))
                .UseInternalServiceProvider(serviceProvider)
                .Options;

            using (var db = new LibraryContext(options))
            {
                UnitOfWork uow = new UnitOfWork(db);
                uow.UserRepository.Add(new User
                {
                    LoginName = "Anastasiia",
                    Password = "123452",
                    email = "nastia@gmail.com"
                });
                uow.Save();
            }

            using (var testDb = new LibraryContext(options))
            {
                UnitOfWork uow = new UnitOfWork(testDb);                
                var users = uow.UserRepository.Get().ToList();

                Assert.That(1, Is.EqualTo(users.Count()));
                Assert.That("Anastasiia", Is.EqualTo(users[0].LoginName));

            }
        }

        [Test]
        public void User_And_ConnectedBookCatalogue_AreAdded_ToInMemoryDatabase()
        {
            var serviceProvider = new ServiceCollection()
                .AddEntityFrameworkInMemoryDatabase()
                .BuildServiceProvider();

            var options = new DbContextOptionsBuilder<LibraryContext>()
                .UseInMemoryDatabase("Add_writes_to_database")
                .ConfigureWarnings(w => w.Ignore(InMemoryEventId.TransactionIgnoredWarning))
                .UseInternalServiceProvider(serviceProvider)
                .Options;

            using (var db = new LibraryContext(options))
            {
                UnitOfWork uow = new UnitOfWork(db);
                uow.UserRepository.Add(new User
                {
                    LoginName = "Anastasiia2",
                    Password = "123452",
                    email = "nastia2@gmail.com"
                });
                uow.Save();

                var userForBookCatalogue = uow.UserRepository.Get().ToList().FirstOrDefault();
                uow.BookCatalogueRepository.Add(new BookCatalogue
                {
                    Title = "For future reading",
                    Description = "Fill later",
                    User = userForBookCatalogue
                });
                uow.Save();
            }

            using (var testDb = new LibraryContext(options))
            {
                UnitOfWork uow = new UnitOfWork(testDb);
                var users = uow.UserRepository.Get().ToList();
                var catalogues = uow.BookCatalogueRepository.Get().ToList();

                Assert.That(1, Is.EqualTo(users.Count()));
                Assert.That("Anastasiia2", Is.EqualTo(users[0].LoginName));

                Assert.That(1, Is.EqualTo(catalogues.Count));
                Assert.That("For future reading", Is.EqualTo(catalogues[0].Title));
                Assert.That(users[0].Id, Is.EqualTo(catalogues[0].UserId));
            }
        }

    }
}

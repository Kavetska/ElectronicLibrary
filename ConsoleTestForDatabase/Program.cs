using System;
using System.IO;
using System.Linq;
using ElectronicLibrary.DataAccessLayer;
using ElectronicLibrary.DataAccessLayer.Infrastructure.Repositories;
using ElectronicLibrary.DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ConsoleTestForDatabase
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("appsettings.json");
            var config = builder.Build();
            string connectionString = config.GetConnectionString("DefaultConnection");

            var optionsBuilder = new DbContextOptionsBuilder<LibraryContext>();
            var options = optionsBuilder
                .UseSqlServer(connectionString)
                .Options;

            var user = new User
            {
                Id = 1,
                LoginName = "Anastasiia",
                Password = "12345",
                email = "nastia@gmail.com"
            };
            using (var db = new LibraryContext(options))
            {
                UnitOfWork uow = new UnitOfWork(db);
                uow.UserRepository.Add(new User
                {
                    //Id = 1,
                    LoginName = "Anastasiia2",
                    Password = "123452",
                    email = "nastia2@gmail.com"
                });

                uow.Save();
            }

            using (var testDb = new LibraryContext(options))
            {
                UnitOfWork uow = new UnitOfWork(testDb);
                //Func<User, bool> query = user1 => user1.Id == 1;
                var users = uow.UserRepository.Get();
                foreach (var u in users)
                {
                    Console.WriteLine(u.Id);
                    Console.WriteLine(u.LoginName);
                }
            }
            Console.ReadKey();
        }
    }
}

using System;
using System.Data.Common;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace WebApplication1
{
    public class MyDbContext : DbContext
    {
        private static SqliteConnection _connection;
        public DbSet<BlogPost> BlogPosts { get; set; }
        public DbSet<BlogComment> BlogComments { get; set; }
        public string DbPath { get; private set; }
        //public MyDbContext(ILoggerFactory loggerFactory) : base(new DbContextOptionsBuilder<MyDbContext>()
        //    .UseSqlite(CreateInMemoryDatabase())
        //    .UseLoggerFactory(loggerFactory)
        //    .Options)
        //{
        //}

        public MyDbContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = $"{path}{System.IO.Path.DirectorySeparatorChar}blogging.db";
        }

        // The following configures EF to create a Sqlite database file in the
        // special "local" folder for your platform.
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={DbPath}");

        //private static DbConnection CreateInMemoryDatabase()
        //{
        //    _connection = new SqliteConnection("Filename=:memory:");
        //    _connection.Open();
        //    return _connection;
        //}

        //public override void Dispose() => _connection.Dispose();
    }
}
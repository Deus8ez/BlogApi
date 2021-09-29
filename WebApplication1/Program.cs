using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            var loggerFactory = LoggerFactory.Create(builder => { builder.AddConsole(); });

            var context = new MyDbContext();
            context.Database.EnsureCreated();
            InitializeData(context);

            CreateHostBuilder(args).Build().Run();
        }


        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

        private static void InitializeData(MyDbContext context)
        {
            if (!context.BlogPosts.Any())
            {
                context.BlogPosts.Add(new BlogPost("Post1")
                {
                    Comments = new List<BlogComment>()
                {
                    new BlogComment("1", new DateTime(2020, 3, 4)),
                    new BlogComment("2", new DateTime(2020, 3, 1)),
                }
                });
                context.BlogPosts.Add(new BlogPost("Post2")
                {
                    Comments = new List<BlogComment>()
                {
                    new BlogComment("3", new DateTime(2020, 3, 5)),
                    new BlogComment("4", new DateTime(2020, 3, 6)),
                }
                });
                context.BlogPosts.Add(new BlogPost("Post3")
                {
                    Comments = new List<BlogComment>()
                {
                    new BlogComment("5", new DateTime(2020, 2, 7)),
                    new BlogComment("6", new DateTime(2020, 2, 9)),
                    new BlogComment("7", new DateTime(2020, 2, 8)),
                }
                });
                context.SaveChanges();
            }
        }
    }
}
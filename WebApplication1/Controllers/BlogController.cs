using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models.ViewModels;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BlogController : ControllerBase
    {

        private readonly ILogger<BlogController> _logger;
        private readonly MyDbContext _context;
        public BlogController(ILogger<BlogController> logger, MyDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public IEnumerable<BlogPost> Get()
        {
            var data = _context.BlogPosts.Include(x => x.Comments.OrderByDescending(p => p.CreatedDate).Take(1)).ToList();

            return data;          
        }

        [HttpGet("{id}")]
        public IEnumerable<BlogPost> GetById(int id)
        {
            var data = _context.BlogPosts.Where(x => x.Id == id).Include(x => x.Comments.OrderByDescending(p => p.CreatedDate).Take(1)).ToList();

            return data;
        }

        [HttpGet("allComments/{id}")]
        public IEnumerable<BlogPost> GetAllCommentsById(int id)
        {
            var data = _context.BlogPosts.Where(x => x.Id == id).Include(x => x.Comments.OrderByDescending(p => p.CreatedDate)).ToList();

            return data;
        }
    }
}

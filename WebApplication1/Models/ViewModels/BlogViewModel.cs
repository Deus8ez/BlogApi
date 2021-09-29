using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models.ViewModels
{
    public class BlogViewModel
    {
        public BlogPost BlogPost { get; set; }
        public BlogComment BlogComment { get; set; }
    }
}

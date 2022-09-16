using ExploreCalifornia.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExploreCalifornia.Controllers
{
    [Route("blog")]
    public class BlogController : Controller
    {
        private readonly BlogDataContext _db;
        public BlogController(BlogDataContext db)
        {
            _db = db;
        }
        [Route("")]
        public IActionResult Index(int page = 0)
        {
            var pageSize = 2;
            var totalPosts = _db.Posts.Count();
            var totalPages = totalPosts / pageSize;
            var previousPage = page - 1;
            var nextPage = page + 1;

            ViewBag.PreviousPage = previousPage;
            ViewBag.HasPreviousPage = previousPage >= 0;
            ViewBag.NextPage = nextPage;
            ViewBag.HasNextPage = nextPage < totalPages;

            var posts =
                _db.Posts
                    .OrderByDescending(x => x.Posted)
                    .Skip(pageSize * page)
                    .Take(pageSize)
                    .ToArray();

            //to check if it's ajax request 
            if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
                return PartialView(posts);

            return View(posts);
        }
        /*public IActionResult Index()
        {            
            var posts = _db.Posts.OrderByDescending(x=>x.Posted).Take(5).ToArray();
            return View(posts);
        }*/

        [Route("{year:min(2000)}/{month:range(1,12)}/{key}")]
        //[Route("Post")]
        public IActionResult Post(int year, int month, string key)
        {

            /*
             var post = new Post
            {
                Title = "My blog post",
                Posted = DateTime.Now,
                Author = "Jess Chedwick",
                Body = "This is a great post, don't you think that?"
            };
             */
            var post = _db.Posts.FirstOrDefault(x => x.Key == key);
            return View(post);
        }

        [Authorize]
        [Route("create")]
        public IActionResult Create()
        { return View(); }

        [Authorize]
        [HttpPost, Route("create")]
        public IActionResult Create(Post post)
        {
            if (!ModelState.IsValid)
                return View();

            post.Author = User.Identity.Name;
            post.Posted = DateTime.Now;

            _db.Posts.Add(post);
            _db.SaveChanges();

            return RedirectToAction("Post", "Blog",
                    new { year = post.Posted.Year, month = post.Posted.Month, key = post.Key }
            
                ); 
        }

        /*
         public class CreatePostRequest
        {
            public string Title { get; set; }
            public string Body  { get; set; }
        }
         */
    }
}

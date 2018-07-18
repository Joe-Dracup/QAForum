using QAForum.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QAForum.Controllers
{
    public class PostController : Controller
    {
        private IForumRepository forumRepository = null;

        public PostController() : this(new SQLForumRepository())
        {

        }

        public PostController(IForumRepository forumRepository)
        {
            this.forumRepository = forumRepository;
        }

        // GET: Post
        [OutputCache(Duration = 10)]
        public ActionResult Index()
        {
            var posts = forumRepository.GetAllPosts();
            ViewBag.Message = "QA Forums list[Posts]";
            return View(posts);
        }

        // GET: Post/Details/5
        public ActionResult Details(int id)
        {
            var post = forumRepository.GetPostByID(id);
            ViewBag.Message = "Thread detail";
            return View(post);
        }

        // GET: Post/Create
        public ActionResult Create()
        {
            Post post = new Post();
            return View(post);
        }

        // POST: Post/Create
        [HttpPost]
        public ActionResult Create(Post post)
        {
            try
            {
                // TODO: Add insert logic here
                forumRepository.AddPost(post);
                return RedirectToAction("Index");
            }
            catch
            {
                return View(post);
            }
        }

        // GET: Post/Edit/5
        public ActionResult Edit(int id)
        {
            Post post = forumRepository.GetPostByID(id);
            return View(post);
        }

        // POST: Post/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Post post)
        {
            try
            {
                // TODO: Add update logic here
                forumRepository.UpdatePost(post);

                return RedirectToAction("Index");
            }
            catch
            {
                return View(post);
            }
        }

        // GET: Post/Delete/5
        public ActionResult Delete(int id)
        {
            Post post = forumRepository.GetPostByID(id);
            return View();
        }

        // POST: Post/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            Post post = forumRepository.GetPostByID(id);
            try
            {
                // TODO: Add delete logic here
                forumRepository.DeletePost(post);
                return RedirectToAction("Index");
            }
            catch
            {
                return View(post);
            }
        }
    }
}

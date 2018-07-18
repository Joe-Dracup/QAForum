using QAForum.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QAForum.Controllers
{
    public class ThreadController : Controller
    {
        private IForumRepository forumRepository = null;

        public ThreadController() : this(new SQLForumRepository())
        {

        }

        public ThreadController(IForumRepository forumRepository)
        {
            this.forumRepository = forumRepository;
        }

        // GET: Thread
        [OutputCache(Duration = 10)]
        public ActionResult Index()
        {
            var threads = forumRepository.GetAllThreads();
            ViewBag.Message = "QA Forums list[Threads]";
            return View(threads);
        }

        public ActionResult GetPostsForThread(List<Post> posts)
        {
            if(posts.Count >  0 && posts != null)
            {
                return PartialView("~/Views/Post/PartialPostList.cshtml", posts);
            }
            else
            {
                ContentResult cvr = new ContentResult();
                cvr.Content = "There are no posts in this thread";
                return cvr;
            }

        }

        // GET: Thread/Details/5
        public ActionResult Details(int id)
        {
            var thread = forumRepository.GetThreadByID(id);
            ViewBag.Message = "Thread detail";
            ViewBag.Post = forumRepository.GetPostsByThread(id);
            return View(thread);
        }

        // GET: Thread/Create
        public ActionResult Create()
        {
            Thread thread = new Thread();

            return View(thread);
        }

        // POST: Thread/Create
        [HttpPost]
        public ActionResult Create(Thread thread)
        {
            try
            {
                // TODO: Add insert logic here
                forumRepository.AddThread(thread);

                return RedirectToAction("Index");
            }
            catch
            {
                return View(thread);
            }
        }

        // GET: Thread/Edit/5
        public ActionResult Edit(int id)
        {
            Thread thread = forumRepository.GetThreadByID(id);

            return View(thread);
        }

        // POST: Thread/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Thread thread)
        {
            try
            {
                // TODO: Add update logic here
                forumRepository.UpdateThread(thread);

                return RedirectToAction("Index");
            }
            catch
            {
                return View(thread);
            }
        }

        // GET: Thread/Delete/5
        public ActionResult Delete(int id)
        {
            Thread thread = forumRepository.GetThreadByID(id);
            return View(thread);
        }

        // POST: Thread/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            Thread thread = forumRepository.GetThreadByID(id);
            try
            {
                // TODO: Add delete logic here
                forumRepository.DeleteThread(thread);

                return RedirectToAction("Index");
            }
            catch
            {
                return View(thread);
            }
        }
    }
}

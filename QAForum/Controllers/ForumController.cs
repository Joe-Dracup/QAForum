using QAForum.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QAForum.Controllers
{
    public class ForumController : Controller
    {
        private IForumRepository forumRepository = null;

        public ForumController() : this(new SQLForumRepository())
        {

        }

        public ForumController(IForumRepository forumRepository)
        {
            this.forumRepository = forumRepository;
        }

        // GET: Forum
        [OutputCache(Duration = 10)]
        public ActionResult Index()
        {
            IEnumerable<Forum> forums = forumRepository.GetAllForums();

            ViewBag.Message = "QA Forums List";

            return View(forums);
        }

        // GET: Forum/Details/5
        public ActionResult Details(int id)
        {
            Forum forum = forumRepository.GetForumByID(id);

            ViewBag.Threads = forumRepository.GetThreadsByForum(id);

            return View(forum);
        }

        // GET: Forum/Create
        public ActionResult Create()
        {
            Forum forum = new Forum();

            return View(forum);
        }

        // POST: Forum/Create
        [HttpPost]
        public ActionResult Create(Forum forum)
        {
            try
            {
                // TODO: Add insert logic here
                forumRepository.AddForum(forum);

                return RedirectToAction("Index");
            }
            catch
            {
                return View(forum);
            }
        }

        // GET: Forum/Edit/5
        public ActionResult Edit(int id)
        {
            Forum forum = forumRepository.GetForumByID(id);
            
            return View(forum);
        }

        // POST: Forum/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Forum forum)
        {
            try
            {
                // TODO: Add update logic here
                forumRepository.UpdateForum(forum);

                return RedirectToAction("Index");
            }
            catch
            {
                return View(forum);
            }
        }

        // GET: Forum/Delete/5
        public ActionResult Delete(int id)
        {
            Forum forum = forumRepository.GetForumByID(id);
            return View(forum);
        }

        // POST: Forum/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            Forum forum = forumRepository.GetForumByID(id);
            try
            {
                // TODO: Add delete logic here
                forumRepository.DeleteForum(forum);

                return RedirectToAction("Index");
            }
            catch
            {
                return View(forum);
            }
        }
    }
}

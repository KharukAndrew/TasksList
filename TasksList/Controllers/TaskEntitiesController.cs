using System;
using System.Net;
using System.Web.Mvc;
using TasksList.Models;
using TasksList.Repository;

namespace TasksList.Controllers
{
    public class TaskEntitiesController : Controller
    {
        private readonly ITasksRepository _repository;

        public TaskEntitiesController(ITasksRepository repo)
        {
            _repository = repo;
        }

        // GET: TaskEntities
        public ActionResult Index()
        {
            try
            {
                return View(_repository.GetAll());
            }
            catch (Exception ex)
            {
                return View("~/Views/Shared/Error.cshtml", ex);
            }
        }

        // GET: TaskEntities/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            TaskEntity task = null;
            try
            {
                task = _repository.GetById(id.Value);
            }
            catch (Exception ex)
            {
                return View("~/Views/Shared/Error.cshtml", ex);
            }

            if (task == null)
            {
                return HttpNotFound();
            }
            return View(task);
        }

        // GET: TaskEntities/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TaskEntities/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Date,Header,Text,IsDone")] TaskEntity task)
        {
            if (!ModelState.IsValid)
                return View(task);

            try
            {
                _repository.Create(task);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View("~/Views/Shared/Error.cshtml", ex);
            }
        }

        // GET: TaskEntities/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            TaskEntity task = null;

            try
            {
                task = _repository.GetById(id.Value);
            }
            catch (Exception ex)
            {
                return View("~/Views/Shared/Error.cshtml", ex);
            }

            if (task == null)
            {
                return HttpNotFound();
            }
            return View(task);
        }

        // POST: TaskEntities/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Date,Header,Text,IsDone")] TaskEntity task)
        {
            if (!ModelState.IsValid)
                return View(task);

            try
            {
                _repository.Update(task);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View("~/Views/Shared/Error.cshtml", ex);
            }
        }

        // GET: TaskEntities/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TaskEntity task = null;

            try
            {
                task = _repository.GetById(id.Value);
            }
            catch (Exception ex)
            {
                return View("~/Views/Shared/Error.cshtml", ex);
            }

            if (task == null)
            {
                return HttpNotFound();
            }
            return View(task);
        }

        // POST: TaskEntities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                _repository.Delete(id);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View("~/Views/Shared/Error.cshtml", ex);
            }
        }
    }
}

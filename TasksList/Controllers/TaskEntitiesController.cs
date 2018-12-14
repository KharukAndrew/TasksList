using System;
using System.Net;
using System.Web.Mvc;
using TasksList.Models;
using TasksList.Repository;
using PagedList;
using PagedList.Mvc;

namespace TasksList.Controllers
{
    public class TaskEntitiesController : Controller
    {
        private readonly ITasksRepository _repository;
        private const int pageSize = 3;

        public TaskEntitiesController(ITasksRepository repo)
        {
            _repository = repo;
        }

        // GET: TaskEntities
        public ActionResult Index(int? page)
        {
            try
            {
                int pageNumber = (page ?? 1);
                return View(_repository.GetAll().ToPagedList(pageNumber, pageSize));
            }
            catch (Exception ex)
            {
                return View("~/Views/Shared/Error.cshtml", ex);
            }
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

                int returnPageNumber = GetPageNumberForReturn(task.Id);

                return RedirectToAction("Index", "TaskEntities", new { page = returnPageNumber });
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

                ViewBag.Page = GetPageNumberForReturn(task.Id);
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

                int returnPageNumber = GetPageNumberForReturn(task.Id);

                return RedirectToAction("Index", "TaskEntities", new { page = returnPageNumber });
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

        private int GetPageNumberForReturn(int id)
        {
            var list = _repository.GetAll();

            int numberTask = 0;

            foreach (var item in list)
            {
                numberTask++;
                if (item.Id == id)
                    break;
            }

            double page = (double)numberTask / pageSize;

            if ((page - (int)page) == 0)       
                return (int)page;

            return (int)page + 1;
        }

    }
}

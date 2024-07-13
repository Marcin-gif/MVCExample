using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVCExample.Models;
using MVCExample.Repositories;

namespace MVCExample.Controllers
{
    public class TaskController : Controller
    {
        private readonly ITaskRepository _taskRepository;

        public TaskController(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }
        // GET: TaskController
        public ActionResult Index()
        {
            return View(_taskRepository.GetAll());
        }

        // GET: TaskController/Details/5
        public ActionResult Details(int id)
        {
            return View(_taskRepository.Get(id));
        }

        // GET: TaskController/Create
        public ActionResult Create()
        {
            return View(new TaskModel());
        }

        // POST: TaskController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TaskModel taskModel)
        {
            _taskRepository.Add(taskModel);    
            return RedirectToAction(nameof(Index));
            
        }

        // GET: TaskController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_taskRepository.Get(id));
        }

        // POST: TaskController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, TaskModel taskModel)
        {
            _taskRepository.Update(id, taskModel);
            return RedirectToAction(nameof(Index));     
        }

        // GET: TaskController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_taskRepository.Get(id));
        }

        // POST: TaskController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, TaskModel taskModel)
        {
            _taskRepository.Delete(id);
           return RedirectToAction(nameof(Index));
            
        }
        // GET: Task/Done
        public ActionResult Done(int id)
        { 
            TaskModel task = _taskRepository.Get(id);
            task.Done = true;
            _taskRepository.Update(id,task);

            return RedirectToAction(nameof(Index));
        }
    }
}

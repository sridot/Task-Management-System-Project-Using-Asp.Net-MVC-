using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using TaskManagementSystem.ViewModel;
using TaskManagementSystem.BLL;

namespace TaskManagementSystem.Controllers
{
    [Authorize(Roles ="Admin, User")]
    public class TaskController : Controller
    {
        private readonly TaskServices _taskServices;
        public TaskController()
        {
            _taskServices = new TaskServices();
        }

        // GET: Task
        public ActionResult TaskList()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account");
            }
            else
            {
                List<TaskViewModel> taskList = _taskServices.GetAllTasksByUsername(User.Identity.Name);                
                return View(taskList);
            }
        }

        public ActionResult CreateTask()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account");
            }
            else
            {

                return View();
            }
        }

        [HttpPost]
        public ActionResult CreateTask(TaskViewModel task)
        {
            if (ModelState.IsValid)
            {
                task.UserName = User.Identity.Name;
                task.Status = 1;
                task.Date = DateTime.Now;
                bool isVerify = _taskServices.CreateTask(task);
                if (isVerify)
                    return RedirectToAction("TaskList");
                task.ErrorMessage = "Task Creation Failed";
            }

            return View(task);
        }

        public ActionResult Edit(int? taskId)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account");
            }
            else
            {
                if (taskId != 0 && taskId!=null)
                {
                    TaskViewModel _task = _taskServices.GetTaskById(int.Parse(taskId.ToString()));
                    ViewBag.StatusList = TaskStatusList();
                    return View(_task);
                }
                else
                {
                    return RedirectToAction("TaskList");
                }
            }
        }

        [HttpPost]
        [ActionName("Edit")]
        public ActionResult Edit_Post(TaskViewModel task)
        {
            if(ModelState.IsValid)
            {
               bool isUpdated= _taskServices.UpdateTask(task);
                if(isUpdated)
                {
                    return RedirectToAction("TaskList");
                }
                else
                {
                    return View(task);
                }
            }
            else
            {
                return View(task);
            }
        }

        public IEnumerable<SelectListItem> TaskStatusList()
        {
            return new List<SelectListItem>()
            {
                new SelectListItem(){Text="To Do", Value="1"},
                new SelectListItem(){Text="InProgress", Value="2"},
                new SelectListItem(){Text="Done", Value="3"},
                new SelectListItem(){Text="Abort", Value="4"}
            };
        }



    }
}
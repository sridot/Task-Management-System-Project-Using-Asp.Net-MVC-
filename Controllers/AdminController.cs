using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TaskManagementSystem.BLL;
using TaskManagementSystem.ViewModel;

namespace TaskManagementSystem.Controllers
{
    [Authorize(Roles ="Admin")]
    public class AdminController : Controller
    {
        private readonly TaskServices _taskServices;
        private readonly TaskController _taskController;
        public AdminController()
        {
            _taskServices = new TaskServices();
            _taskController = new TaskController();
        }

        // GET: Admin
        public ActionResult TaskList()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account");
            }
            else
            {
                List<TaskViewModel> taskList = _taskServices.GetAllTasks();
                return View(taskList);
            }
        }


        public ActionResult Delete(int? taskId)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account");
            }
            else
            {
                if (taskId != 0 && taskId != null)
                {
                    TaskViewModel _task = _taskServices.GetTaskById(int.Parse(taskId.ToString()));
                    ViewBag.StatusList = _taskController.TaskStatusList();
                    return View(_task);
                }
                else
                {
                    return RedirectToAction("TaskList");
                }
            }
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult Delete_Post(TaskViewModel task)
        {

            if (task.TaskId != 0)
            {
                bool isUpdated = _taskServices.DeleteTask(task.TaskId);
                if (isUpdated)
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

    }
}
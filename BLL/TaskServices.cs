using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Security;
using TaskManagementSystem.DLL;
using TaskManagementSystem.Models;
using TaskManagementSystem.ViewModel;

namespace TaskManagementSystem.BLL
{
    public class TaskServices
    {
        public readonly TaskRepository taskRepository;
        public TaskServices()
        {
            taskRepository = new TaskRepository();
        }

        // Get All Task
        public List<TaskViewModel> GetAllTasks()
        {
            return taskRepository.GetAllTasks().Select(x => new TaskViewModel()
            {
                TaskId = x.TaskId,
                Title = x.Title,
                Description = x.Description,
                Date = x.DueDate,
                Status = x.Status,
                UserId = x.UserId,
                UserName = x.User.Username
            }).ToList();
        }

        // Get Task List with Username
        public List<TaskViewModel> GetAllTasksByUsername(string username)
        {
            return taskRepository.GetAllTasks(username)
                                 .Select(x => new TaskViewModel()
                                    {
                                        TaskId = x.TaskId,
                                        Title = x.Title,
                                        Description = x.Description,
                                        Date = x.DueDate,
                                        Status = x.Status,
                                        UserId = x.UserId
                                    }).ToList();
        }


        // Get Task
        public TaskViewModel GetTaskById(int taskId)
        {
            Tasks _task = taskRepository.GetTask(taskId);
            if (_task != null)
            {
                TaskViewModel _taskViewModel = new TaskViewModel()
                {
                    TaskId = _task.TaskId,
                    Title = _task.Title,
                    Description = _task.Description,
                    Date = _task.DueDate,
                    Status = _task.Status,
                    UserId = _task.UserId
                };
                return _taskViewModel;
            }
            else
            {
                return null;
            }
        }

        // Create New Task
        public bool CreateTask(TaskViewModel taskViewModel)
        {
            Tasks task = new Tasks()
            {
                Title= taskViewModel.Title,
                Description=taskViewModel.Description,
                DueDate=taskViewModel.Date,
                Status=taskViewModel.Status,
                User=new Users() { Username=taskViewModel.UserName },
            };
            int i = taskRepository.CreateTask(task);
            if(i>0)
                return true;
            return false;
        }

        // Update Task
        public bool UpdateTask(TaskViewModel taskViewModel)
        {
            Tasks _task = new Tasks()
            {
              TaskId=taskViewModel.TaskId,
              Title = taskViewModel.Title,
              Description = taskViewModel.Description,
              DueDate=DateTime.Now,
              Status = taskViewModel.Status,
              UserId = taskViewModel.UserId
            };
            int i = taskRepository.UpdateTask(_task);
            if (i > 0)
                return true;
            return false;
        }


        // Delete Task
        public bool DeleteTask(int taskId)
        {
            int i = taskRepository.DeleteTask(taskId);
            if (i > 0)
                return true;
            return false;
        }

    }
}
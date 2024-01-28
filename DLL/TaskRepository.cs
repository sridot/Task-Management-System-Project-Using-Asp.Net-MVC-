using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TaskManagementSystem.Models;
using TaskManagementSystem.Context;
using System.Data.Entity;
using System.Threading.Tasks;

namespace TaskManagementSystem.DLL
{
    public class TaskRepository
    {
        private readonly DBContext dbContext;
        public TaskRepository()
        {
            dbContext = new DBContext();
        }

        //Get All Task
        public List<Tasks> GetAllTasks()
        {
            var userList = dbContext.Users.ToList();
            return dbContext.Tasks.ToList().Join(userList, t => t.UserId, u => u.UserId, (t, u) => new { t, u })
                                  .Select(x => new Tasks()
                                  {
                                      TaskId = x.t.TaskId,
                                      Title = x.t.Title,
                                      Description = x.t.Description,
                                      DueDate = x.t.DueDate,
                                      Status = x.t.Status,
                                      UserId = x.t.UserId,
                                      User = new Users()
                                      {
                                          Username = x.u.Username
                                      }

                                  }).ToList();
        }

        // Get All Task throudh user id
        public List<Tasks> GetAllTasks(int userId)
        {
            return dbContext.Tasks.Where(x=>x.UserId == userId).ToList();
        }

        // Get All Task through username
        public List<Tasks> GetAllTasks(string username)
        {
            var _user = dbContext.Users.ToList().SingleOrDefault(s=>s.Username== username);
            if (_user == null)
                return new List<Tasks>();
            return dbContext.Tasks.Where(x => x.UserId == _user.UserId).ToList();

        }

        // Get Single Task
        public Tasks GetTask(int taskId)
        {
            return dbContext.Tasks.SingleOrDefault(x=>x.TaskId == taskId);
        }

        // Create New Task
        public int CreateTask(Tasks task)
        {
           task.UserId = task.UserId=dbContext.Users.SingleOrDefault(x=>x.Username==task.User.Username).UserId;
           task.User = null;
           dbContext.Tasks.Add(task);
           return dbContext.SaveChanges();
        }

        // Update
        public int UpdateTask(Tasks task) 
        {
            //var _task = GetTask(task.TaskId);
            //_task.User = new Users();
            //_task.User.Roles = new Roles();
            //if (_task != null)
            //{
            //    _task.Title = task.Title;
            //    _task.Description = task.Description;
            //    _task.DueDate = task.DueDate;
            //    _task.Status = task.Status;
            //}
            dbContext.Entry(task).State=EntityState.Modified;
            return dbContext.SaveChanges();            
        }

        // Delete
        public int DeleteTask(int taskId)
        {
            var _task=GetTask(taskId);
            dbContext.Entry(_task).State=EntityState.Deleted;
            return dbContext.SaveChanges();
        }

    }
}
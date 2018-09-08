﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using TaskManager.BusinessEntities;
using TaskManager.DataModel;
using AutoMapper; // TODO - use me
using System.Data.Entity;

namespace TaskManager.BusinessServices
{
    public class TaskServices : ITaskServices
    {
        TaskManagerContext _context;
        IMapper _mapper;
        public static TaskServices CreateService()
        {
            return new TaskServices(new TaskManagerContext());
        }
        public TaskServices(TaskManagerContext context)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Task, TaskDTO>().ReverseMap());
            
            _mapper = config.CreateMapper();               
      
            _context = context;
        }
        public bool AddTask(TaskDTO task)
        {
            Task taskData = _mapper.Map<Task>(task);
            _context.tasks.Add(taskData);
            _context.SaveChanges();
            return false;
        }
        public List<TaskDTO> GetTasks(FilterDTO filter)
        {
            // TODO use filter with linq
            var data = _context.tasks.ToList<Task>();
            if (data == null)
            {
                throw new ApplicationException("No value read from database");
            }
            var list=  _mapper.Map<List<Task>, List<TaskDTO>>(data);

            return list;
        }
        public List<TaskDTO> GetTasks()
        {            
            var data = _context.tasks.Where(t => t.IsCompleted == false).ToList<Task>();
            var list = _mapper.Map<List<Task>, List<TaskDTO>>(data);

            return list;
        }
        public bool UpdateTask(TaskDTO changedTask)
        {
            Task taskData = _mapper.Map<Task>(changedTask);

            var entity = _context.tasks.Find(changedTask.TaskId);
            if(entity == null)
            {
                return false;
            }
            var task = _mapper.Map<Task>(changedTask);

            _context.Entry(entity).CurrentValues.SetValues(changedTask);
            _context.SaveChanges();

            return true;

           /* var task = _context.tasks.SingleOrDefault(t => t.TaskId == changedTask.TaskId);
            if(task !=null)
            {
                task = _mapper.Map<Task>(changedTask);

                _context.Entry(task).State = EntityState.Modified;

                _context.tasks.Attach(task);
                
                
                _context.SaveChanges();
                return true;
            }
            return false;*/
        }
        public bool CompleteTask(string taskName)
        {

            var task = _context.tasks.SingleOrDefault(t => t.TaskName == taskName);
            if (task != null)
            {
                task.IsCompleted = true;
                _context.SaveChanges();
                return true;
            }
            return false;

        }
        public bool DeleteTask(string taskName)
        {

            var task = _context.tasks.SingleOrDefault(t => t.TaskName == taskName);
            if (task != null)
            {
                _context.Entry(task).State = EntityState.Deleted;
                _context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}

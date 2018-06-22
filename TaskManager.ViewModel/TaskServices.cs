using System;
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
        TaskMangagerContext _context;
        IMapper _mapper;
        TaskServices()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Task, TaskDTO>().ReverseMap());
            
            _mapper = config.CreateMapper();               
      
            _context = new TaskMangagerContext();
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
            var list=  _mapper.Map<List<Task>, List<TaskDTO>>(data);

            return list;
        }
        public bool UpdateTask(TaskDTO newtask)
        {
            Task taskData = _mapper.Map<Task>(newtask);

            var task = _context.tasks.SingleOrDefault(t => t.TaskName == newtask.TaskName);
            if(task !=null)
            {
                task = _mapper.Map<Task>(newtask);
                _context.SaveChanges();
                return true;
            }
            return false;
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

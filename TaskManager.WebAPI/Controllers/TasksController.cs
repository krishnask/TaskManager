using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TaskManager.BusinessServices;
using TaskManager.BusinessEntities;

namespace TaskManager.WebAPI.Controllers
{
    public class TasksController : ApiController
    {

        ITaskServices _repository;
        public TasksController()
        {
            _repository = new TaskServices();
        }
        // GET api/tasks
        public IHttpActionResult Get(FilterDTO filter)
        {
            List<TaskDTO> tasks = _repository.GetTasks(filter);

            return Ok(tasks);
        }
       

        // GET api/tasks/5
       /* public IHttpActionResult Get(string taskName)
        {
            TaskDTO task = _repository.
            return Ok();
        }*/

        // POST api/tasks
        // post us used to create new 
        public IHttpActionResult Post(TaskDTO task)
        {
            bool ret = _repository.AddTask(task);
            if(ret == true)
            {
                return Ok();
            }
            return NotFound();
        }

        // PUT api/tasks/5
        // put is used to update
        public IHttpActionResult Put(string taskNameKey, [FromBody]TaskDTO task)
        {
            bool ret = _repository.UpdateTask(taskNameKey, task);

            if (ret == true)
            {
                return Ok();
            }
            return NotFound();
        }

        // DELETE api/tasks/5
        public IHttpActionResult Delete(string taskName)
        {
            bool ret = _repository.DeleteTask(taskName);
            if (ret == true)
            {
                return Ok();
            }
            return NotFound();
        }
    }
}

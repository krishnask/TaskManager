using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TaskManager.BusinessServices;
using TaskManager.BusinessEntities;
// get - no filter - implement, test using postman, test using nunit, test using nBench, find coverage using nCover
// integrate unit testing, coverage and load testing using jenkins, deploy in iis
//post - create
//put - update

namespace TaskManager.WebAPI.Controllers
{
    public class TasksController : ApiController
    {

        ITaskServices _repository;
        public TasksController()
        {
            _repository = TaskServices.CreateService();
        }
        // GET api/tasks
        public IHttpActionResult Get()
        {
            try
            {
                List<TaskDTO> tasks = _repository.GetTasks();

                return Ok(tasks);
            }
            catch(Exception ex)
            {
                return InternalServerError(ex);
            }
            
        }
       
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

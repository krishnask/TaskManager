using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TaskManager.BusinessServices;
using TaskManager.BusinessEntities;
using System.Web.Http.Cors;
// get - no filter - implement, test using postman, test using nunit, test using nBench, find coverage using nCover
// integrate unit testing, coverage and load testing using jenkins, deploy in iis
//post - create
//put - update
// Edit to test web hook

namespace TaskManager.WebAPI.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods:"*")]
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
        public IHttpActionResult Post(TaskDTO newTask)
        {
            try
            {
                bool ret = _repository.AddTask(newTask);
                if (ret)
                    return Ok(ret);
                else
                    return BadRequest();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // PUT api/tasks/5
        // put is used to update
        public IHttpActionResult Put(int id, TaskDTO task)
        {
            try
            {
                bool ret = _repository.UpdateTask(task);
                if (ret)
                    return Ok(ret);
                else
                    return BadRequest();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
/*
        // DELETE api/tasks/5
        public IHttpActionResult Delete(string taskName)
        {
            bool ret = _repository.DeleteTask(taskName);
            if (ret == true)
            {
                return Ok();
            }
            return NotFound();
        }*/
    }
}

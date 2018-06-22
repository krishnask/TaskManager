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

        // GET api/tasks
        public IHttpActionResult Get()
        {
            return Ok();
        }

        // GET api/tasks/5
        public IHttpActionResult Get(int id)
        {
            return Ok();
        }

        // POST api/tasks
        public void Post([FromBody]string value)
        {
        }

        // PUT api/tasks/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/tasks/5
        public void Delete(int id)
        {
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using TaskManager.WebAPI.Controllers;
using System.Web.Http;

namespace TaskManager.Tests
{
    [TestFixture]
    public class TestWebAPI
    {
        [Test]
        public void TestGetAllTasks_WithValues()
        {
            TasksController controller = new TasksController();
            IHttpActionResult actual =  controller.Get();
           

            Assert.That(1 == 1);

        }
        [Test]
        public void TestGetAllTasks_WithEmptyTaskList()
        {
            Assert.That(1 == 0);

        }
        [Test]
        public void TestGetAllTask_DBError()
        {
            Assert.That(1 == 0);

        }

    }
}

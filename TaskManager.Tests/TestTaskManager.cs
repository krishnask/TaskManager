using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using TaskManager.BusinessServices;
using TaskManager.BusinessEntities;
using TaskManager.DataModel;
using System.Data.Entity;
using System.Web.Http;
using Moq;

namespace TaskManager.Tests
{
    [TestFixture]
    public class TestTaskManager
    {
        [Test]
        public void TestGetAllTasks_WithValues()
        {
            
            try
            {
                var data = new List<TaskManager.DataModel.Task>()
                {
                    new DataModel.Task{TaskId=1, TaskName="SampleTask", ParentTaskName="Myparent", StartDate= DateTime.Now, EndDate= DateTime.Now,IsCompleted=false},
                     new DataModel.Task{TaskId=1, TaskName="Another task", ParentTaskName="Myparent", StartDate= DateTime.Now, EndDate= DateTime.Now,IsCompleted=false}
                }.AsQueryable();

                var mockSet = new Mock<DbSet<TaskManager.DataModel.Task>>();
                mockSet.As<IQueryable<TaskManager.DataModel.Task>>().Setup(m => m.Provider).Returns(data.Provider);
                mockSet.As<IQueryable<TaskManager.DataModel.Task>>().Setup(m => m.Expression).Returns(data.Expression);
                mockSet.As<IQueryable<TaskManager.DataModel.Task>>().Setup(m => m.ElementType).Returns(data.ElementType);
                mockSet.As<IQueryable<TaskManager.DataModel.Task>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
                mockSet.As<IQueryable<TaskManager.DataModel.Task>>().Setup(m => m.Provider).Returns(data.Provider);



                var mockContext = new Mock<TaskManagerContext>();
                mockContext.Setup(m => m.tasks).Returns(mockSet.Object);

                var service = new TaskServices(mockContext.Object);
                List<TaskDTO> taskList = service.GetTasks();

                Assert.That(taskList.Count == 2);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Assert.That(1 == 0);
            }
        }
        [Test]
        public void TestGetAllTasks_WithSingleTask()
        {
            try
            {
                var data = new List<TaskManager.DataModel.Task>()
                {
                    new DataModel.Task{TaskId=1, TaskName="SampleTask", ParentTaskName="Myparent", StartDate= DateTime.Now, EndDate= DateTime.Now,IsCompleted=false}
                }.AsQueryable();
         
                var mockSet = new Mock<DbSet<TaskManager.DataModel.Task>>();
                mockSet.As<IQueryable<TaskManager.DataModel.Task>>().Setup(m => m.Provider).Returns(data.Provider);
                mockSet.As<IQueryable<TaskManager.DataModel.Task>>().Setup(m => m.Expression).Returns(data.Expression);
                mockSet.As<IQueryable<TaskManager.DataModel.Task>>().Setup(m => m.ElementType).Returns(data.ElementType);
                mockSet.As<IQueryable<TaskManager.DataModel.Task>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
                mockSet.As<IQueryable<TaskManager.DataModel.Task>>().Setup(m => m.Provider).Returns(data.Provider);



                var mockContext = new Mock<TaskManagerContext>();
                mockContext.Setup(m => m.tasks).Returns(mockSet.Object);

                var service = new TaskServices(mockContext.Object);
                List<TaskDTO> taskList = service.GetTasks();

                Assert.That(taskList.Count == 1);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Assert.That(1 == 0);
            }

        }
        [Test]
        public void TestGetAllTask_Empty()
        {
            try
            {
                var data = new List<TaskManager.DataModel.Task>()
                {
                }.AsQueryable();

                var mockSet = new Mock<DbSet<TaskManager.DataModel.Task>>();
                mockSet.As<IQueryable<TaskManager.DataModel.Task>>().Setup(m => m.Provider).Returns(data.Provider);
                mockSet.As<IQueryable<TaskManager.DataModel.Task>>().Setup(m => m.Expression).Returns(data.Expression);
                mockSet.As<IQueryable<TaskManager.DataModel.Task>>().Setup(m => m.ElementType).Returns(data.ElementType);
                mockSet.As<IQueryable<TaskManager.DataModel.Task>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
                mockSet.As<IQueryable<TaskManager.DataModel.Task>>().Setup(m => m.Provider).Returns(data.Provider);



                var mockContext = new Mock<TaskManagerContext>();
                mockContext.Setup(m => m.tasks).Returns(mockSet.Object);

                var service = new TaskServices(mockContext.Object);
                List<TaskDTO> taskList = service.GetTasks();

                Assert.That(taskList.Count == 0);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Assert.That(1 == 0);
            }

        }
        [Test]
        public void TestCompleteTask()
        {
            Assert.That(1 == 0);

        }
        [Test]
        public void TestCompleteTaskThatDoesNotExist()
        {
            Assert.That(1 == 0);

        }

        [Test]
        public void TestEditTask()
        {
            Assert.That(1 == 0);

        }
        [Test]
        public void TestEditTaskThatDoesNotExist()
        {
            Assert.That(1 == 0);

        }
        [Test]
        public void TestEditCompletedTask()
        {
            Assert.That(1 == 0);

        }

    }
}

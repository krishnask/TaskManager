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
using NBench;

namespace TaskManager.Tests
{
    [TestFixture]
    public class TestTaskManager
    {
        [Test]
        [PerfBenchmark(NumberOfIterations =500,RunTimeMilliseconds =600000,RunMode =RunMode.Iterations)]
        [CounterMeasurement("MyCounter")]
        [MemoryMeasurement(MemoryMetric.TotalBytesAllocated)]
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
            try
            {
                var orgSvc = TaskServices.CreateService(); // No Error should be thrown

                var data = new List<TaskManager.DataModel.Task>()
                {
                      new DataModel.Task{TaskId=1, TaskName="SampleTask", ParentTaskName="Myparent", StartDate= DateTime.Now, EndDate= DateTime.Now,IsCompleted=false},
                     new DataModel.Task{TaskId=2, TaskName="Another task", ParentTaskName="Another parent", StartDate= DateTime.Now, EndDate= DateTime.Now,IsCompleted=false}

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
        public void TestEditTask()
        {
            try
            {
                var data = new List<TaskManager.DataModel.Task>()
                {
                      new DataModel.Task{TaskId=1, TaskName="SampleTask", ParentTaskName="Myparent", StartDate= DateTime.Now, EndDate= DateTime.Now,IsCompleted=false},
                     new DataModel.Task{TaskId=2, TaskName="Another task", ParentTaskName="Another parent", StartDate= DateTime.Now, EndDate= DateTime.Now,IsCompleted=false}

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

                var cTask = taskList[0];
                cTask.Priority = 10;

                bool ret = service.UpdateTask(cTask);


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Assert.That(1 == 0);
            }


        }

        [Test]
        public void TestEditCompletedTask()
        {
            try
            {
                var data = new List<TaskManager.DataModel.Task>()
                {
                      new DataModel.Task{TaskId=1, TaskName="SampleTask", ParentTaskName="Myparent", StartDate= DateTime.Now, EndDate= DateTime.Now,IsCompleted=true},
                     new DataModel.Task{TaskId=2, TaskName="Another task", ParentTaskName="Another parent", StartDate= DateTime.Now, EndDate= DateTime.Now,IsCompleted=true}

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

                var cTask = taskList[0];
                cTask.Priority = 10;

                bool ret = service.UpdateTask(cTask);


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Assert.That(1 == 1);
            }

        }
        [Test]
        public void TestAddTask()
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

                TaskDTO task = new TaskDTO { TaskId = 1, TaskName = "SampleTask", ParentTaskName = "Myparent", StartDate = DateTime.Now, EndDate = DateTime.Now, IsCompleted = true };

                var mockContext = new Mock<TaskManagerContext>();
                mockContext.Setup(m => m.tasks).Returns(mockSet.Object);

                var service = new TaskServices(mockContext.Object);
                List<TaskDTO> taskList = service.GetTasks();

                Assert.That(taskList.Count == 0);
                bool ret = service.AddTask(task);
          
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Assert.That(1 == 0);
            }

        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.BusinessEntities;

namespace TaskManager.BusinessServices
{
    public interface ITaskServices
    {
        bool AddTask(TaskDTO task);
        List<TaskDTO> GetTasks();
        bool UpdateTask(TaskDTO task);
    }
}

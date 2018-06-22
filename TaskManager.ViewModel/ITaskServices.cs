﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.BusinessEntities;

namespace TaskManager.BusinessServices
{
    interface ITaskServices
    {
        bool AddTask(TaskDTO task);
        List<TaskDTO> GetTasks(FilterDTO filter);
        bool UpdateTask(TaskDTO task);
        bool CompleteTask(string taskName);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.DataModel
{
    public class Task
    {
        public int TaskId { get; set; }
        public int ParentID { get; set; }
        public string TaskName { get; set; }
        public short Priority { get; set; }
        public string ParentTaskName { get; set; }
        public DateTime StartDate { set; get; }
        public DateTime EndDate { set; get; }
        public bool IsCompleted { set; get; }
    }
}

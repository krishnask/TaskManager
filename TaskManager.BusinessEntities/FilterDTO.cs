using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.BusinessEntities
{
    public class FilterDTO
    {
        public string TaskName { get; set; }
        public string ParentTaskName { get; set; }
        public short PirorityFrom { get; set; }
        public short PriorityTo { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

    }
}

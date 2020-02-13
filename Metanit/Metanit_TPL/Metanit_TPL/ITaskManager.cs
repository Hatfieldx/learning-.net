using System;
using System.Threading.Tasks;

namespace Metanit_TPL
{
    interface ITaskManager
    {
        int lenthTime { get; set; }
        string name { get; set; }

        Task StartTask();

        void GetTaskInfo(Task task);
    }
}

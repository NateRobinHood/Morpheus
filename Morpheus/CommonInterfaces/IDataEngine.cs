using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonInterfaces
{
    public interface IDataEngine
    {
        event EventHandler<NewRequestRecordEventArgs> OnNewRequestRecord;

        void StartEngine();
        void StopEngine();

        bool IsRunning { get; }
    }
}

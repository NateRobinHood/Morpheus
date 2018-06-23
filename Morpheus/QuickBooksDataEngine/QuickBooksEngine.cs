using CommonInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickBooksDataEngine
{
    public class QuickBooksEngine : IDataEngine
    {
        public bool IsRunning
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public event EventHandler<NewRequestRecordEventArgs> OnNewRequestRecord;

        public QuickBooksEngine()
        {
        }

        public void StartEngine()
        {
            throw new NotImplementedException();
        }

        public void StopEngine()
        {
            throw new NotImplementedException();
        }
    }
}

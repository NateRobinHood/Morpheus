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
        public event EventHandler<NewRequestRecordEventArgs> OnNewRequestRecord;

        public QuickBooksEngine()
        {
        }
    }
}

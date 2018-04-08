using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Morpheus.Framework
{
    public class MainThread
    {
        private Thread m_Thread = new Thread(Worker);

        //Constructors
        public MainThread()
        {

        }

        //Private Methods
        private static void Worker()
        {
            //Sample Data Engines for changes
        }
    }
}

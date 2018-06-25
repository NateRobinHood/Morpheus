using CommonInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace QuickBooksDataEngine
{
    public class QuickBooksEngine : IDataEngine
    {
        //Private Variables
        private bool m_IsRunning = false;
        private bool m_Shutdown = false;
        private Thread m_EngineThread;

        public bool IsRunning
        {
            get
            {
                return m_IsRunning;
            }
        }

        public event EventHandler<NewRequestRecordEventArgs> OnNewRequestRecord;

        public QuickBooksEngine()
        {
        }

        public void StartEngine()
        {
            m_Shutdown = false;

            m_EngineThread = new Thread(EngineThread);
            m_EngineThread.Start();
        }

        public void StopEngine()
        {
            m_Shutdown = true;
            m_EngineThread.Join();
        }

        //Private Methods
        private void EngineThread()
        {
            while (!m_Shutdown)
            {
                m_IsRunning = true;

                Thread.Sleep(1000);
            }

            m_IsRunning = false;
        }
    }
}

using CommonInterfaces;
using Composer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Morpheus.Framework
{
    public class DataEngineManager
    {
        private IDataAccess m_DataAccess;
        private List<IDataEngine> m_DataEngines = new List<IDataEngine>();

        public DataEngineManager(IDataAccess dataAccess)
        {
            m_DataAccess = dataAccess;
        }

        //Public Methods
        public void AddEngine(IDataEngine dataEngine)
        {
            dataEngine.OnNewRequestRecord += DataEngine_OnNewRequestRecord;
            m_DataEngines.Add(dataEngine);
        }

        public void StartDataEngines()
        {
            foreach (IDataEngine dataEngine in m_DataEngines)
            {
                dataEngine.StartEngine();
            }
        }

        public void StopDataEngines()
        {
            foreach (IDataEngine dataEngine in m_DataEngines)
            {
                dataEngine.StopEngine();
            }
        }

        //Event Handlers
        private void DataEngine_OnNewRequestRecord(object sender, NewRequestRecordEventArgs e)
        {
            m_DataAccess.AddRequestRecord(e.NewRequestRecord);
        }
    }
}

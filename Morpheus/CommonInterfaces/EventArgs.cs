using Composer.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonInterfaces
{
    public class NewRequestRecordEventArgs
    {
        private RequestRecord m_RequestRecord;

        public NewRequestRecordEventArgs(RequestRecord requestRecord)
        {
            m_RequestRecord = requestRecord;
        }

        public RequestRecord NewRequestRecord
        {
            get
            {
                return m_RequestRecord;
            }
        }
    }
}

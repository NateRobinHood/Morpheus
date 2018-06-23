using CommonInterfaces;
using Composer;
using Composer.DataModel;
using Moq;
using Morpheus.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DataEngineTests
{
    public class DataEngineTests
    {
        [Fact]
        public void CanStartDataEngines()
        {
            var dataAccessDummy = new Mock<IDataAccess>();
            var dataEngineMock = new Mock<IDataEngine>();

            DataEngineManager dataEngineManager = new DataEngineManager(dataAccessDummy.Object);
            dataEngineManager.AddEngine(dataEngineMock.Object);

            dataEngineManager.StartDataEngines();

            dataEngineMock.Verify(de => de.StartEngine());
        }

        [Fact]
        public void CanStopDataEngines()
        {
            var dataAccessDummy = new Mock<IDataAccess>();
            var dataEngineMock = new Mock<IDataEngine>();

            DataEngineManager dataEngineManager = new DataEngineManager(dataAccessDummy.Object);
            dataEngineManager.AddEngine(dataEngineMock.Object);

            dataEngineManager.StopDataEngines();

            dataEngineMock.Verify(de => de.StopEngine());
        }

        [Fact]
        public void DidDataEngineManagerSaveRequestRecord()
        {
            var dataAccessMock = new Mock<IDataAccess>();
            var dataEngineMock = new Mock<IDataEngine>();

            DataEngineManager dataEngineManager = new DataEngineManager(dataAccessMock.Object);

            dataEngineManager.AddEngine(dataEngineMock.Object);

            RequestRecord testRecord = new RequestRecord();
            dataEngineMock.Raise(de => de.OnNewRequestRecord += null, this, new NewRequestRecordEventArgs(testRecord));

            dataAccessMock.Verify(da => da.AddRequestRecord(testRecord));
        }
    }
}

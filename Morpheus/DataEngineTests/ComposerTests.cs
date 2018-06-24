using Composer;
using Composer.DataModel;
using Moq;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DataEngineTests
{
    public class ComposerTests : IDisposable
    {
        //Any EntityFramework test is a I/O Bound test
        //I/O free tests with EntityFramework need to use Mocks

        private Mock<DbSet<RequestRecord>> m_RequestRecordsMock;
        private Mock<ComposerEngine> m_ComposerMock;

        public ComposerTests()
        {
            m_RequestRecordsMock = new Mock<DbSet<RequestRecord>>();
            m_ComposerMock = new Mock<ComposerEngine>();

            m_ComposerMock.Setup(ce => ce.RequestRecords).Returns(m_RequestRecordsMock.Object);
            m_RequestRecordsMock.Setup(rr => rr.Add(It.IsAny<RequestRecord>())).Returns<RequestRecord>(c => c);
        }

        public void Dispose()
        {
            m_RequestRecordsMock = null;
            m_ComposerMock = null;
        }

        [Fact]
        public void TestRequestRecordTimeStampSet()
        {
            ComposerEngine sut = m_ComposerMock.Object;

            RequestRecord testRecord = new RequestRecord();
            sut.AddRequestRecord(testRecord);

            Assert.NotNull(testRecord.DateCreated);
            Assert.NotNull(testRecord.DateModified);
        }

        [Fact]
        public void CanAddRequestRecord()
        {
            ComposerEngine sut = m_ComposerMock.Object;

            RequestRecord testRecord = new RequestRecord();
            sut.AddRequestRecord(testRecord);

            m_RequestRecordsMock.Verify(rr => rr.Add(testRecord));
        }
    }
}

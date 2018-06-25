using QuickBooksDataEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace QuickBooksEngineTests
{
    public class QuickBooksEngineTests
    {
        [Fact]
        public void CanStartAndStopEngineThread()
        {
            QuickBooksEngine sut = new QuickBooksEngine();

            sut.StartEngine();

            Assert.True(sut.IsRunning);

            sut.StopEngine();

            Assert.False(sut.IsRunning);
        }
    }
}

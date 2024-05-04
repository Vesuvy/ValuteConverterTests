using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValuteConverterTests
{
    [TestClass]
    internal class ValuteEntryTests
    {
        // метод не нуждается в moq тесте, так как нет внешних зависимостей у класса ValuteEntry
        [TestMethod]
        public void ValuteEntry_Constructor_InitializesProperties()
        {
            // Arrange
            string valuteName = "TestValute";
            string valuteCode = "TV";
            double valuteCourse = 1.0;

            // Act
            var valuteEntry = new ValuteEntry(valuteName, valuteCode, valuteCourse);

            // Assert
            Assert.AreEqual(valuteName, valuteEntry.ValuteName);
            Assert.AreEqual(valuteCode, valuteEntry.ValuteCode);
            Assert.AreEqual(valuteCourse, valuteEntry.ValuteCourse);
        }
    }
}

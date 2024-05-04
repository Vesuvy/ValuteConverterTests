using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValuteConverterTests
{
    [TestClass]
    internal class CoinYepParserTests
    {
        [TestMethod]
        // метод не нуждается в moq тесте, так как нет внешних зависимостей у класса CoinYepParser
        public void GetValuteEntries_ValidDataTable_ReturnsValuteEntries()
        {
            // Arrange
            var dataTable = new DataTable();
            dataTable.Columns.Add("Vname", typeof(string));
            dataTable.Columns.Add("Vchcode", typeof(string));
            dataTable.Columns.Add("Vcurs", typeof(double));

            dataTable.Rows.Add("TestValute1", "TV1", 1.0);
            dataTable.Rows.Add("TestValute2", "TV2", 2.0);

            // Act
            var result = CoinYepParser.GetValuteEntries(dataTable);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count());
        }
    }
}

using System.Data;
using ValuteConverter.Model.Interfaces;

namespace ValuteConverterTests
{
    [TestClass]
    public class ViewModelTests
    {
        [TestMethod]
        public async Task LoadValutes_ValidExchangeRate_ReturnsValuteEntries()
        {
            // Arrange
            var mockConverter = new Mock<ICourseConverter>();
            mockConverter.Setup(mock => mock.GetExchangeRateOnDateAsync(It.IsAny<DateTime>()))
                         .ReturnsAsync(GetTestDataTable());
            var viewModel = new ViewModel(mockConverter.Object);

            // Act
            await viewModel.LoadValutes();

            // Assert
            Assert.IsNotNull(viewModel.ValuteEntries);
            Assert.IsTrue(viewModel.ValuteEntries.Count > 0);
        }

        private DataTable GetTestDataTable()
        {
            
            DataTable dataTable = new DataTable();
            
            dataTable.Columns.Add("Vname", typeof(string));
            dataTable.Columns.Add("Vchcode", typeof(string));
            dataTable.Columns.Add("Vcurs", typeof(double));
            
            dataTable.Rows.Add("TestValute1", "TV1", 1.0);
            dataTable.Rows.Add("TestValute2", "TV2", 2.0);
            
            return dataTable;
        }

        // DataRow - передача в тестовый метод различных параметров
        [TestMethod]
        [DataRow("123,45", "123.45")]
        [DataRow("1 234,56", "1234.56")]
        [DataRow("123 456,78", "123456.78")]
        public void TestUnifyInput(string input, string expected)
        {
            // Act
            string result = InputHandler.Unify(input);

            // Assert
            Assert.AreEqual(expected, result);
        }
    }
}
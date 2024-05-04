using System;
using System.Data;
using System.Threading.Tasks;

namespace ValuteConverterTests
{
    [TestClass]
    internal class SoapRequestTests
    {
        [TestMethod]
        public async Task GetExchangeRateOnDateAsync_ValidDate_ReturnsDataTable()
        {
            // Arrange
            DateTime testDate = new DateTime(2024, 5, 5);
            var mockWebRequest = new Mock<IWebRequest>(); //веб-запрос
            // возвращение асинхронного результата в виде мок-объекта IWebResp..
            mockWebRequest.Setup(mock => mock.GetResponseAsync()).ReturnsAsync(new Mock<IWebResponse>().Object);
            var soapRequest = new SoapRequest(mockWebRequest.Object);

            // Act
            DataTable result = await soapRequest.GetExchangeRateOnDateAsync(testDate);

            // Assert
            Assert.IsNotNull(result);
        }
    }
}

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValuteConverterTests
{
    [TestClass]
    internal class InputHandlerTests
    {
        [TestCase("123", ExpectedResult = "123")]
        [TestCase("12,3", ExpectedResult = "12,3")]
        [TestCase("12.3", ExpectedResult = "12,3")]
        [TestCase("12.3,", ExpectedResult = "12,3")]
        [TestCase("12,3,", ExpectedResult = "12,3")]
        [TestCase("12,3,,", ExpectedResult = "12,3")]
        [TestCase("", ExpectedResult = "")]
        [TestCase(null, ExpectedResult = "")]
        public string Unify_ValidInput_ReturnsUnifiedInput(string input)
        {
            // Arrange
            var mockInputHandler = new Mock<InputHandler>();
            mockInputHandler.Setup(x => x.Unify(It.IsAny<string>())).Returns((string s) => InputHandler.Unify(s));

            // Act
            return mockInputHandler.Object.Unify(input);
        }
    }
}

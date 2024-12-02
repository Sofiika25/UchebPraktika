using Microsoft.VisualStudio.TestTools.UnitTesting;
using UchebPraktika;

namespace UnitTestProject1
{
    [TestClass]
    public class PasswordValidationTests
    {
        private Autorization autorization;

        [TestInitialize]
        public void TestInitialize()
        {
            autorization = new Autorization();
        }

        [TestMethod]
        public void ValidatePassword_ValidPassword_ReturnsZero()
        {

            string validPassword = "qwertyQWERTY123!";

            int result = autorization.ValidatePassword(validPassword);

            Assert.AreEqual(0, result);
        }
        [TestMethod]
        public void ValidatePassword_ValidPassword_ReturnsOne()
        {

            string validPassword = "qQE1!";

            int result = autorization.ValidatePassword(validPassword);

            Assert.AreEqual(1, result);
        }
        [TestMethod]
        public void ValidatePassword_ValidPassword_ReturnsTwo()
        {

            string validPassword = "qwerty123!";

            int result = autorization.ValidatePassword(validPassword);

            Assert.AreEqual(2, result);
        }
        [TestMethod]
        public void ValidatePassword_ValidPassword_ReturnsThree()
        {

            string validPassword = "QQW123!";

            int result = autorization.ValidatePassword(validPassword);

            Assert.AreEqual(3, result);
        }
        [TestMethod]
        public void ValidatePassword_ValidPassword_ReturnsFour()
        {

            string validPassword = "qwertyQQQ!";

            int result = autorization.ValidatePassword(validPassword);

            Assert.AreEqual(4, result);
        }
        [TestMethod]
        public void ValidatePassword_ValidPassword_ReturnsFive()
        {

            string validPassword = "qwertyQQQ123";

            int result = autorization.ValidatePassword(validPassword);

            Assert.AreEqual(5, result);
        }
    }

    [TestClass]
    public class LoadTest
    {
        private MainWindow mainWindow;

    }
}

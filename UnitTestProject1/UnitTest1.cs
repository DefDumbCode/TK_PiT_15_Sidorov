using Microsoft.VisualStudio.TestTools.UnitTesting;
using TK_PiT_15_Sidorov;
using System;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void IsValidInputSuccess()
        {
            var window = new MainWindow();
            Assert.IsTrue(window.IsValidInput("108,98", "3"));
            Assert.IsTrue(window.IsValidInput("1000", "200"));
            Assert.IsTrue(window.IsValidInput("45", "6"));
        }

        [TestMethod]
        public void IsValidInputFail()
        {
            var window = new MainWindow();
            Assert.IsFalse(window.IsValidInput("108.98", "3"));
            Assert.IsFalse(window.IsValidInput("1000", "200.89"));
            Assert.IsFalse(window.IsValidInput("45", "-6"));
            Assert.IsFalse(window.IsValidInput("", ""));
            Assert.IsFalse(window.IsValidInput(" ", " "));
            Assert.IsFalse(window.IsValidInput("-365", "12"));
        }

        [TestMethod]
        public void Calculate()
        {
            var window = new MainWindow();
            double range = 80.75;
            int amount = 9;
            string comf = "люкс";
            double mult = 1.3;
            double price_exp = range * 8 * amount * mult;
            double price_act = window.CalculatePrice(range, amount, comf);
            Assert.AreEqual(price_exp, price_act, Math.Abs(price_act - price_exp) * 0.05);


            range = 1003.78;
            amount = 1000;
            comf = "плацкарт";
            mult = 1;
            price_exp = range * 8 * amount * mult;
            price_act = window.CalculatePrice(range, amount, comf);
            Assert.AreEqual(price_exp, price_act, Math.Abs(price_act - price_exp) * 0.05);

        }
    }
}

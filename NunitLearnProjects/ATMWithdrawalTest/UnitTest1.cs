using ATMWithdrawal;

namespace ATMWithdrawalTest
{
    public class Tests
    {
        private ATM machine;
        [SetUp]
        public void Setup()
        {
            machine = new ATM();
        }

        [TestCase(1000u, 500u)]
        [TestCase(2000u, 1500u)]
        [TestCase(2000u, 100u)]
        [TestCase(1230u, 300u)]
        public void ValidWithdrawalTest(uint balance, uint toWithdraw)
        {
            machine.EnterAccBalance(balance);
            Assert.That(machine.Withdraw(toWithdraw), Is.True);
        }

        [TestCase(1000u, 1000u)]
        [TestCase(2000u, 2000u)]
        [TestCase(0u, 0u)]
        [TestCase(100u, 100u)]
        public void WithdrawalEqualToBalanceTest(uint balance, uint toWithdraw)
        {
            machine.EnterAccBalance(balance);
            Assert.That(machine.Withdraw(toWithdraw), Is.False);
        }

        [TestCase(1000u, 500u)]
        [TestCase(2000u, 1500u)]
        [TestCase(500u, 0u)]    // Withdrawal amount 0
        [TestCase(600u, 100u)]
        public void WithdrawalLeave500Test(uint balance, uint toWithdraw)
        {
            machine.EnterAccBalance(balance);
            Assert.That(machine.Withdraw(toWithdraw), Is.True);
        }

        // Cant use negative withdrawal as it is uint
        [TestCase(599u, 100u)]  //Withdrawal leaving 499
        [TestCase(499u, 0u)]   // Withdrawal amount is 0
        [TestCase(600u, 199u)]   // non multiple of 100
        public void InvalidWithdrawalTest(uint balance, uint toWithdraw)
        {
            machine.EnterAccBalance(balance);
            Assert.That(machine.Withdraw(toWithdraw), Is.False);
        }
    }
}
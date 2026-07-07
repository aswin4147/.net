namespace ATMWithdrawal
{
    public class ATM
    {
        private uint _balance;

        public void EnterAccBalance(uint amount) => this._balance = amount;

        public bool Withdraw(uint toWithdraw)
        {

            // Cannot withdraw more than balance
            if (this._balance < toWithdraw)
            {
                return false;
            }

            // Only withdraw in multiples of 100
            if ((toWithdraw % 100) != 0)
            {
                return false;
            }

            // Minimum Balance of 500 AFTER withdrawing
            if ((this._balance - toWithdraw) < 500)
            {
                return false;
            }

            this._balance -= toWithdraw;
            return true;
        }
    }
}

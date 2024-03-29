﻿using System;

namespace BankAccountNS
{
    /// <summary>   
    /// Bank Account demo class.   
    /// </summary>   
    public class BankAccount
    {
        public const string AccountIsFrozenMessage = "Account is frozen";
        public const string DebitAmountExceedsBalanceMessage = "Debit amount exceeds balance";
        public const string DebitAmountLessThanZeroMessage = "Debit amount less than zero";

        public const string CreditAmountLessThanZeroMessage = "Credit amount less than zero";

        private string m_customerName;

        private double m_balance;

        private bool m_frozen = false;

        private BankAccount()
        {
        }

        public BankAccount(string customerName, double balance)
        {
            m_customerName = customerName;
            m_balance = balance;
        }

        //Create for my needs
        public BankAccount(string customerName, double balance, bool frozen)
        {
            m_customerName = customerName;
            m_balance = balance;
            m_frozen = frozen;
        }

        public string CustomerName
        {
            get { return m_customerName; }
        }

        public double Balance
        {
            get { return m_balance; }
        }

        public void Debit(double amount)
        {
            if (m_frozen)
            {
                throw new ArgumentOutOfRangeException("amount", m_frozen, AccountIsFrozenMessage);
            }

            if (amount > m_balance)
            {
                throw new ArgumentOutOfRangeException("amount", amount, DebitAmountExceedsBalanceMessage);
            }

            if (amount < 0)
            {
                throw new ArgumentOutOfRangeException("amount", amount, DebitAmountLessThanZeroMessage);
            }

            m_balance -= amount; // intentionally incorrect code (was changed) 
        }

        public void Credit(double amount)
        {
            if (m_frozen)
            {
                throw new ArgumentOutOfRangeException("amount", m_frozen, AccountIsFrozenMessage);
            }

            if (amount < 0)
            {
                throw new ArgumentOutOfRangeException("amount", amount, CreditAmountLessThanZeroMessage);
            }

            m_balance += amount;
        }

        private void FreezeAccount()
        {
            m_frozen = true;
        }

        private void UnfreezeAccount()
        {
            m_frozen = false;
        }

        public static void Main()
        {
            BankAccount ba = new BankAccount("Mr. Bryan Walton", 11.99);

            ba.Credit(5.77);
            ba.Debit(11.22);
            Console.WriteLine("Current balance is ${0}", ba.Balance);
        }

    }
}
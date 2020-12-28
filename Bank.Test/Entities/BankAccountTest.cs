using Bank.Entities.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bank.Test.Entities
{
    [TestClass]
    public class BankAccountTest
    {
        private Mock<IBankAccount> _mock;
		BankAccount account = new BankAccount("Josefano", 130.00);

		//add interest test =====================================================
		[TestMethod]
        public void BankAccount_AddInterest_BalancePlusInterest_Test_Success()
        {
            
            _mock = new Mock<IBankAccount>();

            BankAccount accountMock = new BankAccount();
            accountMock.SetNameOfCustomer("Josefano");
            accountMock.Balance = 130.00;

            _mock.Setup(x => x.AddInterest(It.IsAny<double>()));
			double balanceRes = 16900;
            double balanceUpdated = accountMock.AddInterest(130.00);
            Assert.AreEqual(balanceRes, balanceUpdated);
        }

		[TestMethod]
		public void BankAccount_AddInterest_BalancePlusInterest_Test_Fail()
		{
			_mock = new Mock<IBankAccount>();

			BankAccount accountMock = new BankAccount();
			accountMock.SetNameOfCustomer("Josefano");
			accountMock.Balance = 130.00;

			_mock.Setup(x => x.AddInterest(It.IsAny<double>()));
			double balanceRes = 130.00;
			double balanceUpdated = account.AddInterest(130.00);
			Assert.AreNotEqual(balanceRes, balanceUpdated);
		}

		//credit ========================================================
		[TestMethod]
		public void BankAccount_Credit_BalancePlusAmount_Test_Success()
		{
			_mock = new Mock<IBankAccount>();

			BankAccount accountMock = new BankAccount();
			accountMock.SetNameOfCustomer("Josefano");
			accountMock.Balance = 130.00;

			
			_mock.Setup(x => x.Credit(It.IsAny<double>()));

			double amount = 10.00;

			double balanceRes = 140;
			double balanceUpdated = account.Credit(amount);
			Assert.AreEqual(balanceRes, balanceUpdated);
		}

		[TestMethod]
		public void BankAccount_Credit_BalancePlusAmount_Test_Fail()
		{
			_mock = new Mock<IBankAccount>();

			BankAccount accountMock = new BankAccount();
			accountMock.SetNameOfCustomer("Josefano");
			accountMock.Balance = 130.00;

			double amount = 10.00;

			_mock.Setup(x => x.Credit(It.IsAny<double>()));

			double balanceRes = 130.00;
			double balanceUpdated = account.Credit(amount);
			Assert.AreNotEqual(balanceRes, balanceUpdated);
		}

		[TestMethod]
		public void BankAccount_Credit_Exception_Test_Exception()
		{
			_mock = new Mock<IBankAccount>();

			BankAccount accountMock = new BankAccount();
			accountMock.SetNameOfCustomer("Josefano");
			accountMock.Balance = 130.00;

			double amount = -10.00;

			_mock.Setup(x => x.Credit(It.IsAny<double>()));

			Assert.ThrowsException<Exception>(() => account.Credit(amount));
		}

		//debit ========================================================
		[TestMethod]
		public void BankAccount_Debit_BalanceMinusAmount_Test_Success()
		{
			_mock = new Mock<IBankAccount>();

			BankAccount accountMock = new BankAccount();
			accountMock.SetNameOfCustomer("Josefano");
			accountMock.Balance = 130.00;

			double amount = 10.00;

			_mock.Setup(x => x.Debit(It.IsAny<double>()));

			double balanceRes = account.Balance - amount*1.025;
			double balanceUpdated = account.Debit(amount);
			Assert.AreEqual(balanceRes, balanceUpdated);
		}

		[TestMethod]                              
		public void BankAccount_Debit_BalanceMinusAmount_Test_Fail()
		{
			_mock = new Mock<IBankAccount>();

			BankAccount accountMock = new BankAccount();
			accountMock.SetNameOfCustomer("Josefano");
			accountMock.Balance = 130.00;

			double amount = 10.00;

			_mock.Setup(x => x.Debit(It.IsAny<double>()));

			double balanceRes = account.Balance - amount;
			double balanceUpdated = account.Debit(amount);
			Assert.AreNotEqual(balanceRes, balanceUpdated);
		}

		[TestMethod]
		public void BankAccount_Debit_Exception_Test_Exception()
		{
			_mock = new Mock<IBankAccount>();

			BankAccount accountMock = new BankAccount();
			accountMock.SetNameOfCustomer("Josefano");
			accountMock.Balance = 130.00;

			double amount = -10.00;

			_mock.Setup(x => x.Credit(It.IsAny<double>()));

			double balanceRes = account.Balance;
			Assert.ThrowsException<Exception>(() => account.Debit(amount));
		}

	}
}

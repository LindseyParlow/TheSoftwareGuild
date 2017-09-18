using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using SGBank.Data;
using SGBank.Models;

namespace SGBank.Tests
{
    [TestFixture]
    public class FileAccountTests
    {
        //old test to make sure my list was pulling the correct information. no longer needed.
        //[Test]
        //public void CanReadDataFromFile()
        //{
        //    FileAccountRepository repo = new FileAccountRepository(@"C:\Repos\bitbucket\dotnet-lindsey-parlow\SGBankAccounts\Accounts.txt");

        //    List<Account> accounts = repo.List();

        //    Assert.AreEqual(3, accounts.Count());

        //    Account check = accounts[2];

        //    Assert.AreEqual("33333", check.AccountNumber);
        //    Assert.AreEqual("Premium Customer", check.Name);
        //    Assert.AreEqual(1000, check.Balance);
        //    Assert.AreEqual(AccountType.Premium, check.Type);
        //}
    }
}

using SGBank.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGBank.Models;
using System.IO;

namespace SGBank.Data
{
    public class FileAccountRepository : IAccountRepository
    {
        List<Account> _allAccounts = new List<Account>();

        private string _filePath;

        public FileAccountRepository(string filePath)
        {
            _filePath = filePath;

            List();
        }

        public void List()
        {
            using (StreamReader sr = new StreamReader(_filePath))
            {
                sr.ReadLine();
                string line;

                while ((line = sr.ReadLine()) != null)
                {
                    Account newAccount = new Account();

                    string[] columns = line.Split(',');


                    newAccount.AccountNumber = columns[0];
                    newAccount.Name = columns[1];
                    newAccount.Balance = decimal.Parse(columns[2]);

                    if (columns[3] == "F")
                    {
                        newAccount.Type = AccountType.Free;
                    }
                    else if (columns[3] == "B")
                    {
                        newAccount.Type = AccountType.Basic;
                    }
                    else if (columns[3] == "P")
                    {
                        newAccount.Type = AccountType.Premium;

                    }
                        _allAccounts.Add(newAccount);
                }
            }
        }

        Account _account = new Account();

        public Account LoadAccount(string AccountNumber)
        {
            var Accounts = _allAccounts.SingleOrDefault(a => a.AccountNumber == AccountNumber);
            _account = Accounts;

            return Accounts;
        }

        public void SaveAccount(Account account)
        {
            if (File.Exists(_filePath))
                File.Delete(_filePath);

            using (StreamWriter sw = new StreamWriter(_filePath))
            {
                sw.WriteLine("AccountNumber,Name,Balance,Type");
                foreach (var _account in _allAccounts)
                {
                    if(_account.AccountNumber == account.AccountNumber)
                    {
                        sw.WriteLine(CreateCsvForAccount(account));
                    }
                    else
                    {
                        sw.WriteLine(CreateCsvForAccount(_account));
                    }
                }
            }
        }
        private string CreateCsvForAccount(Account account)
        {
            string accountCsv = "";

            accountCsv += account.AccountNumber + ",";
            accountCsv += account.Name + ",";
            accountCsv += account.Balance + ",";
            accountCsv += account.Type.ToString()[0];

            return accountCsv;
        }
    }
}

using BootCampV2.Homeworks.ThirdWeek.Exceptions;
using System;
using System.Collections.Generic;
using System.IO;

namespace BootCampV2.Homeworks.ThirdWeek
{
    public enum LoginResult
    {
        AccountWithUsernameDontExists,
        InvalidPassword,
        Success
    }

    public enum RegistrationResult
    {
        InvalidUsername,
        NotMatchingPassword,
        Success
    }

    public class UserFileManager
    {
        public readonly string Path;

        private List<Account> Accounts = new List<Account>();

        public UserFileManager(string path)
        {
            Path = path;

            bool validFile = ValidateUserFile(Path, out List<Account> accounts, out Exception exception);

            if (validFile)
                Accounts = accounts;
            else
                throw exception;
        }

        public LoginResult Login(string username, string password, out Account loggedInAccount)
        {
            loggedInAccount = null;

            Account account = GetAccountByUsername(username);

            if (account == null)
                return LoginResult.AccountWithUsernameDontExists;
            else if (!password.Equals(account.Password))
                return LoginResult.InvalidPassword;
            else
                loggedInAccount = account;

            return LoginResult.Success;
        }

        public RegistrationResult Register(string username, string password, string confirmpassword)
        {
            Account account = GetAccountByUsername(username);

            if (account != null)
                return RegistrationResult.InvalidUsername;

            if (!password.Equals(confirmpassword))
                return RegistrationResult.NotMatchingPassword;

            account = new Account(username, password);

            AddAccountInUserFile(account);

            return RegistrationResult.Success;
        }

        public bool ValidateUserFile(string path, out List<Account> account, out Exception exception)
        {
            account = new List<Account>();
            exception = null;

            try
            {
                account.AddRange(GetAccountsInUserfile(path));

                List<string> usernames = new List<string>();

                foreach (var item in account)
                {
                    usernames.Add(item.Username);
                }

                if(CheckDistinct(usernames))
                    throw new DuplicateUserCredentialsException();

                if (string.IsNullOrWhiteSpace(ReadUserFile(Path)) || string.IsNullOrEmpty(ReadUserFile(Path)))
                {
                    string[] contentlines = {
                        "#  # -> Command line\n",
                        "# .U -> Username line\n",
                        "# .P -> Password line\n",
                        "#  - -> Start/End line"
                        };
                    
                    WriteUserfile(contentlines);
                }
            }
            catch (InvalidUserFileFormatException)
            {
                exception = new InvalidUserFileFormatException();
                return false;
            }
            catch (DuplicateUserCredentialsException)
            {
                exception = new DuplicateUserCredentialsException();
                return false;
            }
            catch (FileNotFoundException)
            {
                exception = new UserFileNotFoundException();
                return false;
            }
            catch (Exception)
            {
                exception = new Exception();
                return false;
            }

            return true;
        }

        private string ReadUserFile(string path)
        {
            var content = string.Empty;

            using (StreamReader reader = new StreamReader(path))
            {
                while (!reader.EndOfStream)
                {
                    var readLine = reader.ReadLine();

                    if (readLine.Length > 0 && !readLine[0].Equals("#"))
                        content += $"{readLine}\n";
                }
                return content;
            }
        }

        private void WriteUserfile(string[] lines)
        {
            using (StreamWriter writer = new StreamWriter(Path))
            {
                foreach (var item in lines)
                {
                    writer.Write(item);
                }
            }

        }

        private string[] ConvertToArray(string content)
        {
            string[] contentAsList = content.Split("\n");

            for (int i = 0; i < contentAsList.Length; i++)
                contentAsList[i] = contentAsList[i].Replace("\n", "");

            return contentAsList;
        }

        private List<Account> GetAccountsInUserfile(string path)
        {
            string content = ReadUserFile(path);
            string[] contentList = ConvertToArray(content);

            List<Account> accounts = new List<Account>();

            for (int i = 0; i < contentList.Length; i++)
            {
                if (contentList[i].StartsWith("-") && (i + 3) < contentList.Length - 1)
                {
                    if (contentList[i + 1].StartsWith(".U") && contentList[i + 2].StartsWith(".P") && contentList[i + 3].StartsWith("-"))
                    {
                        string username = contentList[i + 1].Substring(2, (contentList[i + 1].Length - 1) - 1);
                        string password = contentList[i + 2].Substring(2, (contentList[i + 2].Length - 1) - 1);

                        username = username.Trim();
                        password = password.Trim();
                        accounts.Add(new Account(username, password));
                    }
                    else
                    {
                        throw new InvalidUserFileFormatException();
                    }
                }
            }
            return accounts;
        }

        private Account GetAccountByUsername(string username)
        {
            foreach (var item in Accounts)
            {
                if (item.Username.Equals(username))
                    return item;
            }

            return null;
        }

        private void AddAccountInUserFile(Account account)
        {
            string context;

            context = ReadUserFile(Path);

            string[] contextList = ConvertToArray(context);
          
            using (StreamWriter writer = new StreamWriter(Path))
            {
                writer.Write(context);

                if (!contextList[contextList.Length - 2].Equals("-"))
                    writer.WriteLine("-");

                writer.WriteLine($".U {account.Username}");
                writer.WriteLine($".P {account.Password}");
                writer.WriteLine("-");
            }

            Accounts = GetAccountsInUserfile(Path);
        }

        private static IEnumerable<Tuple<T, int>> Count<T>(IEnumerable<T> source)
        {
            var counter = new Dictionary<T, int>();

            foreach (var s in source)
            {
                if (counter.ContainsKey(s))
                    counter[s]++;
                else
                    counter.Add(s, 1);

                yield return Tuple.Create(s, counter[s]);
            }
        }

        private static bool CheckDistinct<T>(IEnumerable<T> source)
        {
            IEnumerable<Tuple<T, int>> sourceCount = Count(source);

            foreach (var item in sourceCount)
            {
                if (item.Item2 > 1)
                    return true;
            }

            return false;
        }
    }
}
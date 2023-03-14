using ShopMnagementSystem.Screens;
using ShopMnagementSystem.Screens.Accounts;
using ShopMnagementSystem.Screens.Accounts.Clients_Accounts;
using ShopMnagementSystem.Screens.Accounts.Company_Accounts;
using ShopMnagementSystem.Screens.Accounts.Company_Accounts.Company_Borrow;
using ShopMnagementSystem.Screens.Accounts.Employees;
using ShopMnagementSystem.Screens.Accounts.Expenditures;
using ShopMnagementSystem.Screens.Accounts.Purchase_Accounts;
using ShopMnagementSystem.Screens.Accounts.Sale_Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShopMnagementSystem
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LoginForm());

        }
    }
}

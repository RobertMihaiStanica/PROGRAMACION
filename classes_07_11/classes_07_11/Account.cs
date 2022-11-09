using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace classes_07_11
{
    internal class Account
    {
        string holder;
        double quantity;
        
        public Account(string holder, double quantity)
        {
            this.holder = holder;

            if (quantity < 0)
            {
                quantity = 0;
            } 
            else
            {
                this.quantity = quantity;
            }
        }

        public Account(string holder)
        {
            this.holder = holder;
            quantity = 0;
        }

        public string GetHolder()
        {
            return holder;
        }

        public double GetQuantity()
        {
            return quantity;
        }

        public void SetHolder(string name)
        {
            holder = name;
        }

        public void SetQuantity(double quantity)
        {
            if (quantity < 0)
            {
                quantity = 0;
            }
            else
            {
                this.quantity = quantity;
            }
        }
        public bool Deposit(double quantity)
        {
            if (quantity < 0)
            {
                quantity = 0;
                return false;
            }
            else
            {
                this.quantity += quantity;
                return true;
            }
        }
        public bool Withdraw(double quantity)
        {
            if (quantity < 0)
            {
                return false;
            }
            else if (this.quantity - quantity >= 0)
            {
                this.quantity -= quantity;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GroceryCo.Services;

namespace GroceryCo.Presentation
{
    class Program
    {
        static void Main(string[] args)
        {
            var svc = new CheckoutService();
            svc.DoCheckout();
        }
    }
}

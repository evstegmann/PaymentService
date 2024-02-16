using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentService.Entities.Services
{
    interface IPaymentService
    {
        public double CalculatePayment(double amount, double value);
    }
}

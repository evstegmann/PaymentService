using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentService.Entities.Services
{
    class PayPalPaymentService : IPaymentService
    {
        public double CalculatePayment(double value, double installments)
        {
            double amount = ((value * 0.01) * installments) + value;

            amount += amount * 0.02;

            return amount;

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PaymentService.Entities.Exceptions;

namespace PaymentService.Entities.Services
{
    class ContractService
    {

        private IPaymentService _paymentService;
        public ContractService(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        public void ProcessContract(Contract contract,DateTime date, double quantity)
        {
            if (quantity == 0)
            {
                throw new DomainException("Error: 0 is not allowed");
            }

            double value = contract.TotalValue / quantity;
            
            for (int i = 1; i <= quantity; i++)
            {
                DateTime dueDate = date.AddMonths(i);                
                double amount = _paymentService.CalculatePayment(value, i);
                contract.AddContract(new Installment(dueDate, amount));
            }
        }

    }
}

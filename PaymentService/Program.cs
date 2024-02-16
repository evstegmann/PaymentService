using System;
using System.Globalization;
using PaymentService.Entities;
using PaymentService.Entities.Exceptions;
using PaymentService.Entities.Services;

namespace PaymentService
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Enter contract data: ");
                Console.Write("Number: ");
                int number = int.Parse(Console.ReadLine());
                Console.Write("Date (dd/MM/yyyy): ");
                DateTime date = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                double value = 0.0;
                do
                {
                    Console.Write("Contract value: ");
                    value = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                }
                while (value == 0);

                Console.Write("Enter number of installments: ");
                int installments = int.Parse(Console.ReadLine());

                Contract contract = new Contract(number, date, value);
                ContractService service = new ContractService(new PayPalPaymentService());

                service.ProcessContract(contract, date, installments);

                foreach (Installment i in contract.Installments)
                {
                    Console.WriteLine(i);
                }

            }

            catch (FormatException)
            {
                Console.WriteLine("Error: incorrect format");
            }

            catch (DomainException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
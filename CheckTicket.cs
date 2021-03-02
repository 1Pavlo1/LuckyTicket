using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuckyTicket
{
    public class CheckTicket
    {
        public void CheckYourLuck()
        {
            while(true)
            {
                var ticketNumber = PrintNumber();

                while (ticketNumber.Length > 8 || ticketNumber.Length < 4 || !int.TryParse(ticketNumber, out var convertedNumber) || convertedNumber < 0)
                {
                    Console.WriteLine("Ticket number must have from 4 to 8 positive digits. Check it once again.");
                    ticketNumber = PrintNumber();
                }

                var ticketNumberParts = SeparateString(ticketNumber);

                var firstPartSum = CountSum(int.Parse(ticketNumberParts[0]));
                var secondPartSum = CountSum(int.Parse(ticketNumberParts[1]));

                if (firstPartSum == secondPartSum)
                    Console.WriteLine("Congratulation!!! This ticket is lucky.");
                else
                    Console.WriteLine("Sorry, not this time. Check another ticket.");
            }  
        }

        private string PrintNumber()
        {
            Console.WriteLine("Type your ticket number:");
            var ticketNumber = Console.ReadLine();
            return ticketNumber;
        }

        private string[] SeparateString(string ticketNumber)
        {
            if (ticketNumber.Length % 2 != 0)
                ticketNumber = ticketNumber.Insert(0, "0");

            var firstPart = ticketNumber.Substring(0, ticketNumber.Length / 2);
            var secondPart = ticketNumber.Substring(ticketNumber.Length / 2, ticketNumber.Length / 2);

            return new string[] { firstPart, secondPart };
        }
        private int CountSum(int number)
        {
            var sum = 0;

            while(number > 0)
            {
                sum += number % 10;
                number /= 10;
            }
            return sum;
        }
    }
}

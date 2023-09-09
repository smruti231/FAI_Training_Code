using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAssignment1
    {
    public class Item
        {
        public int Id { get; set; }
        public string Particulars { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }

        public decimal TotalAmount => UnitPrice * Quantity;
        }

    public class Bill
        {
        public int BillNo { get; set; }
        public DateTime BillDate { get; set; }
        public string BillHolder { get; set; }
        public List<Item> Items { get; set; } = new List<Item>();

        public decimal TotalBillAmount
            {
            get
                {
                decimal totalAmount = 0;
                foreach (var item in Items)
                    {
                    totalAmount += item.TotalAmount;
                    }
                return totalAmount;
                }
            }
        }


    class BillCustomer
        {
        static void Main(string[] args)
            {
            Console.Write("Enter Bill Number: ");
            int billNo = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Bill Date (yyyy-MM-dd): ");
            DateTime billDate = DateTime.Parse(Console.ReadLine());

            Console.Write("Enter Bill Holder Name: ");
            string billHolder = Console.ReadLine();

            Bill bill = new Bill
                {
                BillNo = billNo,
                BillDate = billDate,
                BillHolder = billHolder
                };

            Console.WriteLine("\nEnter Item Details:");
            while (true)
                {
                Console.Write("Enter Item ID (0 to finish): ");
                int itemId = Convert.ToInt32(Console.ReadLine());
                if (itemId == 0)
                    {
                    break;
                    }

                Console.Write("Enter Item Particulars: ");
                string itemParticulars = Console.ReadLine();

                Console.Write("Enter Unit Price: ");
                decimal unitPrice = Convert.ToDecimal(Console.ReadLine());

                Console.Write("Enter Quantity: ");
                int quantity = Convert.ToInt32(Console.ReadLine());

                bill.Items.Add(new Item { Id = itemId, Particulars = itemParticulars, UnitPrice = unitPrice, Quantity = quantity });
                }

            Console.WriteLine($"\nBill No: {bill.BillNo}");
            Console.WriteLine($"Bill Date: {bill.BillDate.ToShortDateString()}");
            Console.WriteLine($"Bill Holder: {bill.BillHolder}");
            Console.WriteLine("\nItemized Billing:");
            Console.WriteLine("ID  Particulars  Unit Price  Quantity  Total Amount");

            foreach (var item in bill.Items)
                {
                Console.WriteLine($"{item.Id,-3} {item.Particulars,-12} {item.UnitPrice,-10:C} {item.Quantity,-9} {item.TotalAmount:C}");
                }

            Console.WriteLine($"\nTotal Bill Amount: {bill.TotalBillAmount:C}");
            }
        }
    }
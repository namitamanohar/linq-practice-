using System;
using System.Collections.Generic;
using System.Linq;

namespace linq {
    class Program {
        static void Main (string[] args) {
            // Restriction/Filtering Operations
            // Find the words in the collection that start with the letter 'L'
            List<string> fruits = new List<string> () { "Lemon", "Apple", "Orange", "Lime", "Watermelon", "Loganberry" };

            var LFruits = fruits.Where (fruit => {
                return fruit.StartsWith ("L");
            });

            foreach (var fruit in LFruits) {
                // Console.WriteLine (fruit);
            }
            // Which of the following numbers are multiples of 4 or 6
            List<int> numbers = new List<int> () {
                15,
                8,
                21,
                24,
                32,
                13,
                30,
                12,
                7,
                54,
                48,
                4,
                49,
                96
            };

            IEnumerable<int> fourSixMultiples = numbers.Where (number => {
                return number % 4 == 0 || number % 6 == 0;
            }).ToList ();

            foreach (var item in fourSixMultiples) {
                // Console.WriteLine (item);
            }
            // Ordering Operations 
            // Order these student names alphabetically, in descending order (Z to A)
            List<string> names = new List<string> () {
                "Heather",
                "James",
                "Xavier",
                "Michelle",
                "Brian",
                "Nina",
                "Kathleen",
                "Sophia",
                "Amir",
                "Douglas",
                "Zarley",
                "Beatrice",
                "Theodora",
                "William",
                "Svetlana",
                "Charisse",
                "Yolanda",
                "Gregorio",
                "Jean-Paul",
                "Evangelina",
                "Viktor",
                "Jacqueline",
                "Francisco",
                "Tre"
            };

            var ZtoANames = names.OrderByDescending (name => name).ToList ();
            foreach (var name in ZtoANames) {
                // Console.WriteLine (name);
            }
            // Build a collection of these numbers sorted in ascending order
            List<int> numbers2 = new List<int> () {
                15,
                8,
                21,
                24,
                32,
                13,
                30,
                12,
                7,
                54,
                48,
                4,
                49,
                96
            };
            var sortedNumbers = numbers2.OrderBy (num => num).ToList ();

            foreach (var number in sortedNumbers) {
                // Console.WriteLine (number);
            }
            // Aggregate Operations
            // Output how many numbers are in this list
            List<int> numbers3 = new List<int> () {
                15,
                8,
                21,
                24,
                32,
                13,
                30,
                12,
                7,
                54,
                48,
                4,
                49,
                96
            };

            var numberCount = numbers3.Count ();

            // Console.WriteLine (numberCount);

            // How much money have we made?
            List<double> purchases = new List<double> () {
                2340.29,
                745.31,
                21.76,
                34.03,
                4786.45,
                879.45,
                9442.85,
                2454.63,
                45.65
            };

            var moneyMade = purchases.Sum ();
            // Console.WriteLine (moneyMade);
            // What is our most expensive product?
            List<double> prices = new List<double> () {
                879.45,
                9442.85,
                2454.63,
                45.65,
                2340.29,
                34.03,
                4786.45,
                745.31,
                21.76
            };
            var mostExpensiveItem = prices.Max ();
            // Console.WriteLine (mostExpensiveItem);

            // Partioning Operators 
            List<int> wheresSquaredo = new List<int> () {
                66,
                12,
                8,
                27,
                82,
                34,
                7,
                50,
                19,
                46,
                81,
                23,
                30,
                4,
                68,
                14
            };

            var squareRoot = wheresSquaredo.TakeWhile (
                number => number % Math.Sqrt (number) != 0
            );

            foreach (var item in squareRoot) {
                // Console.WriteLine (item);
            }
            // Using Custom Types 
            List<Customer> customers = new List<Customer> () {
                new Customer () { Name = "Bob Lesman", Balance = 80345.66, Bank = "FTB" },
                new Customer () { Name = "Joe Landy", Balance = 9284756.21, Bank = "WF" },
                new Customer () { Name = "Meg Ford", Balance = 487233.01, Bank = "BOA" },
                new Customer () { Name = "Peg Vale", Balance = 7001449.92, Bank = "BOA" },
                new Customer () { Name = "Mike Johnson", Balance = 790872.12, Bank = "WF" },
                new Customer () { Name = "Les Paul", Balance = 8374892.54, Bank = "WF" },
                new Customer () { Name = "Sid Crosby", Balance = 957436.39, Bank = "FTB" },
                new Customer () { Name = "Sarah Ng", Balance = 56562389.85, Bank = "FTB" },
                new Customer () { Name = "Tina Fey", Balance = 1000000.00, Bank = "CITI" },
                new Customer () { Name = "Sid Brown", Balance = 49582.68, Bank = "CITI" }
            };

            var millionares = customers.Where (millionare => {
                return millionare.Balance >= 1000000;
            }).ToList ();

            var bankBreakDown = millionares.GroupBy (ind => ind.Bank)
                .Select (group => {
                    return new BankReport {
                    CustomerCount = group.Count (),
                    Bank = group.Key
                    };

                });
            foreach (var bank in bankBreakDown) {
                //    bank is a class 
                Console.WriteLine ($"Bank Name: {bank.Bank} Number of Millionares {bank.CustomerCount} ");

            }
        }
    }
    public class BankReport {

        public int CustomerCount { get; set; }
        public string Bank { get; set; }

    }
}
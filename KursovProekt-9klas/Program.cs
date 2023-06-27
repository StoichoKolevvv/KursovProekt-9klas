using System.IO;

namespace CarParts
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WindowWidth = 180;

            // ----------------- STAGE 1 -----------------

            // -- 1.1 --
            Console.WriteLine("Въведи количество на частите: ");
            int count = int.Parse(Console.ReadLine());


            List<Parts> list = new List<Parts>();


            for (int i = 0; i < count; i++)
            {
                Console.WriteLine("Въведете данните за частите, разделени с разтояние в следния ред (Тип на частите, Марка кола на която съответстват, Количество, Цена за единица, Мерна единица) : ");
                string partInfo = Console.ReadLine();
                string[] dataTokens = partInfo.Split(' ');

                string type = dataTokens[0];
                string carBrand = dataTokens[1];
                int quantity = int.Parse(dataTokens[2]);
                decimal pricePerUnit = decimal.Parse(dataTokens[3]);
                int unit = int.Parse(dataTokens[4]);


                Parts tmp = new Parts
                {
                    Type = type,
                    CarBrand = carBrand,
                    Quantity = quantity,
                    UnitPrice = pricePerUnit,
                    Unit = unit,
                };
                list.Add(tmp);


            }
            Console.Clear();

            // -- 1.2 --
            list.ForEach(part => Console.WriteLine(part.ToString()));
            Console.ReadKey();
            Console.Clear();


            //  ----------------- STAGE 2 -----------------


            // -- 2.1 --
            Console.WriteLine("Търсене на част по име: ");
            string searchByName = Console.ReadLine();
            var searchResults = list.Where(part => part.Type == searchByName);


            foreach (var part in searchResults)
            {
                Console.WriteLine($"Намерена част: Тип: {part.Type} Марка: {part.CarBrand} Количество: {part.Quantity} Цена за единица: {part.UnitPrice} Мерна единица: {part.Unit}");
            }
            Console.ReadKey();
            Console.Clear();

            // -- 2.2 --
            list.Where(part => part.Quantity == 0).ToList().ForEach(part => Console.WriteLine($"Намерена част с количество 0: Тип: {part.Type} Марка: {part.CarBrand} Количество: {part.Quantity} Цена за единица: {part.UnitPrice} Мерна единица: {part.Unit}"));
            Console.ReadKey();
            Console.Clear();

            // -- 2.3 --
            Console.WriteLine("Въведете име на частта, която искате да актуализирате: ");
            string searchByName2 = Console.ReadLine();

            bool found = false;

            foreach (var part in list)
            {
                if (part.Type == searchByName2)
                {
                    Console.WriteLine($"Намерена част: Тип: {part.Type} Марка: {part.CarBrand} Количество: {part.Quantity} Цена за единица: {part.UnitPrice} Мерна единица: {part.Unit}");

                    Console.WriteLine("Въведете нови данни за частта (Тип на частта, Марка на колата, Количество, Цена за единица, Мерна единица): ");
                    string partInfo = Console.ReadLine();
                    string[] dataTokens = partInfo.Split(' ');

                    part.Type = dataTokens[0];
                    part.CarBrand = dataTokens[1];
                    part.Quantity = int.Parse(dataTokens[2]);
                    part.UnitPrice = decimal.Parse(dataTokens[3]);
                    part.Unit = int.Parse(dataTokens[4]);

                    Console.WriteLine("Частта е успешно актуализирана.");
                    found = true;
                    break;
                }
            }

            if (!found)
            {
                Console.WriteLine("Част с това име не е намерена.");
            }
            Console.ReadKey();
            Console.Clear();

            // -- 2.4 --

            Console.WriteLine("Въведете име на частта, която искате да изтриете: ");
            string searchByName3 = Console.ReadLine();

            var partToDelete = list.FirstOrDefault(part => part.Type == searchByName3);

            if (partToDelete != null)
            {
                list.Remove(partToDelete);
                Console.WriteLine("Частта е успешно изтрита.");
            }
            else
            {
                Console.WriteLine("Част с това име не е намерена.");
            }
            Console.ReadKey();
            Console.Clear();


            //  ----------------- STAGE 3 -----------------


            // -- 3.1 --
            decimal averageQuantity = (decimal)list.Where(part => part.Quantity > 0).Average(part => part.Quantity);

            if (averageQuantity > 0)
            {
                Console.WriteLine($"Средно количество на наличните части: {averageQuantity}");
            }
            else
            {
                Console.WriteLine("Няма налични части.");
            }
            Console.ReadKey();
            Console.Clear();

            //  -- 3.2 --
            Parts mostExpensivePart = list.OrderByDescending(part => part.UnitPrice).FirstOrDefault();

            if (mostExpensivePart != null)
            {
                Console.WriteLine($"Най-скъпата част: Тип: {mostExpensivePart.Type} Марка: {mostExpensivePart.CarBrand} Количество: {mostExpensivePart.Quantity} Цена за единица: {mostExpensivePart.UnitPrice} Мерна единица: {mostExpensivePart.Unit}");
            }
            else
            {
                Console.WriteLine("Няма налични части.");
            }
            Console.ReadKey();
            Console.Clear();

            // -- 3.3 --
            Console.WriteLine("Въведете марка на колата, по която да намерите най-евтината част: ");
            string searchBrand = Console.ReadLine();

            Parts cheapestPart = list.Where(part => part.CarBrand == searchBrand).OrderBy(part => part.UnitPrice).FirstOrDefault();

            if (cheapestPart != null)
            {
                Console.WriteLine($"Най-евтината част за марка {searchBrand}: Тип: {cheapestPart.Type} Количество: {cheapestPart.Quantity} Цена за единица: {cheapestPart.UnitPrice} Мерна единица: {cheapestPart.Unit}");
            }
            else
            {
                Console.WriteLine($"Няма налична част за марка {searchBrand}.");
            }
            Console.ReadKey();
            Console.Clear();

            // -- 3.4 --
            List<Parts> sortedParts = list.OrderByDescending(part => part.Quantity).ToList();

            foreach (var part in sortedParts)
            {
                Console.WriteLine($"Тип: {part.Type} Марка: {part.CarBrand} Количество: {part.Quantity} Цена за единица: {part.UnitPrice} Мерна единица: {part.Unit}");
            }

        }
    }
}
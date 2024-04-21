using System.Drawing;

namespace HratkySCisly;

internal class Program {
    static void Main(string[] args) {
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("Program pro převod kladného desetinného čísla jako součet mocnin čísla (-2).\r\n");
        Console.Write("Zadejte kladné číslo (max 6 cifer před i za desetinnou čárkou): ");

        try
        {
            string input = Console.ReadLine().Replace(',', '.');

            int maxLength = 6;

            // Ošetření záporného čísla
            if (double.Parse(input) < 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Zadané číslo nesmí být záporné. Program se ukončí.");
                Console.ForegroundColor = ConsoleColor.White;
                Console.ReadKey();
                Environment.Exit(0);
            }

            // Ošetření délky čísla
            if (input.Contains('.')) {
                if (input.Split('.')[0].Length > maxLength || input.Split('.')[1].Length > maxLength)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Zadané číslo nesplňuje formát. Pouze 6 míst před i za desetinnou čárkou. Program se ukončí.");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.ReadKey();
                    Environment.Exit(0);
                }
            } else if (input.Length > maxLength)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Zadané číslo nesplňuje formát. Pouze 6 míst před i za desetinnou čárkou. Program se ukončí.");
                Console.ForegroundColor = ConsoleColor.White;
                Console.ReadKey();
                Environment.Exit(0);
            }

            double numberInput = double.Parse(input);

            // Vypíše výsledek pomocí převodní metody
            Console.WriteLine($"\r\nVýsledek: {Convertor(numberInput)}");
        }
        catch (Exception e)
        {
            Console.WriteLine($"Chyba: {e.Message}");
        }

        Console.ReadKey();
    }

    private static string Convertor(double number)
    {
        // Oddělené kvůli desetinné čárce a celočíselným výsledkům
        string result = "";
        string resultDecimals = "";

        for (int i = 30; i > -11; i--)
        {
            // Porovnává, zda se po odečtení mocniny přiblíží k nule nebo se dostane na nulu - zapíše 1
            if (Math.Abs(number - Math.Pow(-2, i)) <= Math.Abs(number)) {
                number -= Math.Pow(-2, i);

                if (i >= 0)
                    result += "1";
                else
                    resultDecimals += "1";
            }
            else {
                if (i >= 0)
                    result += "0";
                else
                    resultDecimals += "0";
            }
        }

        // Ořezávání nul na začátku a na konci čísla
        result = result.TrimStart('0');
        if (result == "")
            result = "0";

        if (Convert.ToInt32(resultDecimals) != 0)
            result += $".{resultDecimals.TrimEnd('0')}";

        return result;
    }
}

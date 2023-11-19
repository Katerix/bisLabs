class LargeNumbers
{
    static string AddLargeNumbers(string num1, string num2)
    {
        int maxLen = Math.Max(num1.Length, num2.Length);
        num1 = num1.PadLeft(maxLen, '0');
        num2 = num2.PadLeft(maxLen, '0');

        List<int> result = new List<int>();
        int carry = 0;

        for (int i = maxLen - 1; i >= 0; i--)
        {
            int digit1 = num1[i] - '0';
            int digit2 = num2[i] - '0';

            int total = digit1 + digit2 + carry;
            carry = total / 10;

            result.Add(total % 10);
        }

        if (carry > 0) result.Add(carry);

        result.Reverse();

        return string.Join("", result);
    }

    static string MultiplyLargeNumbers(string num1, string num2)
    {
        num1 = new string(num1.ToCharArray(), 0, num1.Length);
        num2 = new string(num2.ToCharArray(), 0, num2.Length);

        int[] result = new int[num1.Length + num2.Length];

        for (int i = num1.Length - 1; i >= 0; i--)
        {
            for (int j = num2.Length - 1; j >= 0; j--)
            {
                int digit1 = num1[i] - '0';
                int digit2 = num2[j] - '0';

                int product = digit1 * digit2;
                result[i + j] += product;
                result[i + j + 1] += result[i + j] / 10;
                result[i + j] %= 10;
            }
        }

        while (result.Length > 1 && result[result.Length - 1] == 0)
        {
            Array.Resize(ref result, result.Length - 1);
        }

        return string.Join("", result);
    }

    static string SquareLargeNumber(string num) => MultiplyLargeNumbers(num, num);

    static int CalculateModulusRemainder(string number, int modulus)
    {
        int result = 0;

        for (int i = 0; i < number.Length; i++)
        {
            result = (result * 10 + (number[i] - '0')) % modulus;
        }

        return result;
    }

    static void Main()
    {
        while (true)
        {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine("Choose action:");
            Console.WriteLine("1. +");
            Console.WriteLine("2. *");
            Console.WriteLine("3. pow2");
            Console.WriteLine("4. %");
            Console.WriteLine("5. exit");
            Console.Write("Enter action number (1-5): ");

            string choice = Console.ReadLine(); string num1, num2, result;

            switch (choice)
            {
                case "1":
                        Console.Write("First large number: ");
                        num1 = Console.ReadLine();
                        Console.Write("Second large number: ");
                        num2 = Console.ReadLine();
                        result = AddLargeNumbers(num1, num2);
                        Console.WriteLine("result(+): " + result);
                    break;

                case "2":
                        Console.Write("First large number: ");
                        num1 = Console.ReadLine();
                        Console.Write("Second large number: ");
                        num2 = Console.ReadLine();
                        result = MultiplyLargeNumbers(num1, num2);
                        Console.WriteLine("result(*): " + result);
                    break;

                case "3":
                        Console.Write("Large number: ");
                        num1 = Console.ReadLine();
                        result = SquareLargeNumber(num1);
                        Console.WriteLine("result(pow2): " + result);
                    break;

                case "4":
                        Console.Write("Large number: ");
                        num1 = Console.ReadLine();
                        Console.Write("Enter modulus: ");
                        int module = int.Parse(Console.ReadLine());
                        int Result = CalculateModulusRemainder(num1, module);
                        Console.WriteLine("result(%): " + Result);
                    break;

                case "5": Console.WriteLine("exited.");
                    break;

                default: Console.WriteLine("Wrong input, try again:");
                    continue;
            };

            Console.Write("To continue, press Enter: ");
            string anotherCalculation = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(anotherCalculation))
            {
                Console.WriteLine("exited.");
                break;
            }
        }
    }
}
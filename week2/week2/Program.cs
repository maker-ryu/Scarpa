// 2-1 구구단 출력하기

// class Program
// {
//     static void Main()
//     {
//         for(int i = 1; i <= 9; i++)
//         {
//             for (int j = 1; j <= 9; j++)
//             {
//                 Console.WriteLine($"{i} x {j} = {i * j}");
//             }
//         }
//     }
// }

// 2-2 별 찍기

// class Program
// {
//     static void FirstTriangle()
//     {
//         for (int i = 1; i <= 5; i++)
//         {
//             for (int j = 1; j <= i; j++)
//             {
//                 Console.Write("*");
//             }
//             Console.WriteLine();
//         }
//     }
//
//     static void SecondTriangle()
//     {
//         for (int i = 1; i <= 5; i++)
//         {
//             for (int j = 5; j >= i; j--)
//             {
//                 Console.Write("*");
//             }
//             Console.WriteLine();
//         }
//     }
//
//     static void ThirdTriangle()
//     {
//         for (int i = 5; i >= 0; i--)
//         {
//             for (int j = 1; j <= i; j++)
//             {
//                 Console.Write(" ");
//             }
//             for (int j = 1; j <= 9 - 2 * i; j++)
//             {
//                 Console.Write("*");
//             }
//             for (int j = 1; j <= i; j++)
//             {
//                 Console.Write(" ");
//             }
//             Console.WriteLine();
//         }
//     }
//     
//     static void Main()
//     {
//         // FirstTriangle();
//         // SecondTriangle();
//         ThirdTriangle();
//     }
// }

// 2-3 최대값, 최소값 찾기

class Program
{
    static void Main()
    {
        int[] numbers = new int[100]; // { 60, 30, 20, 50, 40, 10 }; 
        int howManyNum = 0;

        Console.WriteLine("Enter 'q' to Quiet");
        while (true)
        {
            string temp = Console.ReadLine();
        
            if (temp == "q")
            {
                break;
            }
            
            numbers[howManyNum] = int.Parse(temp);
            howManyNum++;
        }
        
        // 60 30 20 50 40

        for (int i = 0; i < howManyNum; i++)
        {
            // int index = 0;
            for (int j = i + 1; j < howManyNum; j++)
            {
                if (numbers[i] > numbers[j])
                {
                    int temp = numbers[i];
                    numbers[i] = numbers[j];
                    numbers[j] = temp;
                }
            }
        }
        
        Console.WriteLine($"최대값: {numbers[howManyNum - 1]}");
        Console.WriteLine($"최소값: {numbers[0]}");

        // foreach (int num in numbers)
        // {
        //     Console.Write(num + " ");
        // }
    }
}


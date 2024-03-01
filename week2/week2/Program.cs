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

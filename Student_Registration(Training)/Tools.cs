using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Registration_Training_
{
    public class Tools
    {
        public static string TakeName(string Text)
        {
        takeinput:
            Console.Write(Text);
            string input = Console.ReadLine().Trim();

        check2space:
            if (input.IndexOf("  ") > -1)
            {
                input.Replace("  ", " ");
                goto check2space;
            }

            if (input.Length > 30)
            {
                Console.WriteLine("it's a too long name, Please try again.");
            }


            #region Input Checking

            string[] inputs = input.Split(' ');

            for (int i = 0; i < inputs.Length; i++)
            {
                if (CheckSpecialCharacter(inputs[i]) == false)
                {
                    Console.WriteLine("You used special character. Please try again.");
                    goto takeinput;
                }
                if (inputs[i].Length < 2)
                {
                    Console.WriteLine("Names must be at least 2 letters, Please try again");
                    goto takeinput;
                }

                inputs[i] = CapitalizeFirstLetter(inputs[i]);
            }
            #endregion

            input = string.Join(" ", inputs);

            return input;
        }

        public static bool CheckSpecialCharacter(string txt)
        {
            #region Checking Special Character 

            for (int i = 0; i < txt.Length; i++)
            {
                if (char.IsLetter(txt[i]) == false)
                {
                    return false;
                }
            }
            #endregion

            return true;
        }

        public static string CapitalizeFirstLetter(string txt)
        {
            return txt.Substring(0, 1).ToUpper() + txt.Substring(1).ToLower();
        }

        public static int TakeInt(string txt)
        {
        TakeAgain:
            Console.Write(txt);
            string input = Console.ReadLine();

            if (!int.TryParse(input, out int x))
            {
                Console.WriteLine("Invalid input, Please try again.");
                goto TakeAgain;
            }

            return x;
        }

        public static int TakeAge(string txt)
        {
        
        TakeAgain:
            Console.Write(txt);
            string input = Console.ReadLine();

            if (!int.TryParse(input, out int x))
            {
                Console.WriteLine("Invalid input, Please try again.");
                goto TakeAgain;
            }

            if (x > 30 || x < 8)
            {
                Console.WriteLine("Student's age must be between 9 - 29");
                goto TakeAgain;
            }

            return x;
        }

        public static Student.BRANCH TakeBranch()
        {

            //Empty,
            //Science,
            //Math,
            //Language,
            //History
            Console.WriteLine("Please Enter Student's Branch");
            Console.WriteLine();
            Console.WriteLine("for Science (s)");
            Console.WriteLine("for Math (m)");
            Console.WriteLine("for Language (l)");
            Console.WriteLine("for History (h)");

            TakeAgain:
            Console.Write("Input: ");
            string input = Console.ReadLine().ToLower().Trim();

            switch (input)
            {
                case "s":
                    Console.WriteLine("Selected \"Science\"");
                    return Student.BRANCH.Science;
                case "m":
                    Console.WriteLine("Selected \"Math\"");
                    return Student.BRANCH.Math;
                case "l":
                    Console.WriteLine("Selected \"Language\"");
                    return Student.BRANCH.Language;
                case "h":
                    Console.WriteLine("Selected \"History\"");
                    return Student.BRANCH.History;
                
                default:
                    Console.WriteLine("Invalid input, Please try again.");
                    goto TakeAgain;
            }
        }

        public static void Loading(string load,string finish,int repeat,int time)
        {
            Console.WriteLine();
            Console.SetCursorPosition(0,Console.CursorTop);

            // " | = Cursor "
            Console.Write(load);//loading|

            for (int i = 0; i < repeat; i++)
            {
                Console.Write(".");//loading.|
                System.Threading.Thread.Sleep(time);//wait
                Console.Write(".");//loading..|
                System.Threading.Thread.Sleep(time);//wait
                Console.Write(".");//loading...|
                System.Threading.Thread.Sleep(time);//wait

                Console.SetCursorPosition(Console.CursorLeft - 3, Console.CursorTop);//loading|...
                Console.Write("   ");//loading   |
                Console.SetCursorPosition(Console.CursorLeft - 3, Console.CursorTop);//loading|...
                if (i < repeat - 1)
                {
                    System.Threading.Thread.Sleep(time);
                }
            }
            Console.SetCursorPosition(0, Console.CursorTop);//|
            Console.Write("                    ");//deleting it for possible problems 
            Console.SetCursorPosition(0, Console.CursorTop);//|

            Console.Write(finish);//successfully loaded
            System.Threading.Thread.Sleep(time * 2);//wait

            Console.Write("                                    ");//deleting it for possible problems 
        }

    }
}

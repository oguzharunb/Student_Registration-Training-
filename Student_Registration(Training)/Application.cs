using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Registration_Training_
{
    public class Application
    {

        /*
        öğrenci ekle
        öğrenci sil
        {
            lütfen silmek istediğiniz Adını Giriniz
        } 


         */


        #region Defining
        public static List<Student> StudentList = new List<Student>();
        public static int OrderNumber = 1;
        #endregion

        public void App()
        {
            //Application.StudentList = Application.StudentList.OrderBy(x => x.FirstName).ToList();

            AddFakeDataToList();
        Again:
            ShowMenu();
            TakeChoice();
            goto Again;
        }

        static void ShowMenu()
        {
            Console.WriteLine("to Add a New Student (n)");
            Console.WriteLine("to See Student List (s)");
            Console.WriteLine("to Delete a Student (r)");
            Console.WriteLine("to Exiting the System (x)");
            Console.WriteLine("to Clear the Console (c)");
        }

        static void TakeChoice()
        {
        TakeChoice:
            #region TakeInput
            Console.Write("Input: ");
            string choice = Console.ReadLine().Trim().ToLower();
            #endregion

            switch (choice)
            {
                case "n":
                    AddStudent();
                    break;
                case "s":
                    ShowStudentList(StudentList);
                    break;
                case "r":
                    DeleteStudent();
                    break;
                case "x":
                    System.Environment.Exit(0);
                    break;
                case "c":
                    Console.Clear();
                    break;
                default:
                    Console.WriteLine("Invalid input, Please try again.");
                    goto TakeChoice;
            }


        }

        static void AddStudent()
        {

            #region Welcome
            Console.WriteLine();
            Console.WriteLine("Student Registration");
            Console.WriteLine("------------------------------");
            #endregion

            #region Taking datas from user
            string studentfirstname = Tools.TakeName("Please Enter Student's First Name: ");
            string studentlastname = Tools.TakeName("Please Enter Student's Last Name: ");
            int studentage = Tools.TakeAge("Please Enter Student's Age: ");
            Student.BRANCH studentbranch = Tools.TakeBranch();
            #endregion

            #region Registering Student to System
            StudentList.Add(new Student(studentfirstname, studentlastname, studentbranch, studentage));
            #endregion

            #region Finish
            Console.WriteLine();
            Console.WriteLine($"Student's Number: {Application.OrderNumber - 1}");
            Tools.Loading("Loading", "Student has been successfully loaded.", 2, 350);
            Console.Clear();
            #endregion


        }

        static void DeleteStudent()
        {

        #region Creating List
        TakeName:
            Console.WriteLine("Please enter the name of the student to be deleted.");
            Console.Write("Input: ");

            string wanted = Console.ReadLine().ToLower();

            List<Student> vs = StudentList.Where(item => item.FullName.ToLower().IndexOf(wanted) > -1).ToList();
            #endregion

            #region Exeptional
            if (vs.Count == 0)
            {
                Console.WriteLine("No student found with this name");
                Console.Write("Try Again ( y / n ): ");

                if (Console.ReadLine().ToLower().Trim() == "y")
                {
                    goto TakeName;
                }

                Tools.Loading("Returning", "Returned", 2, 200);
                Console.Clear();
                return;
            }

            if (vs.Count == 1)
            {
                Console.WriteLine($"There is only one person named {wanted}. Are you sure you want to delete it? (y / n)");
                Console.Write("Input: ");

                if (Console.ReadLine() == "y")
                {
                    Tools.Loading("Deleting", "Successfully deleted", 2, 300);
                    StudentList.Remove(vs[0]);
                }

                Tools.Loading("Exiting", "Successfully exited", 2, 300);
                return;

            }

            #endregion

            #region Showing List
            Console.WriteLine();
            Console.WriteLine($"{(vs.Count + 1).ToString()} people found in the name you are looking for");
            Console.WriteLine();
            ShowStudentList(vs, true);
        #endregion

        #region Finding the student to be deleted
        TakeNumber:
            Console.WriteLine("Please enter the \"No\" of the student to be deleted.");
            Console.Write("Input: ");

            string wantednumber = Console.ReadLine().ToLower().Trim();

            Student StudentTbDeleted = vs.Where(item => item.StudentNo.ToString() == wantednumber).FirstOrDefault();
            #endregion

            #region IfStudentFound
            if (StudentTbDeleted != null)
            {
                StudentList.Remove(StudentTbDeleted);
                Tools.Loading("Deleting", "Successfully deleted", 2, 300);
                Console.Clear();
                return;
            }
            #endregion

            #region IfStudentNotFound
            Console.WriteLine("No student found for this number, try again (y / n)");
            Console.Write("Input: ");

            if (Console.ReadLine().ToLower().Trim() == "y")
            {
                goto TakeNumber;
            }
            #endregion

        }

        static void ShowStudentList(List<Student> vs)
        {
            /*
             Order   Fullname  Age    Branch
             ---------------------------------------------
             */

            if (StudentList.Count == 0)
            {
                Console.WriteLine();
                Console.WriteLine("no one to list");
                System.Threading.Thread.Sleep(2000);
                Console.Clear();
                return;
            }


            Console.WriteLine("Order".PadRight(8) + "Full Name".PadRight(25) + "Age".PadRight(5) + "Branch");
            Console.WriteLine("--------------------------------------------");
            foreach (var item in vs)
            {
                Console.WriteLine(item.StudentNo.ToString().PadRight(8) + item.FullName.PadRight(25) + item.Age.ToString().PadRight(5) + item.Branch.ToString());
                System.Threading.Thread.Sleep(250);
            }

        ReturnMenu:
            System.Threading.Thread.Sleep(1500);
            Console.WriteLine();
            Console.Write("To return to the Menu (m): ");
            string boolingChoice = Console.ReadLine().Trim().ToLower();

            if (boolingChoice == "m")
            {
                Console.WriteLine();
                Tools.Loading("Loading", "Loaded", 2, 180);
                Console.Clear();
                return;
            }
            goto ReturnMenu;
        }

        static void ShowStudentList(List<Student> vs, bool x)
        {
            /*
             Order   Fullname  Age    Branch
             ---------------------------------------------
             */

            if (StudentList.Count == 0)
            {
                Console.WriteLine();
                Console.WriteLine("no one to list");
                System.Threading.Thread.Sleep(2000);
                Console.Clear();
                return;
            }

            Console.WriteLine("Order".PadRight(8) + "Full Name".PadRight(25) + "Age".PadRight(5) + "Branch");
            Console.WriteLine("--------------------------------------------");
            foreach (var item in vs)
            {
                Console.WriteLine(item.StudentNo.ToString().PadRight(8) + item.FullName.PadRight(25) + item.Age.ToString().PadRight(5) + item.Branch.ToString());
                System.Threading.Thread.Sleep(250);
            }
        }

        static void AddFakeDataToList()
        {
            StudentList.Add(new Student(FakeData.NameData.GetFirstName(), FakeData.NameData.GetSurname(), Student.BRANCH.Science, 12));
            StudentList.Add(new Student(FakeData.NameData.GetFirstName(), FakeData.NameData.GetSurname(), Student.BRANCH.Math, 21));
            StudentList.Add(new Student(FakeData.NameData.GetFirstName(), FakeData.NameData.GetSurname(), Student.BRANCH.Language, 15));
            StudentList.Add(new Student(FakeData.NameData.GetFirstName(), FakeData.NameData.GetSurname(), Student.BRANCH.History, 18));
            StudentList.Add(new Student(FakeData.NameData.GetFirstName(), FakeData.NameData.GetSurname(), Student.BRANCH.Math, 19));
        }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Registration_Training_
{
    public class Student
    {

        public string FirstName;
        public string LastName;
        public string FullName;
        public int StudentNo;
        public BRANCH Branch;
        public int Age;

        public Student()
        {

        }
        
        public Student(string firstname,string lastname,BRANCH branch,int age)
        {
            FirstName = firstname;
            LastName = lastname;
            Branch = branch;
            Age = age;
            FullName = firstname + " " + lastname;
            StudentNo = Application.OrderNumber;
            Application.OrderNumber++;
        }

        public enum BRANCH
        {
            Empty,
            Science,
            Math,
            Language,
            History
        }

    }
}

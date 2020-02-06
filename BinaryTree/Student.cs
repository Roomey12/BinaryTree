using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
{
    public class Student : IComparable<Student>
    {
        string Name { get; set; }
        string TestTitle { get; set; }
        DateTime Date { get; set; }

        private int mark;
        public int Mark
        {
            get
            {
                return mark;
            }
            set
            {
                if (mark < 0 || mark > 100)
                {
                    throw new Exception("Impossible to set this mark.");
                }
                else
                {
                    mark = value;
                }
            }
        }
        public Student(string name, string testTitle, int mark, DateTime date)
        {
            Name = name;
            TestTitle = testTitle;
            Mark = mark;
            Date = date;
        }
        public override string ToString()
        {
            return $"Name: {Name};\t TestTile: {TestTitle};\t Mark: {Mark};\t Date: {Date};";
        }
        public int CompareTo(Student s)
        {
            return this.Mark.CompareTo(s.Mark);
        }
    }

}

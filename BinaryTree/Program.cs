using BinaryTree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnotherTree
{
    class Program
    {
        public static void Message<T>(object sender, TreeEventArgs<T> e)
        {
            Console.WriteLine($"{e.Message}: {e.Element}");
        }
        static void Main(string[] args)
        {
            Student mike = new Student("mike", "math", 78, new DateTime(2019, 04, 12));
            Student joseph = new Student("joseph", "chemistry", 85, new DateTime(2019, 06, 10));
            Student alex = new Student("alex", "math", 80, new DateTime(2019, 01, 05));
            Student kevin = new Student("kevin", "chemistry", 61, new DateTime(2019, 11, 20));
            Student john = new Student("john", "biology", 90, new DateTime(2019, 06, 19));

            BinaryTree<Student> treeStudent = new BinaryTree<Student>(mike);
            //treeStudent.Added += Message;
            treeStudent.Add(joseph);
            treeStudent.Add(alex);
            treeStudent.Add(kevin);
            treeStudent.Add(john);

            foreach(var e in treeStudent)
            {
                Console.WriteLine(e);
            }

            BinaryTree<int> treeInt = new BinaryTree<int>(4);
            treeInt.Added += Message;

            treeInt.Add(6);
            treeInt.Add(7);
            treeInt.Add(3);
            treeInt.Add(8);
            treeInt.Added -= Message;
            treeInt.Add(5);
            treeInt.Add(1);
            treeInt.Add(2);

            foreach (var e in treeInt)
            {
                Console.WriteLine(e);
            }
        }
    }
}
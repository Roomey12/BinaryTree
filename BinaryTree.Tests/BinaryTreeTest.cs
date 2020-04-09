using System;
using Xunit;
using BinaryTree;
using System.Linq;

namespace BinaryTree.Tests
{
    public class BinaryTreeTest
    {
        [Fact]
        public void Add_CreateBinaryTreeIntAndAddSomeValues_ReturnSameArray()
        {
            int[] expected = new int[] { 3, 4, 6, 7, 8 };
            BinaryTree<int> treeInt = new BinaryTree<int>(4);
            treeInt.Add(6);
            treeInt.Add(7);
            treeInt.Add(3);
            treeInt.Add(8);

            int[] actual = new int[5];
            int i = 0;
            foreach(var e in treeInt)
            {
                actual[i] = e;
                i++;
            }
            
            Assert.Equal(actual, expected);
            
        }

        [Fact]
        public void Add_AddElementToTreeAndCheckIfTreeStartsWithIt_TrueReturn()
        {
            int expected = 4;
            BinaryTree<int> treeInt = new BinaryTree<int>(4);
            treeInt.Add(6);

            int actual = treeInt.First();
            Assert.Equal(actual, expected);
        }

        [Fact]
        public void HeadException_RootIsNull_ReturnHeadException()
        {
            Assert.Throws<HeadException>(() => { BinaryTree<string> treeString = new BinaryTree<string>(null); });
        }

        [Fact]
        public void Add_TreeContainsElement6_TrueReturn()
        {
            bool expected = true;
            BinaryTree<int> treeInt = new BinaryTree<int>(4);
            treeInt.Add(6);

            bool actual = treeInt.Contains(6);
            Assert.Equal(actual, expected);
        }

        [Fact]
        public void OperatorMoreThan_AnyNodeMustBeMoreThan5_TrueReturn()
        {
            bool expected = true;
            BinaryTree<int> treeInt = new BinaryTree<int>(4);
            treeInt.Add(6);

            bool actual = false; 
            foreach(var e in treeInt)
            {
                if(e > 5)
                {
                    actual = true;
                }
            }

            Assert.Equal(expected, actual);
        }
    }
}

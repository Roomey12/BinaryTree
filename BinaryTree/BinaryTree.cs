using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BinaryTree
{
    public class BinaryTree<T> : IEnumerable<T> where T : IComparable<T>
    {
        public delegate void EventTree(object sender, TreeEventArgs<T> e);

        public event EventTree Added;

        private BinaryTreeNode<T> root;
        public BinaryTree(T head)
        {
            if (head == null)
            {
                throw new HeadException("Head of binary tree can't be null!");
            }
            root = new BinaryTreeNode<T>(head);
        }
        public void Add(T value)
        {
            if (root == null)
            {
                root = new BinaryTreeNode<T>(value);
            }
            else
            {
                Add(root, new BinaryTreeNode<T>(value));
            }
            Added?.Invoke(this, new TreeEventArgs<T>(value, "A new element has been added"));
        }
        private void Add(BinaryTreeNode<T> parent, BinaryTreeNode<T> child)
        {
            if (parent > child)
            {
                if (parent.Left == null)
                {
                    parent.Left = child;
                }
                else
                {
                    Add(parent.Left, child);
                }
            }
            else
            {
                if (parent.Right == null)
                {
                    parent.Right = child;
                }
                else
                {
                    Add(parent.Right, child);
                }
            }
        }
        public IEnumerator<T> GetEnumerator()
        {
            return Traversal();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        public IEnumerator<T> Traversal()
        {
            if (root != null)
            {
                Stack<BinaryTreeNode<T>> stack = new Stack<BinaryTreeNode<T>>();
                BinaryTreeNode<T> current = root;
                bool goLeftNext = true;
                stack.Push(current);
                while (stack.Count > 0)
                {
                    if (goLeftNext)
                    {
                        while (current.Left != null)
                        {
                            stack.Push(current);
                            current = current.Left;
                        }
                    }
                    yield return current.Value;
                    if (current.Right != null)
                    {
                        current = current.Right;
                        goLeftNext = true;
                    }
                    else
                    {
                        current = stack.Pop();
                        goLeftNext = false;
                    }
                }
            }
        }
    }

    public class BinaryTreeNode<TNode> : IComparable<TNode> where TNode : IComparable<TNode>
    {
        public TNode Value { get; private set; }
        public BinaryTreeNode<TNode> Left { get; set; }
        public BinaryTreeNode<TNode> Right { get; set; }
        public BinaryTreeNode(TNode Value)
        {
            this.Value = Value;
        }
        int IComparable<TNode>.CompareTo(TNode Other)
        {
            return Value.CompareTo(Other);
        }
        public static bool operator >(BinaryTreeNode<TNode> Left, BinaryTreeNode<TNode> Right)
        {
            if (Left.Value.CompareTo(Right.Value) == 1)
            {
                return true;
            }
            else if (Left.Value.CompareTo(Right.Value) == -1 || Left.Value.CompareTo(Right.Value) == 0)
            {
                return false;
            }
            else
            {
                throw new ArgumentException();
            }
        }
        public static bool operator <(BinaryTreeNode<TNode> Left, BinaryTreeNode<TNode> Right)
        {
            return (Right > Left);
        }
    }

    public class TreeEventArgs<T>
    {
        public string Message { get; }
        public T Element { get; }
        public TreeEventArgs(T element, string message)
        {
            Element = element;
            Message = message;
        }
    }
}



/*
 * Алгоритм обхода двоичного дерева предусматривает обход всех вершин дерева только один раз.
Существуют три вида таких обходов:

Прямой порядок (англ. preorder), посещение узлов родителей до посещения узлов потомков:

Зайти в корень.
Зайти в левое поддерево.
Зайти в правое поддерево.
Обратный порядок (англ. postorder), посещение узлов потомков до посещения узлов их родителей:

Зайти в левое поддерево.
Зайти в правое поддерево.
Зайти в корень.
Симметричный порядок(англ. inorder):

Зайти в левое поддерево.
Зайти в корень.
Зайти в правое поддерево.
Прямой порядок
Порядок следования при прямом обходе дерева: 4, 2, 1, 3, 5, 7, 6, 8

Обратный порядок
Порядок следования при обратном обходе дерева: 1, 3, 2, 6, 8, 7, 5, 4

Симметричный порядок
Порядок следования при обратном обходе дерева: 1, 2, 3, 4, 5, 6, 7, 8
*/
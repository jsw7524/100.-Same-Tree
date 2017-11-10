using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _100.Same_Tree
{

    //Definition for a binary tree node.
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x) { val = x; }
    }

    class InOrder
    {
        public List<KeyValuePair<long, int>> OrderList { get; } = new List<KeyValuePair<long, int>>();

        public InOrder(TreeNode tree)
        {
            Parse(tree, 1);
        }

        void Parse(TreeNode tree, int index)
        {
            if (null != tree.left)
            {
                Parse(tree.left, 2*index);
            }
            OrderList.Add(new KeyValuePair<long, int>(index,tree.val));
            if (null != tree.right)
            {
                Parse(tree.right, 2*index + 1);
            }
        }

    }
    class PreOrder
    {
        public List<KeyValuePair<long, int>> OrderList { get; } = new List<KeyValuePair<long, int>>();

        public PreOrder(TreeNode tree)
        {
            Parse(tree, 1);
        }
        void Parse(TreeNode tree, int index)
        {
            OrderList.Add(new KeyValuePair<long, int>(index, tree.val));
            if (null != tree.left)
            {
                Parse(tree.left, 2 * index);
            }
            if (null != tree.right)
            {
                Parse(tree.right, 2 * index + 1);
            }
        }

    }

    public class Solution
    {
        public bool IsSameTree(TreeNode p, TreeNode q)
        {
            if (null == p && null == q)
            {
                return true;
            }
            else if (null == p || null == q)
            {
                return false;
            }
            else
            {
                InOrder pInOrder =new InOrder(p);
                InOrder qInOrder = new InOrder(q);
                PreOrder pPreOrder = new PreOrder(p);
                PreOrder qPreOrder = new PreOrder(q);

                for (int i = 0; i < pInOrder.OrderList.Count; i++)
                {
                    if (!(pInOrder.OrderList[i].Key == qInOrder.OrderList[i].Key &&
                          pInOrder.OrderList[i].Value == qInOrder.OrderList[i].Value))
                    {
                        return false;
                    }
                    if (!(pPreOrder.OrderList[i].Key == qPreOrder.OrderList[i].Key &&
                          pPreOrder.OrderList[i].Value == qPreOrder.OrderList[i].Value))
                    {
                        return false;
                    }
                }

                return true;
            }
        }
    }
    class Program
    {

        static void Main(string[] args)
        {
            TreeNode a = new TreeNode(1) { left = new TreeNode(2), right = new TreeNode(3) };
            TreeNode b = new TreeNode(1) { left = new TreeNode(8), right = new TreeNode(3) };
            Console.WriteLine((new Solution()).IsSameTree(a, b));
            Console.ReadKey();
        }

    }
}

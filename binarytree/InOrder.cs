using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace binarytree
{
    internal class InOrder
    {
        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
 
            public TreeNode(int value)  // constructor
            {
                val = value;
                left = null;
                right = null;
            }
        }

        // Clase para el árbol binario
        public class BinaryTree
        {
            public TreeNode root;

            public BinaryTree()
            {
                root = null;
            }

            // Función para insertar un nuevo nodo en el árbol
            public void Insert(int value)
            {
                root = InsertRec(root, value);
            }

            private TreeNode InsertRec(TreeNode root, int value)
            {
                if (root == null)
                {
                    root = new TreeNode(value);
                    return root;
                }

                if (value < root.val)
                {
                    root.left = InsertRec(root.left, value);
                }
                else if (value > root.val)
                {
                    root.right = InsertRec(root.right, value);
                }

                return root;
            }

            // Función para imprimir el árbol en orden
            public void InOrderTraversal()
            {
                InOrderTraversalRec(root);
                Console.WriteLine();
            }

            private void InOrderTraversalRec(TreeNode root)
            {
                if (root != null)
                {
                    InOrderTraversalRec(root.left);
                    Console.Write(root.val + " ");
                    InOrderTraversalRec(root.right);
                }
            }
        }

        public void inorden()
        {
            BinaryTree tree = new BinaryTree();

            // Insertar nodos en el árbol
            tree.Insert(50);
            tree.Insert(30);
            tree.Insert(20);
            tree.Insert(40);
            tree.Insert(70);
            tree.Insert(60);
            tree.Insert(80);

            // Imprimir el árbol en orden
            Console.WriteLine("Árbol binario en orden:");
            tree.InOrderTraversal();
            Console.Read();
        }
    }
}

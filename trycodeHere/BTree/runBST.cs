using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace trycodeHere.BTree
{
    public class runBST
    {
        public static void run()
        {
            int[] data = { 4,1,98,34,23,15};
            BST r = new BST();
            for (int i = 0; i < data.Length; i++)
            {
                indexNode node = new indexNode();
                node.value = data[i];
                r.insert(node);
            }

            r.PrintTree();
            Console.ReadKey();

        }
    }
}

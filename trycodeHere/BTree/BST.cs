using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace trycodeHere.BTree
{
    public class indexNode
    {
        //public List<indexNode> children;
        public indexNode left;
        public indexNode right;
       
        public int value;
        public int weight;
    }
    public class BST
    {
        private indexNode _root;
        private List<string> printer;
        public BST()
        {
            _root = new indexNode();
            _root.weight = 0;          

        }
        public BST(indexNode node)
        {
            this._root = node;
        }
        public void insert(indexNode node)
        {
            _insert(_root, node,null);
        }
        private indexNode _insert(indexNode root, indexNode entry,indexNode _pos)
        {
            if (root.weight == 0)
            {
                root.value = entry.value;
                root.weight++;
                return root;
            }
            else
            {                            
                if (entry.value < root.value)  // go left
                {
                    if (root.left != null)
                    { 
                        var p =_insert(root.left, entry, null);
                        if (p != null)
                            root.weight++;
                        return p;
                    }
                    else
                    {
                        root.weight++;
                        var node = new indexNode();
                        root.left = node;
                        node.value = entry.value;
                        node.weight = 1;
                        return node;
                    }
                }
                else
                {
                    if (root.right != null)
                    {
                       var p = _insert(root.right, entry, null);
                       if (p != null)
                           root.weight++;
                       return p;
                    }
                    else
                    {
                        root.weight++;
                        var node = new indexNode();
                        root.right = node;
                        node.value = entry.value;
                        node.weight = 1;
                        return node;
                    }
                       
                } 
            }           
        }


        public void PrintTree()
        {
            printLayer();
        }
        private void printLayer()
        {
            Queue<indexNode> _q = new Queue<indexNode>();
            _q.Enqueue(this._root);
            while (_q.Count > 0)
            {
                indexNode cur = _q.Dequeue();
                if(cur.left != null)
                    _q.Enqueue(cur.left);
                if(cur.right != null)
                    _q.Enqueue(cur.right);
                Console.WriteLine(cur.weight +":" +cur.value);
                if (cur.left != null) Console.Write("/");
                if (cur.right != null) Console.Write(@"    \");
                Console.WriteLine();

            }
        }

        private void printDFS()
        {
            this.printer = new List<string>();
            _print(this._root);
        }
        private void _print(indexNode root)
        {
            string pv = root.value + ": " + root.weight;
            printer.Add(pv);
            if (root.left != null)
                _print(root.left);
        }

        public void delete(indexNode node)
        {
            _delete(this._root,null,node);
        }
        private indexNode First(indexNode root)
        { 
            var n = root;
            while (n != null && n.left != null)
                n = n.left;
            return n;                
        }
        private indexNode _delete(indexNode root,indexNode parent, indexNode entry)
        {
            if (root.value == entry.value)
            { 
                // begin del here
                if (parent != null)
                {
                    if (parent.left == root)
                    {
                        if (root.right != null)
                        {                            
                            var n = root.right;
                            var p = root.right;
                            while (n != null && n.left != null)
                            {
                                p = n;
                                n = n.left;
                            }
                            var node = n;
                            p.left = null;  // delete n;
                            node.left = root.left;
                            node.right = root.right;
                            node.weight = root.weight - 1;
                            parent.left = node;
                        }
                        else
                        {
                            parent.left = root.left;
                        }

                    }
                    else
                    { 
                        // mirrror ???
                    }
                    
                }
                else
                { 
                
                }
                return root;
            }
            else if (root.value < entry.value)
            {
                if (root.right != null)
                {
                    var res = _delete(root.right, root,entry);
                    root.weight--;
                    return res;
                }
                   
                else
                    return null;
            }
            else // root.value > entry.value
            {
                if (root.left != null)
                {
                    var res =_delete(root.left,root, entry);
                    root.weight--;
                    return res;
                }
                    
                else
                    return null;
            }
            
        }

    }
}

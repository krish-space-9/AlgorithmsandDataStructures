using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class BinaryTree
    {
        public Node Root { get; set; }

        public BinaryTree()
        {
            Root = null;
        }

        public void BuildBinaryTree(List<Relation> relations)
        {
            //Node root=null;
            IDictionary<int, Node> mappings = GetMappings(relations);

            //Root = mappings[50];
            PrintTree(Root);
        }

        private void PrintTree(Node root)
        {
            if(root!=null)
            {
                PrintTree(root.Left);
                Console.WriteLine(root.Key);
                PrintTree(root.Right);
            }
        }

        private IDictionary<int, Node> GetMappings(List<Relation> relations)
        {
            IDictionary<int, Node> mapping = new Dictionary<int, Node>();
            foreach (var relation in relations)
            {
                if(relation.Parent == -1)
                {
                    Node rnode = null;
                    if (!mapping.ContainsKey(relation.Child))
                    {
                        rnode = new Node(relation.Child);
                        
                        mapping.Add(relation.Child, rnode);                                              
                    }
                    else
                    {
                        rnode = mapping[relation.Child];
                    }
                    Root = rnode;
                }
                else
                {
                    Node n;
                    if (mapping.ContainsKey(relation.Parent))
                    {
                        n = mapping[relation.Parent];
                    }
                    else
                    {
                        n = new Node(relation.Parent);
                        mapping.Add(relation.Parent, n);
                    }

                    if (relation.IsLeftChild)
                    {
                        Node leftChild;
                        if (mapping.TryGetValue(relation.Child, out leftChild))
                        {
                            n.Left = leftChild;
                        }
                        else
                        {
                            n.Left = new Node(relation.Child);
                        }

                    }
                    else
                    {
                        Node rightChild;
                        if (mapping.TryGetValue(relation.Child, out rightChild))
                        {
                            n.Right = rightChild;
                        }
                        else
                        {
                            n.Right = new Node(relation.Child);
                        }

                    }
                    mapping[relation.Parent] = n; 
                }
            }
            
            return mapping;
        }
    }
}

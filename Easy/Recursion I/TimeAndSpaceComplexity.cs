// Given a binary tree, find its maximum depth.
// The maximum depth is the number of nodes along the longest path from the root node down to the farthest leaf node.
// Note: A leaf is a node with no children.

// Example:
// Given binary tree[3, 9, 20, null, null, 15, 7],
//     3
//    / \
//   9  20
//     /  \
//    15   7
// return its depth = 3.

using System;

namespace TimeAndSpaceComplexity {
    public class Program {
        static void Main(string[] args) {
            Solution solution = new Solution();
            TreeNode node = new TreeNode {
                val = 3,
                left = new TreeNode {
                    val = 9,
                    left = new TreeNode {
                        val = 11,
                        left = new TreeNode {
                            val = 12,
                            left = null,
                            right = null
                        },
                        right = new TreeNode {
                            val = 13,
                            left = null,
                            right = null
                        }
                    },
                    right = new TreeNode {
                        val = 15,
                        left = null,
                        right = null
                    }
                },
                right = new TreeNode {
                    val = 20,
                    left = new TreeNode {
                        val = 18,
                        left = new TreeNode {
                            val = 17,
                            left = null,
                            right = null
                        },
                        right = new TreeNode {
                            val = 19,
                            left = new TreeNode {
                                val = 16,
                                left = null,
                                right = null
                            },
                            right = new TreeNode {
                                val = 10,
                                left = null,
                                right = null
                            }
                        }
                    },
                    right = new TreeNode {
                        val = 7,
                        left = null,
                        right = null
                    }
                }
            };
            int num = solution.MaxDepth(node);
            Console.WriteLine(num);
        }
    }

    public class TreeNode {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode() { }
        public TreeNode(int x) { val = x; }
    }

    public class Solution {
        public int MaxDepth(TreeNode root) {
            if (root == null) {
                return 0;
            }
            return 1 + Math.Max(MaxDepth(root.left), MaxDepth(root.right));
        }
    }
}

// Implement pow(x, n), which calculates x raised to the power n (x^n).
using System;

namespace TimeAndSpaceComplexity {
    public class Program {
        static void Main(string[] args) {
            Solution solution = new Solution();
            Console.WriteLine(solution.MyPow(2.00000, 10));
            Console.WriteLine(solution.MyPow(2.10000, 3));
            Console.WriteLine(solution.MyPow(2.00000, -2));
        }
    }

    public class Solution {
        public double MyPow(double x, int n) {
            if (n == 0) {
                return 1.0;
            }
            if (n > 0) {
                return n % 2 == 0 ? MyPow(x * x, n / 2) : MyPow(x * x, n / 2) * x;
            }
            // If n = int.MinValue ?
            return 1 / x * MyPow(1 / x, -(n + 1));
        }
    }
}

using System;

namespace TimeAndSpaceComplexity {
    public class Program {
        static void Main(string[] args) {
            Solution solution = new Solution();
            Console.WriteLine(solution.MyPow(2.00000, 10));
            Console.WriteLine(solution.MyPow(2.10000, 3));
            Console.WriteLine(solution.MyPow(2.00000, -2));
        }
    }

    public class Solution {
        public double MyPow(double x, int n) {
            if (n == 0) { return 1; }
            // If n = int.MinValue ?
            if (n < 0 && n > Int32.MinValue) {
                n = -n;
                x = 1 / x;
            }
            return (n % 2 == 0) ? MyPow(x * x, n / 2) : x * MyPow(x * x, n / 2);
        }
    }
}

// Given an integer n, generate all structurally unique BST's (binary search trees) that store values 1 ... n.
   
// Example:
// Input: 3
// Output:
// [
//   [1,null,3,2],
//   [3,2,null,1],
//   [3,1,null,null,2],
//   [2,1,3],
//   [1,null,2,null,3]
// ]
// Explanation:
// The above output corresponds to the 5 unique BST's shown below:
//    1         3     3      2      1
//     \       /     /      / \      \
//      3     2     1      1   3      2
//     /     /       \                 \
//    2     1         2                 3

using System;
using System.Collections.Generic;

namespace PascalsTriangle {
    public class Program {
        static void Main(string[] args) {
            Solution solution = new Solution();
            List<TreeNode> node = solution.GenerateTrees(0);
            foreach (TreeNode item in node) {
                Cw(item);
                Console.WriteLine();
            }
        }
        private static void Cw(TreeNode node) {
            if (node != null) {
                Queue<TreeNode> queue = new Queue<TreeNode>();
                queue.Enqueue(node);
                while (queue.Count > 0) {
                    TreeNode item = queue.Dequeue();
                    if (item == null) {
                        Console.Write("n ");
                    }
                    else {
                        Console.Write(item.val + " ");
                        queue.Enqueue(item.left);
                        queue.Enqueue(item.right);
                    }
                }
            }
        }
    }

    public class TreeNode {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x) { val = x; }
    }

    public class Solution {
        public List<TreeNode> GenerateTrees(int n) {
            if (n == 0) {
                return new List<TreeNode>();
            }
            return genTrees(1, n);
        }

        public List<TreeNode> genTrees(int start, int end) {
            List<TreeNode> list = new List<TreeNode>();
            if (start > end) {
                list.Add(null);
                return list;
            }
            if (start == end) {
                list.Add(new TreeNode(start));
                return list;
            }
            List<TreeNode> left, right;
            for (int i = start; i <= end; i++) {
                left = genTrees(start, i - 1);
                right = genTrees(i + 1, end);
                foreach (TreeNode lnode in left) {
                    foreach (TreeNode rnode in right) {
                        TreeNode root = new TreeNode(i);
                        root.left = lnode;
                        root.right = rnode;
                        list.Add(root);
                    }
                }
            }
            return list;
        }
    }
}
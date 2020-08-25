// Given an array nums of n integers, are there elements a, b, c in nums such that a + b + c = 0?
// Find all unique triplets in the array which gives the sum of zero.

// Note:
// The solution set must not contain duplicate triplets.

// Example:
// Given array nums = [-1, 0, 1, 2, -1, -4],
// A solution set is:
// [
//   [-1, 0, 1],
//   [-1, -1, 2]
// ]

using System;
using System.Collections.Generic;
using System.Linq;

namespace JulySecond {
    public class ThreeSum {
        public static void Main(string[] args) {
            int[] nums = new int[] { -1, 0, 1, 2, -1, -4 };
            foreach (IList<int> item in ThreeSumFunction(nums).ToList()) {
                foreach (int i in item.ToList()) {
                    Console.Write(i + " ");
                }
                Console.WriteLine();
            }
        }

        public static IList<IList<int>> ThreeSumFunction(int[] nums) {
            Array.Sort(nums);
            List<IList<int>> ans = new List<IList<int>>();
            for (int i = 0; i < nums.Length - 2; i++) {
                if (i > 0 && nums[i - 1] == nums[i]) {
                    continue;
                }
                int l = i + 1;
                int r = nums.Length - 1;
                while (l < r) {
                    int sum = nums[i] + nums[l] + nums[r];
                    if (sum == 0) {
                        ans.Add(new List<int>() { nums[i], nums[l], nums[r] });
                        while (l < r && nums[l + 1] == nums[l]) {
                            l++;
                        }
                        while (l < r && nums[r - 1] == nums[r]) {
                            r--;
                        }
                        l++;
                        r--;
                    }
                    else if (sum > 0) {
                        r--;
                    }
                    else {
                        l++;
                    }
                }
            }
            return ans;
        }
    }
}

// Given a binary tree, write a function to get the maximum width of the given tree.The maximum width of a tree is the maximum width among all levels.
// The width of one level is defined as the length between the end-nodes (the leftmost and right most non-null nodes in the level,
// where the null nodes between the end-nodes are also counted into the length calculation.
// It is guaranteed that the answer will in the range of 32-bit signed integer.

// Example 1:
// Input: 
//            1
//          /   \
//         3     2
//        / \     \  
//       5   3     9 
// Output: 4
// Explanation: The maximum width existing in the third level with the length 4 (5,3,null,9).

// Example 2:
// Input: 
//           1
//          /  
//         3    
//        / \       
//       5   3     
// Output: 2
// Explanation: The maximum width existing in the third level with the length 2 (5,3).

// Example 3:
// Input: 
//           1
//          / \
//         3   2 
//        /        
//       5      
// Output: 2
// Explanation: The maximum width existing in the second level with the length 2 (3,2).

// Example 4:
// Input: 
//           1
//          / \
//         3   2
//        /     \  
//       5       9 
//      /         \
//     6           7
// Output: 8
// Explanation:The maximum width existing in the fourth level with the length 8 (6,null,null,null,null,null,null,7).

// Constraints:
// The given binary tree will have between 1 and 3000 nodes.

using System;
using System.Collections.Generic;

namespace JulySecond {
    public class MaximumWidthOfBinaryTree {
        public static void Main(string[] args) {
            TreeNode node = new TreeNode {
                val = 1,
                left = new TreeNode {
                    val = 3,
                    left = new TreeNode {
                        val = 5,
                        left = null,
                        right = null
                    },
                    right = new TreeNode {
                        val = 3,
                        left = null,
                        right = null
                    }
                },
                right = new TreeNode {
                    val = 2,
                    left = null,
                    right = new TreeNode {
                        val = 9,
                        left = null,
                        right = null
                    }
                }
            };
            Console.WriteLine(WidthOfBinaryTree(node));
        }

        public class TreeNode {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null) {
                this.val = val;
                this.left = left;
                this.right = right;
            }
        }

        internal class MyNode {
            public int Value;
            public TreeNode Node;
            public MyNode(TreeNode node, int val) {
                Node = node;
                Value = val;
            }
        }

        public static int WidthOfBinaryTree(TreeNode root) {
            if (root == null) {
                return 0;
            }
            Queue<MyNode> queue = new Queue<MyNode>();
            MyNode myNode = new MyNode(root, 1);
            queue.Enqueue(myNode);
            int maxWidth = 0;
            while (queue.Count > 0) {
                int size = queue.Count;
                int firstNo = 0;
                int lastNo = 0;
                for (int i = 0; i < size; i++) {
                    MyNode node = queue.Dequeue();
                    int value = node.Value;
                    if (i == 0) {
                        firstNo = value;
                    }
                    if (i == size - 1) {
                        lastNo = value;
                    }
                    if (node.Node.left != null) {
                        queue.Enqueue(new MyNode(node.Node.left, 2 * value - 1));
                    }
                    if (node.Node.right != null) {
                        queue.Enqueue(new MyNode(node.Node.right, 2 * value));
                    }
                }
                int currentLevelWidth = lastNo - firstNo + 1;
                maxWidth = currentLevelWidth > maxWidth ? currentLevelWidth : maxWidth;
            }
            return maxWidth;
        }
    }
}

// You are given a doubly linked list which in addition to the next and previous pointers, it could have a child pointer,
// which may or may not point to a separate doubly linked list.
// These child lists may have one or more children of their own, and so on, to produce a multilevel data structure, as shown in the example below.
// Flatten the list so that all the nodes appear in a single-level, doubly linked list.You are given the head of the first level of the list.

// Example 1:
// Input: head = [1, 2, 3, 4, 5, 6, null, null, null, 7, 8, 9, 10, null, null, 11, 12]
// Output: [1,2,3,7,8,11,12,9,10,4,5,6]

// Example 2:
// Input: head = [1, 2, null, 3]
// Output: [1,3,2]

// Explanation:
// The input multilevel linked list is as follows:
//   1---2---NULL
//   |
//   3---NULL

// Example 3:
// Input: head = []
// Output: []

// How multilevel linked list is represented in test case:
// We use the multilevel linked list from Example 1 above:
//  1---2---3---4---5---6--NULL
//          |
//          7---8---9---10--NULL
//              |
//              11--12--NULL
// The serialization of each level is as follows:
// [1,2,3,4,5,6,null]
// [7,8,9,10,null]
// [11,12,null]
// To serialize all levels together we will add nulls in each level to signify no node connects to the upper node of the previous level.The serialization becomes:
// [1,2,3,4,5,6,null]
// [null,null,7,8,9,10,null]
// [null,11,12,null]
// Merging the serialization of each level and removing trailing nulls we obtain:
// [1,2,3,4,5,6,null,null,null,7,8,9,10,null,null,11,12]

// Constraints:
// Number of Nodes will not exceed 1000.
// 1 <= Node.val <= 10^5

namespace JulySecond {
    public class FlattenAMultilevelDoublyLinkedList {
        public static void Main(string[] args) {
            Node node1 = new Node {
                val = 1,
            };
            Node node2 = new Node {
                val = 2,
            };
            Node node3 = new Node {
                val = 3,
            };
            Node node4 = new Node {
                val = 4,
            };
            Node node5 = new Node {
                val = 5,
            };
            Node node6 = new Node {
                val = 6,
            };
            Node node7 = new Node {
                val = 7,
            };
            Node node8 = new Node {
                val = 8,
            };
            Node node9 = new Node {
                val = 9,
            };
            Node node10 = new Node {
                val = 10,
            };
            Node node11 = new Node {
                val = 11,
            };
            Node node12 = new Node {
                val = 12,
            };
            node1.next = node2;
            node2.next = node3;
            node3.next = node4;
            node4.next = node5;
            node5.next = node6;
            node7.next = node8;
            node8.next = node9;
            node9.next = node10;
            node11.next = node12;

            node12.prev = node11;
            node10.prev = node9;
            node9.prev = node8;
            node8.prev = node7;
            node6.prev = node5;
            node5.prev = node4;
            node4.prev = node3;
            node3.prev = node2;
            node2.prev = node1;

            node3.child = node7;
            node8.child = node11;

            Node node = Flatten(node1);
        }

        public class Node {
            public int val;
            public Node prev;
            public Node next;
            public Node child;
        }

        public static Node Flatten(Node head) {
            return head == null ? head : Helper(head).head;
        }

        private static (Node head, Node tail) Helper(Node node) {
            Node head = node,
                 tail = null;
            while (node != null) {
                if (node.child != null) {
                    Node temp = node.next;
                    (Node head, Node tail) pair = Helper(node.child);
                    node.next = pair.head;
                    pair.head.prev = node;
                    pair.tail.next = temp;
                    if (temp != null) {
                        temp.prev = pair.tail;
                    }
                    if (pair.tail.next == null) {
                        tail = pair.tail;
                    }
                    node.child = null;
                    node = pair.tail.next;
                }
                else {
                    if (node.next == null) {
                        tail = node;
                    }
                    node = node.next;
                }
            }
            return (head, tail);
        }
    }
}

// Given a set of distinct integers, nums, return all possible subsets(the power set).

// Note: The solution set must not contain duplicate subsets.

// Example:
// Input: nums = [1, 2, 3]
// Output:
// [
//   [3],
//   [1],
//   [2],
//   [1,2,3],
//   [1,3],
//   [2,3],
//   [1,2],
//   []
// ]

using System;
using System.Collections.Generic;
using System.Linq;

namespace JulySecond {
    public class Subsets {
        public static void Main(string[] args) {
            int[] nums = new int[] { 1, 2, 3 };
            foreach (IList<int> item in SubsetsFunction(nums)) {
                foreach (int i in item.ToList()) {
                    Console.Write(i + " ");
                }
                Console.WriteLine();
            }
        }

        public static IList<IList<int>> SubsetsFunction(int[] nums) {
            List<IList<int>> result = new List<IList<int>>();
            result.Add(new List<int>());
            Array.Sort(nums);
            for (int i = 0; i < nums.Length; i++) {
                List<IList<int>> newResult = new List<IList<int>>();
                foreach (var r in result) {
                    List<int> nr = new List<int>(r);
                    nr.Add(nums[i]);
                    newResult.Add(nr);
                }
                result.AddRange(newResult);
            }
            return result;
        }
    }
}

// Reverse bits of a given 32 bits unsigned integer.

// Example 1:
// Input: 00000010100101000001111010011100
// Output: 00111001011110000010100101000000
// Explanation: The input binary string 00000010100101000001111010011100 represents the unsigned integer 43261596,
// so return 964176192 which its binary representation is 00111001011110000010100101000000.

// Example 2:
// Input: 11111111111111111111111111111101
// Output: 10111111111111111111111111111111
// Explanation: The input binary string 11111111111111111111111111111101 represents the unsigned integer 4294967293,
// so return 3221225471 which its binary representation is 10111111111111111111111111111111.

// Note:
// Note that in some languages such as Java, there is no unsigned integer type.
// In this case, both input and output will be given as signed integer type and should not affect your implementation,
// as the internal binary representation of the integer is the same whether it is signed or unsigned.
// In Java, the compiler represents the signed integers using 2's complement notation.
// Therefore, in Example 2 above the input represents the signed integer -3 and the output represents the signed integer -1073741825.

using System;

namespace JulySecond {
    public class ReverseBits {
        public static void Main(string[] args) {
            uint n = 43261596;
            Console.WriteLine(Convert.ToString(n, 2));
            Console.WriteLine(Convert.ToString(ReverseBitsFunction(n), 2));
        }

        public static uint ReverseBitsFunction(uint n) {
            uint result = 0;
            for (int i = 0; i < 32; result = result << 1 | (n & 1), n >>= 1, ++i) ;
            return result;
        }
    }
}

// Given two binary trees, write a function to check if they are the same or not.
// Two binary trees are considered the same if they are structurally identical and the nodes have the same value.
   
// Example 1:
// Input:     1         1
//           / \       / \
//          2   3     2   3
//         [1,2,3], [1,2,3]
// Output: true
   
// Example 2:
// Input:     1         1
//           /           \
//          2             2
//         [1,2], [1,null,2]
// Output: false
   
// Example 3:
// Input:     1         1
//           / \       / \
//          2   1     1   2
//         [1,2,1], [1,1,2]
// Output: false

using System;

namespace JulySecond {
    public class SameTree {
        public static void Main(string[] args) {
            TreeNode node = new TreeNode {
                val = 1,
                left = new TreeNode {
                    val = 2,
                    left = null,
                    right = null
                },
                right = new TreeNode {
                    val = 3,
                    left = null,
                    right = null
                }
            };
            Console.WriteLine(IsSameTree(node, node));
        }

        public class TreeNode {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null) {
                this.val = val;
                this.left = left;
                this.right = right;
            }
        }

        public static bool IsSameTree(TreeNode p, TreeNode q) {
            return (p != null && q == null) || (p == null && q != null) || (p != null && q != null && p.val != q.val)
                ? false
                : (p == null && q == null) || (IsSameTree(p.left, q.left) && IsSameTree(p.right, q.right));
        }
    }
}

// Given two numbers, hour and minutes.Return the smaller angle(in degrees) formed between the hour and the minute hand.

// Example 1:
// Input: hour = 12, minutes = 30
// Output: 165

// Example 2:
// Input: hour = 3, minutes = 30
// Output: 75

// Example 3:
// Input: hour = 3, minutes = 15
// Output: 7.5

// Example 4:
// Input: hour = 4, minutes = 50
// Output: 155

// Example 5:
// Input: hour = 12, minutes = 0
// Output: 0

// Constraints:
// 1 <= hour <= 12
// 0 <= minutes <= 59
// Answers within 10^-5 of the actual value will be accepted as correct.

using System;

namespace JulySecond {
    public class AngleBetweenHandsOfAClock {
        public static void Main(string[] args) {
            Console.WriteLine(AngleClock(10, 23));
        }

        public static double AngleClock(int hour, int minutes) {
            double shift = (double)minutes / 60 * 30;
            double hoursDegree = hour % 12 * 30 + shift;
            int minutesDegree = minutes * 6;
            double result = Math.Abs(hoursDegree - minutesDegree);
            return Math.Min(result, 360 - (result));
        }
    }
}
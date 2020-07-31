// Invert a binary tree.

// Example:
// Input:
//      4
//    /   \
//   2     7
//  / \   / \
// 1   3 6   9
// Output:
//      4
//    /   \
//   7     2
//  / \   / \
// 9   6 3   1

using System;
using System.Collections.Generic;

namespace JuneFirst {
    public class InvertBinaryTree {
        public static void Main(string[] args) {
            TreeNode root = new TreeNode {
                val = 4,
                left = new TreeNode {
                    val = 2,
                    left = new TreeNode {
                        val = 1,
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
                    val = 7,
                    left = new TreeNode {
                        val = 6,
                        left = null,
                        right = null
                    },
                    right = new TreeNode {
                        val = 9,
                        left = null,
                        right = null
                    }
                }
            };
            TreeNode node = InvertTree(root);
            Cw(node);
        }

        private static void Cw(TreeNode node) {
            if (node != null) {
                Queue<TreeNode> queue = new Queue<TreeNode>();
                queue.Enqueue(node);
                while (queue.Count > 0) {
                    TreeNode item = queue.Dequeue();
                    if (item == null) {
                        Console.Write("null ");
                    }
                    else {
                        Console.Write(item.val + " ");
                        queue.Enqueue(item.left);
                        queue.Enqueue(item.right);
                    }
                }
            }
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

        public static TreeNode InvertTree(TreeNode root) {
            if (root == null) {
                return null;
            }
            TreeNode right = InvertTree(root.right);
            TreeNode left = InvertTree(root.left);
            root.left = right;
            root.right = left;
            return root;
        }
    }
}

// Write a function to delete a node(except the tail) in a singly linked list, given only access to that node.
// Given linked list -- head = [4,5,1,9], which looks like following:
// 4 -> 5 -> 1 -> 9

// Example 1:
// Input: head = [4,5,1,9], node = 5
// Output: [4,1,9]
// Explanation: You are given the second node with value 5, the linked list should become 4 -> 1 -> 9 after calling your function.

// Example 2:
// Input: head = [4, 5, 1, 9], node = 1
// Output: [4,5,9]
// Explanation: You are given the third node with value 1, the linked list should become 4 -> 5 -> 9 after calling your function.

// Note:
// The linked list will have at least two elements.
// All of the nodes' values will be unique.
// The given node will not be the tail and it will always be a valid node of the linked list.
// Do not return anything from your function.

using System;

namespace JuneFirst {
    public class DeleteNodeInALinkedList {
        public static void Main(string[] args) {
            ListNode node = new ListNode(4) {
                next = new ListNode(5) {
                    next = new ListNode(1) {
                        next = new ListNode(9) {
                            next = null
                        }
                    }
                }
            };
            node = DeleteNode(node);
            Cw(node);
        }

        private static void Cw(ListNode node) {
            Console.Write(node.val + " ");
            if (node.next != null) {
                Cw(node.next);
            }
        }

        public class ListNode {
            public int val;
            public ListNode next;
            public ListNode(int x) { val = x; }
        }

        public static ListNode DeleteNode(ListNode node) {
            node.val = node.next.val;
            node.next = node.next.next;
            return node;
        }
    }
}

// There are 2N people a company is planning to interview.The cost of flying the i-th person to city A is costs[i][0],
// and the cost of flying the i-th person to city B is costs[i][1].
// Return the minimum cost to fly every person to a city such that exactly N people arrive in each city.

// Example 1:
// Input: [[10,20], [30,200], [400,50], [30,20]]
// Output: 110
// Explanation: 
// The first person goes to city A for a cost of 10.
// The second person goes to city A for a cost of 30.
// The third person goes to city B for a cost of 50.
// The fourth person goes to city B for a cost of 20.
// The total minimum cost is 10 + 30 + 50 + 20 = 110 to have half the people interviewing in each city.

// Note:
// 1 <= costs.length <= 100
// It is guaranteed that costs.length is even.
// 1 <= costs[i][0], costs[i][1] <= 1000

using System;

namespace JuneFirst {
    public class TwoCityScheduling {
        public static void Main(string[] args) {
            int[][] costs = new int[4][];
            costs[0] = new int[] { 10, 20 };
            costs[1] = new int[] { 30, 200 };
            costs[2] = new int[] { 400, 50 };
            costs[3] = new int[] { 30, 20 };
            Console.WriteLine(TwoCitySchedCost(costs));
        }

        public static int TwoCitySchedCost(int[][] costs) {
            int N = costs.Length / 2;
            int total = 0;
            Array.Sort(costs, (a, b) => (a[0] - a[1]).CompareTo(b[0] - b[1]));
            for (int i = 0; i < N; i++) {
                total += costs[i][0] + costs[i + N][1];
            }
            return total;
        }
    }
}

// Write a function that reverses a string. The input string is given as an array of characters char[].
// Do not allocate extra space for another array, you must do this by modifying the input array in-place with O(1) extra memory.
// You may assume all the characters consist of printable ascii characters.
   
// Example 1:
// Input: ["h","e","l","l","o"]
// Output: ["o","l","l","e","h"]
   
// Example 2:
// Input: ["H","a","n","n","a","h"]
// Output: ["h","a","n","n","a","H"]

using System;

namespace JuneFirst {
    public class ReverseString {
        public static void Main(string[] args) {
            char[] s = new char[] { 'h', 'e', 'l', 'L', 'o' };
            Console.WriteLine(ReverseStrings(s));
        }

        public static char[] ReverseStrings(char[] s) {
            char[] n = new char[s.Length];
            s.CopyTo(n, 0);
            int j = 0;
            for (int i = s.Length - 1; i >= 0; i--) {
                s[j] = n[i];
                j++;
            }
            return s;
        }
    }
}

// Given an array w of positive integers, where w[i] describes the weight of index i(0-indexed),
// write a function pickIndex which randomly picks an index in proportion to its weight.
// For example, given an input list of values w = [2, 8], when we pick up a number out of it,
// the chance is that 8 times out of 10 we should pick the number 1 as the answer since it's the second element of the array (w[1] = 8).

// Example 1:
// Input
// ["Solution", "pickIndex"]
// [[[1]],[]]
// Output
// [null, 0]
// Explanation
// Solution solution = new Solution([1]);
// solution.pickIndex(); // return 0. Since there is only one single element on the array the only option is to return the first element.

// Example 2:
// Input
// ["Solution", "pickIndex", "pickIndex", "pickIndex", "pickIndex", "pickIndex"]
// [[[1, 3]],[],[],[],[],[]]
// Output
// [null, 1, 1, 1, 1, 0]
// Explanation
// Solution solution = new Solution([1, 3]);
// solution.pickIndex(); // return 1. It's returning the second element (index = 1) that has probability of 3/4.
// solution.pickIndex(); // return 1
// solution.pickIndex(); // return 1
// solution.pickIndex(); // return 1
// solution.pickIndex(); // return 0. It's returning the first element (index = 0) that has probability of 1/4.
// Since this is a randomization problem, multiple answers are allowed so the following outputs can be considered correct :
// [null,1,1,1,1,0]
// [null,1,1,1,1,1]
// [null,1,1,1,0,0]
// [null,1,1,1,0,1]
// [null,1,0,1,0,0]
// ......
// and so on.

// Constraints:
// 1 <= w.length <= 10000
// 1 <= w[i] <= 10^5
// pickIndex will be called at most 10000 times.

using System;

namespace JuneFirst {
    public class RandomPickWithWeight {
        public static void Main(string[] args) {
            int[] w = new int[] { 1, 3 };
            Solution solution = new Solution(w);
            Console.WriteLine(solution.PickIndex()); // return 1. It's returning the second element (index = 1) that has probability of 3/4.
            Console.WriteLine(solution.PickIndex()); // return 1
            Console.WriteLine(solution.PickIndex()); // return 1
            Console.WriteLine(solution.PickIndex()); // return 1
            Console.WriteLine(solution.PickIndex()); // return 0. It's returning the first element (index = 0) that has probability of 1/4.
        }
    }

    public class Solution {
        readonly int[] cWeight;
        readonly int totalWeight;
        readonly Random rnd;

        public Solution(int[] w) {
            totalWeight = 0;
            cWeight = new int[w.Length];
            rnd = new Random(w.Length);
            for (int i = 0; i < w.Length; i++) {
                totalWeight += w[i];
                cWeight[i] = totalWeight;
            }
        }

        public int PickIndex() {
            int index = rnd.Next(0, totalWeight) + 1;
            int start = 0;
            int end = cWeight.Length - 1;
            while (start < end) {
                int mid = ((end + start) / 2);
                if (cWeight[mid] < index) {
                    start = mid + 1;
                }
                else if (cWeight[mid] > index) {
                    end = mid - 1;
                }
                else {
                    return mid;
                }
            }
            if (cWeight[start] >= index) {
                return start;
            }
            return start + 1;
        }
    }
}

// Suppose you have a random list of people standing in a queue.Each person is described by a pair of integers (h, k),
// where h is the height of the person and k is the number of people in front of this person
// who have a height greater than or equal to h.Write an algorithm to reconstruct the queue.
   
// Note:
// The number of people is less than 1,100.
   
// Example
// Input:
// [[7,0], [4,4], [7,1], [5,0], [6,1], [5,2]]
// Output:
// [[5,0], [7,0], [5,2], [6,1], [4,4], [7,1]]

using System;
using System.Collections.Generic;

namespace JuneFirst {
    public class QueueReconstructionByHeight {
        public static void Main(string[] args) {
            int[][] people = new int[6][];
            people[0] = new int[] { 7, 0 };
            people[1] = new int[] { 4, 4 };
            people[2] = new int[] { 7, 1 };
            people[3] = new int[] { 5, 0 };
            people[4] = new int[] { 6, 1 };
            people[5] = new int[] { 5, 2 };
            people = ReconstructQueue(people);
            foreach (int[] item in people) {
                foreach (int i in item) {
                    Console.Write(i + " ");
                }
                Console.WriteLine();
            }
        }

        public static int[][] ReconstructQueue(int[][] people) {
            List<int[]> result = new List<int[]>();
            Array.Sort(people, (a, b) => a[0] != b[0] ? b[0] - a[0] : a[1] - b[1]);
            foreach (var temp in people) {
                int height = temp[0];
                int index = temp[1];
                result.Insert(index, temp);
            }
            return result.ToArray();
        }
    }
}

// You are given coins of different denominations and a total amount of money.
// Write a function to compute the number of combinations that make up that amount.
// You may assume that you have infinite number of each kind of coin.
   
// Example 1:
// Input: amount = 5, coins = [1, 2, 5]
// Output: 4
// Explanation: there are four ways to make up the amount:
// 5=5
// 5=2+2+1
// 5=2+1+1+1
// 5=1+1+1+1+1
   
// Example 2:
// Input: amount = 3, coins = [2]
// Output: 0
// Explanation: the amount of 3 cannot be made up just with coins of 2.
   
// Example 3:
// Input: amount = 10, coins = [10]
// Output: 1
   
// Note:
// You can assume that
// 0 <= amount <= 5000
// 1 <= coin <= 5000
// the number of coins is less than 500
// the answer is guaranteed to fit into signed 32-bit integer

using System;

namespace JuneFirst {
    public class CoinChange2 {
        public static void Main(string[] args) {
            int amount = 5;
            int[] coins = new int[] { 1, 2, 5 };
            Console.WriteLine(Change(amount, coins));
        }

        public static int Change(int amount, int[] coins) {
            int[] dp = new int[amount + 1];
            dp[0] = 1;
            foreach (int item in coins) {
                for (int i = 0; i < amount; i++) {
                    if (i + item > amount) {
                        break;
                    }
                    dp[i + item] += dp[i];
                }
            }
            return dp[amount];
        }
    }
}
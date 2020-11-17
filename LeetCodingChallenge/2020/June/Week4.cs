// Given a non-empty array of integers, every element appears three times except for one, which appears exactly once.Find that single one.

// Note:
// Your algorithm should have a linear runtime complexity. Could you implement it without using extra memory?

// Example 1:
// Input: [2,2,3,2]
// Output: 3

// Example 2:
// Input: [0,1,0,1,0,1,99]
// Output: 99

using System;

namespace JuneFourth {
    public class SingleNumberII {
        public static void Main(string[] args) {
            int[] nums = new int[] { 2, 2, 3, 2 };
            Console.WriteLine(SingleNumber(nums));
        }

        public static int SingleNumber(int[] nums) {
            int ones = 0, twos = 0;
            foreach (int n in nums) {
                ones = (ones ^ n) & ~twos;
                twos = (twos ^ n) & ~ones;
            }
            return ones;
        }
    }
}

// Given a complete binary tree, count the number of nodes.
   
// Note:
// In a complete binary tree every level, except possibly the last, is completely filled, and all nodes in the last level are as far left as possible.
// It can have between 1 and 2h nodes inclusive at the last level h.
   
// Example:
// Input: 
//     1
//    / \
//   2   3
//  / \  /
// 4  5 6
// Output: 6

using System;

namespace JuneFourth {
    public class CountCompleteTreeNodes {
        public static void Main(string[] args) {
            TreeNode node = new TreeNode {
                val = 1,
                left = new TreeNode {
                    val = 2,
                    left = new TreeNode {
                        val = 4,
                        left = null,
                        right = null
                    },
                    right = new TreeNode {
                        val = 5,
                        left = null,
                        right = null
                    }
                },
                right = new TreeNode {
                    val = 3,
                    left = new TreeNode {
                        val = 6,
                        left = null,
                        right = null
                    },
                    right = null
                }
            };
            Console.WriteLine(CountNodes(node));
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

        public static int CountNodes(TreeNode root) {
            if (root == null) {
                return 0;
            }
            TreeNode node = root;
            int count = 0;
            int leftHeight = LeftHeight(node);
            while (node != null) {
                count++; // count self
                int leftLeftHeight = leftHeight - 1;
                int rightLeftHeight = LeftHeight(node.right);
                if (leftLeftHeight == rightLeftHeight) {
                    // left tree is full
                    count += (1 << leftLeftHeight) - 1;
                    node = node.right;
                    leftHeight = rightLeftHeight;
                }
                else {
                    // right tree is full
                    count += (1 << rightLeftHeight) - 1;
                    node = node.left;
                    leftHeight = leftLeftHeight;
                }
            }
            return count;
        }

        public static int LeftHeight(TreeNode node) {
            int count = 0;
            TreeNode n = node;
            while (n != null) {
                count++;
                n = n.left;
            }
            return count;
        }
    }
}

// Given n, how many structurally unique BST's (binary search trees) that store values 1 ... n?

// Example:
// Input: 3
// Output: 5
// Explanation:
// Given n = 3, there are a total of 5 unique BST's:
//    1         3     3      2      1
//     \       /     /      / \      \
//      3     2     1      1   3      2
//     /     /       \                 \
//    2     1         2                 3

// Constraints:
// 1 <= n <= 19

using System;

namespace JuneFourth {
    public class UniqueBinarySearchTrees {
        public static void Main(string[] args) {
            Console.WriteLine(NumTrees(3));
        }

        public static int NumTrees(int n) {
            int[] count = new int[n + 1];
            count[0] = 1;
            count[1] = 1;
            for (int i = 2; i <= n; i++) {
                for (int j = 0; j < i; j++) {
                    count[i] += count[j] * count[i - j - 1];
                }
            }
            return count[n];
        }
    }
}

// Given an array nums containing n + 1 integers where each integer is between 1 and n(inclusive), prove that at least one duplicate number must exist.
// Assume that there is only one duplicate number, find the duplicate one.
   
// Example 1:
// Input: [1,3,4,2,2]
// Output: 2
   
// Example 2:
// Input: [3,1,3,4,2]
// Output: 3
   
// Note:
// You must not modify the array(assume the array is read only).
// You must use only constant, O(1) extra space.
// Your runtime complexity should be less than O(n2).
// There is only one duplicate number in the array, but it could be repeated more than once.

using System;

namespace JuneFourth {
    public class FindTheDuplicateNumber {
        public static void Main(string[] args) {
            int[] nums = new int[] { 3, 1, 3, 4, 2 };
            Console.WriteLine(FindDuplicate(nums));
        }

        public static int FindDuplicate(int[] nums) {
            for (int i = 0; i < nums.Length; i++) {
                while (nums[i] - 1 != i) {
                    int tempIndex = nums[i] - 1;
                    if (nums[tempIndex] == nums[i]) {
                        break;
                    }
                    nums[i] = nums[tempIndex];
                    nums[tempIndex] = tempIndex + 1;
                }
            }
            for (int i = 0; i < nums.Length; i++) {
                if (i != nums[i] - 1) {
                    return nums[i];
                }
            }
            throw new Exception("Never reach");
        }
    }
}

// Given a binary tree containing digits from 0-9 only, each root-to-leaf path could represent a number.
// An example is the root-to-leaf path 1->2->3 which represents the number 123.
// Find the total sum of all root-to-leaf numbers.
// Note: A leaf is a node with no children.

// Example:
// Input: [1,2,3]
//     1
//    / \
//   2   3
// Output: 25
// Explanation:
// The root-to-leaf path 1->2 represents the number 12.
// The root-to-leaf path 1->3 represents the number 13.
// Therefore, sum = 12 + 13 = 25.

// Example 2:
// Input: [4,9,0,5,1]
//     4
//    / \
//   9   0
//  / \
// 5   1
// Output: 1026

// Explanation:
// The root-to-leaf path 4->9->5 represents the number 495.
// The root-to-leaf path 4->9->1 represents the number 491.
// The root-to-leaf path 4->0 represents the number 40.
// Therefore, sum = 495 + 491 + 40 = 1026.

using System;

namespace JuneFourth {
    public class SumRootToLeafNumbers {
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
            Console.WriteLine(SumNumbers(node));
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

        public static int SumNumbers(TreeNode root) {
            int sum = NodeSum(root, 0);
            return sum;
        }

        private static int NodeSum(TreeNode node, int sum) {
            if (node == null) {
                return 0;
            }

            int next = sum * 10 + node.val;

            if (node.left == null && node.right == null) {
                return next;
            }

            int left = NodeSum(node.left, next);
            int right = NodeSum(node.right, next);
            return left + right;
        }
    }
}

// Given a positive integer n, find the least number of perfect square numbers(for example, 1, 4, 9, 16, ...) which sum to n.
   
// Example 1:
// Input: n = 12
// Output: 3 
// Explanation: 12 = 4 + 4 + 4.
   
// Example 2:
// Input: n = 13
// Output: 2
// Explanation: 13 = 4 + 9.

using System;
using System.Collections.Generic;

namespace JuneFourth {
    public class PerfectSquares {
        public static void Main(string[] args) {
            Console.WriteLine(NumSquares(13));
        }

        public static List<int> Dp { get; } = new List<int>() { 0 };

        public static int NumSquares(int n) {
            while (Dp.Count <= n) {
                int m = Dp.Count;
                int res = int.MaxValue;
                for (int i = 1; i * i <= m; i++) {
                    res = Math.Min(res, Dp[m - i * i] + 1);
                }
                Dp.Add(res);
            }
            return Dp[n];
        }
    }
}

// Given a list of airline tickets represented by pairs of departure and arrival airports[from, to], reconstruct the itinerary in order.
// All of the tickets belong to a man who departs from JFK.Thus, the itinerary must begin with JFK.
   
// Note:
// If there are multiple valid itineraries, you should return the itinerary that has the smallest lexical order when read as a single string.
// For example, the itinerary ["JFK", "LGA"] has a smaller lexical order than ["JFK", "LGB"].
// All airports are represented by three capital letters (IATA code).
// You may assume all tickets form at least one valid itinerary.
// One must use all the tickets once and only once.
   
// Example 1:
// Input: [["MUC", "LHR"], ["JFK", "MUC"], ["SFO", "SJC"], ["LHR", "SFO"]]
// Output: ["JFK", "MUC", "LHR", "SFO", "SJC"]
   
// Example 2:
// Input: [["JFK","SFO"],["JFK","ATL"],["SFO","ATL"],["ATL","JFK"],["ATL","SFO"]]
// Output: ["JFK","ATL","JFK","SFO","ATL","SFO"]
// Explanation: Another possible reconstruction is ["JFK","SFO","ATL","JFK","ATL","SFO"].
//              But it is larger in lexical order.

using System;
using System.Collections.Generic;
using System.Linq;

namespace JuneFourth {
    public class ReconstructItinerary {
        public static void Main(string[] args) {
            IList<string> str1 = new List<string> { "MUC", "LHR" };
            IList<string> str2 = new List<string> { "JFK", "MUC" };
            IList<string> str3 = new List<string> { "SFO", "SJC" };
            IList<string> str4 = new List<string> { "LHR", "SFO" };
            IList<IList<string>> lists = new List<IList<string>> { str1, str2, str3, str4 };
            IList<IList<string>> tickets = lists;
            Console.WriteLine(string.Join(" ", FindItinerary(tickets).ToList()));
        }

        private class Node<T> : IEquatable<Node<T>> {
            private readonly IComparer<Node<T>> _comparer;
            public readonly T Value;
            public readonly List<Node<T>> Edges;

            public Node(T value, IComparer<Node<T>> comparer) {
                _comparer = comparer;
                Value = value;
                Edges = new List<Node<T>>();
            }

            public override bool Equals(object obj) {
                return Equals((Node<T>)obj);
            }

            public bool Equals(Node<T> other) {
                return Value.Equals(other.Value);
            }

            public override int GetHashCode() {
                return HashCode.Combine(Value);
            }

            public override string ToString() {
                return $"Value: {Value}";
            }

            public void SortEdges() {
                Edges.Sort(_comparer);
            }
        }

        private class AirportComparer : IComparer<Node<string>> {
            public int Compare(Node<string> x, Node<string> y) => string.Compare(x.Value, y.Value, StringComparison.OrdinalIgnoreCase);
        }

        private static bool Helper(IList<string> res, Node<string> node, HashSet<(string, int)> visitedEdge, int targetPathLength) {
            res.Add(node.Value);

            if (targetPathLength == 0) {
                return true;
            }

            for (int i = 0; i < node.Edges.Count; i++) {
                Node<string> nextNode = node.Edges[i];

                if (!visitedEdge.Add((node.Value, i))) {
                    continue;
                }

                if (Helper(res, nextNode, visitedEdge, targetPathLength - 1)) {
                    return true;
                }

                visitedEdge.Remove((node.Value, i));
            }

            res.RemoveAt(res.Count - 1);
            return false;
        }

        public static IList<string> FindItinerary(IList<IList<string>> tickets) {
            IDictionary<string, Node<string>> graph = new Dictionary<string, Node<string>>();
            AirportComparer comparer = new AirportComparer();

            foreach (IList<string> ticket in tickets) {
                if (!graph.ContainsKey(ticket[0])) {
                    graph[ticket[0]] = new Node<string>(ticket[0], comparer);
                }

                if (!graph.ContainsKey(ticket[1])) {
                    graph[ticket[1]] = new Node<string>(ticket[1], comparer);
                }

                graph[ticket[0]].Edges.Add(graph[ticket[1]]);
            }

            foreach (KeyValuePair<string, Node<string>> node in graph) {
                node.Value.SortEdges();
            }

            IList<string> res = new List<string>();
            Node<string> root = graph["JFK"];
            int targetPathLength = tickets.Count;
            if (targetPathLength == 0) {
                return res;
            }
            HashSet<(string, int)> visited = new HashSet<(string, int)>();
            if (Helper(res, root, visited, targetPathLength)) {
                return res;
            }
            return new List<string>();
        }
    }
}
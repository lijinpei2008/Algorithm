// Given a binary tree, return the zigzag level order traversal of its nodes' values.
// (ie, from left to right, then right to left for the next level and alternate between).

// For example:
// Given binary tree[3, 9, 20, null, null, 15, 7],
//     3
//    / \
//   9  20
//     /  \
//    15   7
// return its zigzag level order traversal as:
// [
//   [3],
//   [20,9],
//   [15,7]
// ]

using System;
using System.Collections.Generic;
using System.Linq;

namespace JulyFourth {
    public class BinaryTreeZigzagLevelOrderTraversal {
        public static void Main(string[] args) {
            TreeNode node = new TreeNode {
                val = 3,
                left = new TreeNode {
                    val = 9,
                    left = null,
                    right = null
                },
                right = new TreeNode {
                    val = 20,
                    left = new TreeNode {
                        val = 15,
                        left = null,
                        right = null
                    },
                    right = new TreeNode {
                        val = 7,
                        left = null,
                        right = null
                    }
                }
            };
            foreach (IList<int> item in ZigzagLevelOrder(node)) {
                foreach (int i in item.ToList()) {
                    Console.Write(i + " ");
                }
                Console.WriteLine();
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

        public static IList<IList<int>> ZigzagLevelOrder(TreeNode root) {
            if (root == null) {
                return new int[0][];
            }
            int level = 0;
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            List<List<int>> zzLevelOrder = new List<List<int>>();
            while (queue.Count > 0) {
                int count = queue.Count;
                List<int> currentLevel = new List<int>();
                for (int i = 0; i < count; i++) {
                    TreeNode current = queue.Dequeue();
                    currentLevel.Add(current.val);
                    if (current.left != null) {
                        queue.Enqueue(current.left);
                    }
                    if (current.right != null) {
                        queue.Enqueue(current.right);
                    }
                }
                if (level % 2 == 0) {
                    zzLevelOrder.Add(currentLevel);
                }
                else {
                    currentLevel.Reverse();
                    zzLevelOrder.Add(currentLevel);
                }
                level++;
            }
            return zzLevelOrder.ToArray();
        }
    }
}

// Given an integer array nums, in which exactly two elements appear only once and all the other elements appear exactly twice.
// Find the two elements that appear only once.You can return the answer in any order.
// Follow up: Your algorithm should run in linear runtime complexity.Could you implement it using only constant space complexity?

// Example 1:
// Input: nums = [1,2,1,3,2,5]
// Output: [3,5]
// Explanation:  [5, 3] is also a valid answer.

// Example 2:
// Input: nums = [-1, 0]
// Output: [-1,0]

// Example 3:
// Input: nums = [0, 1]
// Output: [1,0]

// Constraints:
// 1 <= nums.length <= 30000
// Each integer in nums will appear twice, only two integers will appear once.

using System;
using System.Linq;

namespace JulyFourth {
    public class SingleNumberIII {
        public static void Main(string[] args) {
            int[] nums = new int[6] { 1, 2, 1, 3, 2, 5 };
            int[] result = SingleNumber(nums);
            foreach (int item in result) {
                Console.WriteLine(item);
            }
        }

        public static int[] SingleNumber(int[] nums) {
            int xor = nums.Aggregate(0, (x, n) => x ^ n);
            int setBit = xor ^ (xor & (xor - 1));
            int xor0 = 0, xor1 = 0;
            foreach (int num in nums) {
                if ((num & setBit) == 0) {
                    xor0 ^= num;
                }
                else {
                    xor1 ^= num;
                }
            }
            return new int[] { xor0, xor1 };
        }
    }
}

// Given a directed acyclic graph (DAG) of n nodes labeled from 0 to n - 1, find all possible paths from node 0 to node n - 1, and return them in any order.
// The graph is given as follows: graph[i] is a list of all nodes you can visit from node i (i.e., there is a directed edge from node i to node graph[i] [j]).

// Example 1:
// Input: graph = [[1, 2],[3],[3],[]]
// Output:[[0,1,3],[0,2,3]]
// Explanation: There are two paths: 0-> 1-> 3 and 0-> 2-> 3.

// Example 2:
// Input: graph = [[4, 3, 1],[3,2,4],[3],[4],[]]
// Output:[[0,4],[0,3,4],[0,1,3,4],[0,1,2,3,4],[0,1,4]]

// Example 3:
// Input: graph = [[1],[]]
// Output:[[0,1]]

// Example 4:
// Input: graph = [[1, 2, 3],[2],[3],[]]
// Output:[[0,1,2,3],[0,2,3],[0,3]]

// Example 5:
// Input: graph = [[1, 3],[2],[3],[]]
// Output:[[0,1,2,3],[0,3]]

// Constraints:
// n == graph.length
// 2 <= n <= 15
// 0 <= graph[i][j] < n
// graph[i][j] != i(i.e., there will be no self - loops).
// The input graph is guaranteed to be a DAG.

using System;
using System.Collections.Generic;

namespace JulyFourth {
    public class AllPathsFromSourceToTarget {
        public static void Main(string[] args) {
            int[][] graph = new int[4][];
            graph[0] = new int[2] { 1, 2 };
            graph[1] = new int[1] { 3 };
            graph[2] = new int[1] { 3 };
            graph[3] = new int[0] { };
            foreach (IList<int> item in AllPathsSourceTarget(graph)) {
                foreach (int i in item) {
                    Console.Write(i + " ");
                }
                Console.WriteLine();
            }
        }

        public static IList<IList<int>> AllPathsSourceTarget(int[][] graph) {
            List<IList<int>> result = new List<IList<int>>();
            List<int> path = new List<int>() { 0 };
            PathFunction(0, graph, path, result);
            return result.AsReadOnly();
        }

        private static void PathFunction(int v, int[][] graph, List<int> path, List<IList<int>> result) {
            if (v == graph.Length - 1) {
                result.Add(new List<int>(path));
                return;
            }
            foreach (int x in graph[v]) {
                path.Add(x);
                PathFunction(x, graph, path, result);
                path.RemoveAt(path.Count - 1);
            }
        }
    }
}

// Suppose an array sorted in ascending order is rotated at some pivot unknown to you beforehand.
// (i.e.,  [0, 1, 2, 4, 5, 6, 7] might become  [4,5,6,7,0,1,2]).
// Find the minimum element.
// The array may contain duplicates.
   
// Example 1:
// Input:[1,3,5]
// Output: 1
   
// Example 2:
// Input:[2,2,2,0,1]
// Output: 0
   
// Note:
// This is a follow up problem to Find Minimum in Rotated Sorted Array.
// Would allow duplicates affect the run-time complexity? How and why?

using System;

namespace JulyFourth {
    public class FindMinimumInRotatedSortedArrayII {
        public static void Main(string[] args) {
            int[] nums = new int[] { 2, 2, 2, 0, 1 };
            Console.WriteLine(FindMin(nums));
        }

        public static int FindMin(int[] nums) {
            if (nums.Length == 0) {
                return 0;
            }
            for (int i = 0; i < nums.Length; i++) {
                if (i > 0 && nums[i - 1] > nums[i]) {
                    return nums[i];
                }
            }
            return nums[0];
        }
    }
}

// Given a non-negative integer num, repeatedly add all its digits until the result has only one digit.
   
// Example:
// Input: 38
// Output: 2
// Explanation: The process is like: 3 + 8 = 11, 1 + 1 = 2.
//              Since 2 has only one digit, return it.
   
// Follow up:
// Could you do it without any loop/recursion in O(1) runtime ?

using System;

namespace JulyFourth {
    public class AddDigits {
        public static void Main(string[] args) {
            Console.WriteLine(AddDigitsFunction(38));
        }

        public static int AddDigitsFunction(int num) {
            if (num == 0) {
                return 0;
            }
            return num % 9 == 0 ? 9 : num % 9;
        }
    }
}

// Given inorder and postorder traversal of a tree, construct the binary tree.

// Note:
// You may assume that duplicates do not exist in the tree.

// For example, given
// inorder = [9,3,15,20,7]
// postorder = [9, 15, 7, 20, 3]
// Return the following binary tree:
//     3
//    / \
//   9  20
//     /  \
//    15   7

using System;
using System.Collections.Generic;

namespace JulyFourth {
    public class ConstructBinaryTreeFromInorderAndPostorderTraversal {
        public static void Main(string[] args) {
            int[] inOrder = new int[] { 9, 3, 15, 20, 7 };
            int[] postOrder = new int[] { 9, 15, 7, 20, 3 };
            TreeNode node = BuildTree(inOrder, postOrder);
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

        static int current;
        public static TreeNode BuildTree(int[] inOrder, int[] postOrder) {
            current = postOrder.Length - 1;
            Dictionary<int, int> map = new Dictionary<int, int>();
            for (int i = 0; i < inOrder.Length; i++) {
                map.Add(inOrder[i], i);
            }
            return BuildTheTree(inOrder, postOrder, 0, inOrder.Length - 1, map);
        }

        private static TreeNode BuildTheTree(int[] inOrder, int[] postOrder, int start, int end, Dictionary<int, int> map) {
            if (start > end) {
                return null;
            }
            int rootVal = postOrder[current];
            TreeNode root = new TreeNode(rootVal);
            int index = map[rootVal];
            current--;
            root.right = BuildTheTree(inOrder, postOrder, index + 1, end, map);
            root.left = BuildTheTree(inOrder, postOrder, start, index - 1, map);
            return root;
        }
    }
}

// Given a characters array tasks, representing the tasks a CPU needs to do, where each letter represents a different task.
// Tasks could be done in any order. Each task is done in one unit of time. For each unit of time, the CPU could complete either one task or just be idle.
// However, there is a non-negative integer n that represents the cooldown period between two same tasks (the same letter in the array),
// that is that there must be at least n units of time between any two same tasks.
// Return the least number of units of times that the CPU will take to finish all the given tasks.
   
// Example 1:
// Input: tasks = ["A", "A", "A", "B", "B", "B"], n = 2
// Output: 8
// Explanation:
// A->B->idle->A->B->idle->A->B
// There is at least 2 units of time between any two same tasks.
   
// Example 2:
// Input: tasks = ["A", "A", "A", "B", "B", "B"], n = 0
// Output: 6
// Explanation: On this case any permutation of size 6 would work since n = 0.
// ["A","A","A","B","B","B"]
// ["A","B","A","B","A","B"]
// ["B","B","B","A","A","A"]
// ...
// And so on.
   
// Example 3:
// Input: tasks = ["A", "A", "A", "A", "A", "A", "B", "C", "D", "E", "F", "G"], n = 2
// Output: 16
// Explanation:
// One possible solution is
// A -> B->C->A->D->E->A->F->G->A->idle->idle->A->idle->idle->A
   
// Constraints:
// 1 <= task.length <= 104
// tasks[i] is upper -case English letter.
// The integer n is in the range [0, 100].

using System;

namespace JulyFourth {
    public class TaskScheduler {
        public static void Main(string[] args) {
            char[] tasks = new char[] { 'A', 'A', 'A', 'B', 'B', 'B' };
            int n = 2;
            Console.WriteLine(LeastInterval(tasks, n));
        }

        public static int LeastInterval(char[] tasks, int n) {
            int maxFreq = 0, cnt = 0;
            int[] freq = new int[26];
            foreach (char t in tasks) {
                freq[t - 'A']++;
                // Find the most frequent task
                if (freq[t - 'A'] > maxFreq) {
                    maxFreq = freq[t - 'A'];
                    cnt = 1;
                }
                // Count the number of most frequent tasks
                else if (freq[t - 'A'] == maxFreq) {
                    cnt++;
                }
            }
            // maxFreq - 1: blocks needed to allocate the first maxFreq-1 most-frequent task
            // n + 1: each block needs n+1 spaces due the the cooling interval.
            // cnt: Size of last block = number of most-frequent tasks
            int interval = (maxFreq - 1) * (n + 1) + cnt;
            return interval < tasks.Length ? tasks.Length : interval;
        }
    }
}
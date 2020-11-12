// Given an array of integers arr, sort the array by performing a series of pancake flips.
// In one pancake flip we do the following steps:
// Choose an integer k where 1 <= k <= arr.length.
// Reverse the sub-array arr[1...k].
// For example, if arr = [3,2,1,4] and we performed a pancake flip choosing k = 3, we reverse the sub-array [3,2,1],
// so arr = [1, 2, 3, 4] after the pancake flip at k = 3.
// Return the k-values corresponding to a sequence of pancake flips that sort arr.
// Any valid answer that sorts the array within 10 * arr.length flips will be judged as correct.

// Example 1:
// Input: arr = [3, 2, 4, 1]
// Output:[4,2,4,3]
// Explanation:
// We perform 4 pancake flips, with k values 4, 2, 4, and 3.
// Starting state: arr = [3, 2, 4, 1]
// After 1st flip(k = 4): arr = [1, 4, 2, 3]
// After 2nd flip(k = 2): arr = [4, 1, 2, 3]
// After 3rd flip(k = 4): arr = [3, 2, 1, 4]
// After 4th flip(k = 3): arr = [1, 2, 3, 4], which is sorted.
// Notice that we return an array of the chosen k values of the pancake flips.

// Example 2:
// Input: arr = [1, 2, 3]
// Output:[]
// Explanation: The input is already sorted, so there is no need to flip anything.
// Note that other answers, such as [3, 3], would also be accepted.

// Constraints:
// 1 <= arr.length <= 100
// 1 <= arr[i] <= arr.length
// All integers in arr are unique (i.e. arr is a permutation of the integers from 1 to arr.length).

using System;
using System.Collections.Generic;

namespace AugFifth {
    public class PancakeSorting {
        public static void Main(string[] args) {
            int[] arr = new int[] { 3, 2, 4, 1 };
            foreach (int i in PancakeSort(arr)) {
                Console.Write(i + " ");
            }
        }

        public static IList<int> PancakeSort(int[] arr) {
            List<int> res = new List<int>();
            if (arr == null || arr.Length == 0) {
                return res;
            }
            int max = arr.Length;
            while (max > 1) {
                int maxIndex = GetIndexOfMaxValue(arr, max);
                Flip(arr, 0, maxIndex);
                res.Add(maxIndex + 1);
                Flip(arr, 0, max - 1);
                res.Add(max);
                max--;
            }
            return res;
        }

        private static int GetIndexOfMaxValue(int[] arr, int max) {
            for (int i = 0; i < arr.Length; i++) {
                if (arr[i] == max) {
                    return i;
                }
            }
            return -1;
        }

        private static void Flip(int[] arr, int start, int end) {
            while (start < end) {
                int temp = arr[start];
                arr[start] = arr[end];
                arr[end] = temp;
                start++;
                end--;
            }
        }
    }
}

// Given a non-empty array of unique positive integers A, consider the following graph:
// There are A.length nodes, labelled A[0] to A[A.length - 1];
// There is an edge between A[i] and A[j] if and only if A[i] and A[j] share a common factor greater than 1.
// Return the size of the largest connected component in the graph.

// Example 1:
// Input:[4,6,15,35]
// Output: 4
// 4-6-15-13

// Example 2:
// Input:[20,50,9,63]
// Output: 2
// 20-50 9-63

// Example 3:
// Input:[2,3,6,7,4,12,21,39]
// Output: 8

// Note:
// 1 <= A.length <= 20000
// 1 <= A[i] <= 100000

using System;
using System.Collections.Generic;

namespace AugFifth {
    public class LargestComponentSizeByCommonFactor {
        public static void Main(string[] args) {
            int[] A = new int[] { 2, 3, 6, 7, 4, 12, 21, 39 };
            Console.WriteLine(LargestComponentSize(A));
        }

        public static int LargestComponentSize(int[] A) {
            int maxLen = 1;
            int[] countOf = new int[A.Length];
            int[] component = new int[A.Length];
            Dictionary<int, int> map = new Dictionary<int, int>();
            for (int i = 0; i < A.Length; i++) {
                int n = A[i], m = (int)Math.Sqrt(n);
                countOf[i] = 1;
                component[i] = i;
                for (int x = 2; x <= m; x++) {
                    bool match = false;
                    while (n % x == 0) {
                        match = true;
                        n /= x;
                    }
                    if (match) {
                        m = (int)Math.Sqrt(n);
                        SetFactor(i, x);
                    }
                }
                if (n > 1) {
                    SetFactor(i, n);
                }
            }
            return maxLen;

            void SetFactor(int i, int x) {
                if (map.TryGetValue(x, out var j)) {
                    Union(i, j);
                }
                else {
                    map.Add(x, i);
                }
            }

            void Union(int a, int b) {
                int ac = FindNumber(a);
                int bc = FindNumber(b);
                if (ac != bc) {
                    int a1 = countOf[ac];
                    int b1 = countOf[bc];
                    component[ac] = bc;
                    countOf[bc] = a1 + b1;
                    maxLen = Math.Max(maxLen, a1 + b1);
                }
            }

            int FindNumber(int c) {
                while (c != component[c]) {
                    c = component[c] = component[component[c]];
                }
                return c;
            }
        }
    }
}

// Given a root node reference of a BST and a key, delete the node with the given key in the BST. Return the root node reference (possibly updated) of the BST.
// Basically, the deletion can be divided into two stages:
// Search for a node to remove.
// If the node is found, delete the node.
// Follow up: Can you solve it with time complexity O(height of tree) ?

// Example 1:
//     5          5
//    / \        / \
//   3   6  =>  4   6
//  / \   \    /     \
// 2   4   7  2       7
// Input: root = [5, 3, 6, 2, 4, null, 7], key = 3
// Output: [5,4,6,2,null,null,7]
// Explanation: Given key to delete is 3. So we find the node with value 3 and delete it.
// One valid answer is [5,4,6,2,null,null,7], shown in the above BST.
// Please notice that another valid answer is [5,2,6,null,4,null,7] and it's also accepted.
//   5
//  / \
// 2   6
//  \   \
//   4   7

// Example 2:
// Input: root = [5, 3, 6, 2, 4, null, 7], key = 0
// Output:[5,3,6,2,4,null,7]
// Explanation: The tree does not contain a node with value = 0.

// Example 3:
// Input: root = [], key = 0
// Output:[]

// Constraints:
// The number of nodes in the tree is in the range [0, 10^4].
// -10^5 <= Node.val <= 10^5
// Each node has a unique value.
// root is a valid binary search tree.
// -10^5 <= key <= 10^5

using System;
using System.Collections.Generic;

namespace AugFifth {
    public class DeleteNodeInBST {
        public static void Main(string[] args) {
            TreeNode root = new TreeNode {
                val = 5,
                left = new TreeNode {
                    val = 3,
                    left = new TreeNode {
                        val = 2,
                        left = null,
                        right = null
                    },
                    right = new TreeNode {
                        val = 4,
                        left = null,
                        right = null
                    }
                },
                right = new TreeNode {
                    val = 6,
                    left = null,
                    right = new TreeNode {
                        val = 7,
                        left = null,
                        right = null
                    }
                }
            };
            Cw(DeleteNode(root, 3));
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

        public static TreeNode DeleteNode(TreeNode root, int key) {
            if (root == null) {
                return root;
            }
            if (root.val < key) {
                root.right = DeleteNode(root.right, key);
            }
            else if (root.val > key) {
                root.left = DeleteNode(root.left, key);
            }
            else {
                if (root.left == null && root.right == null) {
                    return null;
                }
                if (root.left == null || root.right == null) {
                    if (root.right == null) {
                        return root.left;
                    }
                    else {
                        return root.right;
                    }
                }
                TreeNode rightMin = root.right;
                while (rightMin.left != null) {
                    rightMin = rightMin.left;
                }
                root.val = rightMin.val;
                root.right = DeleteNode(root.right, rightMin.val);
            }
            return root;
        }
    }
}
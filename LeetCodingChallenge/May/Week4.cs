// Given a string, sort it in decreasing order based on the frequency of characters.

// Example 1:
// Input:
// "tree"
// Output:
// "eert"
// Explanation:
// 'e' appears twice while 'r' and 't' both appear once.
// So 'e' must appear before both 'r' and 't'. Therefore "eetr" is also a valid answer.

// Example 2:
// Input:
// "cccaaa"
// Output:
// "cccaaa"
// Explanation:
// Both 'c' and 'a' appear three times, so "aaaccc" is also a valid answer.
// Note that "cacaca" is incorrect, as the same characters must be together.

// Example 3:
// Input:
// "Aabb"
// Output:
// "bbAa"
// Explanation:
// "bbaA" is also a valid answer, but "Aabb" is incorrect.
// Note that 'A' and 'a' are treated as two different characters.

using System;
using System.Text;

namespace MayFourth {
    public class SortCharactersByFrequency {
        public static void Main(string[] args) {
            Console.WriteLine(FrequencySort("Aabbcsdd"));
        }

        public static string FrequencySort(string s) {
            if (string.IsNullOrEmpty(s) || s.Length <= 2) {
                return s;
            }
            int[][] freq = new int[128][];
            for (int i = 0; i < 128; i++) {
                freq[i] = new int[2];
                freq[i][0] = i;
            }
            foreach (char c in s) {
                freq[c][1]++;
            }
            Array.Sort(freq, (x, y) => y[1].CompareTo(x[1]));
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < 128; i++) {
                sb.Append((char)(freq[i][0]), freq[i][1]);
            }
            return sb.ToString();
        }
    }
}

// Given two lists of closed intervals, each list of intervals is pairwise disjoint and in sorted order.
// Return the intersection of these two interval lists.
// (Formally, a closed interval [a, b] (with a <= b) denotes the set of real numbers x with a <= x <= b.
// The intersection of two closed intervals is a set of real numbers that is either empty, or can be represented as a closed interval.
// For example, the intersection of[1, 3] and[2, 4] is [2, 3].)

// Example 1:
//      ____       __________         ____________________    __
// A   |____|     |__________|       |____________________|  |__|
//        ________        ________        __________________    __
// B     |________|      |________|      |__________________|  |__|
//        __              ____            ________________
// ans   |__|     |      |____|          |________________|  |  |
//     0       4         8        12       16       20      24
// Input: A = [[0,2],[5,10],[13,23],[24,25]], B = [[1,5],[8,12],[15,24],[25,26]]
// Output: [[1,2],[5,5],[8,10],[15,23],[24,24],[25,25]]

// Note:
// 0 <= A.length< 1000
// 0 <= B.length< 1000
// 0 <= A[i].start, A[i].end, B[i].start, B[i].end< 10^9

using System;
using System.Collections.Generic;

namespace MayFourth {
    public class IntervalListIntersections {
        public static void Main(string[] args) {
            int[][] A = new int[4][];
            A[0] = new int[] { 0, 2 };
            A[1] = new int[] { 5, 10 };
            A[2] = new int[] { 13, 23 };
            A[3] = new int[] { 24, 25 };
            int[][] B = new int[4][];
            B[0] = new int[] { 1, 5 };
            B[1] = new int[] { 8, 12 };
            B[2] = new int[] { 15, 24 };
            B[3] = new int[] { 25, 26 };
            int[][] C = IntervalIntersection(A, B);
            foreach (int[] item in C) {
                foreach (int i in item) {
                    Console.Write(i + " ");
                }
                Console.WriteLine();
            }
        }

        public static int[][] IntervalIntersection(int[][] A, int[][] B) {
            var result = new List<int[]>();
            int i = 0, j = 0;
            while (i < A.Length && j < B.Length) {
                int low = Math.Max(A[i][0], B[j][0]);
                int high = Math.Min(A[i][1], B[j][1]);
                if (low <= high) {
                    result.Add(new int[2] { low, high });
                }
                var maxBoundry = Math.Max(A[i][1], B[j][1]);
                if (A[i][1] < maxBoundry) {
                    i++;
                }
                else {
                    j++;
                }
            }
            return result.ToArray();
        }
    }
}

// Return the root node of a binary search tree that matches the given preorder traversal.
// (Recall that a binary search tree is a binary tree where for every node, any descendant of node.left has a value<node.val,
// and any descendant of node.right has a value > node.val. Also recall that a preorder traversal displays the value of the node first,
// then traverses node.left, then traverses node.right.)
// It's guaranteed that for the given test cases there is always possible to find a binary search tree with the given requirements.

// Example 1:
//     8
//    / \
//   5  10
//  / \   \
// 1   7   12
// Input: [8,5,1,7,10,12]
// Output: [8,5,10,1,7,null,12]

// Constraints:
// 1 <= preorder.length <= 100
// 1 <= preorder[i] <= 10^8
// The values of preorder are distinct.

using System;
using System.Collections.Generic;

namespace MayFourth {
    public class ConstructBinarySearchTreeFromPreorderTraversal {
        public static void Main(string[] args) {
            TreeNode result = BstFromPreorder(new int[] { 8, 5, 1, 7, 10, 12 });
            Cw(result);
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

        public static TreeNode BstFromPreorder(int[] preorder) {
            return preorderTraversal(preorder, 0, preorder.Length - 1);
        }

        private static TreeNode preorderTraversal(int[] preorder, int start, int end) {
            if (start >= preorder.Length || start > end) {
                return null;
            }
            int rootValue = preorder[start];
            TreeNode root = new TreeNode(rootValue);
            int lastOne = start;
            for (int i = start; i <= end; i++) {
                int current = preorder[i];
                if (current > rootValue) {
                    break;
                }
                lastOne = i;
            }
            root.left = preorderTraversal(preorder, start + 1, lastOne);
            root.right = preorderTraversal(preorder, lastOne + 1, end);
            return root;
        }
    }
}

// We write the integers of A and B(in the order they are given) on two separate horizontal lines.
// Now, we may draw connecting lines: a straight line connecting two numbers A[i] and B[j] such that:
// A[i] == B[j];
// The line we draw does not intersect any other connecting(non-horizontal) line.
// Note that a connecting lines cannot intersect even at the endpoints: each number can only belong to one connecting line.
// Return the maximum number of connecting lines we can draw in this way.

// Example 1:
// 1 4 2
// |  \
// 1 2 4
// Input: A = [1, 4, 2], B = [1, 2, 4]
// Output: 2
// Explanation: We can draw 2 uncrossed lines as in the diagram.
// We cannot draw 3 uncrossed lines, because the line from A[1]= 4 to B[2]= 4 will intersect the line from A[2]= 2 to B[1]=2.

// Example 2:
// Input: A = [2, 5, 1, 2, 5], B = [10, 5, 2, 1, 5, 2]
// Output: 3

// Example 3:
// Input: A = [1, 3, 7, 1, 7, 5], B = [1, 9, 2, 5, 1]
// Output: 2

// Note:
// 1 <= A.length <= 500
// 1 <= B.length <= 500
// 1 <= A[i], B[i] <= 2000

using System;
using System.Collections.Generic;
using System.Linq;

namespace MayFourth {
    public class UncrossedLines {
        public static void Main(string[] args) {
            int[] A = new int[] { 1, 3, 7, 1, 7, 5 };
            int[] B = new int[] { 1, 9, 2, 5, 1 };
            Console.WriteLine(MaxUncrossedLines(A, B));
        }

        public static int MaxUncrossedLines(int[] A, int[] B) {
            int rows = A.Length;
            int cols = B.Length;
            int[,] dp = new int[rows, cols];
            for (int row = 0; row < rows; row++) {
                for (int col = 0; col < cols; col++) {
                    int value1 = A[row];
                    int value2 = B[col];
                    bool isEqual = value1 == value2;
                    List<int> list = new List<int>();
                    if (row > 0) {
                        list.Add(dp[row - 1, col]);
                    }
                    if (col > 0) {
                        list.Add(dp[row, col - 1]);
                    }
                    int thirdValue = isEqual ? 1 : 0;
                    if (row > 0 && col > 0) {
                        thirdValue += dp[row - 1, col - 1];
                    }
                    list.Add(thirdValue);
                    dp[row, col] = list.ToArray().Max();
                }
            }
            return dp[rows - 1, cols - 1];
        }
    }
}

// Given a binary array, find the maximum length of a contiguous subarray with equal number of 0 and 1.

// Example 1:
// Input: [0,1]
// Output: 2
// Explanation: [0, 1] is the longest contiguous subarray with equal number of 0 and 1.

// Example 2:
// Input: [0,1,0]
// Output: 2
// Explanation: [0, 1] (or[1, 0]) is a longest contiguous subarray with equal number of 0 and 1.

// Note: The length of the given binary array will not exceed 50,000.

using System;
using System.Collections.Generic;

namespace MayFourth {
    public class ContiguousArray {
        public static void Main(string[] args) {
            int[] nums = new int[] { 0, 1, 0 };
            Console.WriteLine(FindMaxLength(nums));
        }

        public static int FindMaxLength(int[] nums) {
            if (nums == null || nums.Length == 0) {
                return 0;
            }
            Dictionary<int, int> dp = new Dictionary<int, int>();
            dp[0] = -1;
            int maxLen = 0;
            int len = 0;
            for (int i = 0; i < nums.Length; ++i) {
                len += (nums[i] == 0) ? -1 : 1;
                if (dp.ContainsKey(len)) {
                    maxLen = Math.Max(maxLen, i - dp[len]);
                }
                else {
                    dp[len] = i;
                }
            }
            return maxLen;
        }
    }
}

// Given a set of N people(numbered 1, 2, ..., N), we would like to split everyone into two groups of any size.
// Each person may dislike some other people, and they should not go into the same group.
// Formally, if dislikes[i] = [a, b], it means it is not allowed to put the people numbered a and b into the same group.
// Return true if and only if it is possible to split everyone into two groups in this way.

// Example 1:
// Input: N = 4, dislikes = [[1, 2], [1,3], [2,4]]
// Output: true
// Explanation: group1[1, 4], group2[2, 3]

// Example 2:
// Input: N = 3, dislikes = [[1,2],[1,3],[2,3]]
// Output: false

// Example 3:
// Input: N = 5, dislikes = [[1,2],[2,3],[3,4],[4,5],[1,5]]
// Output: false

// Constraints:
// 1 <= N <= 2000
// 0 <= dislikes.length <= 10000
// dislikes[i].length == 2
// 1 <= dislikes[i][j] <= N
// dislikes[i][0] < dislikes[i][1]
// There does not exist i != j for which dislikes[i] == dislikes[j].

using System;
using System.Collections.Generic;

namespace MayFourth {
    public class PossibleBipartition {
        public static void Main(string[] args) {
            int N = 4;
            int[][] dislikes = new int[3][];
            dislikes[0] = new int[] { 1, 2 };
            dislikes[1] = new int[] { 1, 3 };
            dislikes[2] = new int[] { 2, 4 };
            Console.WriteLine(PossibleBipartitions(N, dislikes));
        }

        public static bool PossibleBipartitions(int N, int[][] dislikes) {
            if (dislikes.Length == 0) {
                return true;
            }
            Dictionary<int, List<int>> adjacent = new Dictionary<int, List<int>>();
            foreach (int[] d in dislikes) {
                if (!adjacent.ContainsKey(d[0])) {
                    adjacent[d[0]] = new List<int>();
                }
                adjacent[d[0]].Add(d[1]);
                if (!adjacent.ContainsKey(d[1])) {
                    adjacent[d[1]] = new List<int>();
                }
                adjacent[d[1]].Add(d[0]);
            }
            int[] groups = new int[N + 1];
            Queue<int> queue = new Queue<int>();
            foreach (int i in adjacent.Keys) {
                if (groups[i] != 0) {
                    continue;
                }
                groups[i] = 1;
                queue.Enqueue(i);
                while (queue.Count > 0) {
                    int qi = queue.Dequeue();
                    foreach (int aqi in adjacent[qi]) {
                        if (groups[aqi] == 0) {
                            groups[aqi] = groups[qi] ^ 2;
                            queue.Enqueue(aqi);
                        }
                        else {
                            if (groups[aqi] == groups[qi]) {
                                return false;
                            }
                        }
                    }
                }
            }
            return true;
        }
    }
}

// Given a non negative integer number num.
// For every numbers i in the range 0 ≤ i ≤ num calculate the number of 1's in their binary representation and return them as an array.

// Example 1:
// Input: 2
// Output: [0,1,1]

// Example 2:
// Input: 5
// Output: [0,1,1,2,1,2]

// Follow up:
// It is very easy to come up with a solution with run time O(n*sizeof(integer)). But can you do it in linear time O(n) /possibly in a single pass?
// Space complexity should be O(n).
// Can you do it like a boss? Do it without using any builtin function like __builtin_popcount in c++ or in any other language.

using System;

namespace MayFourth {
    public class CountingBits {
        public static void Main(string[] args) {
            int num = 4;
            int[] result = CountBits(num);
            foreach (int item in result) {
                Console.Write(item + " ");
            }
        }

        public static int[] CountBits(int num) {
            int[] arr = new int[num + 1];
            int prev2 = 0;
            int next2 = 1;
            for (int i = 1; i <= num; i++) {
                if (i == next2) {
                    arr[i] = 1;
                    prev2 = next2;
                    next2 *= 2;
                }
                else {
                    arr[i] = arr[i - prev2] + 1;
                }
            }
            return arr;
        }
    }
}
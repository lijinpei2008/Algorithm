// Given an array nums of n integers where n > 1,  return an array output such that output[i] is equal to the product of all the elements of nums except nums[i].

// Example:
// Input:  [1,2,3,4]
// Output: [24,12,8,6]

// Constraint: It's guaranteed that the product of the elements of any prefix or suffix of the array (including the whole array) fits in a 32 bit integer.

// Note: Please solve it without division and in O(n).

// Follow up:
// Could you solve it with constant space complexity? (The output array does not count as extra space for the purpose of space complexity analysis.)

using System;

namespace AprilThird {
    public class ProductOfArrayExceptSelf {
        public static void Main(string[] args) {
            int[] nums = { 1, 2, 3, 4 };
            int[] val = ProductExceptSelfs1(nums);
            foreach (int item in val) {
                Console.Write(item + " ");
            }
            Console.WriteLine();
            val = ProductExceptSelfs2(nums);
            foreach (int item in val) {
                Console.Write(item + " ");
            }
        }

        public static int[] ProductExceptSelfs1(int[] nums) {
            int length = nums.Length;
            int[] L = new int[length];
            int[] R = new int[length];
            int[] answer = new int[length];
            L[0] = 1;
            for (int i = 1; i < length; i++) {
                L[i] = nums[i - 1] * L[i - 1];
            }
            R[length - 1] = 1;
            for (int i = length - 2; i >= 0; i--) {
                R[i] = nums[i + 1] * R[i + 1];
            }
            for (int i = 0; i < length; i++) {
                answer[i] = L[i] * R[i];
            }
            return answer;
        }

        public static int[] ProductExceptSelfs2(int[] nums) {
            int length = nums.Length;
            int[] answer = new int[length];
            answer[0] = 1;
            for (int i = 1; i < length; i++) {
                answer[i] = nums[i - 1] * answer[i - 1];
            }
            int R = 1;
            for (int i = length - 1; i >= 0; i--) {
                answer[i] = answer[i] * R;
                R *= nums[i];
            }
            return answer;
        }
    }
}

// Given a string containing only three types of characters: '(', ')' and '*', write a function to check whether this string is valid.
// We define the validity of a string by these rules:
// Any left parenthesis '(' must have a corresponding right parenthesis ')'.
// Any right parenthesis ')' must have a corresponding left parenthesis '('.
// Left parenthesis '(' must go before the corresponding right parenthesis ')'.
// '*' could be treated as a single right parenthesis ')' or a single left parenthesis '(' or an empty string.
// An empty string is also valid.

// Example 1:
// Input: "()"
// Output: True

// Example 2:
// Input: "(*)"
// Output: True

// Example 3:
// Input: "(*))"
// Output: True

// Note:
// The string size will be in the range [1, 100].

using System;

namespace AprilThird {
    public class ValidParenthesisString {
        public static void Main(string[] args) {
            string s = "()";
            Console.WriteLine(CheckValidString(s));
        }

        public static bool CheckValidString(string s) {
            int lo = 0, hi = 0;
            foreach (char c in s.ToCharArray()) {
                lo += c == '(' ? 1 : -1;
                hi += c != ')' ? 1 : -1;
                if (hi < 0) break;
                lo = Math.Max(lo, 0);
            }
            return lo == 0;
        }
    }
}

// Given a 2d grid map of '1's(land) and '0's(water), count the number of islands.
// An island is surrounded by water and is formed by connecting adjacent lands horizontally or vertically.
// You may assume all four edges of the grid are all surrounded by water.
   
// Example 1:
// Input:
// 11110
// 11010
// 11000
// 00000
// Output: 1
   
// Example 2:
// Input:
// 11000
// 11000
// 00100
// 00011
// Output: 3

using System;

namespace AprilThird {
    public class NumberOfIslands {
        public static void Main(string[] args) {
            char[][] grid = new char[4][];
            grid[0] = new char[5] { '1', '1', '0', '0', '0' };
            grid[1] = new char[5] { '1', '1', '0', '0', '0' };
            grid[2] = new char[5] { '0', '0', '1', '0', '0' };
            grid[3] = new char[5] { '0', '0', '0', '1', '1' };
            Console.WriteLine(NumIslands(grid));
        }

        public static int NumIslands(char[][] grid) {
            if (grid == null || grid.Length == 0)
                return 0;
            int R = grid.Length;
            int C = grid[0].Length;
            int numIslands = 0;
            for (int r = 0; r < R; r++) {
                for (int c = 0; c < C; c++) {
                    if (grid[r][c] == '1') {
                        numIslands++;
                        Dfs(grid, r, c, R, C);
                    }
                }
            }
            return numIslands;
        }

        public static void Dfs(char[][] grid, int r, int c, int R, int C) {
            if (r < 0 || r >= R || c < 0 || c >= C || grid[r][c] == '0')
                return;
            grid[r][c] = '0';
            Dfs(grid, r, c - 1, R, C);
            Dfs(grid, r, c + 1, R, C);
            Dfs(grid, r - 1, c, R, C);
            Dfs(grid, r + 1, c, R, C);
        }
    }
}

// Given a m x n grid filled with non-negative numbers, find a path from top left to bottom right which minimizes the sum of all numbers along its path.
// Note: You can only move either down or right at any point in time.

// Example:
// Input:
// [
//   [1,3,1],
//   [1,5,1],
//   [4,2,1]
// ]
// Output: 7
// Explanation: Because the path 1→3→1→1→1 minimizes the sum.

using System;

namespace AprilThird {
    public class MinimumPathSum {
        public static void Main(string[] args) {
            int[][] grid = new int[3][];
            grid[0] = new int[3] { 1, 3, 1 };
            grid[1] = new int[3] { 1, 5, 1 };
            grid[2] = new int[3] { 1, 1, 1 };
            Console.WriteLine(MinPathSum(grid));
        }

        public static int MinPathSum(int[][] grid) {
            if (grid == null || grid.Length == 0) {
                return 0;
            }
            int[,] dp = new int[grid.Length, grid[0].Length];
            for (int i = 0; i < grid.Length; i++) {
                for (int j = 0; j < grid[0].Length; j++) {
                    dp[i, j] += grid[i][j];
                    if (i > 0 && j > 0) {
                        dp[i, j] += Math.Min(dp[i - 1, j], dp[i, j - 1]);
                    }
                    else if (i > 0) {
                        dp[i, j] += dp[i - 1, j];
                    }
                    else if (j > 0) {
                        dp[i, j] += dp[i, j - 1];
                    }
                }
            }
            return dp[grid.Length - 1, grid[0].Length - 1];
        }
    }
}

// Suppose an array sorted in ascending order is rotated at some pivot unknown to you beforehand.
// (i.e., [0,1,2,4,5,6,7] might become [4,5,6,7,0,1,2]).
// You are given a target value to search.If found in the array return its index, otherwise return -1.
// You may assume no duplicate exists in the array.
// Your algorithm's runtime complexity must be in the order of O(log n).
   
// Example 1:
// Input: nums = [4, 5, 6, 7, 0, 1, 2], target = 0
// Output: 4
   
// Example 2:
// Input: nums = [4, 5, 6, 7, 0, 1, 2], target = 3
// Output: -1

using System;

namespace AprilThird {
    public class SearchInRotatedSortedArray {
        public static void Main(string[] args) {
            int[] nums = { 1, 3 };
            int target = 0;
            Console.WriteLine(Search(nums, target));
        }

        public static int Search(int[] nums, int target) {
            if (nums == null || nums.Length == 0) {
                return -1;
            }
            int start = 0;
            int end = nums.Length - 1;
            while (start <= end) {
                int mid = start + (end - start) / 2;
                if (nums[mid] == target) {
                    return mid;
                }
                if (target >= nums[0]) {
                    if (nums[mid] < nums[0]) {
                        end = mid - 1;
                    }
                    else {
                        if (nums[mid] > target) {
                            end = mid - 1;
                        }
                        else {
                            start = mid + 1;
                        }
                    }
                }
                else {
                    if (nums[mid] >= nums[0]) {
                        start = mid + 1;
                    }
                    else {
                        if (nums[mid] > target) {
                            end = mid - 1;
                        }
                        else {
                            start = mid + 1;
                        }
                    }
                }
            }
            return -1;
        }
    }
}

// Return the root node of a binary search tree that matches the given preorder traversal.
// (Recall that a binary search tree is a binary tree where for every node, any descendant of node.left has a value<node.val, and any descendant of node.right has a value > node.val.Also recall that a preorder traversal displays the value of the node first, then traverses node.left, then traverses node.right.)
// It's guaranteed that for the given test cases there is always possible to find a binary search tree with the given requirements.
   
// Example 1:
//     8
//    / \
//   5   10
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

namespace AprilThird {
    public class ConstructBinarySearchTreeFromPreorderTraversal {
        public static void Main(string[] args) {
            int[] preorder = { 8, 5, 1, 7, 10, 12 };
            TreeNode node = BstFromPreorder(preorder);
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

        public static TreeNode BstFromPreorder(int[] preorder) {
            return BstFromPreorderInternal(preorder, 0, preorder.Length - 1);
        }

        private static TreeNode BstFromPreorderInternal(int[] preorder, int start, int end) {
            if (start > end) {
                return null;
            }
            var root = new TreeNode(preorder[start]);
            int mid = start;
            while (mid <= end) {
                if (preorder[mid] > root.val) {
                    break;
                }
                mid += 1;
            }
            root.left = BstFromPreorderInternal(preorder, start + 1, mid - 1);
            root.right = BstFromPreorderInternal(preorder, mid, end);
            return root;
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
}
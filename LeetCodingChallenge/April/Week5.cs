// Given a non-empty binary tree, find the maximum path sum.
// For this problem, a path is defined as any sequence of nodes from some starting node to any node in the tree along the parent-child connections. 
// The path must contain at least one node and does not need to go through the root.

// Example 1:
// Input: [1,2,3]
//        1
//       / \
//      2   3
// Output: 6

// Example 2:
// Input: [-10,9,20,null,null,15,7]
//    -10
//    / \
//   9  20
//     /  \
//    15   7
// Output: 42

using System;

namespace AprilFifth {
    public class BinaryTreeMaximumPathSum {
        public static void Main(string[] args) {
            TreeNode root = new TreeNode {
                val = -10,
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
            Console.WriteLine(MaxPathSum(root));
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

        public static int MaxPathSum(TreeNode root) {
            // check bad input
            if (root == null) {
                return 0;
            }
            // Initialize max to the minimum value
            int maxSum = int.MinValue;
            // Use a helper method and pass the maxSum as reference
            MaxPathSumHelper(root, ref maxSum);
            return maxSum;
        }

        public static int MaxPathSumHelper(TreeNode root, ref int maxSum) {
            // if the child is null return 0 so there is no any impact in the addition
            if (root == null) {
                return 0;
            }
            int leftSum = MaxPathSumHelper(root.left, ref maxSum);
            int rightSum = MaxPathSumHelper(root.right, ref maxSum);
            int closedPathSum = root.val;
            bool onePositiveChild = false;
            // We add a child only if it's value is positive
            if (leftSum > 0) {
                closedPathSum += leftSum;
                onePositiveChild = true;
            }
            if (rightSum > 0) {
                closedPathSum += rightSum;
                onePositiveChild = true;
            }
            // Compare to the max value
            if (closedPathSum > maxSum) {
                maxSum = closedPathSum;
            }
            // We will return here the maximum sum of opened path:
            // root+left or root+right or root
            int openedPathSum = root.val;
            if (onePositiveChild) {
                openedPathSum += (leftSum > rightSum ? leftSum : rightSum);
            }
            return openedPathSum;
        }
    }
}
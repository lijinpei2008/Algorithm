// A divide-and-conquer algorithm works by recursively breaking the problem down into two or more subproblems of the same or related type,
// until these subproblems become simple enough to be solved directly.
// Then one combines the results of subproblems to form the final solution.

// 1. Divide. Divide the problem {S}S into a set of subproblems:{S1,S2,S3,...,Sn} where n ≥ 2, i.e. there are usually more than one subproblem.
// 2. Conquer. Solve each subproblem recursively. 
// 3. Combine. Combine the results of each subproblem.

// Given an array of integers nums, sort the array in ascending order.
// Example 1:
// Input: nums = [5,2,3,1]
// Output: [1,2,3,5]
// Example 2:
// Input: nums = [5,1,1,2,0,0]
// Output: [0,0,1,1,2,5]

using System;
using System.Collections.Generic;
using System.Linq;

namespace SortAnArray {
    public class Program {
        static void Main(string[] args) {
            Solution solution = new Solution();
            IList<int> num = solution.SortArray(new int[] { 1, 2, 3, 4, 1, 2, -1, -4, -23, 11, 41, 13 });
            foreach (int item in num) {
                Console.Write(item + " ");
            }
        }

        public class Solution {
            public IList<int> SortArray(int[] nums) {
                if (nums == null) {
                    return null;
                }
                if (nums.Length < 2) {
                    return nums.ToList();
                }
                QuickSort(nums, 0, nums.Length - 1);
                return nums.ToList();
            }

            private void QuickSort(int[] nums, int start, int end) {
                if (start >= end) {
                    return;
                }
                int halfVal = nums[(start + end) / 2];
                int leftVal = start;
                int rightVal = end;
                while (leftVal <= rightVal) {
                    while (leftVal <= rightVal && nums[leftVal] < halfVal) {
                        leftVal++;
                    }
                    while (leftVal <= rightVal && nums[rightVal] > halfVal) {
                        rightVal--;
                    }
                    if (leftVal <= rightVal) {
                        // 使用位运算会很快，但是请注意，如果leftVal==rightVal 那么就会出现 a ^= a 从而导致a的值被修改为0
                        // nums[leftVal] ^= nums[rightVal];
                        // nums[rightVal] ^= nums[leftVal];
                        // nums[leftVal] ^= nums[rightVal];
                        int temp = nums[leftVal];
                        nums[leftVal] = nums[rightVal];
                        nums[rightVal] = temp;
                        leftVal++;
                        rightVal--;
                    }
                }
                QuickSort(nums, start, rightVal);
                QuickSort(nums, leftVal, end);
            }
        }
    }
}

using System;
using System.Collections.Generic;

namespace SortAnArray {
    public class Program {
        static void Main(string[] args) {
            Solution solution = new Solution();
            IList<int> num = solution.SortArray(new int[] { 1, 2, 3, 4, 1, 2, -1, -4, -23, 11, 41, 13 });
            foreach (int item in num) {
                Console.Write(item + " ");
            }
        }

        public class Solution {
            public IList<int> SortArray(int[] nums) {
                MergeSort(0, nums.Length - 1);
                return nums;
                void MergeSort(int i, int j) {
                    if (i == j) {
                        return;
                    }
                    int med = (i + j) / 2;
                    MergeSort(i, med);
                    MergeSort(med + 1, j);
                    Merge(i, med, med + 1, j);
                }
                void Merge(int i1, int j1, int i2, int j2) {
                    int fIndex = i1, sIndex = i2;
                    int[] arr = new int[j2 - i1 + 1];
                    int indexToInsert = 0;
                    while (indexToInsert != arr.Length) {
                        if (fIndex > j1 || (sIndex <= j2 && nums[fIndex] > nums[sIndex])) {
                            arr[indexToInsert++] = nums[sIndex++];
                        }
                        else {
                            arr[indexToInsert++] = nums[fIndex++];
                        }
                    }
                    for (int i = 0; i < arr.Length; i++) {
                        nums[i1 + i] = arr[i];
                    }
                }
            }
        }
    }
}

// Java
import java.util.Arrays;
public class Solution {
    public int[] merge_sort(int[] input) {
        if (input.length <= 1) {
            return input;
        }
        // 获取需要排序数组的长度（元素个数）然后从中间拆分为左右两份
        // Java中方法Arrays.copyOfRange（T[] original,int from,int to）的作用是将数组original从from开始进行复制，复制到下标为to的位置，包含[from,to)不包含
        int pivot = input.length / 2;
        int[] left_list = merge_sort(Arrays.copyOfRange(input, 0, pivot));
        int[] right_list = merge_sort(Arrays.copyOfRange(input, pivot, input.length));
        return merge(left_list, right_list);
    }

    public int[] merge(int[] left_list, int[] right_list) {
        int[] ret = new int[left_list.length + right_list.length];
        int left_cursor = 0, right_cursor = 0, ret_cursor = 0;
        while (left_cursor < left_list.length &&
               right_cursor < right_list.length) {
            if (left_list[left_cursor] < right_list[right_cursor]) {
                ret[ret_cursor++] = left_list[left_cursor++];
            }
            else {
                ret[ret_cursor++] = right_list[right_cursor++];
            }
        }
        // append what is remain the above lists
        while (left_cursor < left_list.length) {
            ret[ret_cursor++] = left_list[left_cursor++];
        }
        while (right_cursor < right_list.length) {
            ret[ret_cursor++] = right_list[right_cursor++];
        }
        return ret;
    }
}

// Python
def merge_sort(nums):
    # bottom cases: empty or list of a single element.
    if len(nums) <= 1:
        return nums
    pivot = int(len(nums) / 2)
    left_list = merge_sort(nums[0:pivot])
    right_list = merge_sort(nums[pivot:])
    return merge(left_list, right_list)
def merge(left_list, right_list):
    left_cursor = right_cursor = 0
    ret = []
    while left_cursor<len(left_list) and right_cursor<len(right_list):
        if left_list[left_cursor] < right_list[right_cursor]:
            ret.append(left_list[left_cursor])
            left_cursor += 1
        else:
            ret.append(right_list[right_cursor])
            right_cursor += 1
    # append what is remained in either of the lists
    ret.extend(left_list[left_cursor:])
    ret.extend(right_list[right_cursor:])
    return ret

// Given a binary tree, determine if it is a valid binary search tree(BST).
// Assume a BST is defined as follows:
// The left subtree of a node contains only nodes with keys less than the node's key.
// The right subtree of a node contains only nodes with keys greater than the node's key.
// Both the left and right subtrees must also be binary search trees.
   
// Example 1:
//     2
//    / \
//   1   3
// Input: [2,1,3]
// Output: true
   
// Example 2:
//     5
//    / \
//   1   4
//      / \
//     3   6
// Input: [5,1,4,null,null,3,6]
// Output: false
// Explanation: The root node's value is 5 but its right child's value is 4.
   
using System;
using System.Collections.Generic;
using System.Linq;

namespace SortAnArray {
    public class Program {
        static void Main(string[] args) {
            Solution solution = new Solution();
            TreeNode node = new TreeNode {
                val = 10,
                left = new TreeNode {
                    val = 8,
                    left = new TreeNode {
                        val = 6,
                        left = new TreeNode {
                            val = 4,
                            left = new TreeNode {
                                val = 3,
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
                            val = 7,
                            left = null,
                            right = null
                        }
                    },
                    right = new TreeNode {
                        val = 9,
                        left = null,
                        right = null
                    }
                },
                right = new TreeNode {
                    val = 12,
                    left = new TreeNode {
                        val = 11,
                        left = null,
                        right = null
                    },
                    right = new TreeNode {
                        val = 13,
                        left = null,
                        right = null
                    }
                }
            };
            bool key = solution.IsValidBST(node);
            Console.WriteLine(key);
        }
    }

    public class TreeNode {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x) { val = x; }
        public TreeNode() { }
    }

    public class Solution {
        public bool IsValidBST(TreeNode root) {
            if (root == null) {
                return true;
            }
            Stack<TreeNode> stack = new Stack<TreeNode>();
            TreeNode pre = null;
            while (root != null || stack.Count() > 0) {
                while (root != null) {
                    stack.Push(root);
                    root = root.left;
                }
                root = stack.Pop();
                if (pre != null && root.val <= pre.val) {
                    return false;
                }
                pre = root;
                root = root.right;
            }
            return true;
        }
    }
}

using System;

namespace SortAnArray {
    public class Program {
        static void Main(string[] args) {
            Solution solution = new Solution();
            TreeNode node = new TreeNode {
                val = 50,
                left = new TreeNode {
                    val = 40,
                    left = new TreeNode {
                        val = 30,
                        left = null,
                        right = null
                    },
                    right = new TreeNode {
                        val = 45,
                        left = null,
                        right = null
                    }
                },
                right = new TreeNode {
                    val = 60,
                    left = new TreeNode {
                        val = 55,
                        left = null,
                        right = null
                    },
                    right = new TreeNode {
                        val = 70,
                        left = new TreeNode {
                            val = 65,
                            left = null,
                            right = null
                        },
                        right = new TreeNode {
                            val = 80,
                            left = null,
                            right = null
                        }
                    }
                }
            };
            bool key = solution.IsValidBST(node);
            Console.WriteLine(key);
        }
    }

    public class TreeNode {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x) { val = x; }
        public TreeNode() { }
    }

    public class Solution {
        public bool IsValidBST(TreeNode root) {
            if (root == null) {
                return true;
            }
            if (root.left != null) {
                if (!IsValidLeftChildren(root, root.left)) {
                    return false;
                }
            }
            if (root.right != null) {
                if (!IsValidRightChildren(root, root.right)) {
                    return false;
                }
            }
            return IsValidBST(root.left) && IsValidBST(root.right);
        }

        private bool IsValidLeftChildren(TreeNode root, TreeNode left) {
            if (left == null) {
                return true;
            }
            if (root.val <= left.val) {
                return false;
            }
            return IsValidLeftChildren(root, left.left) && IsValidLeftChildren(root, left.right);
        }

        private bool IsValidRightChildren(TreeNode root, TreeNode right) {
            if (right == null) {
                return true;
            }
            if (root.val >= right.val) {
                return false;
            }
            return IsValidRightChildren(root, right.left) && IsValidRightChildren(root, right.right);
        }
    }
}

using System;

namespace SortAnArray {
    public class Program {
        static void Main(string[] args) {
            Solution solution = new Solution();
            TreeNode node = new TreeNode {
                val = 50,
                left = new TreeNode {
                    val = 40,
                    left = new TreeNode {
                        val = 30,
                        left = null,
                        right = null
                    },
                    right = new TreeNode {
                        val = 45,
                        left = null,
                        right = null
                    }
                },
                right = new TreeNode {
                    val = 60,
                    left = new TreeNode {
                        val = 55,
                        left = null,
                        right = null
                    },
                    right = new TreeNode {
                        val = 70,
                        left = new TreeNode {
                            val = 65,
                            left = null,
                            right = null
                        },
                        right = new TreeNode {
                            val = 80,
                            left = null,
                            right = null
                        }
                    }
                }
            };
            bool key = solution.IsValidBST(node);
            Console.WriteLine(key);
        }
    }

    public class TreeNode {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x) { val = x; }
        public TreeNode() { }
    }

    public class Solution {
        public bool IsValidBST(TreeNode root) {
            return IsValidBST(root, long.MinValue, long.MaxValue);
        }

        private bool IsValidBST(TreeNode root, long minValue, long maxValue) {
            if (root == null) {
                return true;
            }
            if (root.val < minValue || root.val > maxValue) {
                return false;
            }
            return IsValidBST(root.left, minValue * 1L, root.val * 1L - 1)
                && IsValidBST(root.right, root.val * 1L + 1, maxValue * 1L);
        }
    }
}

// Write an efficient algorithm that searches for a value in an m x n matrix.This matrix has the following properties:
// Integers in each row are sorted in ascending from left to right.
// Integers in each column are sorted in ascending from top to bottom.

// Example:
// Consider the following matrix:
// [
//   [1,   4,  7, 11, 15],           /15
//   [2,   5,  8, 12, 19],          /11 /19
//   [3,   6,  9, 16, 22],   =>    /7  /12 /22
//   [10, 13, 14, 17, 24],        /4  /8  /16 /24
//   [18, 21, 23, 26, 30]        /1  /5  /9  /17 /30
// ]                                /2  /6  /14 /26
// Given target = 5, return true.
// Given target = 20, return false.

using System;

namespace SortAnArray {
    public class Program {
        static void Main(string[] args) {
            Solution solution = new Solution();
            int[,] matrix = new int[,] {
                {1, 4, 7, 11, 15},
                {2, 5, 8, 12, 19},
                {3, 6, 9, 16, 22},
                {10, 13, 14, 17, 24}
            };
            bool key = solution.SearchMatrix(matrix, 15);
            Console.WriteLine(key);
        }

        public class Solution {
            public bool SearchMatrix(int[,] matrix, int target) {
                // 二维数组[,]是每行元素个数都相同的数组。交错数组[][]是一种行和列没有要求的数组，际上是一维数组的变种
                // 在int[x,y]中，使用.GetLength(0)获取x的值，使用.GetLength(1)获取y的值。
                if (matrix == null || matrix.GetLength(0) < 1 || matrix.GetLength(1) < 1) {
                    return false;
                }
                // 从数组的右上角开始向左下角进行排查，整个数组向左倾斜45°后呈现出一种变态式的树状结构。
                int col = matrix.GetLength(1) - 1;
                int row = 0;
                while (col >= 0 && row <= matrix.GetLength(0) - 1) {
                    if (target == matrix[row, col]) {
                        return true;
                    }
                    else if (target < matrix[row, col]) {
                        // 前递增++i 优先于 后递增 i++
                        // 因为前递增这种方式避免了额外的寄存器复制
                        --col;
                    }
                    else if (target > matrix[row, col]) {
                        ++row;
                    }
                }
                return false;
            }
        }
    }
}

using System;

namespace SortAnArray {
    public class Program {
        static void Main(string[] args) {
            Solution solution = new Solution();
            int[,] matrix = new int[,] {
                {1, 4, 7, 11, 15},
                {2, 5, 8, 12, 19},
                {3, 6, 9, 16, 22},
                {10, 13, 14, 17, 24}
            };
            bool key = solution.SearchMatrix(matrix, 5);
            Console.WriteLine(key);
        }

        public class Solution {
            public bool SearchMatrix(int[,] matrix, int target) {
                if (matrix == null || matrix.GetLength(0) == 0 || matrix.GetLength(1) == 0) {
                    return false;
                }
                int rows = matrix.GetLength(0);
                int cols = matrix.GetLength(1);
                // 定位右上角
                int row1 = 0;
                int col1 = matrix.GetLength(1) - 1;
                // 定位左下角
                int row2 = matrix.GetLength(0) - 1;
                int col2 = 0;
                while (IsValid(row1, col1, row2, col2, rows, cols)) {
                    if (matrix[row1, col1] == target || matrix[row2, col2] == target) {
                        return true;
                    }
                    if (matrix[row1, col1] < target) {
                        ++row1;
                    }
                    else {
                        --col1;
                    }
                    if (matrix[row2, col2] < target) {
                        ++col2;
                    }
                    else {
                        --row2;
                    }
                }
                return false;
            }

            private bool IsValid(int row1, int col1, int row2, int col2, int rows, int cols) {
                return row1 < rows && col1 >= 0
                    && row2 >= 0 && col2 < cols
                    && (col2 <= col1 && row2 >= row1);
            }
        }
    }
}

// Here are the sample implementation of the quick sort algorithm.

// Java
public class Solution {

    public void quickSort(int[] lst) {
        /* Sorts an array in the ascending order in O(n log n) time */
        int n = lst.length;
        qSort(lst, 0, n - 1);
    }

    private void qSort(int[] lst, int lo, int hi) {
        if (lo < hi) {
            int p = partition(lst, lo, hi);
            qSort(lst, lo, p - 1);
            qSort(lst, p + 1, hi);
        }
    }

    private int partition(int[] lst, int lo, int hi) {
        /*
          Picks the last element hi as a pivot
          and returns the index of pivot value in the sorted array */
        int pivot = lst[hi];
        int i = lo;
        for (int j = lo; j < hi; ++j) {
            if (lst[j] < pivot) {
                int tmp = lst[i];
                lst[i] = lst[j];
                lst[j] = tmp;
                i++;
            }
        }
        int tmp = lst[i];
        lst[i] = lst[hi];
        lst[hi] = tmp;
        return i;
    }

}

// Python
def quicksort(lst):
    """
    Sorts an array in the ascending order in O(n log n) time
    :param nums: a list of numbers
    :return: the sorted list
    """
    n = len(lst)
    qsort(lst, 0, n - 1)

def qsort(lst, lo, hi):
    """
    Helper
    :param lst: the list to sort
    :param lo:  the index of the first element in the list
    :param hi:  the index of the last element in the list
    :return: the sorted list
    """
    if lo<hi:
        p = partition(lst, lo, hi)
        qsort(lst, lo, p - 1)
        qsort(lst, p + 1, hi)

def partition(lst, lo, hi):
    """
    Picks the last element hi as a pivot
     and returns the index of pivot value in the sorted array
    """
    pivot = lst[hi]
    i = lo
    for j in range(lo, hi) :
        if lst[j] < pivot:
            lst[i], lst[j] = lst[j], lst[i]
            i += 1
    lst[i], lst[hi] = lst[hi], lst[i]
    return i

// Other than evaluating the time complexity of recursion algorithms case by case, 
// sometimes you can apply a method called Master Theorem to quickly calculate the time complexity of many recursion algorithms.

// C++
function dac(n ) :
  if n<k:  // k: some constant
    Solve "n" directly without recursion
  else:
    [1]. divide the problem "n" into "b" subproblems of equal size.
      - then the size of each subproblem would be "n/b"
    [2]. call the function "dac()" recursively "a" times on the subproblems
    [3]. combine the results from the subproblems
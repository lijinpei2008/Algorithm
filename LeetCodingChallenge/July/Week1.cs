// You have a total of n coins that you want to form in a staircase shape, where every k-th row must have exactly k coins.
// Given n, find the total number of full staircase rows that can be formed.
// n is a non-negative integer and fits within the range of a 32-bit signed integer.

// Example 1:
// n = 5
// The coins can form the following rows:
// ¤
// ¤ ¤
// ¤ ¤
// Because the 3rd row is incomplete, we return 2.

// Example 2:
// n = 8
// The coins can form the following rows:
// ¤
// ¤ ¤
// ¤ ¤ ¤
// ¤ ¤
// Because the 4th row is incomplete, we return 3.

using System;

namespace JulyFirst {
    public class ArrangingCoins {
        public static void Main(string[] args) {
            Console.WriteLine(ArrangeCoinsFunction(5));
        }

        public static int ArrangeCoinsFunction(int n) {
            long left = 0, right = n;
            long k, curr;
            while (left <= right) {
                k = left + (right - left) / 2;
                curr = k * (k + 1) / 2;
                if (curr == n) {
                    return (int)k;
                }
                if (n < curr) {
                    right = k - 1;
                }
                else {
                    left = k + 1;
                }
            }
            return (int)right;
        }
    }
}

// Given a binary tree, return the bottom-up level order traversal of its nodes' values. (ie, from left to right, level by level from leaf to root).
// For example:
// Given binary tree[3, 9, 20, null, null, 15, 7],
//     3
//    / \
//   9  20
//     /  \
//    15   7
// return its bottom-up level order traversal as:
// [
//   [15,7],
//   [9,20],
//   [3]
// ]

using System;
using System.Collections.Generic;
using System.Linq;

namespace JulyFirst {
    public class BinaryTreeLevelOrderTraversalII {
        public static void Main(string[] args) {
            TreeNode root = new TreeNode {
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
            foreach (IList<int> item in LevelOrderBottom(root).ToList()) {
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

        public static IList<IList<int>> LevelOrderBottom(TreeNode root) {
            List<IList<int>> res = new List<IList<int>>();
            levelMaker(res, root, 0);
            return res;
        }

        public static void levelMaker(List<IList<int>> list, TreeNode root, int level) {
            if (root == null) return;
            if (level >= list.Count) {
                list.Insert(0, new List<int>());
            }
            levelMaker(list, root.left, level + 1);
            levelMaker(list, root.right, level + 1);
            list[list.Count - level - 1].Add(root.val);
        }
    }
}

// There are 8 prison cells in a row, and each cell is either occupied or vacant.
// Each day, whether the cell is occupied or vacant changes according to the following rules:
// If a cell has two adjacent neighbors that are both occupied or both vacant, then the cell becomes occupied.
// Otherwise, it becomes vacant.
// (Note that because the prison is a row, the first and the last cells in the row can't have two adjacent neighbors.)
// We describe the current state of the prison in the following way: cells[i] == 1 if the i-th cell is occupied, else cells[i] == 0.
// Given the initial state of the prison, return the state of the prison after N days (and N such changes described above.)

// Example 1:
// Input: cells = [0,1,0,1,1,0,0,1], N = 7
// Output: [0,0,1,1,0,0,0,0]
// Explanation: 
// The following table summarizes the state of the prison on each day:
// Day 0: [0, 1, 0, 1, 1, 0, 0, 1]
// Day 1: [0, 1, 1, 0, 0, 0, 0, 0]
// Day 2: [0, 0, 0, 0, 1, 1, 1, 0]
// Day 3: [0, 1, 1, 0, 0, 1, 0, 0]
// Day 4: [0, 0, 0, 0, 0, 1, 0, 0]
// Day 5: [0, 1, 1, 1, 0, 1, 0, 0]
// Day 6: [0, 0, 1, 0, 1, 1, 0, 0]
// Day 7: [0, 0, 1, 1, 0, 0, 0, 0]

// Example 2:
// Input: cells = [1,0,0,1,0,0,1,0], N = 1000000000
// Output: [0,0,1,1,1,1,1,0] 

// Note:
// cells.length == 8
// cells[i] is in {0, 1}
// 1 <= N <= 10^9

using System;
using System.Collections.Generic;

namespace JulyFirst {
    public class PrisonCellsAfterNDays {
        public static void Main(string[] args) {
            int[] cells = new int[] { 0, 1, 0, 1, 1, 0, 0, 1 };
            Console.WriteLine(string.Join(" ", PrisonAfterNDays(cells, 7)));
        }

        public static int[] PrisonAfterNDays(int[] cells, int N) {
            int[] newCell = new int[cells.Length];
            HashSet<int> cycleSet = new HashSet<int>();
            int count = 0;
            for (int j = 0; j < N; j++) {
                for (int i = 1; i < cells.Length - 1; i++) {
                    if (cells[i - 1] == cells[i + 1]) {
                        newCell[i] = 1;
                    }
                    else {
                        newCell[i] = 0;
                    }
                }
                for (int i = 1; i < cells.Length - 1; i++) {
                    cells[i] = newCell[i];
                }
                if (j == 0) {
                    cells[0] = 0;
                    cells[^1] = 0;
                }
                int cellValue = BinaryToInt(cells);
                if (!cycleSet.Add(cellValue)) {
                    N = (N - 1) % count + j + 1;
                    cycleSet.Clear();
                }
                count++;
            }
            return cells;
        }

        private static int BinaryToInt(int[] nums) {
            int value = 0;
            foreach (int num in nums) {
                value = (value << 1) + num;
            }
            return value;
        }
    }
}

// Write a program to find the n-th ugly number.
// Ugly numbers are positive numbers whose prime factors only include 2, 3, 5. 

// Example:
// Input: n = 10
// Output: 12
// Explanation: 1, 2, 3, 4, 5, 6, 8, 9, 10, 12 is the sequence of the first 10 ugly numbers.

// Note:  
// 1 is typically treated as an ugly number.
// n does not exceed 1690.

using System;

namespace JulyFirst {
    public class UglyNumberII {
        public static void Main(string[] args) {
            Console.WriteLine(NthUglyNumber(10));
        }

        public static int NthUglyNumber(int n) {
            int[] ugly = new int[n];
            ugly[0] = 1;
            int index2 = 0, index3 = 0, index5 = 0;
            int factor2 = 2, factor3 = 3, factor5 = 5;
            for (int i = 1; i < n; i++) {
                int min = Math.Min(Math.Min(factor2, factor3), factor5);
                ugly[i] = min;
                if (factor2 == min) {
                    factor2 = 2 * ugly[++index2];
                }
                if (factor3 == min) {
                    factor3 = 3 * ugly[++index3];
                }
                if (factor5 == min) {
                    factor5 = 5 * ugly[++index5];
                }
            }
            return ugly[n - 1];
        }
    }
}

// Hamming distance(https://en.wikipedia.org/wiki/Hamming_distance)
// The Hamming distance between two integers is the number of positions at which the corresponding bits are different.
// Given two integers x and y, calculate the Hamming distance.

// Note:
// 0 ≤ x, y< 2^31.

// Example:
// Input: x = 1, y = 4
// Output: 2

// Explanation:
// 1   (0 0 0 1)
// 4   (0 1 0 0)
//        ↑ ↑
// The above arrows point to positions where the corresponding bits are different.

using System;

namespace JulyFirst {
    public class HammingDistance {
        public static void Main(string[] args) {
            Console.WriteLine(HammingDistances(1, 4));
        }

        public static int HammingDistances(int x, int y) {
            int xor = x ^ y;
            int distance = 0;
            for (int i = 0; i < 32; i++) {
                if ((xor & (1 << i)) != 0) {
                    distance++;
                }
            }
            return distance;
        }
    }
}

// Given a non-empty array of digits representing a non-negative integer, increment one to the integer.
// The digits are stored such that the most significant digit is at the head of the list, and each element in the array contains a single digit.
// You may assume the integer does not contain any leading zero, except the number 0 itself.
   
// Example 1:
// Input: [1,2,3]
// Output: [1,2,4]
// Explanation: The array represents the integer 123.
   
// Example 2:
// Input: [4,3,2,1]
// Output: [4,3,2,2]
// Explanation: The array represents the integer 4321.

using System;
using System.Collections.Generic;

namespace JulyFirst {
    public class PlusOne {
        public static void Main(string[] args) {
            int[] digits = new int[] { 1, 2, 3 };
            Console.WriteLine(string.Join(" ", PlusOneFunction(digits)));
        }

        public static int[] PlusOneFunction(int[] digits) {
            int carry = 1;
            List<int> answer = new List<int>();
            for (int current = digits.Length - 1; current >= 0; current--) {
                int sum = digits[current] + carry;
                answer.Insert(0, sum % 10);
                carry = sum / 10;
            }
            if (carry > 0) {
                answer.Insert(0, carry);
            }
            return answer.ToArray();
        }
    }
}

// You are given a map in form of a two-dimensional integer grid where 1 represents land and 0 represents water.
// Grid cells are connected horizontally/vertically (not diagonally).
// The grid is completely surrounded by water, and there is exactly one island (i.e., one or more connected land cells).
// The island doesn't have "lakes" (water inside that isn't connected to the water around the island).
// One cell is a square with side length 1. The grid is rectangular, width and height don't exceed 100. Determine the perimeter of the island.
   
// Example:
// Input:
// [[0,1,0,0],
//  [1,1,1,0],
//  [0,1,0,0],
//  [1,1,0,0]]
// Output: 16

using System;

namespace JulyFirst {
    public class IslandPerimeter {
        public static void Main(string[] args) {
            int[][] grid = new int[4][];
            grid[0] = new int[4] { 0, 1, 0, 0 };
            grid[1] = new int[4] { 1, 1, 1, 0 };
            grid[2] = new int[4] { 0, 1, 0, 0 };
            grid[3] = new int[4] { 1, 1, 0, 0 };
            Console.WriteLine(IslandPerimeterFunction(grid));
        }

        public static int IslandPerimeterFunction(int[][] grid) {
            if (grid == null || grid.Length == 0) {
                return 0;
            }
            int islands = 0;
            int neighbors = 0;
            int rows = grid.Length;
            int cols = grid[0].Length;
            for (int i = 0; i < rows; i++) {
                for (int j = 0; j < cols; j++) {
                    if (grid[i][j] == 1) {
                        islands++;
                        if (i + 1 < rows && grid[i + 1][j] == 1) {
                            neighbors++;
                        }
                        if (j + 1 < cols && grid[i][j + 1] == 1) {
                            neighbors++;
                        }
                    }
                }
            }
            return islands * 4 - neighbors * 2;
        }
    }
}
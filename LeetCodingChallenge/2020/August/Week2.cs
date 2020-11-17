// You are given a binary tree in which each node contains an integer value.
// Find the number of paths that sum to a given value.
// The path does not need to start or end at the root or a leaf, but it must go downwards (traveling only from parent nodes to child nodes).
// The tree has no more than 1,000 nodes and the values are in the range -1,000,000 to 1,000,000.

// Example:
// root = [10, 5, -3, 3, 2, null, 11, 3, -2, null, 1], sum = 8
//       10
//      /  \
//     5   -3
//    / \    \
//   3   2   11
//  / \   \
// 3  -2   1
// Return 3.The paths that sum to 8 are:
// 1.  5-> 3
// 2.  5-> 2-> 1
// 3. -3-> 11

using System;

namespace AugSecond {
    public class PathSumIII {
        public static void Main(string[] args) {
            TreeNode node = new TreeNode {
                val = 10,
                left = new TreeNode {
                    val = 5,
                    left = new TreeNode {
                        val = 3,
                        left = new TreeNode {
                            val = 3,
                            left = null,
                            right = null
                        },
                        right = new TreeNode {
                            val = -2,
                            left = null,
                            right = null
                        }
                    },
                    right = new TreeNode {
                        val = 2,
                        left = null,
                        right = new TreeNode {
                            val = 1,
                            left = null,
                            right = null
                        }
                    }
                },
                right = new TreeNode {
                    val = -3,
                    left = null,
                    right = new TreeNode {
                        val = 11,
                        left = null,
                        right = null
                    }
                }
            };
            Console.WriteLine(PathSum(node, 8));
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

        public static int PathSum(TreeNode root, int sum) {
            return PathSum(root, sum, true);
        }

        private static int PathSum(TreeNode root, int sum, bool start) {
            int res = 0;
            if (root != null) {
                if (start) {
                    res = PathSum(root.left, sum, true) + PathSum(root.right, sum, true);
                }
                if (root.val == sum) {
                    res++;
                }
                res += PathSum(root.left, sum - root.val, false) + PathSum(root.right, sum - root.val, false);
            }
            return res;
        }
    }
}

// In a given grid, each cell can have one of three values:
// the value 0 representing an empty cell;
// the value 1 representing a fresh orange;
// the value 2 representing a rotten orange.
// Every minute, any fresh orange that is adjacent (4-directionally) to a rotten orange becomes rotten.
// Return the minimum number of minutes that must elapse until no cell has a fresh orange.  If this is impossible, return -1 instead.

// Example 1:
// Input:[[2,1,1],[1,1,0],[0,1,1]]
// Output: 4

// Example 2:
// Input:[[2,1,1],[0,1,1],[1,0,1]]
// Output: -1
// Explanation: The orange in the bottom left corner (row 2, column 0) is never rotten, because rotting only happens 4-directionally.

// Example 3:
// Input:[[0,2]]
// Output: 0
// Explanation: Since there are already no fresh oranges at minute 0, the answer is just 0.

// Note:
// 1 <= grid.length <= 10
// 1 <= grid[0].length <= 10
// grid[i][j] is only 0, 1, or 2.

using System;
using System.Linq;

namespace AugSecond {
    public class RottingOranges {
        public static void Main(string[] args) {
            int[][] grid = new int[3][];
            grid[0] = new int[] { 2, 1, 1 };
            grid[1] = new int[] { 0, 1, 1 };
            grid[2] = new int[] { 1, 0, 1 };
            Console.WriteLine(OrangesRotting(grid));
        }

        public static int OrangesRotting(int[][] grid) {
            for (int i = 0; i < grid.Length; i++) {
                for (int j = 0; j < grid[i].Length; j++) {
                    if (grid[i][j] == 2) {
                        Crawl(grid, i, j, 0, false);
                    }
                }
            }
            if (grid.Any(ln => ln.Contains(1))) return -1;
            int min = int.MaxValue;
            for (int i = 0; i < grid.Length; i++) {
                min = Math.Min(min, grid[i].Min());
            }
            return Math.Abs(min);
        }

        private static void Crawl(int[][] grid, int i, int j, int time, bool rotten) {
            if (i < 0 || j < 0 || i >= grid.Length || j >= grid[i].Length) return;
            if (grid[i][j] == 0) return;
            if (grid[i][j] < 0 && rotten) {
                if (-time > grid[i][j]) {
                    grid[i][j] = -time;
                }
                else {
                    return;
                }
            }
            if (grid[i][j] == 2) {
                rotten = true;
                time = 0;
                grid[i][j] = 0;
            }
            if (grid[i][j] == 1) {
                if (!rotten) return;

                grid[i][j] = -time;
                rotten = true;
            }
            Crawl(grid, i, j + 1, time + 1, rotten);
            Crawl(grid, i + 1, j, time + 1, rotten);
            Crawl(grid, i, j - 1, time + 1, rotten);
            Crawl(grid, i - 1, j, time + 1, rotten);
        }
    }
}

// Given a column title as appear in an Excel sheet, return its corresponding column number.

// For example:
//     A-> 1
//     B-> 2
//     C-> 3
//     ...
//     Z-> 26
//     AA-> 27
//     AB-> 28
//     ...

// Example 1:
// Input: "A"
// Output: 1

// Example 2:
// Input: "AB"
// Output: 28

// Example 3:
// Input: "ZY"
// Output: 701

// Constraints:
// 1 <= s.length <= 7
// s consists only of uppercase English letters.
// s is between "A" and "FXSHRXW".

using System;

namespace AugSecond {
    public class ExcelSheetColumnNumber {
        public static void Main(string[] args) {
            string s = "ZY";
            Console.WriteLine(TitleToNumber(s));
        }

        public static int TitleToNumber(string s) {
            int result = 0;
            foreach (char c in s) {
                result = result * 26 + c - 64;
            }
            return result;
        }
    }
}

// Given an array of citations (each citation is a non-negative integer) of a researcher, write a function to compute the researcher's h-index.
// According to the definition of h-index on Wikipedia: 
// "A scientist has index h if h of his/her N papers have at least h citations each, and the other N − h papers have no more than h citations each."

// Example:
// Input: citations = [3, 0, 6, 1, 5]
// Output: 3
// Explanation:[3,0,6,1,5] means the researcher has 5 papers in total and each of them had 
//              received 3, 0, 6, 1, 5 citations respectively. 
//              Since the researcher has 3 papers with at least 3 citations each and the remaining 
//              two with no more than 3 citations each, her h-index is 3.
// Note: If there are several possible values for h, the maximum one is taken as the h-index.

using System;

namespace AugSecond {
    public class HIndex {
        public static void Main(string[] args) {
            int[] citations = new int[] { 3, 0, 6, 1, 5 };
            Console.WriteLine(HIndexFunction(citations));
        }

        public static int HIndexFunction(int[] citations) {
            int n = citations.Length;
            Array.Sort(citations, (a, b) => b - a);
            int i = 0;
            while (i < n && citations[i] > i) {
                i++;
            }
            return i;
        }
    }
}

// Given an integer rowIndex, return the rowIndexth row of the Pascal's triangle.
// Notice that the row index starts from 0.
// In Pascal's triangle, each number is the sum of the two numbers directly above it.
// Follow up:
// Could you optimize your algorithm to use only O(k) extra space?

// Example 1:
// Input: rowIndex = 3
// Output:[1,3,3,1]

// Example 2:
// Input: rowIndex = 0
// Output:[1]

// Example 3:
// Input: rowIndex = 1
// Output:[1,1]

// Constraints:
// 0 <= rowIndex <= 40

using System;
using System.Collections.Generic;

namespace AugSecond {
    public class PascalsTriangleII {
        public static void Main(string[] args) {
            int rowIndex = 5;
            foreach (int item in GetRow(rowIndex)) {
                Console.Write(item + " ");
            }
        }

        public static IList<int> GetRow(int rowIndex) {
            IList<int> ret = new List<int> { 1 };
            for (int i = 1; i <= rowIndex; i++) {
                for (int j = i; j > 0; j--) {
                    if (j == i) {
                        ret.Add(1);
                    }
                    else {
                        ret[j] = (ret[j - 1] + ret[j]);
                    }
                }
            }
            return ret;
        }
    }
}

// Design an Iterator class, which has:
// A constructor that takes a string characters of sorted distinct lowercase English letters and a number combinationLength as arguments.
// A function next() that returns the next combination of length combinationLength in lexicographical order.
// A function hasNext() that returns True if and only if there exists a next combination.
   
// Example:
// CombinationIterator iterator = new CombinationIterator("abc", 2); // creates the iterator.
// iterator.next(); // returns "ab"
// iterator.hasNext(); // returns true
// iterator.next(); // returns "ac"
// iterator.hasNext(); // returns true
// iterator.next(); // returns "bc"
// iterator.hasNext(); // returns false
   
// Constraints:
// 1 <= combinationLength <= characters.length <= 15
// There will be at most 10^4 function calls per test.
// It's guaranteed that all calls of the function next are valid.

using System;
using System.Collections.Generic;
using System.Linq;

namespace AugSecond {
    public class IteratorForCombination {
        public static void Main(string[] args) {
            CombinationIterator iterator = new CombinationIterator("abc", 2); // creates the iterator.
            Console.WriteLine(iterator.Next());    // returns "ab"
            Console.WriteLine(iterator.HasNext()); // returns true
            Console.WriteLine(iterator.Next());    // returns "ac"
            Console.WriteLine(iterator.HasNext()); // returns true
            Console.WriteLine(iterator.Next());    // returns "bc"
            Console.WriteLine(iterator.HasNext()); // returns false
        }
    }

    public class CombinationIterator {
        int Index = 0;
        List<string> ListStr = new List<string>();

        public CombinationIterator(string characters, int combinationLength) {
            GetCombinations(characters, combinationLength, 0, new List<char>());
        }

        private void GetCombinations(string characters, int combinationLength, int currIndex, IList<char> backet) {
            if (ListStr.Count >= 5000) {
                return;
            }
            if (backet.Count == combinationLength) {
                ListStr.Add(new string(backet.ToArray()));
                return;
            }
            if (currIndex == characters.Length) {
                return;
            }
            backet.Add(characters[currIndex]);
            GetCombinations(characters, combinationLength, currIndex + 1, backet);
            backet.RemoveAt(backet.Count - 1);
            GetCombinations(characters, combinationLength, currIndex + 1, backet);
        }

        public string Next() {
            return ListStr[Index++];
        }

        public bool HasNext() {
            return Index < ListStr.Count;
        }
    }
}

// Given a string s which consists of lowercase or uppercase letters, return the length of the longest palindrome that can be built with those letters.
// Letters are case sensitive, for example, "Aa" is not considered a palindrome here.
   
// Example 1:
// Input: s = "abccccdd"
// Output: 7
// Explanation:
// One longest palindrome that can be built is "dccaccd", whose length is 7.
   
// Example 2:
// Input: s = "a"
// Output: 1
   
// Example 3:
// Input: s = "bb"
// Output: 2
   
// Constraints:
// 1 <= s.length <= 2000
// s consits of lower-case and/or upper-case English letters only.

using System;

namespace AugSecond {
    public class LongestPalindrome {
        public static void Main(string[] args) {
            Console.WriteLine(LongestPalindromFunction("abccccdd"));
        }

        public static int LongestPalindromFunction(string s) {
            int result = 0;
            bool odd = false;
            int[] freq = new int[58];
            foreach (char c in s) {
                freq[c - 'A']++;
            }
            for (int i = 0; i < 58; i++) {
                result += freq[i] / 2;
                if (freq[i] % 2 != 0) {
                    odd = true;
                }
            }
            return odd ? result * 2 + 1 : result * 2;
        }
    }
}
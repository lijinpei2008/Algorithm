// 5315. Maximum 69 Number
// Difficulty:Easy
// Given a positive integer num consisting only of digits 6 and 9.
// Return the maximum number you can get by changing at most one digit(6 becomes 9, and 9 becomes 6).

// Example 1:
// Input: num = 9669
// Output: 9969
// Explanation: 
// Changing the first digit results in 6669.
// Changing the second digit results in 9969.
// Changing the third digit results in 9699.
// Changing the fourth digit results in 9666. 
// The maximum number is 9969.

// Example 2:
// Input: num = 9996
// Output: 9999
// Explanation: Changing the last digit 6 to 9 results in the maximum number.

// Example 3:
// Input: num = 9999
// Output: 9999
// Explanation: It is better not to apply any change.

using System;
using System.Text;

namespace Contest {
    public class Program {
        static void Main(string[] args) {
            Solution solution = new Solution();
            Console.WriteLine(solution.Maximum69Number(9669));
        }
    }

    public class Solution {
        public int Maximum69Number(int num) {
            StringBuilder stringBuilder = new StringBuilder(num.ToString());
            for (int i = 0; i < stringBuilder.Length; i++) {
                if (stringBuilder[i] == '6') {
                    stringBuilder[i] = '9';
                    return Convert.ToInt32(stringBuilder.ToString());
                }
            }
            return num;
        }
    }
}

// 5316. Print Words Vertically
// Difficulty:Medium
// Given a string s.Return all the words vertically in the same order in which they appear in s.
// Words are returned as a list of strings, complete with spaces when is necessary. (Trailing spaces are not allowed).
// Each word would be put on only one column and that in one column there will be only one word.
   
// Example 1:
// Input: s = "HOW ARE YOU"
// Output: ["HAY","ORO","WEU"]
// Explanation: Each word is printed vertically. 
//  "HAY"
//  "ORO"
//  "WEU"
   
// Example 2:
// Input: s = "TO BE OR NOT TO BE"
// Output: ["TBONTB","OEROOE","   T"]
// Explanation: Trailing spaces is not allowed. 
// "TBONTB"
// "OEROOE"
// "   T"
   
// Example 3:
// Input: s = "CONTEST IS COMING"
// Output: ["CIC","OSO","N M","T I","E N","S G","T"]

using System;
using System.Collections.Generic;
using System.Text;

namespace Contest {
    public class Program {
        static void Main(string[] args) {
            Solution solution = new Solution();
            IList<string> str = solution.PrintVertically("TO BE OR NOT TO BE");
            foreach (string item in str) {
                Console.WriteLine(item);
            }
        }
    }

    public class Solution {
        public IList<string> PrintVertically(string s) {
            String[] ss = s.Split(" ");
            int max = 0;
            for (int i = 0; i < ss.Length; i++) {
                max = Math.Max(max, ss[i].Length);
            }
            IList<string> ans = new List<string>();
            for (int i = 0; i < max; i++) {
                StringBuilder tmp = new StringBuilder();
                int c = 0;
                for (int j = 0; j < ss.Length; j++) {
                    if (i < ss[j].Length) {
                        while (c > 0) {
                            tmp.Append(" "); c--;
                        }
                        tmp.Append(ss[j][i]);
                    }
                    else c++;
                }
                ans.Add(tmp.ToString());
            }
            return ans;
        }
    }
}

// 1325. Delete Leaves With a Given Value
// Difficulty:Medium
// Given a binary tree root and an integer target, delete all the leaf nodes with value target.
// Note that once you delete a leaf node with value target, if it's parent node becomes a leaf node and has the value target, it should also be deleted (you need to continue doing that until you can't).

// Example 1:
//     1                1             1
//    / \              / \             \
//   2   3      =>    2   3    =>       3
//  /   / \                \             \
// 2   2   4                4             4
// Input: root = [1,2,3,2,null,2,4], target = 2
// Output: [1,null,3,null,4]
// Explanation: Leaf nodes in green with value(target = 2) are removed(Picture in left). 
// After removing, new nodes become leaf nodes with value(target = 2) (Picture in center).

// Example 2:
//     1          1
//    / \        /
//   3   3  =>  3
//  / \          \
// 3   2          2
// Input: root = [1,3,3,3,2], target = 3
// Output: [1,3,null,null,2]

// Example 3:
//       1
//      /           1
//     2           /            1
//    /     =>    2      =>    /    =>   1
//   2           /            2
//  /           2
// 2
// Input: root = [1,2,null,2,null,2], target = 2
// Output: [1]
// Explanation: Leaf nodes in green with value(target = 2) are removed at each step.

// Example 4:
// Input: root = [1,1,1], target = 1
// Output: []

// Example 5:
// Input: root = [1,2,3], target = 1
// Output: [1,2,3] 

using System;
using System.Collections.Generic;

namespace Contest {
    public class Program {
        static void Main(string[] args) {
            Solution solution = new Solution();
            TreeNode node = new TreeNode {
                val = 1,
                left = new TreeNode {
                    val = 2,
                    left = new TreeNode {
                        val = 2,
                        left = null,
                        right = null
                    },
                    right = null
                },
                right = new TreeNode {
                    val = 3,
                    left = new TreeNode {
                        val = 2,
                        right = null
                    },
                    right = new TreeNode {
                        val = 4,
                        left = null,
                        right = null
                    }
                }
            };
            TreeNode root = solution.RemoveLeafNodes(node, 2);
            Cw(root);
        }
        private static void Cw(TreeNode node) {
            if (node != null) {
                Queue<TreeNode> queue = new Queue<TreeNode>();
                queue.Enqueue(node);
                while (queue.Count > 0) {
                    TreeNode item = queue.Dequeue();
                    if (item == null) {
                        Console.Write("n ");
                    }
                    else {
                        Console.Write(item.val + " ");
                        queue.Enqueue(item.left);
                        queue.Enqueue(item.right);
                    }
                }
            }
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
        public TreeNode RemoveLeafNodes(TreeNode root, int target) {
            if (root == null) {
                return null;
            }
            root.left = RemoveLeafNodes(root.left, target);
            root.right = RemoveLeafNodes(root.right, target);
            if (root.left == null && root.right == null && root.val == target) {
                return null;
            }
            return root;
        }
    }
}

// 1326. Minimum Number of Taps to Open to Water a Garden
// Difficulty:Hard
// There is a one-dimensional garden on the x-axis.The garden starts at the point 0 and ends at the point n. (i.e The length of the garden is n).
// There are n + 1 taps located at points[0, 1, ..., n] in the garden.
// Given an integer n and an integer array ranges of length n + 1 where ranges[i] (0-indexed) means the i-th tap can water the area[i - ranges[i], i + ranges[i]] if it was open.
// Return the minimum number of taps that should be open to water the whole garden, If the garden cannot be watered return -1.

// Example 1:
//       ⚪----------------A---------------⚪
//       ⚪--------------------B-----------------------⚪
//                              ⚪----C----⚪
//                                    ⚪----D----⚪
//                                                E⚪
//                                                      F⚪
// <-----|-----|-----|-----|-----|-----|-----|-----|-----|----->
//      -3    -2    -1     0     1     2     3     4     5
//                      |--A     B     C     D     E     F--|
//                      |-------Garden(To be covered)-------|
// Input: n = 5, ranges = [3,4,1,1,0,0]
// Output: 1
// Explanation: 
// A:The tap at point 0 can cover the interval[-3, 3]
//   The A means 0-index tap
//   The area = [0-3,0+3] = [-3,3]
// B:The tap at point 1 can cover the interval[-3, 5]
//   The B means 1-index tap
//   The area = [1-4,1+4] = [-3,5]
// C:The tap at point 2 can cover the interval[1, 3]
//   The C means 2-index tap
//   The area = [2-1,2+1] = [1,3]
// D:The tap at point 3 can cover the interval[2, 4]
//   The D means 0-index tap
//   The area = [3-1,3+1] = [2,4]
// E:The tap at point 4 can cover the interval[4, 4]
//   The E means 0-index tap
//   The area = [4-0,4+0] = [4,4] = 4
// F:The tap at point 5 can cover the interval[5, 5]
//   The F means 0-index tap
//   The area = [5-0,5+0] = [5,5] = 5
// Opening Only the second(B) tap will water the whole garden[0, 5]

// Example 2:
// Input: n = 3, ranges = [0,0,0,0]
// Output: -1
// Explanation: Even if you activate all the four taps you cannot water the whole garden.

// Example 3:
// Input: n = 7, ranges = [1, 2, 1, 0, 2, 1, 0, 1]
// Output: 3

// Example 4:
// Input: n = 8, ranges = [4, 0, 0, 0, 0, 0, 0, 0, 4]
// Output: 2

// Example 5:
// Input: n = 8, ranges = [4, 0, 0, 0, 4, 0, 0, 0, 4]
// Output: 1

using System;
using System.Linq;

namespace Contest {
    public class Program {
        static void Main(string[] args) {
            Solution solution = new Solution();
            int num = solution.MinTaps(5, new int[] { 3, 4, 1, 1, 2, 0 });
            Console.WriteLine(num);
        }
    }

    public class Solution {
        public int MinTaps(int n, int[] ranges) {
            int[] dp = Enumerable.Repeat(100000, n + 1).ToArray();
            dp[0] = 0;
            for (int i = 0; i < n + 1; i++) {
                int left = Math.Max(i - ranges[i], 0);
                int right = Math.Min(i + ranges[i], n);
                // Why j <= right ?
                for (int j = left; j <= right; j++)
                    dp[j] = Math.Min(dp[j], dp[left] + 1);
            }
            return dp[n] < 100000 ? dp[n] : -1;
        }
    }
}
// Given the root node of a binary search tree(BST) and a value.You need to find the node in the BST that the node's value equals the given value.
// Return the subtree rooted with that node. If such node doesn't exist, you should return NULL.
// For example,
// Given the tree:
//         4
//        / \
//       2   7
//      / \
//     1   3
// And the value to search: 2
// You should return this subtree:
//       2     
//      / \   
//     1   3
// In the example above, if we want to search the value 5, since there is no node with value 5, we should return NULL.
// Note that an empty tree is represented by NULL, therefore you would see the expected output (serialized tree format) as [], not null.

using System;
using System.Collections.Generic;

namespace JuneThird {
    public class SearchInABinarySearchTree {
        public static void Main(string[] args) {
            TreeNode node = new TreeNode {
                val = 4,
                left = new TreeNode {
                    val = 2,
                    left = new TreeNode {
                        val = 1,
                        left = null,
                        right = null
                    },
                    right = new TreeNode {
                        val = 3,
                        left = null,
                        right = null
                    }
                },
                right = new TreeNode {
                    val = 7,
                    left = null,
                    right = null
                }
            };
            Cw(SearchBST(node, 2));
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

        public static TreeNode SearchBST(TreeNode root, int val) {
            while (root != null) {
                if (root == null || (root.val == val)) {
                    return root;
                }
                else if (root.val < val) {
                    root = root.right;
                }
                else {
                    root = root.left;
                }
            }
            return root;
        }
    }
}

// Write a function to check whether an input string is a valid IPv4 address or IPv6 address or neither.
// IPv4 addresses are canonically represented in dot-decimal notation, which consists of four decimal numbers,
// each ranging from 0 to 255, separated by dots("."), e.g.,172.16.254.1;
// Besides, leading zeros in the IPv4 is invalid.For example, the address 172.16.254.01 is invalid.
// IPv6 addresses are represented as eight groups of four hexadecimal digits, each group representing 16 bits.The groups are separated by colons(":").
// For example, the address 2001:0db8:85a3:0000:0000:8a2e:0370:7334 is a valid one.
// Also, we could omit some leading zeros among four hexadecimal digits and some low-case characters in the address to upper-case ones,
// so 2001:db8:85a3:0:0:8A2E:0370:7334 is also a valid IPv6 address(Omit leading zeros and using upper cases).
// However, we don't replace a consecutive group of zero value with a single empty group using two consecutive colons (::) to pursue simplicity.
// For example, 2001:0db8:85a3::8A2E:0370:7334 is an invalid IPv6 address.
// Besides, extra leading zeros in the IPv6 is also invalid.For example, the address 02001:0db8:85a3:0000:0000:8a2e:0370:7334 is invalid.
   
// Example 1:
// Input: IP = "172.16.254.1"
// Output: "IPv4"
// Explanation: This is a valid IPv4 address, return "IPv4".
   
// Example 2:
// Input: IP = "2001:0db8:85a3:0:0:8A2E:0370:7334"
// Output: "IPv6"
// Explanation: This is a valid IPv6 address, return "IPv6".
   
// Example 3:
// Input: IP = "256.256.256.256"
// Output: "Neither"
// Explanation: This is neither a IPv4 address nor a IPv6 address.
   
// Constraints:
// IP consists only of English letters, digits and the characters "." and ":".

using System;

namespace JuneThird {
    public class ValidateIPAddress {
        public static void Main(string[] args) {
            Console.WriteLine(ValidIPAddress("172.16.254.1"));
        }

        public static string ValidIPAddress(string IP) {
            // IPv4?
            string[] split = IP.Split(new Char[] { '.' });
            if (split.Length == 4) {
                for (int i = 0; i < split.Length; i++) {
                    string cur = split[i];
                    // Length 1-3
                    if (cur.Length == 0 || cur.Length > 3) {
                        return "Neither";
                    }
                    // No Leading 0
                    if (cur.Length != 1 && cur[0] == '0') {
                        return "Neither";
                    }
                    // Range 0-255
                    if (!int.TryParse(cur, out int len) || len > 255) {
                        return "Neither";
                    }
                }
                return "IPv4";
            }
            // IPv6?
            const string hexdigits = "0123456789abcdefABCDEF";
            split = IP.Split(new char[] { ':' });
            if (split.Length == 8) {
                for (int i = 0; i < split.Length; i++) {
                    string cur = split[i];
                    // Length 1-4
                    if (cur.Length == 0 || cur.Length > 4) {
                        return "Neither";
                    }
                    // Hex digit
                    for (int j = 0; j < cur.Length; j++) {
                        if (hexdigits.IndexOf(cur[j]) < 0) {
                            return "Neither";
                        }
                    }
                }
                return "IPv6";
            }
            return "Neither";
        }
    }
}

// Given a 2D board containing 'X' and 'O' (the letter O), capture all regions surrounded by 'X'.
// A region is captured by flipping all 'O's into 'X's in that surrounded region.

// Example:
// X X X X
// X O O X
// X X O X
// X O X X
// After running your function, the board should be:
// X X X X
// X X X X
// X X X X
// X O X X

// Explanation:
// Surrounded regions shouldn’t be on the border, which means that any 'O' on the border of the board are not flipped to 'X'.
// Any 'O' that is not on the border and it is not connected to an 'O' on the border will be flipped to 'X'.
// Two cells are connected if they are adjacent cells connected horizontally or vertically.

namespace JuneThird {
    public class SurroundedRegions {
        public void Solve(char[][] board) {
            for (int i = 0; i < board.Length; i++) {
                for (int j = 0; j < board[i].Length; j++) {
                    if (board[i][j] == 'O') {
                        if (i == 0 || j == 0 || i == board.Length - 1 || j == board[i].Length - 1) {
                            UpdateToY(board, i, j);
                        }
                    }
                }
            }
            for (int i = 0; i < board.Length; i++) {
                for (int j = 0; j < board[i].Length; j++) {
                    if (board[i][j] == 'O') {
                        board[i][j] = 'X';
                    }
                }
            }
            for (int i = 0; i < board.Length; i++) {
                for (int j = 0; j < board[i].Length; j++) {
                    if (board[i][j] == 'Y') {
                        board[i][j] = 'O';
                    }
                }
            }
        }

        private bool UpdateBoard(char[][] board, int i, int j) {
            if (board[i][j] == 'X') return true;
            int[] dim = new int[5] { 1, 0, -1, 0, 1 };
            bool res = true;
            board[i][j] = 'Y';
            for (int k = 0; k < dim.Length - 1; k++) {
                if ((i + dim[k]) >= board.Length || (i + dim[k]) < 0 || (j + dim[k + 1]) >= board[i].Length || (j + dim[k + 1]) < 0) {
                    res = false; continue;
                }
                if (board[i + dim[k]][j + dim[k + 1]] == 'O') {
                    res &= UpdateBoard(board, i + dim[k], j + dim[k + 1]);
                }
            }
            if (res) {
                board[i][j] = 'O';
            }
            return res;
        }

        private void UpdateToY(char[][] board, int i, int j) {
            int[] dim = new int[5] { 1, 0, -1, 0, 1 };
            board[i][j] = 'Y';
            for (int k = 0; k < dim.Length - 1; k++) {
                if ((i + dim[k]) >= board.Length || (i + dim[k]) < 0 || (j + dim[k + 1]) >= board[i].Length || (j + dim[k + 1]) < 0) {
                    continue;
                }
                if (board[i + dim[k]][j + dim[k + 1]] == 'O') {
                    UpdateToY(board, i + dim[k], j + dim[k + 1]);
                }
            }
        }
    }
}

// Given an array of citations sorted in ascending order(each citation is a non-negative integer) of a researcher,
// write a function to compute the researcher's h-index.
// According to the definition of h-index on Wikipedia: "A scientist has index h if h of his/her N papers have at least h citations each,
// and the other N − h papers have no more than h citations each."

// Example:
// Input: citations = [0,1,3,5,6]
// Output: 3 
// Explanation: [0,1,3,5,6] means the researcher has 5 papers in total and each of them had
//              received 0, 1, 3, 5, 6 citations respectively.
//              Since the researcher has 3 papers with at least 3 citations each and the remaining
//              two with no more than 3 citations each, her h-index is 3.

// Note:
// If there are several possible values for h, the maximum one is taken as the h-index.

// Follow up:
// This is a follow up problem to H-Index, where citations is now guaranteed to be sorted in ascending order.
// Could you solve it in logarithmic time complexity?

using System;

namespace JuneThird {
    public class HIndexII {
        public static void Main(string[] args) {
            int[] citations = new int[] { 0, 1, 3, 5, 6 };
            Console.WriteLine(HIndex(citations));
        }

        public static int HIndex(int[] citations) {
            int ans = 0;
            int left = 0;
            int right = citations.Length - 1;
            while (left <= right) {
                int middle = left + (right - left) / 2;
                int citation = citations[middle];
                int peoples = citations.Length - middle;
                if (citation == peoples) {
                    return peoples;
                }
                if (citation > peoples) {
                    ans = peoples;
                    right = middle - 1;
                }
                else {
                    left = middle + 1;
                }
            }
            return ans;
        }
    }
}

// Given a string S, consider all duplicated substrings: (contiguous) substrings of S that occur 2 or more times.  (The occurrences may overlap.)
// Return any duplicated substring that has the longest possible length.  (If S does not have a duplicated substring, the answer is "".)
   
// Example 1:
// Input: "banana"
// Output: "ana"
   
// Example 2:
// Input: "abcd"
// Output: ""
   
// Note:
// 2 <= S.length <= 10^5
// S consists of lowercase English letters.

using System;
using System.Collections.Generic;

namespace JuneThird {
    public class LongestDuplicateSubstring {
        public static void Main(string[] args) {
            Console.WriteLine(LongestDupSubstring("banana"));
        }

        public static string LongestDupSubstring(string S) {
            int left = 1, right = S.Length - 1, maxLength = -1, maxIndex = -1;
            const long mod = long.MaxValue / 26;
            HashSet<long> seen = new HashSet<long>();

            while (left <= right) {
                int middle = left + (right - left) / 2;
                seen.Clear();
                bool found = false;
                long hash = 0;
                long aL = 1;
                for (int i = 0; i < middle; i++) {
                    hash = (hash * 26 + (S[i] - 'a')) % mod;
                    aL = aL * 26 % mod;
                }
                seen.Add(hash);
                for (int index = 1; index <= S.Length - middle; index++) {
                    hash = (hash * 26 - (S[index - 1] - 'a') * aL + (S[index + middle - 1] - 'a')) % mod;
                    if (hash < 0) {
                        hash += mod;
                    }
                    if (seen.Add(hash)) {
                        continue;
                    }
                    maxLength = middle;
                    maxIndex = index;
                    found = true;
                    break;
                }
                if (found) {
                    left = middle + 1;
                }
                else {
                    right = middle - 1;
                }
            }
            return maxLength == -1
                ? ""
                : S.Substring(maxIndex, maxLength);
        }
    }
}

// The set[1, 2, 3, ..., n] contains a total of n! unique permutations.
// By listing and labeling all of the permutations in order, we get the following sequence for n = 3:
// "123"
// "132"
// "213"
// "231"
// "312"
// "321"
// Given n and k, return the kth permutation sequence.

// Note:
// Given n will be between 1 and 9 inclusive.
// Given k will be between 1 and n! inclusive.
   
// Example 1:
// Input: n = 3, k = 3
// Output: "213"
   
// Example 2:
// Input: n = 4, k = 9
// Output: "2314"

using System;

namespace JuneThird {
    public class PermutationSequence {
        public static void Main(string[] args) {
            Console.WriteLine(GetPermutation(4, 9));
        }

        public static string GetPermutation(int n, int k) {
            int[] num = new int[n];
            for (int i = 0; i < n; i++) {
                num[i] = i + 1;
            }
            Permute(num, k - 1);
            return string.Join("", num);
        }

        private static void Permute(int[] num, int k) {
            if (k <= 0) {
                return;
            }
            if (k == 1) {
                Move(num, num.Length - 2, num.Length - 1);
                return;
            }
            int pos = 1;
            while (Factorial(pos) <= k) {
                pos++;
            }
            int index = num.Length - pos;
            int del = 0;
            int posFac = Factorial(pos - 1);
            while (k >= posFac) {
                del++;
                k -= posFac;
            }
            Move(num, index, index + del);
            Permute(num, k);
        }

        private static int Factorial(int pos) {
            int f = 1;
            while (pos > 0) {
                f *= pos;
                pos--;
            }
            return f;
        }

        private static void Move(int[] num, int left, int right) {
            int t = num[right];
            while (right > left) {
                num[right] = num[right - 1];
                right--;
            }
            num[left] = t;
        }
    }
}

// The demons had captured the princess(P) and imprisoned her in the bottom-right corner of a dungeon.The dungeon consists of M x N rooms laid out in a 2D grid.
// Our valiant knight(K) was initially positioned in the top-left room and must fight his way through the dungeon to rescue the princess.
// The knight has an initial health point represented by a positive integer.If at any point his health point drops to 0 or below, he dies immediately.
// Some of the rooms are guarded by demons, so the knight loses health (negative integers) upon entering these rooms;
// other rooms are either empty(0's) or contain magic orbs that increase the knight's health (positive integers).
// In order to reach the princess as quickly as possible, the knight decides to move only rightward or downward in each step.
// Write a function to determine the knight's minimum initial health so that he is able to rescue the princess.
// For example, given the dungeon below, the initial health of the knight must be at least 7 if he follows the optimal path RIGHT-> RIGHT -> DOWN -> DOWN.
// |-2(K)   |-3     |3
// |-5      |-10    |1
// |10      |30     |-5 (P)

// Note:
// The knight's health has no upper bound.
// Any room can contain threats or power-ups, even the first room the knight enters and the bottom-right room where the princess is imprisoned.

using System;

namespace JuneThird {
    public class DungeonGame {
        public static void Main(string[] args) {
            int[][] dungeon = new int[3][];
            dungeon[0] = new int[3] { -2, -3, 3 };
            dungeon[1] = new int[3] { -5, -10, 1 };
            dungeon[2] = new int[3] { 10, 30, -5 };
            Console.WriteLine(CalculateMinimumHP(dungeon));
        }

        public static int CalculateMinimumHP(int[][] dungeon) {
            int m = dungeon.Length;
            int n = dungeon[0].Length;
            int[,] dp = new int[m + 1, n + 1];
            for (int i = 0; i <= m; i++) {
                for (int j = 0; j <= n; j++) {
                    dp[i, j] = int.MaxValue;
                }
                dp[m, n - 1] = 1;
                dp[m - 1, n] = 1;
            }
            for (int i = m - 1; i >= 0; i--) {
                for (int j = n - 1; j >= 0; j--) {
                    dp[i, j] = Math.Max(1, Math.Min(dp[i + 1, j], dp[i, j + 1]) - dungeon[i][j]);
                }
            }
            return dp[0, 0];
        }
    }
}
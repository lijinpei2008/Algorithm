// Given an input string, reverse the string word by word.

// Example 1:
// Input: "the sky is blue"
// Output: "blue is sky the"

// Example 2:
// Input: "  hello world!  "
// Output: "world! hello"
// Explanation: Your reversed string should not contain leading or trailing spaces.

// Example 3:
// Input: "a good   example"
// Output: "example good a"

// Explanation: You need to reduce multiple spaces between two words to a single space in the reversed string.

// Note:
// A word is defined as a sequence of non-space characters.
// Input string may contain leading or trailing spaces.However, your reversed string should not contain leading or trailing spaces.
// You need to reduce multiple spaces between two words to a single space in the reversed string.

// Follow up:
// For C programmers, try to solve it in-place in O(1) extra space.

using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace JulyThird {
    public class ReverseWordsInAString {
        public static void Main(string[] args) {
            Console.WriteLine(ReverseWords("Hello World!"));
        }

        public static string ReverseWords(string s) {
            return String.Join(" ", new Regex(" +").Split(s).Reverse()).Trim();
        }
    }
}

// Implement pow(x, n), which calculates x raised to the power n(i.e.xn).

// Example 1:
// Input: x = 2.00000, n = 10
// Output: 1024.00000

// Example 2:
// Input: x = 2.10000, n = 3
// Output: 9.26100

// Example 3:
// Input: x = 2.00000, n = -2
// Output: 0.25000
// Explanation: 2-2 = 1/22 = 1/4 = 0.25

// Constraints:
// -100.0 < x< 100.0
// -231 <= n <= 231-1
// -104 <= xn <= 104

using System;

namespace JulyThird {
    public class PowXN {
        public static void Main(string[] args) {
            Console.WriteLine(MyPow(2.00000, -2));
        }

        public static double MyPow(double x, int n) {
            if (n == 0) { return 1; }
            if (n < 0 && n > Int32.MinValue) {
                n = -n;
                x = 1 / x;
            }
            return (n % 2 == 0) ? MyPow(x * x, n / 2) : x * MyPow(x * x, n / 2);
        }
    }
}

// Given a non-empty array of integers, return the k most frequent elements.
   
// Example 1:
// Input: nums = [1,1,1,2,2,3], k = 2
// Output: [1,2]
   
// Example 2:
// Input: nums = [1], k = 1
// Output: [1]
   
// Note:
// You may assume k is always valid, 1 ≤ k ≤ number of unique elements.
// Your algorithm's time complexity must be better than O(n log n), where n is the array's size.
// It's guaranteed that the answer is unique, in other words the set of the top k frequent elements is unique.
// You can return the answer in any order.

using System;
using System.Collections.Generic;
using System.Linq;

namespace JulyThird {
    public class TopKFrequentElements {
        public static void Main(string[] args) {
            int[] nums = new int[] { 1, 1, 1, 3, 3, 4, 5 };
            foreach (int item in TopKFrequent(nums, 2)) {
                Console.Write(item + " ");
            }
        }

        public static int[] TopKFrequent(int[] nums, int k) {
            int[] ans = new int[k];
            Dictionary<int, int> map = new Dictionary<int, int>();
            foreach (int n in nums) {
                if (map.ContainsKey(n)) {
                    map[n]++;
                }
                else {
                    map.Add(n, 1);
                }
            }
            int i = 0;
            foreach (var v in map.OrderByDescending(o => o.Value)) {
                ans[i++] = v.Key;
                if (i >= k) break;
            }
            return ans;
        }
    }
}

// There are a total of n courses you have to take, labeled from 0 to n-1.
// Some courses may have prerequisites, for example to take course 0 you have to first take course 1, which is expressed as a pair: [0,1]
// Given the total number of courses and a list of prerequisite pairs, return the ordering of courses you should take to finish all courses.
// There may be multiple correct orders, you just need to return one of them.If it is impossible to finish all courses, return an empty array.
   
// Example 1:
// Input: 2, [[1,0]] 
// Output: [0,1]
// Explanation: There are a total of 2 courses to take.To take course 1 you should have finished
//              course 0. So the correct course order is [0,1] .
   
// Example 2:
// Input: 4, [[1,0],[2,0],[3,1],[3,2]]
// Output: [0,1,2,3]
// or[0, 2, 1, 3]
// Explanation: There are a total of 4 courses to take.To take course 3 you should have finished both
//             courses 1 and 2. Both courses 1 and 2 should be taken after you finished course 0. 
//              So one correct course order is [0,1,2,3]. Another correct ordering is [0,2,1,3] .
   
// Note:
// The input prerequisites is a graph represented by a list of edges, not adjacency matrices.Read more about how a graph is represented.
// You may assume that there are no duplicate edges in the input prerequisites.

using System;
using System.Collections.Generic;

namespace JulyThird {
    public class CourseScheduleII {
        public static void Main(string[] args) {
            int[][] prere = new int[4][];
            prere[0] = new int[2] { 1, 0 };
            prere[1] = new int[2] { 2, 0 };
            prere[2] = new int[2] { 3, 1 };
            prere[3] = new int[2] { 3, 2 };
            foreach (int item in FindOrder(4, prere)) {
                Console.Write(item + " ");
            }
        }

        public static int[] FindOrder(int numCourses, int[][] prerequisites) {
            List<int> result = new List<int>();
            Dictionary<int, List<int>> graph = new Dictionary<int, List<int>>();
            int[] indegree = new int[numCourses];
            Queue<int> queue = new Queue<int>();
            Stack<int> stack = new Stack<int>();
            int count = 0;
            if (prerequisites == null || prerequisites.Length == 0) {
                for (int i = 0; i < numCourses; i++) {
                    result.Add(i);
                }
                return result.ToArray();
            }
            for (int i = 0; i < numCourses; i++) {
                graph.Add(i, new List<int>());
            }
            for (int i = 0; i < prerequisites.Length; i++) {
                graph[prerequisites[i][0]].Add(prerequisites[i][1]);
                indegree[prerequisites[i][1]]++;
            }
            for (int i = 0; i < indegree.Length; i++) {
                if (indegree[i] == 0) {
                    queue.Enqueue(i);
                }
            }
            while (queue.Count > 0) {
                int cur = queue.Dequeue();
                stack.Push(cur);
                foreach (var node in graph[cur]) {
                    if (--indegree[node] == 0) {
                        queue.Enqueue(node);
                    }
                }
                count++;
            }
            if (count == numCourses) {
                while (stack.Count > 0) {
                    result.Add(stack.Pop());
                }
            }
            return count != numCourses ? new int[] { } : result.ToArray();
        }
    }
}

// Given two binary strings, return their sum(also a binary string).
// The input strings are both non-empty and contains only characters 1 or 0.

// Example 1:
// Input: a = "11", b = "1"
// Output: "100"

// Example 2:
// Input: a = "1010", b = "1011"
// Output: "10101"

// Constraints:
// Each string consists only of '0' or '1' characters.
// 1 <= a.length, b.length <= 10^4
// Each string is either "0" or doesn't contain any leading zero.

using System;
using System.Text;

namespace JulyThird {
    public class AddBinary {
        public static void Main(string[] args) {
            Console.WriteLine(AddBinaryFunction("1011", "1101"));
        }

        public static string AddBinaryFunction(string a, string b) {
            StringBuilder sb = new StringBuilder();
            int carry = 0;
            int i = a.Length - 1;
            int j = b.Length - 1;
            while (i >= 0 || j >= 0) {
                int sum = carry;
                if (i >= 0) {
                    sum += a[i--] - '0';
                }
                if (j >= 0) {
                    sum += b[j--] - '0';
                }
                sb.Insert(0, sum % 2);
                carry = sum / 2;
            }
            if (carry > 0) {
                sb.Insert(0, 1);
            }
            return sb.ToString();
        }
    }
}

// Remove all elements from a linked list of integers that have value val.

// Example:
// Input:  1->2->6->3->4->5->6, val = 6
// Output: 1->2->3->4->5

using System;
using System.Text;

namespace JulyThird {
    public class RemoveLinkedListElements {
        public static void Main(string[] args) {
            ListNode node = new ListNode {
                val = 1,
                next = new ListNode {
                    val = 2,
                    next = new ListNode {
                        val = 6,
                        next = new ListNode {
                            val = 3,
                            next = new ListNode {
                                val = 4,
                                next = new ListNode {
                                    val = 5,
                                    next = new ListNode {
                                        val = 6,
                                        next = null
                                    }
                                }
                            }
                        }
                    }
                }
            };
            node = RemoveElements(node, 6);
            Cw(node);
        }

        private static void Cw(ListNode node) {
            Console.Write(node.val + "->");
            if (node.next != null) {
                Cw(node.next);
            }
        }

        public class ListNode {
            public int val;
            public ListNode next;
            public ListNode(int val = 0, ListNode next = null) {
                this.val = val;
                this.next = next;
            }
        }

        public static ListNode RemoveElements(ListNode head, int val) {
            ListNode sentinel = new ListNode(-1);
            sentinel.next = head;
            ListNode cur = head;
            ListNode prev = sentinel;
            while (cur != null) {
                if (cur.val == val) {
                    prev.next = cur.next;
                }
                else {
                    prev = cur;
                }
                cur = cur.next;
            }
            return sentinel.next;
        }
    }
}

// Given a 2D board and a word, find if the word exists in the grid.
// The word can be constructed from letters of sequentially adjacent cell, where "adjacent" cells are those horizontally or vertically neighboring.
// The same letter cell may not be used more than once.

// Example:
// board =
// [
//  ['A', 'B', 'C', 'E'],
//  ['S','F','C','S'],
//  ['A','D','E','E']
// ]
// Given word = "ABCCED", return true.
// Given word = "SEE", return true.
// Given word = "ABCB", return false.

// Constraints:
// board and word consists only of lowercase and uppercase English letters.
// 1 <= board.length <= 200
// 1 <= board[i].length <= 200
// 1 <= word.length <= 10^3

using System;

namespace JulyThird {
    public class WordSearch {
        public static void Main(string[] args) {
            char[][] board = new char[3][];
            board[0] = new char[4] { 'A', 'B', 'C', 'E' };
            board[1] = new char[4] { 'S', 'F', 'C', 'S' };
            board[2] = new char[4] { 'A', 'D', 'E', 'E' };
            Console.WriteLine(Exist(board, "SEE"));
        }

        public static bool Exist(char[][] board, string word) {
            if (word.Length == 0) {
                return true;
            }
            for (int i = 0; i < board.Length; i++) {
                for (int j = 0; j < board[0].Length; j++) {
                    if (board[i][j] == word[0]) {
                        bool c = Dfs(board, i, j, 0, word);
                        if (c) {
                            return c;
                        }
                    }
                }
            }
            return false;
        }

        private static bool Dfs(char[][] B, int i, int j, int k, string gw) {
            if (k == gw.Length) {
                return true;
            }
            if (!ValidCell(B, i, j) || k > gw.Length || B[i][j] != gw[k]) {
                return false;
            }
            char o = B[i][j];
            B[i][j] = '#';
            bool l = Dfs(B, i, j - 1, k + 1, gw); if (l) return l;
            bool r = Dfs(B, i, j + 1, k + 1, gw); if (r) return r;
            bool u = Dfs(B, i - 1, j, k + 1, gw); if (u) return u;
            bool d = Dfs(B, i + 1, j, k + 1, gw); if (d) return d;
            B[i][j] = o;
            return false;
        }

        private static bool ValidCell(char[][] B, int i, int j) => i < B.Length && j < B[0].Length && i >= 0 && j >= 0 && B[i][j] != '#';
    }
}
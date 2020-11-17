// Given a list of non-overlapping axis-aligned rectangles rects, write a function pick which randomly 
// and uniformily picks an integer point in the space covered by the rectangles.

// Note:
// An integer point is a point that has integer coordinates. 
// A point on the perimeter of a rectangle is included in the space covered by the rectangles. 
// ith rectangle = rects[i] = [x1, y1, x2, y2], where[x1, y1] are the integer coordinates of the bottom-left corner,
// and[x2, y2] are the integer coordinates of the top-right corner.
// length and width of each rectangle does not exceed 2000.
// 1 <= rects.length <= 100
// pick return a point as an array of integer coordinates [p_x, p_y]
// pick is called at most 10000 times.

// Example 1:
// Input:
// ["Solution","pick","pick","pick"]
// [[[[1,1,5,5]]],[],[],[]]
// Output:
// [null,[4,1],[4,1],[3,3]]

// Example 2:
// Input:
// ["Solution","pick","pick","pick","pick","pick"]
// [[[[-2,-2,-1,-1],[1,0,3,0]]],[],[],[],[],[]]
// Output:
// [null,[-1,-2],[2,0],[-2,-1],[3,0],[-2,-2]]

// Explanation of Input Syntax:
// The input is two lists: the subroutines called and their arguments. Solution's constructor has one argument, the array of rectangles rects.
// pick has no arguments. Arguments are always wrapped with a list, even if there aren't any.

using System;
using System.Collections.Generic;

namespace AugFourth {
    public class RandomPointInNonOverlappingRectangles {
        public static void Main(string[] args) {
            int[][] rects = new int[4][];
            rects[0] = new int[4] { 1, 1, 5, 5 };
            rects[1] = new int[0] { };
            rects[2] = new int[0] { };
            rects[3] = new int[0] { };
            Solution obj = new Solution(rects);
            int[] param1 = obj.Pick();
            Console.WriteLine(string.Join(" ", param1.ToString()));
        }
    }

    public class Solution {
        public Solution(int[][] rects) {
            this.rects = rects;
            for (int i = 0; i < rects.Length; i++) {
                var area = (rects[i][2] - rects[i][0] + 1) * (rects[i][3] - rects[i][1] + 1);
                this.areaSum += area;
                areas.Add(this.areaSum);
            }
        }

        public int[] Pick() {
            var area = random.Next(1, this.areaSum + 1);
            var index = this.areas.BinarySearch(area);
            if (index < 0) index = ~index;
            var x = random.Next(this.rects[index][0], this.rects[index][2] + 1);
            var y = random.Next(this.rects[index][1], this.rects[index][3] + 1);
            return new int[] { x, y };
        }

        int areaSum = 0;
        List<int> areas = new List<int>();
        Random random = new Random();
        int[][] rects;
    }
}

// Implement the StreamChecker class as follows:
// StreamChecker(words): Constructor, init the data structure with the given words.
// query(letter): returns true if and only if for some k >= 1, the last k characters queried(in order from oldest to newest,
// including this letter just queried) spell one of the words in the given list.

// Example:
// StreamChecker streamChecker = new StreamChecker(["cd", "f", "kl"]) ; // init the dictionary.
// streamChecker.query('a');          // return false
// streamChecker.query('b');          // return false
// streamChecker.query('c');          // return false
// streamChecker.query('d');          // return true, because 'cd' is in the wordlist
// streamChecker.query('e');          // return false
// streamChecker.query('f');          // return true, because 'f' is in the wordlist
// streamChecker.query('g');          // return false
// streamChecker.query('h');          // return false
// streamChecker.query('i');          // return false
// streamChecker.query('j');          // return false
// streamChecker.query('k');          // return false
// streamChecker.query('l');          // return true, because 'kl' is in the wordlist

// Note:
// 1 <= words.length <= 2000
// 1 <= words[i].length <= 2000
// Words will only consist of lowercase English letters.
// Queries will only consist of lowercase English letters.
// The number of queries is at most 40000.

using System;
using System.Collections.Generic;

namespace AugFourth {
    public class StreamOfCharacters {
        public static void Main(string[] args) {
            StreamChecker streamChecker = new StreamChecker(new string[] { "cd", "f", "kl" }); // init the dictionary.
            Console.WriteLine(streamChecker.Query('a'));          // return false
            Console.WriteLine(streamChecker.Query('b'));          // return false
            Console.WriteLine(streamChecker.Query('c'));          // return false
            Console.WriteLine(streamChecker.Query('d'));          // return true, because 'cd' is in the wordlist
            Console.WriteLine(streamChecker.Query('e'));          // return false
            Console.WriteLine(streamChecker.Query('f'));          // return true, because 'f' is in the wordlist
            Console.WriteLine(streamChecker.Query('g'));          // return false
            Console.WriteLine(streamChecker.Query('h'));          // return false
            Console.WriteLine(streamChecker.Query('i'));          // return false
            Console.WriteLine(streamChecker.Query('j'));          // return false
            Console.WriteLine(streamChecker.Query('k'));          // return false
            Console.WriteLine(streamChecker.Query('l'));          // return true, because 'kl' is in the wordlist
        }
    }

    public class StreamChecker {
        public TrieNode root;
        public List<char> list;

        public StreamChecker(string[] words) {
            root = new TrieNode();
            list = new List<char>();
            foreach (string word in words) {
                BuildTrie(word, root);
            }
        }

        private void BuildTrie(string word, TrieNode root) {
            TrieNode p = root;
            for (int i = word.Length - 1; i >= 0; i--) {
                int index = word[i] - 'a';
                if (p.next[index] == null) {
                    p.next[index] = new TrieNode();
                }
                p = p.next[index];
            }
            p.isWord = true;
        }

        public bool Query(char letter) {
            list.Add(letter);
            TrieNode current = root;
            for (int i = list.Count - 1; i >= 0; i--) {
                int index = list[i] - 'a';
                if (current.next[index] == null) {
                    return false;
                }
                current = current.next[index];
                if (current.isWord) {
                    return true;
                }
            }
            return false;
        }

        public class TrieNode {
            public bool isWord;
            public TrieNode[] next;
            public TrieNode() {
                isWord = false;
                next = new TrieNode[26];
            }
        }
    }
}

// Find the sum of all left leaves in a given binary tree.

// Example:
//     3
//    / \
//   9  20
//     /  \
//    15   7

// There are two left leaves in the binary tree, with values 9 and 15 respectively. Return 24.

using System;
using System.Collections.Generic;
using System.Linq;

namespace AugFourth {
    public class SumOfLeftLeaves {
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
            Console.WriteLine(SumOfLeftLeavesFunction(root));
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

        public static int SumOfLeftLeavesFunction(TreeNode root) {
            if (root == null) {
                return 0;
            }
            int sum = 0;
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            while (queue.Any()) {
                int size = queue.Count;
                for (int s = 0; s < size; s++) {
                    TreeNode cur = queue.Dequeue();
                    if (cur.left != null && cur.left.left == null && cur.left.right == null) {
                        sum += cur.left.val;
                    }
                    if (cur.left != null) {
                        queue.Enqueue(cur.left);
                    }
                    if (cur.right != null) {
                        queue.Enqueue(cur.right);
                    }
                }
            }
            return sum;
        }
    }
}

// In a country popular for train travel, you have planned some train travelling one year in advance.
// The days of the year that you will travel is given as an array days.  Each day is an integer from 1 to 365.
// Train tickets are sold in 3 different ways:
// a 1 - day pass is sold for costs[0] dollars;
// a 7 - day pass is sold for costs[1] dollars;
// a 30 - day pass is sold for costs[2] dollars.
// The passes allow that many days of consecutive travel.For example, if we get a 7 - day pass on day 2,
// then we can travel for 7 days: day 2, 3, 4, 5, 6, 7, and 8.
// Return the minimum number of dollars you need to travel every day in the given list of days.

// Example 1:
// Input: days = [1, 4, 6, 7, 8, 20], costs = [2, 7, 15]
// Output: 11
// Explanation:
// For example, here is one way to buy passes that lets you travel your travel plan:
// On day 1, you bought a 1-day pass for costs[0] = $2, which covered day 1.
// On day 3, you bought a 7-day pass for costs[1] = $7, which covered days 3, 4, ..., 9.
// On day 20, you bought a 1-day pass for costs[0] = $2, which covered day 20.
// In total you spent $11 and covered all the days of your travel.

// Example 2:
// Input: days = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 30, 31], costs = [2, 7, 15]
// Output: 17
// Explanation:
// For example, here is one way to buy passes that lets you travel your travel plan:
// On day 1, you bought a 30-day pass for costs[2] = $15 which covered days 1, 2, ..., 30.
// On day 31, you bought a 1-day pass for costs[0] = $2 which covered day 31.
// In total you spent $17 and covered all the days of your travel.

// Note:
// 1 <= days.length <= 365
// 1 <= days[i] <= 365
// days is in strictly increasing order.
// costs.length == 3
// 1 <= costs[i] <= 1000

using System;

namespace AugFourth {
    public class MinimumCostForTickets {
        public static void Main(string[] args) {
            int[] days = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 21, 30, 31 };
            int[] costs = new int[] { 2, 7, 15 };
            Console.WriteLine(MincostTickets(days, costs)); ;
        }

        public static int MincostTickets(int[] days, int[] costs) {
            if (days.Length == 0) {
                return 0;
            }
            int[] dp = new int[days.Length];
            dp[0] = costs[0];
            for (int i = 1; i < days.Length; i++) {
                dp[i] = Math.Min(dp[i - 1] + costs[0], Math.Min(dp[i - 1] + costs[1], dp[i - 1] + costs[2]));
                for (int j = 0; j < i; j++) {
                    if (days[j] + 6 >= days[i]) {
                        dp[i] = Math.Min(dp[i], (j == 0 ? 0 : dp[j - 1]) + costs[1]);
                    }
                    if (days[j] + 29 >= days[i]) {
                        dp[i] = Math.Min(dp[i], (j == 0 ? 0 : dp[j - 1]) + costs[2]);
                    }
                }
            }
            return dp[days.Length - 1];
        }
    }
}

// Write a program that outputs the string representation of numbers from 1 to n.
// But for multiples of three it should output “Fizz” instead of the number and for the multiples of five output “Buzz”.
// For numbers which are multiples of both three and five output “FizzBuzz”.
   
// Example:
// n = 15,
// Return:
// [
//     "1",
//     "2",
//     "Fizz",
//     "4",
//     "Buzz",
//     "Fizz",
//     "7",
//     "8",
//     "Fizz",
//     "Buzz",
//     "11",
//     "Fizz",
//     "13",
//     "14",
//     "FizzBuzz"
// ]

using System;
using System.Collections.Generic;

namespace AugFourth {
    public class OutPutFizzBuzz {
        public static void Main(string[] args) {
            foreach (string str in FizzBuzz(15)) {
                Console.Write(str + " ");
            }
        }

        public static IList<string> FizzBuzz(int n) {
            IList<string> res = new List<string>();
            for (int i = 1; i <= n; i++) {
                string s = string.Empty;
                if (0 == i % 3) {
                    s += "Fizz";
                }
                if (0 == i % 5) {
                    s += "Buzz";
                }
                if (string.IsNullOrEmpty(s)) {
                    s += i;
                }
                res.Add(s);
            }
            return res;
        }
    }
}

// You are given an array of intervals, where intervals[i] = [start[i], end[i]] and each starti is unique.
// The right interval for an interval i is an interval j such that start[j] >= end[i] and start[j] is minimized.
// Return an array of right interval indices for each interval i. If no right interval exists for interval i, then put -1 at index i.

// Example 1:
// Input: intervals = [[1, 2]]
// Output:[-1]
// Explanation: There is only one interval in the collection, so it outputs -1.

// Example 2:
// Input: intervals = [[3, 4],[2,3],[1,2]]
// Output:[-1,0,1]
// Explanation: There is no right interval for [3, 4].
// The right interval for [2, 3] is [3, 4] since start0 = 3 is the smallest start that is >= end1 = 3.
// The right interval for [1, 2] is [2, 3] since start1 = 2 is the smallest start that is >= end2 = 2.

// Example 3:
// Input: intervals = [[1, 4],[2, 3],[3, 4]]
// Output: [-1,2,-1]
// Explanation: There is no right interval for [1, 4] and[3, 4].
// The right interval for [2, 3] is [3, 4] since start2 = 3 is the smallest start that is >= end1 = 3.

// Constraints:
// 1 <= intervals.length <= 2 * 10^4
// intervals[i].length == 2
// -10^6 <= start[i] <= end[i] <= 10^6
// The start point of each interval is unique.

using System;
using System.Collections.Generic;
using System.Linq;

namespace AugFourth {
    public class FindRightInterval {
        public static void Main(string[] args) {
            int[][] intervals = new int[3][];
            intervals[0] = new int[2] { 3, 4 };
            intervals[1] = new int[2] { 2, 3 };
            intervals[2] = new int[2] { 1, 2 };
            foreach (int i in RightInterval(intervals)) {
                Console.Write(i + " ");
            }
        }

        public static int[] RightInterval(int[][] intervals) {
            int n = intervals.Length;
            int[] result = new int[n];
            List<int[]> startTimeAndIndex = new List<int[]>();
            for (int i = 0; i < n; i++) {
                startTimeAndIndex.Add(new int[] { intervals[i][0], i });
            }
            startTimeAndIndex.Sort((x, y) => x[0].CompareTo(y[0]));
            List<int> startTimes = startTimeAndIndex.Select(x => x[0]).ToList();
            for (int i = 0; i < n; i++) {
                int index = startTimes.BinarySearch(intervals[i][1]);
                if (index < 0) {
                    index = ~index;
                }
                result[i] = index == n ? -1 : startTimeAndIndex[index][1];
            }
            return result;
        }
    }
}

// Given the API rand7() that generates a uniform random integer in the range [1, 7],
// write a function rand10() that generates a uniform random integer in the range [1, 10].
// You can only call the API rand7(), and you shouldn't call any other API. Please do not use a language's built-in random API.
// Each test case will have one internal argument n, the number of times that your implemented function rand10() will be called while testing.
// Note that this is not an argument passed to rand10().

// Follow up:
// What is the expected value for the number of calls to rand7() function ?
// Could you minimize the number of calls to rand7() ?

// Example 1:
// Input: n = 1
// Output: [2]

// Example 2:
// Input: n = 2
// Output:[2,8]

// Example 3:
// Input: n = 3
// Output:[3,8,10]

// Constraints:
// 1 <= n <= 10^5

using System;

namespace AugFourth {
    public class ImplementRand10UsingRand7 {
        public static void Main(string[] args) {
            Solution obj = new Solution();
            Console.WriteLine(obj.Rand10());
        }
    }

    public class Solution : SolBase {
        public int Rand10() {
            int n = 48;
            while (n >= 40) {
                n = (Rand7() - 1) * 7 + Rand7() - 1;
            }
            return n % 10 + 1;
        }
    }
}
// Given an array of integers and an integer k, you need to find the total number of continuous subarrays whose sum equals to k.

// Example 1:
// Input:nums = [1,1,1], k = 2
// Output: 2

// Constraints:
// The length of the array is in range[1, 20, 000].
// The range of numbers in the array is [-1000, 1000] and the range of the integer k is [-1e7, 1e7].

using System;

namespace AprilFourth {
    public class SubarraySumEqualsK {
        public static void Main(string[] args) {
            int[] nums = { 3, 4, 7, 2, -3, 1, 4, 2 };
            int k = 7;
            Console.WriteLine(SubarraySum(nums, k));
        }

        public static int SubarraySum(int[] nums, int k) {
            var sum = 0;
            var result = 0;
            var n = nums.Length;
            var map = new Dictionary<int, int>(n);
            map.Add(0, 1);
            for (int i = 0; i < n; i++) {
                sum += nums[i];
                if (map.TryGetValue(sum - k, out var val)) {
                    result += val;
                }
                if (!map.TryAdd(sum, 1)) {
                    map[sum]++;
                }
            }
            return result;
        }
    }
}

// Given a range[m, n] where 0 <= m <= n <= 2147483647, return the bitwise AND of all numbers in this range, inclusive.

// Example 1:
// Input: [5,7]
// Output: 4

// Example 2:
// Input: [0,1]
// Output: 0

using System;

namespace AprilFourth {
    public class BitwiseANDOfNumbersRange {
        public static void Main(string[] args) {
            int m = 5, n = 7;
            Console.WriteLine(RangeBitwiseAnd(m, n));
        }

        public static int RangeBitwiseAnd(int m, int n) {
            int count = 0;
            for (int changed = m ^ n; changed > 0; changed /= 2, count++) ;
            return m >> count << count;
        }
    }
}

// Design and implement a data structure for Least Recently Used(LRU) cache.It should support the following operations: get and put.
// get(key) - Get the value(will always be positive) of the key if the key exists in the cache, otherwise return -1.
// put(key, value) - Set or insert the value if the key is not already present.When the cache reached its capacity,
//it should invalidate the least recently used item before inserting a new item.
// The cache is initialized with a positive capacity.
   
// Follow up:
// Could you do both operations in O(1) time complexity?
   
// Example:
// LRUCache cache = new LRUCache(2 /* capacity */ );
// cache.put(1, 1);
// cache.put(2, 2);
// cache.get(1);       // returns 1
// cache.put(3, 3);    // evicts key 2
// cache.get(2);       // returns -1 (not found)
// cache.put(4, 4);    // evicts key 1
// cache.get(1);       // returns -1 (not found)
// cache.get(3);       // returns 3
// cache.get(4);       // returns 4

using System;
using System.Collections.Generic;

namespace AprilFourth {
    public class LRUCache {
        public static void Main(string[] args) {
            LRUCache cache = new LRUCache(2);
            cache.Put(1, 1);
            cache.Put(2, 2);
            Console.WriteLine(cache.Get(1));    // returns 1
            cache.Put(3, 3);    // evicts key 2
            Console.WriteLine(cache.Get(2));    // returns -1 (not found)
            cache.Put(4, 4);    // evicts key 1
            Console.WriteLine(cache.Get(1));    // returns -1 (not found)
            Console.WriteLine(cache.Get(3));    // returns 3
            Console.WriteLine(cache.Get(4));    // returns 4
        }

        public class ListNode {
            public int key;
            public int val;
            public ListNode higher;
            public ListNode lower;

            public ListNode(int key, int val) {
                this.key = key;
                this.val = val;
                higher = null;
                lower = null;
            }
        }

        private readonly int Capacity;
        private Dictionary<int, ListNode> _dictionary;
        private ListNode _high;
        private ListNode _low;

        public LRUCache(int capacity) {
            this.Capacity = capacity;
            this._dictionary = new Dictionary<int, ListNode>();
            this._high = new ListNode(-1, -1);
            this._low = new ListNode(-1, -1);
            this._high.lower = this._low;
            this._low.higher = this._high;
        }

        public int Get(int key) {
            if (this._dictionary.ContainsKey(key)) {
                //bump priority of key
                BumpPriority(key);
                return this._dictionary[key].val;
            }
            else return -1;
        }

        public void Put(int key, int value) {
            if (this._dictionary.Count == this.Capacity && !this._dictionary.ContainsKey(key)) {

                // remove list used 
                RemoveLeastUsed();
            }
            if (this._dictionary.ContainsKey(key)) {
                this._dictionary[key].val = value;
            }
            else {
                ListNode node = new ListNode(key, value);
                this._dictionary[key] = node;
            }
            //bump priority of key
            BumpPriority(key);
        }

        // O(1)
        private void BumpPriority(int key) {
            ListNode nodeToBump = this._dictionary[key];
            ListNode tempHigher, tempLower, temp;

            tempHigher = nodeToBump.higher;

            tempLower = nodeToBump.lower;

            if (tempLower != null) {
                tempHigher.lower = tempLower;
            }
            if (nodeToBump.lower != null) {
                tempLower.higher = tempHigher;
            }
            //move nodeToBump all the way up to the head
            temp = this._high.lower;
            this._high.lower = nodeToBump;
            nodeToBump.lower = temp;
            temp.higher = nodeToBump;
            nodeToBump.higher = this._high;
        }

        // O(1)
        private void RemoveLeastUsed() {
            ListNode leastUsed = this._low.higher;
            // remove from dictionary
            this._dictionary.Remove(leastUsed.key);
            // remove from linkedlist
            ListNode higherNode = leastUsed.higher;
            higherNode.lower = leastUsed.lower;
            this._low.higher = higherNode;
        }
    }
}

// Given an array of non-negative integers, you are initially positioned at the first index of the array.
// Each element in the array represents your maximum jump length at that position.
// Determine if you are able to reach the last index.
   
// Example 1:
// Input: nums = [2, 3, 1, 1, 4]
// Output: true
// Explanation: Jump 1 step from index 0 to 1, then 3 steps to the last index.
   
// Example 2:
// Input: nums = [3, 2, 1, 0, 4]
// Output: false
// Explanation: You will always arrive at index 3 no matter what.Its maximum jump length is 0, which makes it impossible to reach the last index.
   
// Constraints:
// 1 <= nums.length <= 3 * 10^4
// 0 <= nums[i][j] <= 10^5

using System;

namespace AprilFourth {
    public class JumpGame {
        public static void Main(string[] args) {
            int[] nums = { 2, 3, 1, 1, 4 };
            Console.WriteLine(CanJump(nums));
        }

        public static bool CanJump(int[] nums) {
            int min = 0;
            for (int i = nums.Length - 2; i >= 0; i--) {
                if (nums[i] > min) {
                    min = 0;
                }
                else {
                    min++;
                }
            }
            return min == 0;
        }
    }
}

//Given two strings text1 and text2, return the length of their longest common subsequence.
//A subsequence of a string is a new string generated from the original string with some characters(can be none) deleted
//without changing the relative order of the remaining characters. (eg, "ace" is a subsequence of "abcde" while "aec" is not).
//A common subsequence of two strings is a subsequence that is common to both strings.
//If there is no common subsequence, return 0.

//Example 1:
//Input: text1 = "abcde", text2 = "ace"
//Output: 3  
//Explanation: The longest common subsequence is "ace" and its length is 3.

//Example 2:
//Input: text1 = "abc", text2 = "abc"
//Output: 3
//Explanation: The longest common subsequence is "abc" and its length is 3.

//Example 3:
//Input: text1 = "abc", text2 = "def"
//Output: 0
//Explanation: There is no such common subsequence, so the result is 0.

//Constraints:
//1 <= text1.length <= 1000
//1 <= text2.length <= 1000
//The input strings consist of lowercase English characters only.

using System;

namespace AprilFourth {
    public class LongestCommonSubsequence {
        public static void Main(string[] args) {
            Console.WriteLine(LongestCommonSubsequences("abcd", "acde"));
        }

        public static int LongestCommonSubsequences(string text1, string text2) {
            int[,] dp = new int[text1.Length + 1, text2.Length + 1];
            for (var i = 1; i <= text1.Length; i++) {
                for (var j = 1; j <= text2.Length; j++) {
                    if (text1[i - 1] == text2[j - 1]) {
                        dp[i, j] = dp[i - 1, j - 1] + 1;
                    }
                    else {
                        dp[i, j] = Math.Max(dp[i - 1, j], dp[i, j - 1]);
                    }
                }
            }
            return dp[text1.Length, text2.Length];
        }
    }
}

//Given a 2D binary matrix filled with 0's and 1's, find the largest square containing only 1's and return its area.

//Example:
//Input: 
// 1 0 1 0 0
// 1 0 1 1 1
// 1 1 1 1 1
// 1 0 0 1 0
//Output: 4

using System;

namespace AprilFourth {
    public class MaximalSquare {
        public static void Main(string[] args) {
            char[][] matrix = new char[4][];
            matrix[0] = new char[5] { '1', '0', '1', '0', '0' };
            matrix[1] = new char[5] { '1', '0', '1', '1', '1' };
            matrix[2] = new char[5] { '1', '1', '1', '1', '1' };
            matrix[3] = new char[5] { '1', '0', '0', '1', '0' };
            Console.WriteLine(MaximalSquares(matrix));
        }

        public static int MaximalSquares(char[][] matrix) {
            // Max square size
            int height = matrix.Length;
            int width = height > 0 ? matrix[0].Length : 0;
            int currentMaxSize = 0;
            // Create List
            int[,] squares = new int[height + 1, width + 1];
            // Iterate through possibilities.
            for (int i = 1; i <= height; i++) {
                for (int j = 1; j <= width; j++) {
                    if (matrix[i - 1][j - 1] == '1') {
                        squares[i, j] = Math.Min(squares[i - 1, j], Math.Min(squares[i, j - 1], squares[i - 1, j - 1])) + 1;
                        currentMaxSize = Math.Max(currentMaxSize, squares[i, j]);
                    }
                }
            }
            return currentMaxSize * currentMaxSize;
        }
    }
}
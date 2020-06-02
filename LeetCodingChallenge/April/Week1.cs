// Given a non-empty array of integers, every element appears twice except for one.Find that single one.
// Note:
// Your algorithm should have a linear runtime complexity. Could you implement it without using extra memory?

// Example 1:
// Input: [2,2,1]
// Output: 1

// Example 2:
// Input: [4,1,2,1,2]
// Output: 4

using System;

namespace AprilFirst {
    public class SingleNumber {
        public static void Main(string[] args) {
            int[] nums = { 4, 2, 1, 2, 1 };
            Console.WriteLine(SingleNumbers(nums));
        }

        public static int SingleNumbers(int[] nums) {
            if (nums == null || nums.Length <= 0) {
                return 0;
            }
            int key = 0;
            foreach (int item in nums) {
                key ^= item;
            }
            return key;
        }
    }
}

// Write an algorithm to determine if a number n is "happy".
// A happy number is a number defined by the following process: Starting with any positive integer, replace the number by the sum of the squares of its digits, and repeat the process until the number equals 1 (where it will stay), or it loops endlessly in a cycle which does not include 1. Those numbers for which this process ends in 1 are happy numbers.
// Return True if n is a happy number, and False if not.

// Example: 
// Input: 19
// Output: true
// Explanation: 
// 12 + 92 = 82
// 82 + 22 = 68
// 62 + 82 = 100
// 12 + 02 + 02 = 1

using System;

namespace AprilFirst {
    public class HappyNumber {
        public static void Main(string[] args) {
            int n = 19;
            Console.WriteLine(IsHappy(n));
        }

        private static int NumSquare(int num) {
            int n = 0;
            while (num > 0) {
                int d = num % 10;
                n += (d * d);
                num /= 10;
            }
            return n;
        }

        public static bool IsHappy(int n) {
            while (n != 1 && n != 4) {
                n = NumSquare(n);
            }
            if (n != 1) {
                return false;
            }
            return true;
        }
    }
}

// Given an integer array nums, find the contiguous subarray(containing at least one number) which has the largest sum and return its sum.
   
// Example:
// Input: [-2,1,-3,4,-1,2,1,-5,4],
// Output: 6
// Explanation: [4,-1,2,1] has the largest sum = 6.
   
// Follow up:
// If you have figured out the O(n) solution, try coding another solution using the divide and conquer approach, which is more subtle.

using System;

namespace AprilFirst {
    public class MaximumSubarray {
        public static void Main(string[] args) {
            int[] nums = { -2, 1, -3, 4, -1, 2, 1, -5, 4 };
            Console.WriteLine(MaxSubArray(nums));
        }

        public static int MaxSubArray(int[] nums) {
            int temp = int.MinValue;
            int ans = temp;
            for (int i = 0; i < nums.Length; i++) {
                if (temp < 0) {
                    temp = nums[i];
                }
                else {
                    temp += nums[i];
                }
                if (temp > ans) {
                    ans = temp;
                }
            }
            return ans;
        }
    }
}

// Given an array nums, write a function to move all 0's to the end of it while maintaining the relative order of the non-zero elements.
   
// Example:
// Input: [0,1,0,3,12]
// Output: [1,3,12,0,0]
   
// Note:
// You must do this in-place without making a copy of the array.
// Minimize the total number of operations.

using System;

namespace AprilFirst {
    public class MoveZeroes {
        public static void Main(string[] args) {
            int[] nums = { 0, 1, 0, 3, 12 };
            MoveZeroe(nums);
            foreach (int item in nums) {
                Console.WriteLine(item);
            }
        }

        public static void MoveZeroe(int[] nums) {
            int zeroIndex = 0;
            for (int i = 0; i < nums.Length; i++) {
                if (nums[i] != 0) {
                    nums[zeroIndex] = nums[i];
                    zeroIndex++;
                }
            }
            for (int i = zeroIndex; i < nums.Length; i++) {
                nums[i] = 0;
            }
        }
    }
}

// Say you have an array prices for which the ith element is the price of a given stock on day i.
// Design an algorithm to find the maximum profit.You may complete as many transactions as you like (i.e., buy one and sell one share of the stock multiple times).
   
// Note: You may not engage in multiple transactions at the same time(i.e., you must sell the stock before you buy again).
   
// Example 1:
// Input: [7,1,5,3,6,4]
// Output: 7
// Explanation: Buy on day 2 (price = 1) and sell on day 3 (price = 5), profit = 5-1 = 4.
//              Then buy on day 4 (price = 3) and sell on day 5 (price = 6), profit = 6-3 = 3.
   
// Example 2:
// Input: [1,2,3,4,5]
// Output: 4
// Explanation: Buy on day 1 (price = 1) and sell on day 5 (price = 5), profit = 5-1 = 4.
//              Note that you cannot buy on day 1, buy on day 2 and sell them later, as you are
//              engaging multiple transactions at the same time.You must sell before buying again.
   
// Example 3:
// Input: [7,6,4,3,1]
// Output: 0
// Explanation: In this case, no transaction is done, i.e.max profit = 0.
   
// Constraints:
// 1 <= prices.length <= 3 * 10 ^ 4
// 0 <= prices[i] <= 10 ^ 4

using System;

namespace AprilFirst {
    public class BestTimeToBuyAndSellStockII {
        public static void Main(string[] args) {
            int[] prices = { 7, 1, 5, 3, 6, 4 };
            Console.WriteLine(MaxProfit(prices));
        }

        public static int MaxProfit(int[] prices) {
            if (prices.Length < 2) {
                return 0;
            }
            int result = 0, buy = prices[0];
            for (int i = 0; i < prices.Length; i++) {
                buy = Math.Min(prices[i], buy);
                int max = Math.Max(buy, prices[i]);
                result += max - buy;
                if (max - buy != 0) {
                    buy = prices[i];
                }
            }
            return result;
        }
    }
}

// Given an array of strings, group anagrams together.
   
// Example:
// Input: ["eat", "tea", "tan", "ate", "nat", "bat"],
// Output:
// [
//   ["ate","eat","tea"],
//   ["nat","tan"],
//   ["bat"]
// ]
   
// Note:
// All inputs will be in lowercase.
// The order of your output does not matter.

using System;
using System.Collections.Generic;
using System.Linq;

namespace AprilFirst {
    public class GroupAnagrams {
        public static void Main(string[] args) {
            string[] words = { "eat", "tea", "tan", "ate", "nat", "bat" };
            foreach (IList<string> item in GroupAnagram(words).ToList()) {
                foreach (string word in item) {
                    Console.Write(word);
                    Console.Write(" ");
                }
                Console.WriteLine();
            };

        }

        public static IList<IList<string>> GroupAnagram(string[] strs) {
            if (strs == null || strs.Length == 0) {
                return new List<IList<string>>();
            }
            List<IList<string>> groups = new List<IList<string>>();
            Dictionary<string, List<string>> map = new Dictionary<string, List<string>>();
            foreach (string str in strs) {
                char[] ch = str.ToCharArray();
                Array.Sort(ch);
                string key = new string(ch);
                if (!map.ContainsKey(key)) {
                    map.Add(key, new List<string>());
                }
                map[key].Add(str);
            }
            foreach (var item in map) {
                groups.Add(item.Value);
            }
            return groups;
        }
    }
}
// Given an integer, write a function to determine if it is a power of two.

// Example 1:
// Input: 1
// Output: true 
// Explanation: 20 = 1

// Example 2:
// Input: 16
// Output: true
// Explanation: 24 = 16

// Example 3:
// Input: 218
// Output: false

using System;

namespace JuneSecond {
    public class CoinChange2 {
        public static void Main(string[] args) {
            Console.WriteLine(IsPowerOfTwo(16));
        }

        public static bool IsPowerOfTwo(int n) {
            if (n < 1) {
                return false;
            }
            while (n > 1) {
                if (n % 2 == 1) {
                    return false;
                }
                n >>= 1;
            }
            return true;
        }
    }
}

// Given a string s and a string t, check if s is subsequence of t.
// A subsequence of a string is a new string which is formed from the original string by deleting some(can be none) of the characters without disturbing 
// the relative positions of the remaining characters. (ie, "ace" is a subsequence of "abcde" while "aec" is not).
// Follow up:
// If there are lots of incoming S, say S1, S2, ... , Sk where k >= 1B, and you want to check one by one to see if T has its subsequence.
// In this scenario, how would you change your code?
// Credits:
// Special thanks to @pbrother for adding this problem and creating all test cases.
   
// Example 1:
// Input: s = "abc", t = "ahbgdc"
// Output: true
   
// Example 2:
// Input: s = "axc", t = "ahbgdc"
// Output: false
   
// Constraints:
// 0 <= s.length <= 100
// 0 <= t.length <= 10^4
// Both strings consists only of lowercase characters.

using System;

namespace JuneSecond {
    public class IsSubsequence {
        public static void Main(string[] args) {
            Console.WriteLine(IsSubsequences("abc", "ahbgdc"));
        }

        public static bool IsSubsequences(string s, string t) {
            if (s.Length > t.Length) {
                return false;
            }
            int sIndex = 0;
            int tIndex = 0;
            while (sIndex < s.Length && tIndex < t.Length) {
                if (s[sIndex] == t[tIndex]) {
                    sIndex += 1;
                    tIndex += 1;
                }
                else {
                    tIndex += 1;
                }
            }
            return sIndex == s.Length;
        }
    }
}

// Given a sorted array and a target value, return the index if the target is found.If not, return the index where it would be if it were inserted in order.
// You may assume no duplicates in the array.
   
// Example 1:
// Input: [1,3,5,6], 5
// Output: 2
   
// Example 2:
// Input: [1,3,5,6], 2
// Output: 1
   
// Example 3:
// Input: [1,3,5,6], 7
// Output: 4
   
// Example 4:
// Input: [1,3,5,6], 0
// Output: 0

using System;

namespace JuneSecond {
    public class SearchInsertPosition {
        public static void Main(string[] args) {
            int[] nums = new int[] { 1, 3, 5, 7, 9 };
            int target = 11;
            Console.WriteLine(SearchInsert(nums, target));
        }

        public static int SearchInsert(int[] nums, int target) {
            if (nums.Length < 1) {
                return 0;
            }
            for (int i = 0; i < nums.Length; i++) {
                if (target == nums[i] || target < nums[i]) {
                    return i;
                }
            }
            return nums.Length;
        }
    }
}

// Given an array with n objects colored red, white or blue, sort them in-place so that objects of the same color are adjacent,
// with the colors in the order red, white and blue.
// Here, we will use the integers 0, 1, and 2 to represent the color red, white, and blue respectively.
// Note: You are not suppose to use the library's sort function for this problem.
   
// Example:
// Input: [2,0,2,1,1,0]
// Output: [0,0,1,1,2,2]
   
// Follow up:
// A rather straight forward solution is a two-pass algorithm using counting sort.
// First, iterate the array counting number of 0's, 1's, and 2's, then overwrite array with total number of 0's, then 1's and followed by 2's.
// Could you come up with a one-pass algorithm using only constant space?

using System;

namespace JuneSecond {
    public class SortColors {
        public static void Main(string[] args) {
            int[] nums = new int[] { 2, 0, 2, 1, 1, 0 };
            nums = SortColor(nums);
            foreach (int item in nums) {
                Console.Write(item + " ");
            }
        }

        public static int[] SortColor(int[] nums) {
            int[] counts = new int[3];
            foreach (int x in nums) {
                counts[x]++;
            }
            int index = 0;
            for (int x = 0; x <= 2; x++) {
                while (counts[x]-- > 0) {
                    nums[index++] = x;
                }
            }
            return nums;
        }
    }
}

// Design a data structure that supports all following operations in average O(1) time.
// insert(val): Inserts an item val to the set if not already present.
// remove(val): Removes an item val from the set if present.
// getRandom: Returns a random element from current set of elements(it's guaranteed that at least one element exists when this method is called).
// Each element must have the same probability of being returned.

// Example:
// Init an empty set.
// RandomizedSet randomSet = new RandomizedSet();
// Inserts 1 to the set. Returns true as 1 was inserted successfully.
// randomSet.insert(1);
// Returns false as 2 does not exist in the set.
// randomSet.remove(2);
// Inserts 2 to the set, returns true. Set now contains [1,2].
// randomSet.insert(2);
// getRandom should return either 1 or 2 randomly.
// randomSet.getRandom();
// Removes 1 from the set, returns true. Set now contains [2].
// randomSet.remove(1);
// 2 was already in the set, so return false.
// randomSet.insert(2);
// Since 2 is the only number in the set, getRandom always return 2.
// randomSet.getRandom();

using System;
using System.Collections.Generic;

namespace JuneSecond {
    public class RandomizedSet {
        public static void Main(string[] args) {
            RandomizedSet randomSet = new RandomizedSet();
            Console.WriteLine(randomSet.Insert(1));
            Console.WriteLine(randomSet.Remove(2));
            Console.WriteLine(randomSet.Insert(2));
            Console.WriteLine(randomSet.GetRandom());
            Console.WriteLine(randomSet.Remove(1));
            Console.WriteLine(randomSet.Insert(2));
            Console.WriteLine(randomSet.GetRandom());
        }

        private List<int> nums;
        private Dictionary<int, int> map;
        private Random rand;

        /** Initialize your data structure here. */
        public RandomizedSet() {
            map = new Dictionary<int, int>();
            nums = new List<int>();
            rand = new Random();
        }

        /** Inserts a value to the set. Returns true if the set did not already contain the specified element. */
        public bool Insert(int val) {
            if (map.ContainsKey(val)) {
                return false;
            }
            nums.Add(val);
            map.Add(val, nums.Count - 1);
            return true;
        }

        /** Removes a value from the set. Returns true if the set contained the specified element. */
        public bool Remove(int val) {
            if (!map.ContainsKey(val)) {
                return false;
            }
            int i = map[val];
            nums[i] = nums[nums.Count - 1];
            map[nums[i]] = i;
            nums.RemoveAt(nums.Count - 1);
            map.Remove(val);
            return true;
        }

        /** Get a random element from the set. */
        public int GetRandom() {
            return nums[rand.Next(0, nums.Count)];
        }
    }
}

// Given a set of distinct positive integers, find the largest subset such that every pair(Si, Sj) of elements in this subset satisfies:
// Si % Sj = 0 or Sj % Si = 0.
// If there are multiple solutions, return any subset is fine.
   
// Example 1:
// Input: [1,2,3]
// Output: [1,2] (of course, [1, 3] will also be ok)
   
// Example 2:
// Input: [1,2,4,8]
// Output: [1,2,4,8]

using System;
using System.Collections.Generic;
using System.Linq;

namespace JuneSecond {
    public class LargestDivisibleSubset {
        public static void Main(string[] args) {
            int[] nums = new int[] { 1, 2, 4, 8 };
            List<int> val = LargestDivisibleSubsets(nums).ToList();
            foreach (int item in val) {
                Console.Write(item + " ");
            }
        }

        public static IList<int> LargestDivisibleSubsets(int[] nums) {
            int[] dp = new int[nums.Length + 1];
            var res = new List<int>();
            int max = 0;
            int prev = -1;
            Array.Sort(nums);
            for (var i = 1; i < nums.Length; i++) {
                for (int j = 0; j < i; j++) {
                    if (nums[i] % nums[j] == 0 && dp[j] + 1 > dp[i]) {
                        dp[i] = 1 + dp[j];
                        max = Math.Max(dp[i], max);

                    }
                }
            }
            for (var i = nums.Length - 1; i >= 0; i--) {
                if (dp[i] == max && (prev % nums[i] == 0 || prev == -1)) {
                    res.Add(nums[i]);
                    prev = nums[i];
                    max--;
                }
            }
            return res;
        }
    }
}

// There are n cities connected by m flights.Each flight starts from city u and arrives at v with a price w.
// Now given all the cities and flights, together with starting city src and the destination dst,
// your task is to find the cheapest price from src to dst with up to k stops. If there is no such route, output -1.

// Example 1:
// Input: 
// n = 3, edges = [[0, 1, 100], [1,2,100], [0,2,500]]
// src = 0, dst = 2, k = 1
// Output: 200
// Explanation: 
// The graph looks like this:
//          [0]
//        ↙   ↘
//  100 ↙       ↘ 500
//    ↙    100    ↘
// [1] →→→→→→ [2]
// The cheapest price from city 0 to city 2 with at most 1 stop costs 200, as marked red in the picture.

// Example 2:
// Input: 
// n = 3, edges = [[0, 1, 100], [1,2,100], [0,2,500]]
// src = 0, dst = 2, k = 0
// Output: 500
// Explanation: 
// The graph looks like this:
//          [0]
//        ↙   ↘
//  100 ↙       ↘ 500
//    ↙    100    ↘
// [1] →→→→→→ [2]
// The cheapest price from city 0 to city 2 with at most 0 stop costs 500, as marked blue in the picture.

// Constraints:
// The number of nodes n will be in range [1, 100], with nodes labeled from 0 to n - 1.
// The size of flights will be in range [0, n * (n - 1) / 2].
// The format of each flight will be (src, dst, price).
// The price of each flight will be in the range [1, 10000].
// k is in the range of [0, n - 1].
// There will not be any duplicated flights or self cycles.

using System;

namespace JuneSecond {
    public class CheapestFlightsWithinKStops {
        public static void Main(string[] args) {
            int[][] flights = new int[3][];
            flights[0] = new int[3] { 0, 1, 100 };
            flights[1] = new int[3] { 1, 2, 100 };
            flights[2] = new int[3] { 0, 2, 500 };
            Console.WriteLine(FindCheapestPrice(3, flights, 0, 2, 1));
        }

        public static int FindCheapestPrice(int n, int[][] flights, int src, int dst, int k) {
            if (n <= 1) {
                return 0;
            }
            var w1 = new int[n];
            var w2 = new int[n];
            for (int i = 0; i < n; ++i) {
                w1[i] = i == src ? 0 : int.MaxValue;
                w2[i] = i == src ? 0 : int.MaxValue;
            }
            var cur = w1; var next = w2;
            for (int i = 0; i <= k; ++i) {
                foreach (var f in flights) {
                    int s = f[0];
                    int d = f[1];
                    int w = f[2];
                    if (cur[s] == int.MaxValue) {
                        continue;
                    }
                    if (next[d] > cur[s] + w) {
                        next[d] = cur[s] + w;
                    }
                }
                var tmp = cur;
                cur = next;
                next = tmp;
            }
            return cur[dst] == int.MaxValue ? -1 : cur[dst];
        }
    }
}
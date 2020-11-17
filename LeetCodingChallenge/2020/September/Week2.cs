// You are given the root of a binary tree where each node has a value 0 or 1.
// Each root-to-leaf path represents a binary number starting with the most significant bit.
// For example, if the path is 0 -> 1 -> 1 -> 0 -> 1, then this could represent 01101 in binary, which is 13.
// For all leaves in the tree, consider the numbers represented by the path from the root to that leaf.
// Return the sum of these numbers. The answer is guaranteed to fit in a 32-bits integer.

// Example 1:
// Input: root = [1, 0, 1, 0, 1, 0, 1]
// Output: 22
// Explanation: (100) + (101) + (110) + (111) = 4 + 5 + 6 + 7 = 22

// Example 2:
// Input: root = [0]
// Output: 0

// Example 3:
// Input: root = [1]
// Output: 1

// Example 4:
// Input: root = [1, 1]
// Output: 3

// Constraints:
// The number of nodes in the tree is in the range [1, 1000].
// Node.val is 0 or 1.

using System;

namespace SeptemberSecond {
    public class SumOfRootToLeafBinaryNumbers {
        public static void Main(string[] args) {
            TreeNode root = new TreeNode {
                val = 1,
                left = new TreeNode {
                    val = 0,
                    left = new TreeNode {
                        val = 0,
                        left = null,
                        right = null
                    },
                    right = new TreeNode {
                        val = 1,
                        left = null,
                        right = null
                    }
                },
                right = new TreeNode {
                    val = 1,
                    left = new TreeNode {
                        val = 0,
                        left = null,
                        right = null
                    },
                    right = new TreeNode {
                        val = 1,
                        left = null,
                        right = null
                    }
                }
            };
            Console.WriteLine(SumRootToLeaf(root));
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

        public static int SumRootToLeaf(TreeNode root) {
            int result = 0;
            Helper(root, ref result, 0);
            return result;
        }

        private static void Helper(TreeNode root, ref int result, int sum) {
            if (root != null) {
                sum = sum * 2 + root.val;
                if (root.left == null && root.right == null) {
                    result += sum;
                    return;
                }
                Helper(root.left, ref result, sum);
                Helper(root.right, ref result, sum);
            }
        }
    }
}

// Given two version numbers, version1 and version2, compare them.
// Version numbers consist of one or more revisions joined by a dot '.'. Each revision consists of digits and may contain leading zeros.
// Every revision contains at least one character.
// Revisions are 0-indexed from left to right, with the leftmost revision being revision 0, the next revision being revision 1, and so on.
// For example 2.5.33 and 0.1 are valid version numbers.
// To compare version numbers, compare their revisions in left-to-right order.
// Revisions are compared using their integer value ignoring any leading zeros.
// This means that revisions 1 and 001 are considered equal.
// If a version number does not specify a revision at an index, then treat the revision as 0.
// For example, version 1.0 is less than version 1.1 because their revision 0s are the same, but their revision 1s are 0 and 1 respectively, and 0 < 1.
// Return the following:
// If version1<version2, return -1.
// If version1 > version2, return 1.
// Otherwise, return 0.

// Example 1:
// Input: version1 = "1.01", version2 = "1.001"
// Output: 0
// Explanation: Ignoring leading zeroes, both "01" and "001" represent the same integer "1".

// Example 2:
// Input: version1 = "1.0", version2 = "1.0.0"
// Output: 0
// Explanation: version1 does not specify revision 2, which means it is treated as "0".

// Example 3:
// Input: version1 = "0.1", version2 = "1.1"
// Output: -1
// Explanation: version1's revision 0 is "0", while version2's revision 0 is "1". 0 < 1, so version1 < version2.

// Example 4:
// Input: version1 = "1.0.1", version2 = "1"
// Output: 1

// Example 5:
// Input: version1 = "7.5.2.4", version2 = "7.5.3"
// Output: -1

// Constraints:
// 1 <= version1.length, version2.length <= 500
// version1 and version2 only contain digits and '.'.
// version1 and version2 are valid version numbers.
// All the given revisions in version1 and version2 can be stored in a 32-bit integer.

using System;

namespace SeptemberSecond {
    public class CompareVersionNumbers {
        public static void Main(string[] args) {
            string version1 = "1.0.1";
            string version2 = "1";
            Console.WriteLine(CompareVersion(version1, version2));
        }

        public static int CompareVersion(string version1, string version2) {
            string[] verArr1 = version1.Split('.');
            string[] verArr2 = version2.Split('.');
            int len = verArr1.Length > verArr2.Length ? verArr1.Length : verArr2.Length;
            for (int i = 0; i < len; i++) {
                var v1 = i < verArr1.Length ? Convert.ToInt32(verArr1[i]) : 0;
                var v2 = i < verArr2.Length ? Convert.ToInt32(verArr2[i]) : 0;
                if (v1 > v2) {
                    return 1;
                }
                else if (v1 < v2) {
                    return -1;
                }
            }
            return 0;
        }
    }
}

// You are playing the Bulls and Cows game with your friend.
// You write down a secret number and ask your friend to guess what the number is.
// When your friend makes a guess, you provide a hint with the following info:
// The number of "bulls", which are digits in the guess that are in the correct position.
// The number of "cows", which are digits in the guess that are in your secret number but are located in the wrong position.
// Specifically, the non-bull digits in the guess that could be rearranged such that they become bulls.
// Given the secret number secret and your friend's guess guess, return the hint for your friend's guess.
// The hint should be formatted as "xAyB", where x is the number of bulls and y is the number of cows.
// Note that both secret and guess may contain duplicate digits.

// Example 1:
// Input: secret = "1807", guess = "7810"
// Output: "1A3B"
// Explanation: Bulls are connected with a '|' and cows are underlined:
// "1807"
//   |
// "7810"

// Example 2:
// Input: secret = "1123", guess = "0111"
// Output: "1A1B"
// Explanation: Bulls are connected with a '|' and cows are underlined:
//  "1123"         "1123"
//    |      or      |
// "0111"        "0111"
// Note that only one of the two unmatched 1s is counted as a cow since the non-bull digits can only be rearranged to allow one 1 to be a bull.

// Example 3:
// Input: secret = "1", guess = "0"
// Output: "0A0B"

// Example 4:
// Input: secret = "1", guess = "1"
// Output: "1A0B"

// Constraints:
// 1 <= secret.length, guess.length <= 1000
// secret.length == guess.length
// secret and guess consist of digits only.

using System;

namespace SeptemberSecond {
    public class BullsAndCows {
        public static void Main(string[] args) {
            string secret = "1123";
            string guess = "0111";
            Console.WriteLine(GetHint(secret, guess));
        }

        public static string GetHint(string secret, string guess) {
            int bull = 0;
            int cow = 0;
            int[] charCount = new int[10];
            for (int i = 0; i < secret.Length; i++) {
                charCount[secret[i] - '0']++;
            }
            for (int i = 0; i < guess.Length; i++) {
                if (secret[i] == guess[i]) {
                    bull++;
                    charCount[guess[i] - '0']--;
                    if (charCount[guess[i] - '0'] < 0) {
                        cow--;
                    }
                }
                else if (charCount[guess[i] - '0'] > 0) {
                    cow++;
                    charCount[guess[i] - '0']--;
                }
            }
            return $"{bull}A{cow}B";
        }
    }
}

// Given an integer array nums, find the contiguous subarray within an array (containing at least one number) which has the largest product.

// Example 1:
// Input:[2,3,-2,4]
// Output: 6
// Explanation:[2,3] has the largest product 6.

// Example 2:
// Input:[-2,0,-1]
// Output: 0
// Explanation: The result cannot be 2, because[-2, -1] is not a subarray.

using System;

namespace SeptemberSecond {
    public class MaximumProductSubarray {
        public static void Main(string[] args) {
            int[] nums = new int[] { 1, -2, -3, 4, 5 };
            Console.WriteLine(MaxProduct(nums));
        }

        public static int MaxProduct(int[] nums) {
            int maxProduct = nums[0];
            int highRunningProduct = nums[0];
            int lowRunningProduct = nums[0];
            for (int i = 1; i < nums.Length; i++) {
                int tempHigh = highRunningProduct;
                highRunningProduct = Math.Max(highRunningProduct * nums[i], nums[i]);
                lowRunningProduct = Math.Min(Math.Min(tempHigh * nums[i], lowRunningProduct * nums[i]), nums[i]);
                maxProduct = Math.Max(maxProduct, highRunningProduct);
            }
            return maxProduct;
        }
    }
}

// Find all valid combinations of k numbers that sum up to n such that the following conditions are true:
// Only numbers 1 through 9 are used.
// Each number is used at most once.
// Return a list of all possible valid combinations. The list must not contain the same combination twice, and the combinations may be returned in any order.

// Example 1:
// Input: k = 3, n = 7
// Output:[[1,2,4]]
// Explanation:
// 1 + 2 + 4 = 7
// There are no other valid combinations.

// Example 2:
// Input: k = 3, n = 9
// Output:[[1,2,6],[1,3,5],[2,3,4]]
// Explanation:
// 1 + 2 + 6 = 9
// 1 + 3 + 5 = 9
// 2 + 3 + 4 = 9
// There are no other valid combinations.

// Example 3:
// Input: k = 4, n = 1
// Output:[]
// Explanation: There are no valid combinations. [1,2,1] is not valid because 1 is used twice.

// Example 4:
// Input: k = 3, n = 2
// Output:[]
// Explanation: There are no valid combinations.

// Example 5:
// Input: k = 9, n = 45
// Output:[[1,2,3,4,5,6,7,8,9]]
// Explanation:
// 1 + 2 + 3 + 4 + 5 + 6 + 7 + 8 + 9 = 45
//​​​​​​​ There are no other valid combinations.

// Constraints:
// 2 <= k <= 9
// 1 <= n <= 60

using System;
using System.Collections.Generic;

namespace SeptemberSecond {
    public class CombinationSumIII {
        public static void Main(string[] args) {
            foreach (IList<int> item in CombinationSum3(3, 9)) {
                foreach (int i in item) {
                    Console.Write(i + " ");
                }
                Console.WriteLine();
            }
        }

        public static IList<IList<int>> CombinationSum3(int k, int n) {
            IList<IList<int>> result = new List<IList<int>>();
            Helper(k, n, 1, new List<int>(), result);
            return result;
        }

        private static void Helper(int k, int n, int v, List<int> lists, IList<IList<int>> result) {
            if (n < 0) {
                return;
            }
            if (k == 0) {
                if (n == 0) {
                    result.Add(new List<int>(lists));
                }
            }
            else {
                for (int i = v; i <= 9; i++) {
                    lists.Add(i);
                    Helper(k - 1, n - i, i + 1, lists, result);
                    lists.RemoveAt(lists.Count - 1);
                }
            }
        }
    }
}

// Given a set of non-overlapping intervals, insert a new interval into the intervals(merge if necessary).
// You may assume that the intervals were initially sorted according to their start times.

// Example 1:
// Input: intervals = [[1, 3],[6,9]], newInterval = [2, 5]
// Output:[[1,5],[6,9]]

// Example 2:
// Input: intervals = [[1, 2],[3,5],[6,7],[8,10],[12,16]], newInterval = [4, 8]
// Output:[[1,2],[3,10],[12,16]]
// Explanation: Because the new interval[4, 8] overlaps with[3, 5],[6, 7],[8, 10].

// Example 3:
// Input: intervals = [], newInterval = [5, 7]
// Output:[[5,7]]

// Example 4:
// Input: intervals = [[1, 5]], newInterval = [2, 3]
// Output:[[1,5]]

// Example 5:
// Input: intervals = [[1, 5]], newInterval = [2, 7]
// Output:[[1,7]]

// Constraints:
// 0 <= intervals.length <= 10^4
// intervals[i].length == 2
// 0 <= intervals[i][0] <= intervals[i][1] <= 10^5
// intervals is sorted by intervals[i][0] in ascending order.
// newInterval.length == 2
// 0 <= newInterval[0] <= newInterval[1] <= 10^5

using System;
using System.Collections.Generic;

namespace SeptemberSecond {
    public class InsertInterval {
        public static void Main(string[] args) {
            int[][] intervals = new int[2][];
            intervals[0] = new int[] { 1, 3 };
            intervals[1] = new int[] { 6, 9 };
            int[] newInterval = new int[] { 2, 5 };
            foreach (int[] item in Insert(intervals, newInterval)) {
                foreach (int i in item) {
                    Console.Write(i + " ");
                }
                Console.WriteLine();
            }
        }

        public static int[][] Insert(int[][] intervals, int[] newInterval) {
            List<int[]> result = new List<int[]>();
            int i = 0;
            while (i < intervals.Length && intervals[i][1] < newInterval[0]) {
                result.Add(intervals[i++]);
            }
            while (i < intervals.Length && intervals[i][0] <= newInterval[1]) {
                newInterval[0] = Math.Min(newInterval[0], intervals[i][0]);
                newInterval[1] = Math.Max(newInterval[1], intervals[i][1]);
                i++;
            }
            result.Add(newInterval);
            while (i < intervals.Length) {
                result.Add(intervals[i++]);
            }
            return result.ToArray();
        }
    }
}

// You are a professional robber planning to rob houses along a street. 
// Each house has a certain amount of money stashed, the only constraint stopping you from robbing each of them is 
// that adjacent houses have security system connected and it will automatically contact the police if two adjacent houses were broken into on the same night.
// Given a list of non-negative integers representing the amount of money of each house,
// determine the maximum amount of money you can rob tonight without alerting the police.

// Example 1:
// Input: nums = [1, 2, 3, 1]
// Output: 4
// Explanation: Rob house 1(money = 1) and then rob house 3 (money = 3).
//              Total amount you can rob = 1 + 3 = 4.

// Example 2:
// Input: nums = [2, 7, 9, 3, 1]
// Output: 12
// Explanation: Rob house 1(money = 2), rob house 3 (money = 9) and rob house 5 (money = 1).
//              Total amount you can rob = 2 + 9 + 1 = 12.

// Constraints:
// 0 <= nums.length <= 100
// 0 <= nums[i] <= 400

using System;

namespace SeptemberSecond {
    public class HouseRobber {
        public static void Main(string[] args) {
            int[] nums = new int[] { 1, 2, 3, 1 };
            Console.WriteLine(Rob(nums));
        }

        public static int Rob(int[] nums) {
            if (nums.Length == 0) {
                return 0;
            }
            if (nums.Length == 1) {
                return nums[0];
            }
            if (nums.Length == 2) {
                return Math.Max(nums[0], nums[1]);
            }
            int[] dp = new int[nums.Length];
            dp[0] = nums[0];
            dp[1] = Math.Max(nums[0], nums[1]);
            for (int i = 2; i < nums.Length; i++) {
                dp[i] = Math.Max(dp[i - 1], dp[i - 2] + nums[i]);
            }
            return dp[dp.Length - 1];
        }
    }
}
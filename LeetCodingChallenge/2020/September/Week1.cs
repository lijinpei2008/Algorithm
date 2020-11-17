// Given an array arr of 4 digits, find the latest 24-hour time that can be made using each digit exactly once.
// 24-hour times are formatted as "HH:MM", where HH is between 00 and 23, and MM is between 00 and 59.
// The earliest 24-hour time is 00:00, and the latest is 23:59.
// Return the latest 24-hour time in "HH:MM" format.If no valid time can be made, return an empty string.

// Example 1:
// Input: A = [1, 2, 3, 4]
// Output: "23:41"
// Explanation: The valid 24-hour times are "12:34", "12:43", "13:24", "13:42", "14:23", "14:32", "21:34", "21:43", "23:14", and "23:41".
// Of these times, "23:41" is the latest.

// Example 2:
// Input: A = [5, 5, 5, 5]
// Output: ""
// Explanation: There are no valid 24-hour times as "55:55" is not valid.

// Example 3:
// Input: A = [0, 0, 0, 0]
// Output: "00:00"

// Example 4:
// Input: A = [0, 0, 1, 0]
// Output: "10:00"

// Constraints:
// arr.length == 4
// 0 <= arr[i] <= 9

using System;

namespace SeptemberFirst {
    public class LargestTimeForGivenDigits {
        public static void Main(string[] args) {
            int[] arr = new int[4] { 1, 2, 3, 4 };
            Console.WriteLine(LargestTimeFromDigits(arr));
        }

        public static string LargestTimeFromDigits(int[] arr) {
            int maxTime = -1;
            for (int h1 = 0; h1 < 4; h1++) {
                for (int h2 = 0; h2 < 4; h2++) {
                    if (h2 == h1) {
                        continue;
                    }
                    for (int m1 = 0; m1 < 4; m1++) {
                        if (m1 == h1 || m1 == h2) {
                            continue;
                        }
                        int m2 = 6 - h1 - h2 - m1;
                        int hours = arr[h1] * 10 + arr[h2];
                        int mins = arr[m1] * 10 + arr[m2];
                        if (hours < 24 && mins < 60) {
                            maxTime = Math.Max(maxTime, hours * 60 + mins);
                        }
                    }
                }
            }
            return maxTime >= 0 ? string.Format($"{maxTime / 60:00}:{maxTime % 60:00}") : string.Empty;
        }
    }
}

// Given an array of integers, find out whether there are two distinct indices i and j in the array such that the absolute difference
// between nums[i] and nums[j] is at most t and the absolute difference between i and j is at most k.

// Example 1:
// Input: nums = [1, 2, 3, 1], k = 3, t = 0
// Output: true

// Example 2:
// Input: nums = [1, 0, 1, 1], k = 1, t = 2
// Output: true

// Example 3:
// Input: nums = [1, 5, 9, 1, 5, 9], k = 2, t = 3
// Output: false

// Constraints:
// 0 <= nums.length <= 2 * 10^4
// -2^31 <= nums[i] <= 2^31 - 1
// 0 <= k <= 10^4
// 0 <= t <= 2^31 - 1

using System;
using System.Collections.Generic;

namespace SeptemberFirst {
    public class ContainsDuplicateIII {
        public static void Main(string[] args) {
            int[] nums = new int[] { 1, 5, 9, 1, 5, 9 };
            Console.WriteLine(ContainsNearbyAlmostDuplicate(nums, 2, 3));
        }

        public static bool ContainsNearbyAlmostDuplicate(int[] nums, int k, int t) {
            Dictionary<long, long> dict = new Dictionary<long, long>();
            for (int i = 0; i < nums.Length; i++) {
                long id = GetId(nums[i], t);
                if (dict.ContainsKey(id)
                 || dict.ContainsKey(id - 1) && nums[i] - dict[id - 1] <= t
                 || dict.ContainsKey(id + 1) && dict[id + 1] - nums[i] <= t) {
                    return true;
                }
                dict[id] = nums[i];
                if (dict.Count > k) {
                    long oldId = GetId(nums[i - k], t);
                    dict.Remove(oldId);
                }
            }
            return false;
        }

        private static long GetId(int nums, int t) {
            if (nums >= 0) {
                return (long)nums / (t + 1);
            }
            return (long)(nums + 1) / (t + 1) - 1;
        }
    }
}

// Given a non-empty string check if it can be constructed by taking a substring of it and appending multiple copies of the substring together.
// You may assume the given string consists of lowercase English letters only and its length will not exceed 10000.

// Example 1:
// Input: "abab"
// Output: True
// Explanation: It 's the substring "ab" twice.

// Example 2:
// Input: "aba"
// Output: False

// Example 3:
// Input: "abcabcabcabc"
// Output: True
// Explanation: It 's the substring "abc" four times. (And the substring "abcabc" twice.)

using System;

namespace SeptemberFirst {
    public class RepeatedSubstringPattern {
        public static void Main(string[] args) {
            Console.WriteLine(RepeatedSubstringPatternFunction("abcabcabcabc"));
        }

        public static bool RepeatedSubstringPatternFunction(string s) {
            int n = s.Length;
            int[] dp = new int[n];
            int i = 0, j = 1, count = 0;
            while (j < n) {
                if (s[j] == s[i]) {
                    count++;
                    dp[j++] = count;
                    i++;
                }
                else if (s[j] != s[i] && i > 0) {
                    count = i - 1 >= 0 ? dp[i - 1] : 0;
                    i = count;
                }
                else {
                    j++;
                }
            }
            int L = dp[n - 1];
            return L != 0 && n % (n - L) == 0;
        }
    }
}

// A string S of lowercase English letters is given. We want to partition this string into as many parts as possible
// so that each letter appears in at most one part, and return a list of integers representing the size of these parts.

// Example 1:
// Input: S = "ababcbacadefegdehijhklij"
// Output:[9,7,8]
// Explanation:
// The partition is "ababcbaca", "defegde", "hijhklij".
// This is a partition so that each letter appears in at most one part.
// A partition like "ababcbacadefegde", "hijhklij" is incorrect, because it splits S into less parts.

// Note:
// S will have length in range [1, 500].
// S will consist of lowercase English letters ('a' to 'z') only.

using System;
using System.Collections.Generic;

namespace SeptemberFirst {
    public class PartitionLabels {
        public static void Main(string[] args) {
            foreach (int i in PartitionLabelsFunction("ababcbacadefegdehijhklij")) {
                Console.Write(i + " ");
            }
        }

        public static IList<int> PartitionLabelsFunction(string S) {
            int[] indices = new int[26];
            IList<int> res = new List<int>();
            for (int i = 0; i < S.Length; i++) {
                indices[S[i] - 'a'] = i;
            }
            int start = 0, end = 0;
            for (int i = 0; i < S.Length; i++) {
                end = Math.Max(end, indices[S[i] - 'a']);
                if (i == end) {
                    res.Add(end - start + 1);
                    start = end + 1;
                }
            }
            return res;
        }
    }
}

// Given two binary search trees root1 and root2.
// Return a list containing all the integers from both trees sorted in ascending order.

// Example 1:
// Input: root1 = [2, 1, 4], root2 = [1, 0, 3]
// Output:[0,1,1,2,3,4]

// Example 2:
// Input: root1 = [0, -10, 10], root2 = [5, 1, 7, 0, 2]
// Output:[-10,0,0,1,2,5,7,10]

// Example 3:
// Input: root1 = [], root2 = [5, 1, 7, 0, 2]
// Output:[0,1,2,5,7]

// Example 4:
// Input: root1 = [0, -10, 10], root2 = []
// Output:[-10,0,10]

// Example 5:
// Input: root1 = [1, null, 8], root2 = [8, 1]
// Output:[1,1,8,8]

// Constraints:
// Each tree has at most 5000 nodes.
// Each node's value is between [-10^5, 10^5].

using System;
using System.Collections.Generic;

namespace SeptemberFirst {
    public class AllElementsInTwoBinarySearchTrees {
        public static void Main(string[] args) {
            TreeNode root1 = new TreeNode {
                val = 1,
                left = new TreeNode {
                    val = 0,
                    left = null,
                    right = null
                },
                right = new TreeNode {
                    val = 3,
                    left = null,
                    right = null
                }
            };
            TreeNode root2 = new TreeNode {
                val = 2,
                left = new TreeNode {
                    val = 1,
                    left = null,
                    right = null
                },
                right = new TreeNode {
                    val = 4,
                    left = null,
                    right = null
                }
            };
            foreach (int i in GetAllElements(root1, root2)) {
                Console.Write(i + " ");
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

        public static IList<int> GetAllElements(TreeNode root1, TreeNode root2) {
            List<int> list1 = new List<int>();
            List<int> list2 = new List<int>();
            Traverse(root1, list1);
            Traverse(root2, list2);
            return Merge(list1, list2);
        }

        private static void Traverse(TreeNode root, List<int> list) {
            if (root != null) {
                Traverse(root.left, list);
                list.Add(root.val);
                Traverse(root.right, list);
            }
        }

        private static IList<int> Merge(List<int> list1, List<int> list2) {
            IList<int> res = new List<int>();
            int i = 0, j = 0;
            while (i < list1.Count && j < list2.Count) {
                if (list1[i] < list2[j]) {
                    res.Add(list1[i]);
                    i++;
                }
                else {
                    res.Add(list2[j]);
                    j++;
                }
            }
            while (j < list2.Count) {
                res.Add(list2[j]);
                j++;
            }
            while (i < list1.Count) {
                res.Add(list1[i]);
                i++;
            }
            return res;
        }
    }
}

// You are given two images img1 and img2 both of size n x n, represented as binary, square matrices of the same size.
// (A binary matrix has only 0s and 1s as values.)
// We translate one image however we choose (sliding it left, right, up, or down any number of units), and place it on top of the other image.
// After, the overlap of this translation is the number of positions that have a 1 in both images.
// (Note also that a translation does not include any kind of rotation.)
// What is the largest possible overlap?

// Example 1:
// Input: img1 = [[1, 1, 0],[0,1,0],[0,1,0]], img2 = [[0, 0, 0],[0,1,1],[0,0,1]]
// Output: 3
// Explanation: We slide img1 to right by 1 unit and down by 1 unit.
// The number of positions that have a 1 in both images is 3. (Shown in red)

// Example 2:
// Input: img1 = [[1]], img2 = [[1]]
// Output: 1

// Example 3:
// Input: img1 = [[0]], img2 = [[0]]
// Output: 0

// Constraints:
// n == img1.length
// n == img1[i].length
// n == img2.length
// n == img2[i].length
// 1 <= n <= 30
// img1[i][j] is 0 or 1.
// img2[i][j] is 0 or 1.

using System;

namespace SeptemberFirst {
    public class ImageOverlap {
        public static void Main(string[] args) {
            int[][] img1 = new int[3][];
            img1[0] = new int[] { 1, 1, 0 };
            img1[1] = new int[] { 0, 1, 0 };
            img1[2] = new int[] { 0, 1, 1 };
            int[][] img2 = new int[3][];
            img2[0] = new int[] { 0, 0, 0 };
            img2[1] = new int[] { 0, 1, 1 };
            img2[2] = new int[] { 0, 0, 1 };
            Console.WriteLine(LargestOverlap(img1, img2));
        }

        public static int LargestOverlap(int[][] img1, int[][] img2) {
            int count = 0;
            int n = img1.Length;
            int[,] counts = new int[n * 2, n * 2];
            for (int i = 0; i < n; i++) {
                for (int j = 0; j < n; j++) {
                    if (img1[i][j] == 0) {
                        continue;
                    }
                    for (int x = 0; x < n; x++) {
                        for (int y = 0; y < n; y++) {
                            if (img2[x][y] == 0) {
                                continue;
                            }
                            count = Math.Max(count, ++counts[n + i - x, n + j - y]);
                        }
                    }
                }
            }
            return count;
        }
    }
}

// Given a pattern and a string s, find if s follows the same pattern.
// Here follow means a full match, such that there is a bijection between a letter in pattern and a non-empty word in s.

// Example 1:
// Input: pattern = "abba", s = "dog cat cat dog"
// Output: true

// Example 2:
// Input: pattern = "abba", s = "dog cat cat fish"
// Output: false

// Example 3:
// Input: pattern = "aaaa", s = "dog cat cat dog"
// Output: false

// Example 4:
// Input: pattern = "abba", s = "dog dog dog dog"
// Output: false

// Constraints:
// 1 <= pattern.length <= 300
// pattern contains only lower-case English letters.
// 1 <= s.length <= 3000
// s contains only lower-case English letters and spaces ' '.
// s does not contain any leading or trailing spaces.
// All the words in s are separated by a single space.

using System;
using System.Collections.Generic;

namespace SeptemberFirst {
    public class WordPattern {
        public static void Main(string[] args) {
            string pattern = "abba";
            string s = "dog doga doga dog";
            Console.WriteLine(WordPatternFunction(pattern, s));
        }

        public static bool WordPatternFunction(string pattern, string s) {
            Dictionary<char, string> matches = new Dictionary<char, string>();
            string[] sArr = s.Split(' ');
            if (pattern.Length != sArr.Length) {
                return false;
            }
            for (int i = 0; i < pattern.Length; i++) {
                if (matches.ContainsKey(pattern[i])) {
                    if (matches[pattern[i]] != sArr[i]) {
                        return false;
                    }
                }
                else {
                    if (matches.ContainsValue(sArr[i])) {
                        return false;
                    }
                    matches.Add(pattern[i], sArr[i]);
                }
            }
            return true;
        }
    }
}
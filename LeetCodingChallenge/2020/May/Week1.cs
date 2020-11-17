// You are a product manager and currently leading a team to develop a new product.Unfortunately,
// the latest version of your product fails the quality check.
// Since each version is developed based on the previous version, all the versions after a bad version are also bad.
// Suppose you have n versions[1, 2, ..., n] and you want to find out the first bad one, which causes all the following ones to be bad.
// You are given an API bool isBadVersion(version) which will return whether version is bad.
// Implement a function to find the first bad version.You should minimize the number of calls to the API.

// Example:
// Given n = 5, and version = 4 is the first bad version.
// call isBadVersion(3) -> false
// call isBadVersion(5) -> true
// call isBadVersion(4) -> true
// Then 4 is the first bad version.

using System;

namespace MayFirst {
    public class FirstBadVersion {
        public static void Main(string[] args) {
            Console.WriteLine(FirstBadVersions(6));
        }

        public static int FirstBadVersions(int n) {
            int first = 1;
            int mid;
            int count = n;
            int step;
            while (count > 0) {
                step = count / 2;
                mid = first + step;
                if (!IsBadVersion(mid)) {
                    first = mid + 1;
                    count -= (step + 1);
                }
                else {
                    count = step;
                }
            }
            return first;
        }
    }

    public static class VersionControl {
        public static bool IsBadVersion(int version) {
            //return version == AnyNumber;
        }
    }
}

// You're given strings J representing the types of stones that are jewels, and S representing the stones you have.
// Each character in S is a type of stone you have.  You want to know how many of the stones you have are also jewels.
// The letters in J are guaranteed distinct, and all characters in J and S are letters.
// Letters are case sensitive, so "a" is considered a different type of stone from "A".
   
// Example 1:
// Input: J = "aA", S = "aAAbbbb"
// Output: 3
   
// Example 2:
// Input: J = "z", S = "ZZ"
// Output: 0
// Note:
// S and J will consist of letters and have length at most 50.
// The characters in J are distinct.

using System;
using System.Linq;

namespace MayFirst {
    public class JewelsAndStones {
        public static void Main(string[] args) {
            Console.WriteLine(NumJewelsInStones("aA", "aAAbbbb"));
        }

        public static int NumJewelsInStones(string J, string S) {
            return S.Count(c => J.Contains(c));
        }
    }
}

// Given an arbitrary ransom note string and another string containing letters from all the magazines,
// write a function that will return true if the ransom note can be constructed from the magazines ; otherwise, it will return false.
// Each letter in the magazine string can only be used once in your ransom note.
   
// Example 1:
// Input: ransomNote = "a", magazine = "b"
// Output: false
   
// Example 2:
// Input: ransomNote = "aa", magazine = "ab"
// Output: false
   
// Example 3:
// Input: ransomNote = "aa", magazine = "aab"
// Output: true
   
// Constraints:
// You may assume that both strings contain only lowercase letters.

using System;

namespace MayFirst {
    public class RansomNote {
        public static void Main(string[] args) {
            Console.WriteLine(CanConstruct("aa", "ab"));
        }

        public static bool CanConstruct(string ransomNote, string magazine) {
            var charAndCount = new int[256];
            foreach (var c in magazine) {
                charAndCount[c]++;
            }
            foreach (var c in ransomNote) {
                charAndCount[c]--;
                if (charAndCount[c] < 0) {
                    return false;
                }
            }
            return true;
        }
    }
}

// Given a positive integer num, output its complement number.The complement strategy is to flip the bits of its binary representation.
   
// Example 1:
// Input: num = 5
// Output: 2
// Explanation: The binary representation of 5 is 101 (no leading zero bits), and its complement is 010. So you need to output 2.
   
// Example 2:
// Input: num = 1
// Output: 0
// Explanation: The binary representation of 1 is 1 (no leading zero bits), and its complement is 0. So you need to output 0.
   
// Constraints:
// The given integer num is guaranteed to fit within the range of a 32-bit signed integer.
// num >= 1
// You could assume no leading zero bit in the integer’s binary representation.
// This question is the same as 1009: https://leetcode.com/problems/complement-of-base-10-integer/

using System;

namespace MayFirst {
    public class NumberComplement {
        public static void Main(string[] args) {
            Console.WriteLine(FindComplement(5));
        }

        public static int FindComplement(int num) {
            int digits = ((int)Math.Floor(Math.Log(num, 2))) + 1;
            int mask = (1 << digits) - 1;
            return (mask ^ num);
        }
    }
}

// Given a string, find the first non-repeating character in it and return its index.If it doesn't exist, return -1.
   
// Examples:
// s = "leetcode"
// return 0.
// s = "loveleetcode"
// return 2.

// Note: You may assume the string contains only lowercase English letters.

using System;

namespace MayFirst {
    public class FirstUniqueCharacterInAString {
        public static void Main(string[] args) {
            Console.WriteLine(FirstUniqChar("loveleetcode"));
        }

        public static int FirstUniqChar(string s) {
            if (string.IsNullOrWhiteSpace(s)) {
                return -1;
            }
            int[] counter = new int[26];
            for (int i = s.Length - 1; i >= 0; i--) {
                counter[s[i] - 'a']++;
            }
            for (int i = 0; i < s.Length; i++) {
                if (counter[s[i] - 'a'] == 1) {
                    return i;
                }
            }
            return -1;
        }
    }
}

// Given an array of size n, find the majority element.The majority element is the element that appears more than ⌊ n/2 ⌋ times.
// You may assume that the array is non-empty and the majority element always exist in the array.
   
// Example 1:
// Input: [3,2,3]
// Output: 3

// Example 2:
// Input: [2,2,1,1,1,2,2]
// Output: 2

using System;

namespace MayFirst {
    public class MajorityElement {
        public static void Main(string[] args) {
            int[] nums = new int[] { 3, 2, 3 };
            Console.WriteLine(MajorityElements(nums));
        }

        public static int MajorityElements(int[] nums) {
            int majority = 0; // value of majority element
            int occurence = 0; // occurence of majority element
            for (int i = 0; i < nums.Length; i++) {
                if (occurence == 0) {
                    majority = nums[i];
                    occurence = 1;
                }
                else if (nums[i] != majority) {
                    occurence--;
                }
                else {
                    occurence++;
                }
            }
            return majority;
        }
    }
}

// In a binary tree, the root node is at depth 0, and children of each depth k node are at depth k+1.
// Two nodes of a binary tree are cousins if they have the same depth, but have different parents.
// We are given the root of a binary tree with unique values, and the values x and y of two different nodes in the tree.
// Return true if and only if the nodes corresponding to the values x and y are cousins.

// Example 1:
//     1
//    / \
//   2   3
//  /
// 4
// Input: root = [1, 2, 3, 4], x = 4, y = 3
// Output: false

// Example 2:
//     1
//    / \
//   2   3
//    \   \
//     4   5
// Input: root = [1, 2, 3, null, 4, null, 5], x = 5, y = 4
// Output: true

// Example 3:
//     1
//    / \
//   2   3
//    \
//     4
// Input: root = [1, 2, 3, null, 4], x = 2, y = 3
// Output: false

// Constraints:
// The number of nodes in the tree will be between 2 and 100.
// Each node has a unique integer value from 1 to 100.

using System;

namespace MayFirst {
    public class CousinsInBinaryTree {
        public static void Main(string[] args) {
            TreeNode node = new TreeNode {
                val = 1,
                left = new TreeNode {
                    val = 2,
                    left = new TreeNode {
                        val = 4,
                        left = null,
                        right = null
                    },
                    right = null
                },
                right = new TreeNode {
                    val = 3,
                    left = null,
                    right = null
                }
            };
            Console.WriteLine(IsCousins(node, 4, 3));
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

        public static int[] levels = new int[101];
        public static int[] parents = new int[101];

        public static bool IsCousins(TreeNode root, int x, int y) {
            Prepare(root, null, 0);
            return levels[x] == levels[y] && parents[x] != parents[y];
        }

        private static void Prepare(TreeNode node, TreeNode parent, int level) {
            if (node == null) return;
            levels[node.val] = level;
            if (parent != null) {
                parents[node.val] = parent.val;
            }
            Prepare(node.left, node, level + 1);
            Prepare(node.right, node, level + 1);
        }
    }
}
// You are given an array coordinates, coordinates[i] = [x, y],
// where[x, y] represents the coordinate of a point.
// Check if these points make a straight line in the XY plane.

// Example 1:
// Input: coordinates = [[1,2], [2,3], [3,4], [4,5], [5,6], [6,7]]
// Output: true

// Example 2:
// Input: coordinates = [[1,1],[2,2],[3,4],[4,5],[5,6],[7,7]]
// Output: false

// Constraints:
// 2 <= coordinates.length <= 1000
// coordinates[i].length == 2
// -10^4 <= coordinates[i][0], coordinates[i][1] <= 10^4
// coordinates contains no duplicate point.

using System;

namespace MaySecond {
    public class CheckIfItIsAStraightLine {
        public static void Main(string[] args) {
            int[][] coordinates = new int[6][];
            coordinates[0] = new int[2] { 1, 2 };
            coordinates[1] = new int[2] { 2, 3 };
            coordinates[2] = new int[2] { 3, 4 };
            coordinates[3] = new int[2] { 4, 5 };
            coordinates[4] = new int[2] { 5, 6 };
            coordinates[5] = new int[2] { 6, 7 };
            Console.WriteLine(CheckStraightLine(coordinates));
        }

        public static bool CheckStraightLine(int[][] coordinates) {
            if (coordinates == null || coordinates.Length == 1) {
                return true;
            }
            int x1 = coordinates[0][0];
            int y1 = coordinates[0][1];
            int x2, y2, x3, y3;
            for (int i = 1; i < coordinates.Length - 1; i++) {
                x2 = coordinates[i][0];
                y2 = coordinates[i][1];
                x3 = coordinates[i + 1][0];
                y3 = coordinates[i + 1][1];
                int a = (y2 - y1) * (x3 - x2);
                int b = (y3 - y2) * (x2 - x1);
                if (a != b) {
                    return false;
                }
                x2 = x1;
                y2 = y1;
                x1 = x2;
                y1 = y2;
            }
            return true;
        }
    }
}

// Given a positive integer num, write a function which returns True if num is a perfect square else False.
// Follow up: Do not use any built-in library function such as sqrt.
   
// Example 1:
// Input: num = 16
// Output: true
   
// Example 2:
// Input: num = 14
// Output: false
   
// Constraints:
// 1 <= num <= 2^31 - 1

using System;

namespace MaySecond {
    public class ValidPerfectSquare {
        public static void Main(string[] args) {
            int num = 16;
            Console.WriteLine(IsPerfectSquare(num));
            Console.WriteLine(IsPerfectSquare2(num));
        }

        public static bool IsPerfectSquare(int num) {
            long r = num;
            while (r * r > num) {
                r = (r + num / r) / 2;
            }
            return r * r == num;
        }

        public static bool IsPerfectSquare2(int num) {
            double rr = Math.Sqrt(num);
            return rr - Math.Floor(rr) == 0;
        }
    }
}

// In a town, there are N people labelled from 1 to N.There is a rumor that one of these people is secretly the town judge.
// If the town judge exists, then:
// The town judge trusts nobody.
// Everybody (except for the town judge) trusts the town judge.
// There is exactly one person that satisfies properties 1 and 2.
// You are given trust, an array of pairs trust[i] = [a, b] representing that the person labelled a trusts the person labelled b.
// If the town judge exists and can be identified, return the label of the town judge.  Otherwise, return -1.

// Example 1:
// Input: N = 2, trust = [[1, 2]]
// Output: 2

// Example 2:
// Input: N = 3, trust = [[1,3],[2,3]]
// Output: 3

// Example 3:
// Input: N = 3, trust = [[1,3],[2,3],[3,1]]
// Output: -1

// Example 4:
// Input: N = 3, trust = [[1,2],[2,3]]
// Output: -1

// Example 5:
// Input: N = 4, trust = [[1,3],[1,4],[2,3],[2,4],[4,3]]
// Output: 3

// Constraints:
// 1 <= N <= 1000
// 0 <= trust.length <= 10^4
// trust[i].length == 2
// trust[i] are all different
// trust[i][0] != trust[i][1]
// 1 <= trust[i][0], trust[i][1] <= N

using System;
using System.Collections.Generic;
using System.Linq;

namespace MaySecond {
    public class FindTheTownJudge {
        public static void Main(string[] args) {
            int N = 4;
            int[][] trust = new int[5][];
            trust[0] = new int[2] { 1, 3 };
            trust[1] = new int[2] { 1, 4 };
            trust[2] = new int[2] { 2, 3 };
            trust[3] = new int[2] { 2, 4 };
            trust[4] = new int[2] { 4, 3 };
            Console.WriteLine(FindJudge(N, trust));
            Console.WriteLine(FindJudge2(N, trust));
        }

        public static int FindJudge(int N, int[][] trust) {
            if (N == 1 && trust.Length == 0) {
                return 1;
            }
            Dictionary<int, int> dict = new Dictionary<int, int>();
            for (int i = 0; i < trust.Length; i++) {
                dict[trust[i][1]] = dict.ContainsKey(trust[i][1]) ? dict[trust[i][1]] + 1 : 1;
            }
            if (dict.Count(x => x.Value == N - 1) != 1) {
                return -1;
            }
            int judge = dict.First(x => x.Value == N - 1).Key;
            for (int i = 0; i < trust.Length; i++) {
                if (trust[i][0] == judge) {
                    return -1;
                }
            }
            return judge;
        }

        public static int FindJudge2(int N, int[][] trust) {
            int[] people = new int[N + 1];
            foreach (int[] item in trust) {
                people[item[0]]--;
                people[item[1]]++;
            }
            return Array.IndexOf(people, N - 1, 1);
        }
    }
}

// An image is represented by a 2-D array of integers, each integer representing the pixel value of the image(from 0 to 65535).
// Given a coordinate(sr, sc) representing the starting pixel(row and column) of the flood fill, and a pixel value newColor, "flood fill" the image.
// To perform a "flood fill", consider the starting pixel, plus any pixels connected 4-directionally to the starting pixel of the same color as the starting pixel,
// plus any pixels connected 4-directionally to those pixels (also with the same color as the starting pixel), and so on.
// Replace the color of all of the aforementioned pixels with the newColor.
// At the end, return the modified image.

// Example 1:
// Input: 
// image = [[1, 1, 1], [1,1,0], [1,0,1]]
// sr = 1, sc = 1, newColor = 2
// Output: [[2,2,2],[2,2,0],[2,0,1]]
// Explanation: 
// From the center of the image(with position (sr, sc) = (1, 1)), all pixels connected
// by a path of the same color as the starting pixel are colored with the new color.
// Note the bottom corner is not colored 2, because it is not 4-directionally connected
// to the starting pixel.

// Note:
// The length of image and image[0] will be in the range [1, 50].
// The given starting pixel will satisfy 0 <= sr<image.length and 0 <= sc<image[0].length.
// The value of each color in image[i][j] and newColor will be an integer in [0, 65535].

using System;

namespace MaySecond {
    public class FloodFill {
        public static void Main(string[] args) {
            int[][] image = new int[3][];
            image[0] = new int[] { 1, 1, 1 };
            image[1] = new int[] { 1, 1, 0 };
            image[2] = new int[] { 1, 0, 1 };
            int sr = 1, sc = 1, newColor = 2;
            int[][] val = FloodFills(image, sr, sc, newColor);
            foreach (int[] item in val) {
                foreach (int t in item) {
                    Console.Write(t + " ");
                }
                Console.WriteLine();
            }
        }

        public static int[][] FloodFills(int[][] image, int sr, int sc, int newColor) {
            int color = image[sr][sc];
            if (color != newColor) {
                FloodFunction(image, sr, sc, color, newColor);
            }
            return image;
        }

        private static void FloodFunction(int[][] image, int r, int c, int color, int newColor) {
            if (image[r][c] == color) {
                image[r][c] = newColor;
                if (r >= 1) {
                    FloodFunction(image, r - 1, c, color, newColor);
                }
                if (c >= 1) {
                    FloodFunction(image, r, c - 1, color, newColor);
                }
                if (r + 1 < image.Length) {
                    FloodFunction(image, r + 1, c, color, newColor);
                }
                if (c + 1 < image[0].Length) {
                    FloodFunction(image, r, c + 1, color, newColor);
                }
            }
        }
    }
}

// You are given a sorted array consisting of only integers where every element appears exactly twice,
// except for one element which appears exactly once.Find this single element that appears only once.
// Follow up: Your solution should run in O(log n) time and O(1) space.

// Example 1:
// Input: nums = [1,1,2,3,3,4,4,8,8]
// Output: 2

// Example 2:
// Input: nums = [3,3,7,7,10,11,11]
// Output: 10

// Constraints:
// 1 <= nums.length <= 10^5
// 0 <= nums[i] <= 10^5

using System;
using System.Linq;

namespace MaySecond {
    public class SingleElementInASortedArray {
        public static void Main(string[] args) {
            int[] nums = new int[] { 3, 3, 7, 7, 10, 11, 11 };
            Console.WriteLine(SingleNonDuplicate(nums));
            Console.WriteLine(SingleNonDuplicate2(nums));
        }

        public static int SingleNonDuplicate(int[] nums) {
            return nums.Aggregate((x, y) => x ^ y);
        }

        public static int SingleNonDuplicate2(int[] nums) {
            for (int i = 0; i < nums.Length; i += 2) {
                try {
                    if ((nums[i] ^ nums[i + 1]) != 0) {
                        return nums[i];
                    }
                }
                catch {
                    return nums[nums.Length - 1];
                }
            }
            return -1;
        }
    }
}

// Given a non-negative integer num represented as a string, remove k digits from the number so that the new number is the smallest possible.
   
// Note:
// The length of num is less than 10002 and will be ≥ k.
// The given num does not contain any leading zero.
   
// Example 1:
// Input: num = "1432219", k = 3
// Output: "1219"
// Explanation: Remove the three digits 4, 3, and 2 to form the new number 1219 which is the smallest.
   
// Example 2:
// Input: num = "10200", k = 1
// Output: "200"
// Explanation: Remove the leading 1 and the number is 200. Note that the output must not contain leading zeroes.
   
// Example 3:
// Input: num = "10", k = 2
// Output: "0"
// Explanation: Remove all the digits from the number and it is left with nothing which is 0.

using System;

namespace MaySecond {
    public class RemoveKDigits {
        public static void Main(string[] args) {
            string num = "10";
            int k = 2;
            Console.WriteLine(RemoveKdigits(num, k));
        }

        public static string RemoveKdigits(string num, int k) {
            int len = num.Length - k;
            char[] s = new char[num.Length];
            int index = 0;
            for (int i = 0; i < num.Length; i++) {
                while (index > 0 && k > 0 && s[index - 1] > num[i]) {
                    index--;
                    k--;
                }
                s[index++] = num[i];
            }
            int ii = 0;
            while (ii < len && s[ii] == '0') {
                ii++;
            }
            if (ii == len) {
                return "0";
            }
            return new String(s, ii, len - ii);
        }
    }
}

// Implement a trie with insert, search, and startsWith methods.
   
// Example:
// Trie trie = new Trie();
// trie.insert("apple");
// trie.search("apple");   // returns true
// trie.search("app");     // returns false
// trie.startsWith("app"); // returns true
// trie.insert("app");   
// trie.search("app");     // returns true
   
// Note:
// You may assume that all inputs are consist of lowercase letters a-z.
// All inputs are guaranteed to be non-empty strings.

using System;

namespace MaySecond {
    public class ImplementTrie {
        public static void Main(string[] args) {
            Trie obj = new Trie();
            obj.Insert("apple");
            Console.WriteLine(obj.Search("apple"));   // returns true
            Console.WriteLine(obj.Search("app"));     // returns false
            Console.WriteLine(obj.StartsWith("app")); // returns true
            obj.Insert("app");
            Console.WriteLine(obj.Search("app"));     // returns true
        }
    }

    public class Trie {
        /** Initialize your data structure here. */
        private TrieNode root;

        public Trie() {
            root = new TrieNode();
        }

        // Inserts a word into the trie.
        public void Insert(string word) {
            TrieNode node = root;
            for (int i = 0; i < word.Length; i++) {
                char currentChar = word[i];
                if (!node.ContainsKey(currentChar)) {
                    node.Put(currentChar, new TrieNode());
                }
                node = node.Get(currentChar);
            }
            node.SetEnd();
        }

        // search a prefix or whole key in trie and
        // returns the node where search ends
        private TrieNode SearchPrefix(string word) {
            TrieNode node = root;
            for (int i = 0; i < word.Length; i++) {
                char curLetter = word[i];
                if (node.ContainsKey(curLetter)) {
                    node = node.Get(curLetter);
                }
                else {
                    return null;
                }
            }
            return node;
        }

        // Returns if the word is in the trie.
        public bool Search(string word) {
            TrieNode node = SearchPrefix(word);
            return node != null && node.IsEnd();
        }

        // Returns if there is any word in the trie
        // that starts with the given prefix.
        public bool StartsWith(string prefix) {
            TrieNode node = SearchPrefix(prefix);
            return node != null;
        }
    }

    public class TrieNode {
        // R links to node children
        private TrieNode[] links;
        private const int R = 26;
        private bool isEnd;
        
        public TrieNode() {
            links = new TrieNode[R];
        }

        public bool ContainsKey(char ch) {
            return links[ch - 'a'] != null;
        }
        
        public TrieNode Get(char ch) {
            return links[ch - 'a'];
        }
        
        public void Put(char ch, TrieNode node) {
            links[ch - 'a'] = node;
        }
        
        public void SetEnd() {
            isEnd = true;
        }
        
        public bool IsEnd() {
            return isEnd;
        }
    }
}
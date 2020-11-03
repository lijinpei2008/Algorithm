// Given a word, you need to judge whether the usage of capitals in it is right or not.
// We define the usage of capitals in a word to be right when one of the following cases holds:
// All letters in this word are capitals, like "USA".
// All letters in this word are not capitals, like "leetcode".
// Only the first letter in this word is capital, like "Google".
// Otherwise, we define that this word doesn't use capitals in a right way.

// Example 1:
// Input: "USA"
// Output: True

// Example 2:
// Input: "FlaG"
// Output: False

// Note: The input will be a non-empty word consisting of uppercase and lowercase latin letters.

using System;

namespace AugFirst {
    public class WordBreakII {
        public static void Main(string[] args) {
            string word = "USA";
            Console.WriteLine(DetectCapitalUse(word));
        }

        public static bool DetectCapitalUse(string word) {
            if (word.Length == 1) {
                return true;
            }
            bool firstCapital = char.IsUpper(word[0]);
            bool secondCapital = char.IsUpper(word[1]);
            if (!firstCapital && secondCapital) {
                return false;
            }
            for (int i = 2; i < word.Length; i++) {
                if (firstCapital && secondCapital) {
                    if (!char.IsUpper(word[i])) {
                        return false;
                    }
                }
                else {
                    if (char.IsUpper(word[i])) {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}

// Design a HashSet without using any built-in hash table libraries.
// To be specific, your design should include these functions:
// add(value): Insert a value into the HashSet. 
// contains(value) : Return whether the value exists in the HashSet or not.
// remove(value): Remove a value in the HashSet. If the value does not exist in the HashSet, do nothing.
   
// Example:
// MyHashSet hashSet = new MyHashSet();
// hashSet.add(1);
// hashSet.add(2);
// hashSet.contains(1);    // returns true
// hashSet.contains(3);    // returns false (not found)
// hashSet.add(2);
// hashSet.contains(2);    // returns true
// hashSet.remove(2);
// hashSet.contains(2);    // returns false (already removed)
   
// Note:
// All values will be in the range of [0, 1000000].
// The number of operations will be in the range of [1, 10000].
// Please do not use the built -in HashSet library.

using System;
using System.Collections.Generic;

namespace AugFirst {
    public class DesignHashSet {
        public static void Main(string[] args) {
            MyHashSet hashSet = new MyHashSet();
            hashSet.Add(1);
            hashSet.Add(2);
            Console.WriteLine(hashSet.Contains(1));    // returns true
            Console.WriteLine(hashSet.Contains(3));    // returns false (not found)
            hashSet.Add(2);
            Console.WriteLine(hashSet.Contains(2));    // returns true
            hashSet.Remove(2);
            Console.WriteLine(hashSet.Contains(2));    // returns false (already removed)
        }
    }

    public class MyHashSet {
        private List<int>[] buckets;
        private const int bucketSize = 769;

        public MyHashSet() {
            buckets = new List<int>[bucketSize];
            for (int i = 0; i < bucketSize; i++) {
                buckets[i] = new List<int>();
            }
        }

        public void Add(int key) {
            int hashCode = GetHashCode(key);
            if (!buckets[hashCode].Contains(key)) {
                buckets[hashCode].Add(key);
            }
        }

        public void Remove(int key) {
            int hashCode = GetHashCode(key);
            buckets[hashCode].Remove(key);
        }

        public bool Contains(int key) {
            int hashCode = GetHashCode(key);
            return buckets[hashCode].Contains(key);
        }

        private int GetHashCode(int key) {
            return key % bucketSize;
        }
    }
}

// Given a string, determine if it is a palindrome, considering only alphanumeric characters and ignoring cases.
// Note: For the purpose of this problem, we define empty string as valid palindrome.

// Example 1:
// Input: "A man, a plan, a canal: Panama"
// Output: true

// Example 2:
// Input: "race a car"
// Output: false

// Constraints:
// s consists only of printable ASCII characters.

using System;

namespace AugFirst {
    public class ValidPalindrome {
        public static void Main(string[] args) {
            string s = " A man, a Plan, a canal: Panama";
            Console.WriteLine(IsPalindrome(s));
        }

        public static bool IsPalindrome(string s) {
            int left = 0;
            int right = s.Length - 1;
            while (left < right) {
                if (!char.IsLetterOrDigit(s[left])) {
                    left++;
                }
                else if (!char.IsLetterOrDigit(s[right])) {
                    right--;
                }
                else {
                    if (char.ToLower(s[left]) != char.ToLower(s[right])) {
                        return false;
                    }
                    left++;
                    right--;
                }
            }
            return true;
        }
    }
}

// Given an integer (signed 32 bits), write a function to check whether it is a power of 4.

// Example 1:
// Input: 16
// Output: true

// Example 2:
// Input: 5
// Output: false
// Follow up: Could you solve it without loops/recursion?

using System;

namespace AugFirst {
    public class PowerOfFour {
        public static void Main(string[] args) {
            Console.WriteLine(IsPowerOfFour(5));
        }

        public static bool IsPowerOfFour(int num) {
            if (num < 1) {
                return false;
            }
            while (num > 1) {
                if (num % 4 != 0) {
                    return false;
                }
                num /= 4;
            }
            return true;
        }
    }
}

// Design a data structure that supports adding new words and finding if a string matches any previously added string.
// Implement the WordDictionary class:
// WordDictionary() Initializes the object.
// void addWord(word) Adds word to the data structure, it can be matched later.
// bool search(word) Returns true if there is any string in the data structure that matches word or false otherwise.
// word may contain dots '.' where dots can be matched with any letter.

// Example:
// Input
// ["WordDictionary", "addWord", "addWord", "addWord", "search", "search", "search", "search"]
// [[],["bad"],["dad"],["mad"],["pad"],["bad"],[".ad"],["b.."]]
// Output
// [null, null, null, null, false, true, true, true]

// Explanation
// WordDictionary wordDictionary = new WordDictionary();
// wordDictionary.addWord("bad");
// wordDictionary.addWord("dad");
// wordDictionary.addWord("mad");
// wordDictionary.search("pad"); // return False
// wordDictionary.search("bad"); // return True
// wordDictionary.search(".ad"); // return True
// wordDictionary.search("b.."); // return True

// Constraints:
// 1 <= word.length <= 500
// word in addWord consists lower-case English letters.
// word in search consist of  '.' or lower-case English letters.
// At most 50000 calls will be made to addWord and search.

namespace AugFirst {
    using System;

    public class AddAndSearchWordDataStructureDesign {
        public static void Main(string[] args) {
            WordDictionary wordDictionary = new WordDictionary();
            wordDictionary.AddWord("bad");
            wordDictionary.AddWord("dad");
            wordDictionary.AddWord("mad");
            Console.WriteLine(wordDictionary.Search("pad")); // return False
            Console.WriteLine(wordDictionary.Search("bad")); // return True
            Console.WriteLine(wordDictionary.Search(".ad")); // return True
            Console.WriteLine(wordDictionary.Search("b..")); // return True
        }
    }

    public class WordDictionary {
        TrieNode root;
        bool canFind;

        public WordDictionary() {
            root = new TrieNode();
            canFind = false;
        }

        public void AddWord(string word) {
            int n = word.Length;
            TrieNode curNode = root;
            for (int i = 0; i < n; i++) {
                int index = word[i] - 'a';
                if (curNode.nodes[index] == null) {
                    curNode.nodes[index] = new TrieNode();
                }
                curNode = curNode.nodes[index];
                if (i == n - 1) {
                    curNode.isWord = true;
                }
            }
        }

        public bool Search(string word) {
            canFind = false;
            WordFunction(root, word, 0);
            return canFind;
        }

        private void WordFunction(TrieNode root, string word, int i) {
            if (canFind) {
                return;
            }
            if (root == null) {
                return;
            }
            int n = word.Length;
            if (n == i) {
                if (root.isWord) {
                    canFind = true;
                }
                return;
            }
            if (word[i] == '.') {
                for (int j = 'a'; j <= 'z'; j++) {
                    WordFunction(root.nodes[j - 'a'], word, i + 1);
                }
            }
            else {
                int index = word[i] - 'a';
                WordFunction(root.nodes[index], word, i + 1);
            }
        }
    }

    public class TrieNode {
        public TrieNode[] nodes;
        public bool isWord;
        public TrieNode() {
            nodes = new TrieNode[26];
            isWord = false;
        }
    }
}

namespace AugFirst {
    using System;
    using System.Collections.Generic;

    public class AddAndSearchWordDataStructureDesign {
        public static void Main(string[] args) {
            WordDictionary wordDictionary = new WordDictionary();
            wordDictionary.AddWord("bad");
            wordDictionary.AddWord("dad");
            wordDictionary.AddWord("mad");
            Console.WriteLine(wordDictionary.Search("pad")); // return False
            Console.WriteLine(wordDictionary.Search("bad")); // return True
            Console.WriteLine(wordDictionary.Search(".ad")); // return True
            Console.WriteLine(wordDictionary.Search("b..")); // return True
        }
    }

    public class WordDictionary {
        private Dictionary<int, List<string>> Dict = new Dictionary<int, List<string>>();

        public WordDictionary() {
        }

        public void AddWord(string word) {
            if (string.IsNullOrEmpty(word)) {
                return;
            }
            int len = word.Length;
            if (!Dict.ContainsKey(len)) {
                Dict.Add(len, new List<string>());
            }
            Dict[len].Add(word);
        }

        public bool Search(string word) {
            bool found = false;
            int len = word.Length;
            if (Dict.ContainsKey(len)) {
                List<string> words = Dict[len];
                foreach (string addedWord in words) {
                    int i = 0;
                    while ((i < len && (word[i] == addedWord[i] || word[i] == '.'))) {
                        i++;
                    }
                    if (i == len) {
                        return true;
                    }
                }
            }
            return found;
        }
    }
}

// Given an array of integers, 1 ≤ a[i] ≤ n(n = size of array), some elements appear twice and others appear once.
// Find all the elements that appear twice in this array.
// Could you do it without extra space and in O(n) runtime?
   
// Example:
// Input:
// [4,3,2,7,8,2,3,1]
// Output:
// [2,3]

using System;
using System.Collections.Generic;

namespace AugFirst {
    public class FindAllDuplicatesInAnArray {
        public static void Main(string[] args) {
            int[] nums = new int[] { 4, 3, 2, 7, 8, 2, 3, 1 };
            foreach (int item in FindDuplicates(nums)) {
                Console.Write(item + " ");
            }
        }

        public static IList<int> FindDuplicates(int[] nums) {
            IList<int> result = new List<int>();
            for (int i = 0; i < nums.Length; i++) {
                if (nums[Math.Abs(nums[i]) - 1] < 0) {
                    result.Add(Math.Abs(nums[i]));
                }
                else {
                    nums[Math.Abs(nums[i]) - 1] = -1 * nums[Math.Abs(nums[i]) - 1];
                }
            }
            return result;
        }
    }
}

// Given a binary tree, return the vertical order traversal of its nodes values.
// For each node at position (X, Y), its left and right children respectively will be at positions (X-1, Y-1) and(X + 1, Y - 1).
// Running a vertical line from X = -infinity to X = +infinity, whenever the vertical line touches some nodes,
// we report the values of the nodes in order from top to bottom (decreasing Y coordinates).
// If two nodes have the same position, then the value of the node that is reported first is the value that is smaller.
// Return an list of non-empty reports in order of X coordinate.  Every report will have a list of values of nodes.

// Example 1:
// Input:[3,9,20,null,null,15,7]
// Output:[[9],[3,15],[20],[7]]
// Explanation:
// Without loss of generality, we can assume the root node is at position (0, 0):
// Then, the node with value 9 occurs at position (-1, -1);
// The nodes with values 3 and 15 occur at positions (0, 0) and(0, -2);
// The node with value 20 occurs at position (1, -1);
// The node with value 7 occurs at position (2, -2).

// Example 2:
// Input:[1,2,3,4,5,6,7]
// Output:[[4],[2],[1,5,6],[3],[7]]
// Explanation:
// The node with value 5 and the node with value 6 have the same position according to the given scheme.
// However, in the report "[1,5,6]", the node value of 5 comes first since 5 is smaller than 6.

// Note:
// The tree will have between 1 and 1000 nodes.
// Each node's value will be between 0 and 1000.

using System;
using System.Collections.Generic;
using System.Linq;

namespace AugFirst {
    public class VerticalOrderTraversalOfABinaryTree {
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
                    right = new TreeNode {
                        val = 5,
                        left = null,
                        right = null
                    }
                },
                right = new TreeNode {
                    val = 3,
                    left = new TreeNode {
                        val = 6,
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
            foreach (IList<int> item in VerticalTraversal(node)) {
                foreach (int i in item) {
                    Console.Write(i + " ");
                }
                Console.WriteLine();
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

        public static IList<IList<int>> VerticalTraversal(TreeNode root) {
            SortedDictionary<int, IList<int[]>> sd = new SortedDictionary<int, IList<int[]>>();
            Traverse(sd, root, 0, 0);
            IList<IList<int>> res = new List<IList<int>>();
            foreach (var item in sd.Values) {
                res.Add(item.OrderBy(x => x[1]).ThenBy(x => x[0]).Select(x => x[0]).ToList());
            }
            return res;
        }

        private static void Traverse(SortedDictionary<int, IList<int[]>> sd, TreeNode root, int x, int y) {
            if (root == null) {
                return;
            }
            if (!sd.ContainsKey(x)) {
                sd[x] = new List<int[]>();
            }
            sd[x].Add(new[] { root.val, y });
            Traverse(sd, root.left, x - 1, y + 1);
            Traverse(sd, root.right, x + 1, y + 1);
        }
    }
}
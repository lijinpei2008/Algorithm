// Given a string s consists of some words separated by spaces, return the length of the last word in the string. If the last word does not exist, return 0.
// A word is a maximal substring consisting of non-space characters only.

// Example 1:
// Input: s = "Hello World"
// Output: 5

// Example 2:
// Input: s = " "
// Output: 0

// Constraints:
// 1 <= s.length <= 10^4
// s consists of only English letters and spaces ' '.

using System;

namespace SeptemberThird {
    public class LengthOfLastWord {
        public static void Main(string[] args) {
            Console.WriteLine(LengthofLastWord("b   a    "));
        }

        public static int LengthofLastWord(string s) {
            s = s.Trim();
            if (s.Length == 0) {
                return 0;
            }
            int k = s.LastIndexOf(' ');
            if (k < 0) {
                return s.Length;
            }
            return s.Length - k - 1;
        }
    }
}

// Given an integer array nums, return the maximum result of nums[i] XOR nums[j], where 0 ≤ i ≤ j < n.
// Follow up: Could you do this in O(n) runtime?

// Example 1:
// Input: nums = [3, 10, 5, 25, 2, 8]
// Output: 28
// Explanation: The maximum result is 5 XOR 25 = 28.

// Example 2:
// Input: nums = [0]
// Output: 0

// Example 3:
// Input: nums = [2, 4]
// Output: 6

// Example 4:
// Input: nums = [8, 10, 2]
// Output: 10

// Example 5:
// Input: nums = [14, 70, 53, 83, 49, 91, 36, 80, 92, 51, 66, 70]
// Output: 127

// Constraints:
// 1 <= nums.length <= 2 * 10^4
// 0 <= nums[i] <= 2^31 - 1

using System;
using System.Collections.Generic;

namespace SeptemberThird {
    public class MaximumXOROfTwoNumbersInAnArray {
        public static void Main(string[] args) {
            int[] nums = new int[] { 3, 10, 5, 25, 2, 8 };
            Console.WriteLine(FindMaximumXOR(nums));
        }

        public static int FindMaximumXOR(int[] nums) {
            int res = 0;
            for (int i = 31; i >= 0; i--) {
                res <<= 1;
                int next = res | 1;
                HashSet<int> prefix = new HashSet<int>();
                for (int j = 0; j < nums.Length; j++) {
                    if (prefix.Contains((nums[j] >> i) ^ next)) {
                        res = next;
                        break;
                    }
                    prefix.Add(nums[j] >> i);
                }
            }
            return res;
        }
    }
}

// On an infinite plane, a robot initially stands at (0, 0) and faces north.  The robot can receive one of three instructions:
// "G": go straight 1 unit;
// "L": turn 90 degrees to the left;
// "R": turn 90 degress to the right.
// The robot performs the instructions given in order, and repeats them forever.
// Return true if and only if there exists a circle in the plane such that the robot never leaves the circle.

// Example 1:
// Input: "GGLLGG"
// Output: true
// Explanation:
// The robot moves from(0,0) to(0, 2), turns 180 degrees, and then returns to (0,0).
// When repeating these instructions, the robot remains in the circle of radius 2 centered at the origin.

// Example 2:
// Input: "GG"
// Output: false
// Explanation:
// The robot moves north indefinitely.

// Example 3:
// Input: "GL"
// Output: true
// Explanation:
// The robot moves from(0, 0) -> (0, 1)-> (-1, 1)-> (-1, 0)-> (0, 0)-> ...

// Note:
// 1 <= instructions.length <= 100
// instructions[i] is in { 'G', 'L', 'R'}

using System;

namespace SeptemberThird {
    public class RobotBoundedInCircle {
        public static void Main(string[] args) {
            Console.WriteLine(IsRobotBounded("GGLLGG"));
        }

        public static bool IsRobotBounded(string instructions) {
            int direction = 0;
            int x = 0;
            int y = 0;
            int length = instructions.Length;
            for (int i = 0; i < length; i++) {
                if (instructions[i] == 'G') {
                    if (direction == 0) {
                        y++;
                    }
                    else if (direction == 1) {
                        x++;
                    }
                    else if (direction == 2) {
                        y--;
                    }
                    else if (direction == 3) {
                        x--;
                    }
                }
                else if (instructions[i] == 'L') {
                    direction = (direction + 3) % 4;
                }
                else {
                    direction = (direction + 1) % 4;
                }
            }
            return direction >= 1 || (x == 0 && y == 0);
        }
    }
}

// Say you have an array for which the ith element is the price of a given stock on day i.
// If you were only permitted to complete at most one transaction (i.e., buy one and sell one share of the stock),
// design an algorithm to find the maximum profit.
// Note that you cannot sell a stock before you buy one.

// Example 1:
// Input:[7,1,5,3,6,4]
// Output: 5
// Explanation: Buy on day 2(price = 1) and sell on day 5 (price = 6), profit = 6 - 1 = 5.
//             Not 7 - 1 = 6, as selling price needs to be larger than buying price.

// Example 2:
// Input:[7,6,4,3,1]
// Output: 0
// Explanation: In this case, no transaction is done, i.e. max profit = 0.

using System;

namespace SeptemberThird {
    public class BestTimeToBuyAndSellStock {
        public static void Main(string[] args) {
            int[] prices = new int[] { 7, 1, 5, 3, 6, 4 };
            Console.WriteLine(MaxProfit(prices));
        }

        public static int MaxProfit(int[] prices) {
            int price = int.MaxValue;
            int profit = 0;
            for (int i = 0; i < prices.Length; i++) {
                price = Math.Min(price, prices[i]);
                profit = Math.Max(profit, prices[i] - price);
            }
            return profit;
        }
    }
}

// An integer has sequential digits if and only if each digit in the number is one more than the previous digit.
// Return a sorted list of all the integers in the range [low, high] inclusive that have sequential digits.

// Example 1:
// Input: low = 100, high = 300
// Output:[123,234]

// Example 2:
// Input: low = 1000, high = 13000
// Output:[1234,2345,3456,4567,5678,6789,12345]

// Constraints:
// 10 <= low <= high <= 10 ^ 9

using System;
using System.Collections.Generic;
using System.Linq;

namespace SeptemberThird {
    public class SequentialDigits {
        public static void Main(string[] args) {
            foreach (int i in SequentialDigitsFunction(100, 300)) {
                Console.Write(i + " ");
            }
        }

        public static IList<int> SequentialDigitsFunction(int low, int high) {
            SortedSet<int> result = new SortedSet<int>();
            for (int i = 0; i < 10; i++) {
                Backtrack(result, i, i + 1, low, high);
            }
            return result.ToList();
        }

        private static void Backtrack(SortedSet<int> result, int current, int next, int low, int high) {
            if (current > high || next > 10) {
                return;
            }
            else if (current >= low && current <= high) {
                result.Add(current);
            }
            Backtrack(result, current * 10 + next, next + 1, low, high);
        }
    }
}

// On a 2-dimensional grid, there are 4 types of squares:
// 1 represents the starting square.  There is exactly one starting square.
// 2 represents the ending square.  There is exactly one ending square.
// 0 represents empty squares we can walk over.
// -1 represents obstacles that we cannot walk over.
// Return the number of 4-directional walks from the starting square to the ending square, that walk over every non-obstacle square exactly once.

// Example 1:
// Input:[[1,0,0,0],[0,0,0,0],[0,0,2,-1]]
// Output: 2
// Explanation: We have the following two paths: 
// 1. (0, 0),(0, 1),(0, 2),(0, 3),(1, 3),(1, 2),(1, 1),(1, 0),(2, 0),(2, 1),(2, 2)
// 2. (0, 0),(1, 0),(2, 0),(2, 1),(1, 1),(0, 1),(0, 2),(0, 3),(1, 3),(1, 2),(2, 2)

// Example 2:
// Input:[[1,0,0,0],[0,0,0,0],[0,0,0,2]]
// Output: 4
// Explanation: We have the following four paths: 
// 1. (0, 0),(0, 1),(0, 2),(0, 3),(1, 3),(1, 2),(1, 1),(1, 0),(2, 0),(2, 1),(2, 2),(2, 3)
// 2. (0, 0),(0, 1),(1, 1),(1, 0),(2, 0),(2, 1),(2, 2),(1, 2),(0, 2),(0, 3),(1, 3),(2, 3)
// 3. (0, 0),(1, 0),(2, 0),(2, 1),(2, 2),(1, 2),(1, 1),(0, 1),(0, 2),(0, 3),(1, 3),(2, 3)
// 4. (0, 0),(1, 0),(2, 0),(2, 1),(1, 1),(0, 1),(0, 2),(0, 3),(1, 3),(1, 2),(2, 2),(2, 3)

// Example 3:
// Input:[[0,1],[2,0]]
// Output: 0
// Explanation:
// There is no path that walks over every empty square exactly once.
// Note that the starting and ending square can be anywhere in the grid.

// Note:
// 1 <= grid.length * grid[0].length <= 20

using System;

namespace SeptemberThird {
    public class UniquePathsIII {
        public static void Main(string[] args) {
            int[][] grid = new int[3][];
            grid[0] = new int[4] { 1, 0, 0, 0 };
            grid[1] = new int[4] { 0, 0, 0, 0 };
            grid[2] = new int[4] { 0, 0, 2, -1 };
            Console.WriteLine(UniquePaths(grid));
        }

        public static int UniquePaths(int[][] grid) {
            int empty = 0, startX = 0, startY = 0, m = grid.Length, n = grid[0].Length;
            for (int i = 0; i < m; i++) {
                for (int j = 0; j < n; j++) {
                    if (grid[i][j] == 0) {
                        empty++;
                    }
                    else if (grid[i][j] == 1) {
                        startX = i;
                        startY = j;
                    }
                }
            }
            return Helper(grid, startX, startY, empty);
        }

        private static int Helper(int[][] grid, int row, int col, int empty) {
            int m = grid.Length, n = grid[0].Length;
            if (row < 0 || row >= m || col < 0 || col >= n || grid[row][col] == -1) {
                return 0;
            }
            else if (grid[row][col] == 2) {
                return empty == -1 ? 1 : 0;
            }
            grid[row][col] = -1;
            int cnt = Helper(grid, row - 1, col, empty - 1)
                    + Helper(grid, row + 1, col, empty - 1)
                    + Helper(grid, row, col - 1, empty - 1)
                    + Helper(grid, row, col + 1, empty - 1);
            grid[row][col] = 0;
            return cnt;
        }
    }
}

// You are driving a vehicle that has capacity empty seats initially available for passengers.
// The vehicle only drives east (ie. it cannot turn around and drive west.)
// Given a list of trips, trip[i] = [num_passengers, start_location, end_location] contains information about the i-th trip:
// the number of passengers that must be picked up, and the locations to pick them up and drop them off.
// The locations are given as the number of kilometers due east from your vehicle's initial location.
// Return true if and only if it is possible to pick up and drop off all passengers for all the given trips. 

// Example 1:
// Input: trips = [[2, 1, 5],[3,3,7]], capacity = 4
// Output: false

// Example 2:
// Input: trips = [[2, 1, 5],[3,3,7]], capacity = 5
// Output: true

// Example 3:
// Input: trips = [[2, 1, 5],[3,5,7]], capacity = 3
// Output: true

// Example 4:
// Input: trips = [[3, 2, 7],[3,7,9],[8,3,9]], capacity = 11
// Output: true

// Constraints:
// trips.length <= 1000
// trips[i].length == 3
// 1 <= trips[i][0] <= 100
// 0 <= trips[i][1] < trips[i][2] <= 1000
// 1 <= capacity <= 100000

using System;
using System.Collections.Generic;

namespace SeptemberThird {
    public class CarPooling {
        public static void Main(string[] args) {
            int[][] trips = new int[3][];
            trips[0] = new int[3] { 3, 2, 7 };
            trips[1] = new int[3] { 3, 7, 9 };
            trips[2] = new int[3] { 8, 3, 9 };
            Console.WriteLine(CarPool(trips, 11));
        }

        public static bool CarPool(int[][] trips, int capacity) {
            SortedDictionary<int, int> dict = new SortedDictionary<int, int>();
            foreach (int[] trip in trips) {
                if (!dict.ContainsKey(trip[1])) {
                    dict[trip[1]] = 0;
                }
                if (!dict.ContainsKey(trip[2])) {
                    dict[trip[2]] = 0;
                }
                dict[trip[1]] += trip[0];
                dict[trip[2]] -= trip[0];
            }
            int count = 0;
            foreach (KeyValuePair<int, int> kvp in dict) {
                count += kvp.Value;
                if (count > capacity) {
                    return false;
                }
            }
            return true;
        }
    }
}
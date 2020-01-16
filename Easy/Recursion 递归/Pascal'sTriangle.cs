// Pascal's triangle are a series of numbers arranged in the shape of triangle.
// In Pascal's triangle, the leftmost and the rightmost numbers of each row are always 1.
// For the rest, each number is the sum of the two numbers directly above it in the previous row.

//     1
//    1 1
//   1 2 1
//  1 3 3 1
// 1 4 6 4 1

// i => row  j => colum
// f(i,j)=f(i−1,j−1)+f(i−1,j)

// Given a non-negative integer numRows, generate the first numRows of Pascal's triangle.

// Input: 5
// Output:
// [
//      [1],
//     [1,1],
//    [1,2,1],
//   [1,3,3,1],
//  [1,4,6,4,1]
// ]

using System;
using System.Collections.Generic;

namespace PascalsTriangle {
    public class Program {
        static void Main(string[] args) {
            Solution solution = new Solution();
            int key = 10;
            IList<IList<int>> triangle = solution.Generate(key);
            for (int i = 0; i < key; i++) {
                for (int j = 0; j <= i; j++) {
                    Console.Write(triangle[i][j] + " ");
                }
                Console.WriteLine();
            }
        }
    }

    public class Solution {
        public IList<IList<int>> Generate(int numRows) {
            IList<IList<int>> triangle = new List<IList<int>>();
            if (numRows <= 0) {
                return triangle;
            }

            triangle.Add(new List<int> { 1 });

            for (int i = 1; i < numRows; i++) {
                // Get last row data
                IList<int> prevRow = triangle[i - 1];

                // In every row the first element was always 1
                List<int> row = new List<int> {
                1
            };

                for (int j = 1; j < i; j++) {
                    row.Add(prevRow[j - 1] + prevRow[j]);
                }

                // In every row the first element was always 1
                row.Add(1);

                triangle.Add(row);
            }
            return triangle;
        }
    }
}

// Java
class Solution {
    public List<List<Integer>> generate(int numRows) {
        List<List<Integer>> triangle = new ArrayList<List<Integer>>();

        // First base case; if user requests zero rows, they get zero rows.
        if (numRows == 0) {
            return triangle;
        }

        // Second base case; first row is always [1].
        triangle.add(new ArrayList<>());
        triangle.get(0).add(1);

        for (int rowNum = 1; rowNum < numRows; rowNum++) {
            List<Integer> row = new ArrayList<>();
            List<Integer> prevRow = triangle.get(rowNum - 1);

            // The first row element is always 1.
            row.add(1);

            // Each triangle element (other than the first and last of each row)
            // is equal to the sum of the elements above-and-to-the-left and
            // above-and-to-the-right.
            for (int j = 1; j < rowNum; j++) {
                row.add(prevRow.get(j - 1) + prevRow.get(j));
            }

            // The last row element is always 1.
            row.add(1);

            triangle.add(row);
        }

        return triangle;
    }
}

// Python
class Solution :
    def generate(self, num_rows):
        triangle = []

        for row_num in range(num_rows) :
            # The first and last row elements are always 1.
            row = [None for _ in range(row_num + 1)]
            row[0], row[-1] = 1, 1

            # Each triangle element is equal to the sum of the elements
            # above-and-to-the-left and above-and-to-the-right.
            for j in range(1, len(row)-1) :
                row[j] = triangle[row_num - 1][j - 1] + triangle[row_num - 1][j]

                triangle.append(row)

        return triangle

// Given a non-negative index k where k ≤ 33, return the kth index row of the Pascal's triangle.
// Note that the row index starts from 0.

// Input: 3
// Output: [1,3,3,1]

// Could you optimize your algorithm to use only O(k) extra space?
using System;
using System.Collections.Generic;

namespace PascalsTriangle {
    public class Program {
        static void Main(string[] args) {
            Solution solution = new Solution();
            int key = 1;
            var val = solution.Generate(key);
            foreach (int item in val) {
                Console.Write(item + " ");
            }
        }
    }

    public class Solution {
        public IList<int> Generate(int rowIndex) {
            IList<int> triangle = new List<int>();
            IList<IList<int>> triangleList = new List<IList<int>>();

            if (rowIndex < 0) {
                return triangle;
            }

            triangle.Add(1);

            if (rowIndex == 0) {
                return triangle;
            }

            triangleList.Add(new List<int> { 1 });

            for (int i = 1; i <= rowIndex; i++) {
                // Get last row data
                IList<int> prevRow = triangleList[i - 1];

                // In every row the first element was always 1
                List<int> row = new List<int> {
                1
            };

                for (int j = 1; j < i; j++) {
                    row.Add(prevRow[j - 1] + prevRow[j]);
                }

                // In every row the first element was always 1
                row.Add(1);

                triangleList.Add(row);

                if (i == rowIndex) {
                    triangle = row;
                }
            }
            return triangle;
        }
    }
}
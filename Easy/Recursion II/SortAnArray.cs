// A divide-and-conquer algorithm works by recursively breaking the problem down into two or more subproblems of the same or related type,
// until these subproblems become simple enough to be solved directly.
// Then one combines the results of subproblems to form the final solution.

// 1. Divide. Divide the problem {S}S into a set of subproblems:{S1,S2,S3,...,Sn} where n ≥ 2, i.e. there are usually more than one subproblem.
// 2. Conquer. Solve each subproblem recursively. 
// 3. Combine. Combine the results of each subproblem.

// Given an array of integers nums, sort the array in ascending order.
// Example 1:
// Input: nums = [5,2,3,1]
// Output: [1,2,3,5]
// Example 2:
// Input: nums = [5,1,1,2,0,0]
// Output: [0,0,1,1,2,5]

using System;
using System.Collections.Generic;

namespace SortAnArray {
    public class Program {
        static void Main(string[] args) {
            Solution solution = new Solution();
            IList<int> num = solution.SortArray(new int[] { 1, 2, 3, 4, 1, 2, -1, -4, -23, 11, 41, 13 });
            foreach (int item in num) {
                Console.Write(item + " ");
            }
        }

        public class Solution {
            public IList<int> SortArray(int[] nums) {
                MergeSort(0, nums.Length - 1);
                return nums;
                void MergeSort(int i, int j) {
                    if (i == j) {
                        return;
                    }
                    int med = (i + j) / 2;
                    MergeSort(i, med);
                    MergeSort(med + 1, j);
                    Merge(i, med, med + 1, j);
                }
                void Merge(int i1, int j1, int i2, int j2) {
                    int fIndex = i1, sIndex = i2;
                    int[] arr = new int[j2 - i1 + 1];
                    int indexToInsert = 0;
                    while (indexToInsert != arr.Length) {
                        if (fIndex > j1 || (sIndex <= j2 && nums[fIndex] > nums[sIndex])) {
                            arr[indexToInsert++] = nums[sIndex++];
                        }
                        else {
                            arr[indexToInsert++] = nums[fIndex++];
                        }
                    }
                    for (int i = 0; i < arr.Length; i++) {
                        nums[i1 + i] = arr[i];
                    }
                }
            }
        }
    }
}

// Java
import java.util.Arrays;
public class Solution {
    public int[] merge_sort(int[] input) {
        if (input.length <= 1) {
            return input;
        }
        // 获取需要排序数组的长度（元素个数）然后从中间拆分为左右两份
        // Java中方法Arrays.copyOfRange（T[] original,int from,int to）的作用是将数组original从from开始进行复制，复制到下标为to的位置，包含[from,to)不包含
        int pivot = input.length / 2;
        int[] left_list = merge_sort(Arrays.copyOfRange(input, 0, pivot));
        int[] right_list = merge_sort(Arrays.copyOfRange(input, pivot, input.length));
        return merge(left_list, right_list);
    }

    public int[] merge(int[] left_list, int[] right_list) {
        int[] ret = new int[left_list.length + right_list.length];
        int left_cursor = 0, right_cursor = 0, ret_cursor = 0;
        while (left_cursor < left_list.length &&
               right_cursor < right_list.length) {
            if (left_list[left_cursor] < right_list[right_cursor]) {
                ret[ret_cursor++] = left_list[left_cursor++];
            }
            else {
                ret[ret_cursor++] = right_list[right_cursor++];
            }
        }
        // append what is remain the above lists
        while (left_cursor < left_list.length) {
            ret[ret_cursor++] = left_list[left_cursor++];
        }
        while (right_cursor < right_list.length) {
            ret[ret_cursor++] = right_list[right_cursor++];
        }
        return ret;
    }
}

// Python
def merge_sort(nums):
    # bottom cases: empty or list of a single element.
    if len(nums) <= 1:
        return nums
    pivot = int(len(nums) / 2)
    left_list = merge_sort(nums[0:pivot])
    right_list = merge_sort(nums[pivot:])
    return merge(left_list, right_list)
def merge(left_list, right_list):
    left_cursor = right_cursor = 0
    ret = []
    while left_cursor<len(left_list) and right_cursor<len(right_list):
        if left_list[left_cursor] < right_list[right_cursor]:
            ret.append(left_list[left_cursor])
            left_cursor += 1
        else:
            ret.append(right_list[right_cursor])
            right_cursor += 1
    # append what is remained in either of the lists
    ret.extend(left_list[left_cursor:])
    ret.extend(right_list[right_cursor:])
    return ret
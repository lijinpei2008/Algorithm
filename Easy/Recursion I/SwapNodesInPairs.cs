// Given a linked list, swap every two adjacent nodes and return its head.
// You may not modify the values in the list's nodes, only nodes itself may be changed.

// Example:
// Given 1->2->3->4, you should return the list as 2->1->4->3.

// We define the function to implement as swap(head), where the input parameter head refers to the head of a linked list.
// The function should return the head of the new linked list that has any adjacent nodes swapped.
// Following the guidelines we lay out above, we can implement the function as follows:
// First, we swap the first two nodes in the list, i.e.head and head.next;
// Then, we call the function self as swap(head.next.next) to swap the rest of the list following the first two nodes.
// Finally, we attach the returned head of the sub-list in step (2) with the two nodes swapped in step(1) to form a new linked list.

using System;

namespace SwapNodesInPairs {
    public class Program {
        static void Main(string[] args) {
            LinkNode node = new LinkNode();
            node.Add(new ListNode(1));
            node.Add(new ListNode(2));
            node.Add(new ListNode(3));
            node.Add(new ListNode(4));
            node.Add(new ListNode(5));
            Solution solution = new Solution();
            var node = solution.SwapPairs(node.head);
            Cw(node);
        }
        private static void Cw(ListNode node) {
            Console.WriteLine(node.val);
            if (node.next != null) {
                Cw(node.next);
            }
        }
    }

    public class ListNode {
        public int val;
        public ListNode next;
        public ListNode(int x) { val = x; }
    }

    public class LinkNode {
        public ListNode head;
        public ListNode tail;
        public void Add(ListNode node) {
            if (head == null) {
                head = tail = node;
            }
            else {
                tail = tail.next = node;
            }
        }
    }

    public class Solution {
        public ListNode SwapPairs(ListNode head) {
            if (head == null) {
                return head;
            }
            HelpFunction(head);
            return head;
        }

        public void HelpFunction(ListNode head) {
            if (head.next != null) {
                head.val ^= head.next.val;
                head.next.val ^= head.val;
                head.val ^= head.next.val;
                if (head.next.next == null) {
                    return;
                }
                else {
                    HelpFunction(head.next.next);
                }
            }
            else {
                return;
            }
        }
    }
}

using System;

namespace SwapNodesInPairs {
    public class Program {
        static void Main(string[] args) {
            ListNode node = new ListNode() {
                val = 1,
                next = new ListNode {
                    val = 2,
                    next = new ListNode {
                        val = 3,
                        next = new ListNode {
                            val = 4,
                            next = new ListNode {
                                val = 5,
                                next = new ListNode {
                                    val = 6,
                                    next = null
                                }
                            }
                        }
                    }
                }
            };
            Solution solution = new Solution();
            var node = solution.SwapPairs(node.head);
            Cw(node);
        }
        private static void Cw(ListNode node) {
            Console.WriteLine(node.val);
            if (node.next != null) {
                Cw(node.next);
            }
        }
    }

    public class ListNode {
        public int val;
        public ListNode next;
        public ListNode(int x) { val = x; }
        public ListNode() { }
    }

    public class Solution {
        public ListNode SwapPairs(ListNode head) {
            if (head == null) {
                return head;
            }
            HelpFunction(head);
            return head;
        }

        public void HelpFunction(ListNode head) {
            if (head.next != null) {
                head.val ^= head.next.val;
                head.next.val ^= head.val;
                head.val ^= head.next.val;
                if (head.next.next == null) {
                    return;
                }
                else {
                    HelpFunction(head.next.next);
                }
            }
            else {
                return;
            }
        }
    }
}

// Reverse a singly linked list.

// Example:
// Input: 1->2->3->4->5->NULL
// Output: 5->4->3->2->1->NULL

// Follow up:
// A linked list can be reversed either iteratively or recursively.Could you implement both?

using System;

namespace SwapNodesInPairs {
    public class Program {
        static void Main(string[] args) {
            ListNode root = new ListNode() {
                val = 1,
                next = new ListNode {
                    val = 2,
                    next = new ListNode {
                        val = 3,
                        next = new ListNode {
                            val = 4,
                            next = new ListNode {
                                val = 5,
                                next = new ListNode {
                                    val = 6,
                                    next = null
                                }
                            }
                        }
                    }
                }
            };
            Solution solution = new Solution();
            ListNode node = solution.ReverseList(root);
            Cw(node);
        }
        private static void Cw(ListNode node) {
            Console.WriteLine(node.val);
            if (node.next != null) {
                Cw(node.next);
            }
        }
    }

    public class ListNode {
        public int val;
        public ListNode next;
        public ListNode(int x) { val = x; }
        public ListNode() { }
    }

    public class Solution {
        public ListNode ReverseList(ListNode head) {
            if (head == null || head.next == null) {
                return head;
            }

            ListNode node = ReverseList(head.next);
            head.next.next = head;
            head.next = null;
            return node;
        }
    }
}

// While you are traversing the list, change the current node's next pointer to point to its previous element.
// Since a node does not have reference to its previous node, you must store its previous element beforehand.
// You also need another pointer to store the next node before changing the reference.
// Do not forget to return the new head reference at the end!

using System;

namespace SwapNodesInPairs {
    class Program {
        static void Main(string[] args) {
            ListNode root = new ListNode() {
                val = 1,
                next = new ListNode {
                    val = 2,
                    next = new ListNode {
                        val = 3,
                        next = new ListNode {
                            val = 4,
                            next = new ListNode {
                                val = 5,
                                next = new ListNode {
                                    val = 6,
                                    next = null
                                }
                            }
                        }
                    }
                }
            };
            Solution solution = new Solution();
            ListNode node = solution.ReverseList(root);
            Cw(node);
        }
        private static void Cw(ListNode node) {
            Console.WriteLine(node.val);
            if (node.next != null) {
                Cw(node.next);
            }
        }
    }

    public class ListNode {
        public int val;
        public ListNode next;
        public ListNode(int x) { val = x; }
        public ListNode() { }
    }

    public class Solution {
        public ListNode ReverseList(ListNode head) {
            ListNode result = null;
            ListNode curr = head;
            while (curr != null) {
                ListNode tmp = curr.next;
                curr.next = result;
                result = curr;
                curr = tmp;
            }
            return result;
        }
    }
}

// Merge two sorted linked lists and return it as a new list.The new list should be made by splicing together the nodes of the first two lists.

// Example:
// Input: 1->2->4,    1->3->4
// Output: 1->1->2->3->4->4

using System;

namespace SwapNodesInPairs {
    public class Program {
        static void Main(string[] args) {
            Solution solution = new Solution();
            ListNode node1 = new ListNode {
                val = 1,
                next = new ListNode {
                    val = 4,
                    next = new ListNode {
                        val = 9,
                        next = null
                    }
                }
            };
            ListNode node2 = new ListNode {
                val = 1,
                next = new ListNode {
                    val = 3,
                    next = new ListNode {
                        val = 6,
                        next = new ListNode {
                            val = 10,
                            next = null
                        }
                    }
                }
            };
            ListNode node = solution.MergeTwoLists(node1, node2);
            Cw(node);
        }
        private static void Cw(ListNode node) {
            Console.WriteLine(node.val);
            if (node.next != null) {
                Cw(node.next);
            }
        }
    }

    public class ListNode {
        public int val;
        public ListNode next;
        public ListNode() { }
        public ListNode(int x) { val = x; }
    }

    public class Solution {
        public ListNode MergeTwoLists(ListNode node1, ListNode node2) {
            if (node1 == null) {
                return node2;
            }
            if (node2 == null) {
                return node1;
            }
            if (node1.val <= node2.val) {
                node1.next = MergeTwoLists(node1.next, node2);
                return node1;
            }
            else {
                node2.next = MergeTwoLists(node1, node2.next);
                return node2;
            }
        }
    }
}
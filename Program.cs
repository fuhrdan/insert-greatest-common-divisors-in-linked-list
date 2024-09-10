//*****************************************************************************
//** 2807. Insert Greatest Common Divisors in Linked List   leetcode         **
//*****************************************************************************


/**
 * Definition for singly-linked list.
 * struct ListNode {
 *     int val;
 *     struct ListNode *next;
 * };
 */
// Helper function to calculate GCD using the Euclidean algorithm
int gcd(int a, int b) {
    while (b != 0) {
        int temp = b;
        b = a % b;
        a = temp;
    }
    return a;
}

struct ListNode* insertGreatestCommonDivisors(struct ListNode* head) {
    struct ListNode* current = head;

    while (current && current->next) {
        // Calculate the GCD of the current and next node values
        int gcdValue = gcd(current->val, current->next->val);

        // Create a new node for the GCD value
        struct ListNode* gcdNode = (struct ListNode*) malloc(sizeof(struct ListNode));
        gcdNode->val = gcdValue;
        
        // Insert the new node between the current and the next node
        gcdNode->next = current->next;
        current->next = gcdNode;

        // Move to the next pair of nodes
        current = gcdNode->next;
    }

    return head;
}
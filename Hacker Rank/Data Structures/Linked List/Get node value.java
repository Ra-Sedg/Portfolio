/*
  Get Nth element from the end in a linked list of integers
  Number of elements in the list will always be greater than N.
  Node is defined as 
  class Node {
     int data;
     Node next;
  }
*/
    
int GetNode(Node head,int n) {
     // This is a "method-only" submission. 
     // You only need to complete this method. 

    Node pointer1 = head;
    Node pointer2 = head;
    
    // Move pointer 2 up n elements.
    for (int i = 0; i < n; i++) {
        pointer2 = pointer2.next;
    }
    
    // Iterate both pointers until the pointer 2 reaches the end of the list
    while (pointer2.next != null) {
        pointer1 = pointer1.next;
        pointer2 = pointer2.next;
    }
    
    return pointer1.data;
}

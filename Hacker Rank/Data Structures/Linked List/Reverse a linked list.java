/*
  Reverse a linked list and return pointer to the head
  The input list will have at least one element  
  Node is defined as  
  class Node {
     int data;
     Node next;
  }
*/
    // This is a "method-only" submission. 
    // You only need to complete this method. 
Node Reverse(Node head) {

    if (head == null) {
        return head;
    }
    
    Stack<Node> stack = new Stack<Node>();
    
    for (Node n = head; n != null; n = n.next) {
        stack.push(n);
    }
    
    Node current = head = stack.pop();
    while (!stack.isEmpty()) {
        current.next = stack.pop();
        current = current.next;
    }
    current.next = null;
    
    return head;
}
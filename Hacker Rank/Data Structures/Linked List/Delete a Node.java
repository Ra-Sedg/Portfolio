/*
  Delete Node at a given position in a linked list 
  head pointer input could be NULL as well for empty list
  Node is defined as 
  class Node {
     int data;
     Node next;
  }
*/
    // This is a "method-only" submission. 
    // You only need to complete this method. 

Node Delete(Node head, int position) {
  // Complete this method
    
    if (head == null){
        return head;
    }
    
    if (position == 0){
        return head.next;
    }
    
    Node current = head;
    Node previous = null;
    
    for (int i = 0; i < position; i++){
        
        previous = current;
        current = current.next;
        
    }
    
    previous.next = current.next;
    
    return head;
}

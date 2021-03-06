/*
  Insert Node at a given position in a linked list 
  head can be NULL 
  First element in the linked list is at position 0
  Node is defined as 
  class Node {
     int data;
     Node next;
  }
*/
    

Node InsertNth(Node head, int data, int position) {
   // This is a "method-only" submission. 
    // You only need to complete this method. 
    
    Node insertNode = new Node();
    insertNode.data = data;
    insertNode.next = null;
    
    if (head == null || position == 0){
        
        insertNode.next = head;
        return insertNode;
        
    }
    else {
        
        Node current = head;
        Node prev = null;
        
        for (int i = 0; i < position; i++){
            prev = current;
            current = current.next;
        }
        
        prev.next = insertNode;
        insertNode.next = current;
    }
    
    return head;  
}

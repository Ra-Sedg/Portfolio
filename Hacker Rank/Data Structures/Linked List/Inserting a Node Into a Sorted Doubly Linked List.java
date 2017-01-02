/*
  Insert Node at the end of a linked list 
  head pointer input could be NULL as well for empty list
  Node is defined as 
  class Node {
     int data;
     Node next;
     Node prev;
  }
*/

Node SortedInsert(Node head,int data) {
  
    Node insert = new Node();
    insert.data = data;
    insert.next = null;
    insert.prev = null;
    
    if (head == null) {
        return insert;
    }
    
    Node current = head;
    
    if (data <= current.data) {
        insert.next = current;
        current.prev = insert;
        return insert;
    }
    else {
        Node temp = SortedInsert(current.next, data);
        current.next = temp;
        temp.prev = current;
        return head;
    }
}
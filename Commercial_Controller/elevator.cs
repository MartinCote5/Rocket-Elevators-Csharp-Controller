using System;
using System.Collections.Generic;

namespace Commercial_Controller
{
    public class Elevator
    {
        public string ID;
        public string status = "stopped";
        public int currentFloor = 1;
        public string direction;
        public object door = new Door(Battery.IDGenerator.doorID);
        
        List<int> floorRequestsList = new List<int>();
        List<int> completedRequestsList  = new List<int>();

        public Elevator(string id)
        {
            this.ID = id;
                
               
            
            


        }
        public void move() {
            while (this.floorRequestsList.Count != 0) {
                int destination = this.floorRequestsList[0];
                this.status = "moving";
                if (this.currentFloor < destination) {
                    this.direction = "up";

                    this.sortFloorList();
                    destination = this.floorRequestsList[0];
                    while (this.currentFloor < destination) {
                        this.currentFloor++;
                        int screenDisplay = this.currentFloor;
                        }
                }   else if (this.currentFloor > destination) {
                        this.direction = "down";
                        this.sortFloorList();
                        destination = this.floorRequestsList[0];
                        while (this.currentFloor > destination) {
                            this.currentFloor--;
                            int screenDisplay = this.currentFloor;
                            }
                        }
                        this.status = "stopped";
                        this.operateDoors();
                        this.floorRequestsList.RemoveAt(0);
                    }
                this.status = "idle";
            }

                       
        public void sortFloorList() {
            if (this.direction == "up") {
                this.floorRequestsList.Sort();
        }   else {
                this.floorRequestsList.Reverse();
            }
            

        }  
        
        
        public void operateDoors() {
            this.door = "opened";
            this.door = "closed";
            }
        




       

 

    




  




















        public void addNewRequest(int requestedFloor) {
            

            if(this.floorRequestsList.Contains(requestedFloor) == false ) {
                this.floorRequestsList.Add(requestedFloor);
            }

            if (currentFloor < requestedFloor) {
                this.direction = "up";
            }
            if (currentFloor > requestedFloor) {
                this.direction = "down";
            }
            
            
        }

    



    

            
        

    

     






















    }
}
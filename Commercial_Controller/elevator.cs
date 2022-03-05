using System;
using System.Collections.Generic;

namespace Commercial_Controller
{
    public class Elevator
    {
        public string ID;
        public string status;
        public int currentFloor;
        public string direction;
        public Door door = new Door(1);
        public List<int> floorRequestsList = new List<int>();
        public List<int> completedRequestsList  = new List<int>();

        public Elevator(string id)
        {
            this.ID = id;
                
        }




        public void move() {
            while (this.floorRequestsList.Count != 0) {
                int destination = this.floorRequestsList[0];
                status = "moving";
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
                        this.completedRequestsList.Add(floorRequestsList[0]);
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
            this.door.status = "opened";
            this.door.status = "closed";
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
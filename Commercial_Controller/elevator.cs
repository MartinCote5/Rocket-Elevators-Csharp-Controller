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
        public void move()
        {

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
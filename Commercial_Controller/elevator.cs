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
            ID = id;        
        }



        public void move() 
        {
            while (floorRequestsList.Count != 0) 
            {
                int destination = floorRequestsList[0];
                status = "moving";

                if (currentFloor < destination)
                {
                    direction = "up";
                    sortFloorList();
                    destination = floorRequestsList[0];

                    while (currentFloor < destination) 
                    {
                        currentFloor++;
                        int screenDisplay = currentFloor;
                    }
                }   
                else if (currentFloor > destination) 
                {
                    direction = "down";
                    sortFloorList();
                    destination = floorRequestsList[0];

                    while (currentFloor > destination) 
                    {
                        currentFloor--;
                        int screenDisplay = currentFloor;
                    }
                }
                status = "stopped";
                operateDoors();
                completedRequestsList.Add(floorRequestsList[0]);
                floorRequestsList.RemoveAt(0);
            }
            status = "idle";
        }



        public void sortFloorList()
        {
            if (direction == "up")
            {
                floorRequestsList.Sort();
            }   
            else 
            {
                floorRequestsList.Reverse();
            }
        }  
        
        

        public void operateDoors() 
        {
            door.status = "opened";
            door.status = "closed";
        }
        


        public void addNewRequest(int requestedFloor) 
        {
            if(floorRequestsList.Contains(requestedFloor) == false) 
            {
                floorRequestsList.Add(requestedFloor);
            }
            if (currentFloor < requestedFloor) 
            {
                direction = "up";
            }
            if (currentFloor > requestedFloor) 
            {
                direction = "down";
            }        
        }
    }
}
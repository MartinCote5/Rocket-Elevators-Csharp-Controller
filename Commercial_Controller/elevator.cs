using System.Threading;
using System.Collections.Generic;

namespace Commercial_Controller
{
    public class Elevator
    {
        public string ID;
        public string status = "idle";
        public int currentFloor;
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
        
    }
}
using System;
using System.Collections.Generic;

namespace Commercial_Controller
{
    public class Column
    {
        public string ID;
        public string status = "online";
        public List<int> servedFloors;
        public bool isBasement;
        List<Elevator> elevatorsList = new List<Elevator>();
        List<CallButton> callButtonsList = new List<CallButton>();
        public Column(string id, double amountOfElevators, List<int> servedFloors, bool isBasement)
        {
            this.ID = id;
            this.servedFloors = servedFloors;
            this.isBasement = isBasement;
            createElevators(amountOfElevators);
            createCallButtons(servedFloors, isBasement);
        }


        public void createElevators(double amountOfElevators) {
             for (int i = 0; i < amountOfElevators; i++) {
                Elevator elevator = new Elevator("1");    
                elevatorsList.Add(elevator);
                

                 // public elevatorID++;   ------------ dont forget this
            }
        }



         public void createCallButtons(List<int> servedFloors, bool isBasement) {
             Console.WriteLine(servedFloors);
            if(isBasement) {
                int buttonFloor = -1;
                for (int i = 0; i < servedFloors.Count; i++) {
                    CallButton callButton = new CallButton(1, buttonFloor, "up");    
                    callButtonsList.Add(callButton);
                    buttonFloor--;
                    Console.WriteLine(buttonFloor);
                        // public callButtonID++;   ------------ dont forget this
                }     
         }  else {
                int buttonFloor = 1;
                for (int i = 0; i < servedFloors.Count; i++) {
                    CallButton callButton = new CallButton(1, buttonFloor, "down");    
                    callButtonsList.Add(callButton);
                    buttonFloor++;
                    Console.WriteLine(buttonFloor);
                        // public callButtonID++;   ------------ dont forget this
                }      


             }

           
        }


 






    //     //Simulate when a user press a button on a floor to go back to the first floor
    //     public Elevator requestElevator(int requestedFloor, string direction)
    //     {
            
    //     }

    }
}
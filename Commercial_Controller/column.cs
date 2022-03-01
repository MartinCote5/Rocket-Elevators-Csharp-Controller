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
        public Column(string id, decimal amountOfElevators, List<int> servedFloors, bool isBasement)
        {
            this.ID = id;
            this.servedFloors = servedFloors;
            this.isBasement = isBasement;
            createElevators(amountOfElevators);
            createCallButtons(servedFloors, isBasement);
            // findBestColumn(33);
        }


        public void createElevators(decimal amountOfElevators) {
             for (int i = 0; i < amountOfElevators; i++) {
                Elevator elevator = new Elevator(Battery.IDGenerator.elevatorID.ToString());    
                elevatorsList.Add(elevator);
                

                Battery.IDGenerator.elevatorID++;  
            }
        }



         public void createCallButtons(List<int> servedFloors, bool isBasement) {
            //  Console.WriteLine(servedFloors);
             
            if(isBasement) {
                int buttonFloor = -1;
                for (int i = 0; i < servedFloors.Count; i++) {
                    int IDButton = Battery.IDGenerator.callButtonID;
                    CallButton callButton = new CallButton(IDButton, servedFloors[i], "up");    
                    callButtonsList.Add(callButton);
                    buttonFloor--;
                    Battery.IDGenerator.callButtonID++;  
                    // Console.WriteLine(IDButton);
                }     
         }  else {
                int buttonFloor = 1;
                for (int i = 0; i < servedFloors.Count; i++) {
                    int IDButton = Battery.IDGenerator.callButtonID;
                    CallButton callButton = new CallButton(IDButton, servedFloors[i], "down");    
                    callButtonsList.Add(callButton);
                    buttonFloor++;
                    Battery.IDGenerator.callButtonID++;
                    // Console.WriteLine(IDButton);
                }      


             }

           
        }


 
    





    //     //Simulate when a user press a button on a floor to go back to the first floor
    //     public Elevator requestElevator(int requestedFloor, string direction)
    //     {
            
    //     }

    }
}
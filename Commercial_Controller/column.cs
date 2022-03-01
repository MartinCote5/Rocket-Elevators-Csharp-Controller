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


 
        public Elevator findElevator(int requestedFloor, string requestedDirection) {

            Elevator bestElevator = elevatorsList[0];
            int bestScore = 6;
            int referenceGap = 10000000;
            Elevator bestElevatorInformations;

                if (requestedFloor == 1) {
                    foreach (Elevator elevator in elevatorsList) {
                        //The elevator is at the lobby and already has some requests. It is about to leave but has not yet departed
                        if (1 == elevator.currentFloor && elevator.status == "stopped") {
                            bestElevatorInformations = checkIfElevatorIsBetter(1, elevator, bestScore, referenceGap, bestElevator, requestedFloor);    
                            //The elevator is at the lobby and has no requests   
                    }   else if (1 == elevator.currentFloor && elevator.status == "idle") {
                            bestElevatorInformations = checkIfElevatorIsBetter(2, elevator, bestScore, referenceGap, bestElevator, requestedFloor);
                            //The elevator is lower than me and is coming up. It means that I'm requesting an elevator to go to a basement, and the elevator is on it's way to me
                    }   else if (1 > elevator.currentFloor && elevator.direction == "up") {
                            bestElevatorInformations = checkIfElevatorIsBetter(3, elevator, bestScore, referenceGap, bestElevator, requestedFloor);
                            //The elevator is above me and is coming down. It means that I'm requesting an elevator to go to a floor, and the elevator is on it's way to me
                    }   else if (1 < elevator.currentFloor && elevator.direction == "down") {
                            bestElevatorInformations = checkIfElevatorIsBetter(3, elevator, bestScore, referenceGap, bestElevator, requestedFloor); 
                            //The elevator is not at the first floor, but doesn't have any request
                    }   else if (elevator.status == "idle") {
                            bestElevatorInformations = checkIfElevatorIsBetter(4, elevator, bestScore, referenceGap, bestElevator, requestedFloor);
                            //The elevator is not available, but still could take the call if nothing better is found
                    }   else {
                            bestElevatorInformations = checkIfElevatorIsBetter(5, elevator, bestScore, referenceGap, bestElevator, requestedFloor);
                    }
                    // Elevator BestElevator = bestElevatorInformations.bestElevator;
                    // int bestScore = bestElevatorInformations.bestScore;
                    // int referenceGap = bestElevatorInformations.referenceGap;    
                }
                // return bestElevator;
            }
        
                
            Elevator x = null;

            return x;

        }

    
        public  Elevator checkIfElevatorIsBetter(int scoreToCheck, Elevator newElevator, int bestScore, int referenceGap, Elevator bestElevator, int Floor ) {
            
            Elevator bestElevatorInformations = null;
            return bestElevatorInformations;

        }
        

























    //     //Simulate when a user press a button on a floor to go back to the first floor
    //     public Elevator requestElevator(int requestedFloor, string direction)
    //     {
            
    //     }

    }
}
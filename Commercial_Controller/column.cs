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
        public List<Elevator> elevatorsList = new List<Elevator>();
        public List<CallButton> callButtonsList = new List<CallButton>();
        public Column(string id, decimal amountOfElevators, List<int> _servedFloors, bool _isBasement)
        {
            ID = id;
            servedFloors = _servedFloors;
            isBasement = _isBasement;
            createElevators(amountOfElevators);
            createCallButtons(servedFloors, isBasement);    
        }



        public void createElevators(decimal amountOfElevators) 
        {
            int elevatorID = 1;

            for (int i = 0; i < amountOfElevators; i++) {
                Elevator elevator = new Elevator(elevatorID.ToString());    
                elevatorsList.Add(elevator);
                elevatorID++;  
            }
        }



        public void createCallButtons(List<int> servedFloors, bool isBasement) 
        {
            int callButtonID = 1;

            if(isBasement)
            {
                for (int i = 0; i < servedFloors.Count; i++)
                {
                    CallButton callButton = new CallButton(callButtonID, servedFloors[i], "up");    
                    callButtonsList.Add(callButton);
                    callButtonID++;      
                }     
            }  
            else 
            {
                for (int i = 0; i < servedFloors.Count; i++) 
                {
                    CallButton callButton = new CallButton(callButtonID, servedFloors[i], "down");    
                    callButtonsList.Add(callButton);
                    callButtonID++;
                }      
            }   
        }


        //Simulate when a user press a button on a floor to go back to the first floor
        public Elevator requestElevator(int requestedFloor, string direction)
        {
            Elevator elevator = findElevator(requestedFloor, direction);
            elevator.addNewRequest(requestedFloor);
            elevator.move();
            //Always 1 because the user can only go back to the lobby
            elevator.addNewRequest(1);
            elevator.move();

            return elevator;
        }


 
        public Elevator findElevator(int requestedFloor, string requestedDirection) 
        {
            Elevator bestElevator = elevatorsList[1];
            int bestScore = 6;
            int referenceGap = 10000000;
            
            if (requestedFloor == 1) 
            {
                foreach (Elevator elevator in elevatorsList) 
                {
                    //The elevator is at the lobby and already has some requests. It is about to leave but has not yet departed
                    if (elevator.currentFloor == 1 && elevator.status == "stopped") 
                    {
                        (bestElevator, bestScore, referenceGap) = checkIfElevatorIsBetter(1, elevator, bestScore, referenceGap, bestElevator, requestedFloor);  
                    } 
                    //The elevator is at the lobby and has no requests   
                    else if (elevator.currentFloor == 1 && elevator.status == "idle") 
                    {
                        (bestElevator, bestScore, referenceGap) = checkIfElevatorIsBetter(2, elevator, bestScore, referenceGap, bestElevator, requestedFloor);
                    } 
                    //The elevator is lower than me and is coming up. It means that I'm requesting an elevator to go to a basement, and the elevator is on it's way to me
                    else if (elevator.currentFloor < 1 && elevator.direction == "up") 
                    {
                        (bestElevator, bestScore, referenceGap) = checkIfElevatorIsBetter(3, elevator, bestScore, referenceGap, bestElevator, requestedFloor);
                    } 
                    //The elevator is above me and is coming down. It means that I'm requesting an elevator to go to a floor, and the elevator is on it's way to me
                    else if (elevator.currentFloor > 1 && elevator.direction == "down") 
                    {
                        (bestElevator, bestScore, referenceGap) = checkIfElevatorIsBetter(3, elevator, bestScore, referenceGap, bestElevator, requestedFloor); 
                    } 
                    //The elevator is not at the first floor, but doesn't have any request
                    else if (elevator.status == "idle") 
                    {
                        (bestElevator, bestScore, referenceGap) = checkIfElevatorIsBetter(4, elevator, bestScore, referenceGap, bestElevator, requestedFloor);
                    } 
                    //The elevator is not available, but still could take the call if nothing better is found
                    else 
                    {
                        (bestElevator, bestScore, referenceGap) = checkIfElevatorIsBetter(5, elevator, bestScore, referenceGap, bestElevator, requestedFloor);
                    }    
                } 
            }   
            else 
            {
                foreach (Elevator elevator in elevatorsList)
                {
                    //The elevator is at the same level as me, and is about to depart to the first floor
                    if (requestedFloor == elevator.currentFloor && elevator.status == "stopped" && requestedDirection == elevator.direction) 
                    {
                        (bestElevator, bestScore, referenceGap) = checkIfElevatorIsBetter(1, elevator, bestScore, referenceGap, bestElevator, requestedFloor);
                    } 
                    //The elevator is lower than me and is going up. I'm on a basement, and the elevator can pick me up on it's way
                    else if (requestedFloor > elevator.currentFloor && elevator.direction == "up" && requestedDirection == "up") 
                    {
                        (bestElevator, bestScore, referenceGap) = checkIfElevatorIsBetter(2, elevator, bestScore, referenceGap, bestElevator, requestedFloor);  
                    } 
                    //The elevator is higher than me and is going down. I'm on a floor, and the elevator can pick me up on it's way 
                    else if (requestedFloor < elevator.currentFloor && elevator.direction == "down" && requestedDirection == "down") 
                    {
                        (bestElevator, bestScore, referenceGap) = checkIfElevatorIsBetter(2, elevator, bestScore, referenceGap, bestElevator, requestedFloor);
                    }
                    //The elevator is idle and has no requests    
                    else if (elevator.status == "idle") 
                    {
                        (bestElevator, bestScore, referenceGap) = checkIfElevatorIsBetter(4, elevator, bestScore, referenceGap, bestElevator, requestedFloor); 
                    } 
                    //The elevator is not available, but still could take the call if nothing better is found         
                    else 
                    {
                        (bestElevator, bestScore, referenceGap) = checkIfElevatorIsBetter(5, elevator, bestScore, referenceGap, bestElevator, requestedFloor);
                    }
                }       
            }    
            return bestElevator;
        }

    

        public  (Elevator, int, int) checkIfElevatorIsBetter(int scoreToCheck, Elevator newElevator, int bestScore, int referenceGap, Elevator bestElevator, int floor ) 
        {
            if (scoreToCheck < bestScore) 
            {
                bestScore = scoreToCheck;
                bestElevator = newElevator;
                referenceGap = Math.Abs(newElevator.currentFloor - floor);
            }   
            else if (bestScore == scoreToCheck) 
            {
                int gap = Math.Abs(newElevator.currentFloor - floor);

                if (referenceGap > gap)
                {
                    bestElevator = newElevator;
                    referenceGap = gap;
                }
            }
            return (bestElevator, bestScore, referenceGap);   
        }
    }
}
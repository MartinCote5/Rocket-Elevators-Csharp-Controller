using System;
using System.Collections.Generic;

namespace Commercial_Controller
{
    public class Battery
    {
        public int ID;
       
        public string status;
        List<int> columnsList;
        List<int> floorRequestButtonsList;
        public Battery(int id, int amountOfColumns, int amountOfFloors, int amountOfBasements, int amountOfElevatorPerColumn)
        {   
            this.ID = id;
           
            if (amountOfBasements > 0) {
                createBasementFloorRequestButtons(amountOfBasements);
                createBasementColumn(amountOfBasements, amountOfElevatorPerColumn);
                amountOfBasements--;

            } 

            createFloorRequestButtons(amountOfFloors); 

            createColumns(amountOfColumns, amountOfFloors, amountOfElevatorPerColumn);




            Console.WriteLine(ID);
            Console.WriteLine(amountOfFloors);
            
            // Console.WriteLine(columnsList);
        }



        public void createBasementFloorRequestButtons(int amountOfBasements) {
            Console.WriteLine(ID);
        }



        public void createBasementColumn(int amountOfBasements, int amountOfElevatorPerColumn) {
            
        }









        public void createFloorRequestButtons(int amountOfFloors) {
            
        }




        public void createColumns(int amountOfColumns, int amountOfFloors, int amountOfElevatorPerColumn) {

        }



        // public Column findBestColumn(int requestedFloor)
        // {
            
        // }
        // //Simulate when a user press a button at the lobby
        // public (Column, Elevator) assignElevator(int requestedFloor, string direction)
        // {
            
        // }
    }
}


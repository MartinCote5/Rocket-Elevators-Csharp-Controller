using System;
using System.Collections.Generic;

namespace Commercial_Controller
{
    public class Battery
    {
        public int ID;
       
        public string status;
        List<Column> columnsList = new List<Column>();
        List<FloorRequestButton> floorRequestButtonsList = new List<FloorRequestButton>();
        public Battery(int id, int amountOfColumns, int amountOfFloors, int amountOfBasements, int amountOfElevatorPerColumn)
        {   
            this.ID = id;
           
            if (amountOfBasements > 0) {
                createBasementFloorRequestButtons(amountOfBasements);
                createBasementColumn(amountOfBasements, amountOfElevatorPerColumn);
                amountOfColumns--;
            } 

            
            createFloorRequestButtons(amountOfFloors);
            
            createColumns(amountOfColumns, amountOfFloors, amountOfElevatorPerColumn);

             



            // Console.WriteLine(ID);
            // Console.WriteLine(amountOfFloors);
            
            // Console.WriteLine(columnsList);
        }



        public void createBasementFloorRequestButtons(int amountOfBasements) {
            int buttonFloor = -1;
            for (int i = 0; i < amountOfBasements; i++) {
                FloorRequestButton floorRequestButton = new FloorRequestButton(buttonFloor,  buttonFloor, "down");    
                floorRequestButtonsList.Add(floorRequestButton);
                buttonFloor--;

                 // public floorRequestButtonID++;   ------------ dont forget this
            }

        }







    






        public void createBasementColumn(int amountOfBasements, int amountOfElevatorPerColumn) {
            List<int> servedFloors = new List<int>();
            int floor = -1;
            


            for (int i = 0; i < amountOfBasements; i++) {
                // Console.WriteLine(floor);
                servedFloors.Add(floor);
                // Console.WriteLine(servedFloors[i]);
                floor--;
        
            }

            Column column = new Column("1", amountOfElevatorPerColumn, servedFloors, true);

            columnsList.Add(column);


            // public columnID++;   ------------ dont forget this
            
            // Console.WriteLine(column);
            // Console.WriteLine(columnsList[0]);
            // Console.WriteLine(columnsList[0].ID);        

        }



        
 
      










        














        public void createColumns(double amountOfColumns, double amountOfFloors, double amountOfElevatorPerColumn) {
            double amountOfFloorsPerColumn = Math.Round(amountOfFloors / amountOfColumns);
            // Console.WriteLine(amountOfFloors); 
            // Console.WriteLine(amountOfColumns); 
            // Console.WriteLine(amountOfFloorsPerColumn);
            int floor = 1;

            for (int i = 0; i < amountOfColumns; i++) {
                List<int> servedFloors = new List<int>();
                // Console.WriteLine(i);
                // Console.WriteLine("big loop");



                for (int i2 = 0; i2 < amountOfFloorsPerColumn; i2++) {
                    if (floor <= amountOfFloors) {
                        servedFloors.Add(floor);
                        floor++;
                        // Console.WriteLine(i2);
                        // Console.WriteLine("smallLoop");

                    }
                }

                Column column = new Column("1", amountOfElevatorPerColumn, servedFloors, false);
                columnsList.Add(column);


                // public columnID++;   ------------ dont forget this


                // Console.WriteLine(column);
                // Console.WriteLine(columnsList[0]);
                // Console.WriteLine(columnsList[1].servedFloors);  

            
            }




        }


      
 


        public void createFloorRequestButtons(int amountOfFloors) {
            int buttonFloor = 1;

            for (int i = 0; i < amountOfFloors; i++) {
                FloorRequestButton floorRequestButton = new FloorRequestButton(buttonFloor,  buttonFloor, "up");    
                floorRequestButtonsList.Add(floorRequestButton);
                buttonFloor++;

                 // public floorRequestButtonID++;   ------------ dont forget this
            }


            
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


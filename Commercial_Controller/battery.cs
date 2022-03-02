using System;
using System.Collections.Generic;

namespace Commercial_Controller
{
    public class IDGenerator 
    {
            public int columnID = 1;
            public int floorRequestButtonID = 1;
            public int doorID = 1;
    } 

    public class Battery
    {
        public IDGenerator generator;
        public int ID;
       
        public string status;
        public List<Column> columnsList = new List<Column>();
        public List<FloorRequestButton> floorRequestButtonsList = new List<FloorRequestButton>();
        public Battery(int id, int amountOfColumns, int amountOfFloors, int amountOfBasements, int amountOfElevatorPerColumn)
        {   
            generator = new IDGenerator();
            Console.WriteLine("create battery");
            this.ID = id;

            if (amountOfBasements > 0) {
                createBasementFloorRequestButtons(amountOfBasements);
                createBasementColumn(amountOfBasements, amountOfElevatorPerColumn);
                amountOfColumns--;
            } 

            createFloorRequestButtons(amountOfFloors);
            createColumns(amountOfColumns, amountOfFloors, amountOfElevatorPerColumn);   
        }



        public void createBasementFloorRequestButtons(int amountOfBasements) {
            int buttonFloor = -1;

            for (int i = 0; i < amountOfBasements; i++) {
                FloorRequestButton floorRequestButton = new FloorRequestButton(generator.floorRequestButtonID,  buttonFloor, "down");    
                floorRequestButtonsList.Add(floorRequestButton);
                buttonFloor--;
                generator.floorRequestButtonID++; 
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

            Column column = new Column(generator.columnID.ToString(), amountOfElevatorPerColumn, servedFloors, true);
            columnsList.Add(column);
            generator.columnID++;        
        }



        





        public void createColumns(decimal amountOfColumns, decimal amountOfFloors, decimal amountOfElevatorPerColumn) {
            decimal amountOfFloorsPerColumn = Math.Ceiling(amountOfFloors / amountOfColumns);
            int floor = 1;

            for (int i = 0; i < amountOfColumns; i++) {
                List<int> servedFloors = new List<int>();
            
                for (int i2 = 0; i2 < amountOfFloorsPerColumn; i2++) {
                    if (floor <= amountOfFloors) {
                        servedFloors.Add(floor);
                        floor++;
                    }
                }

                Column column = new Column(generator.columnID.ToString(), amountOfElevatorPerColumn, servedFloors, false);
                columnsList.Add(column);
                generator.columnID++;   
                
            }

        }


      
 


        public void createFloorRequestButtons(int amountOfFloors) {
            int buttonFloor = 1;

            for (int i = 0; i < amountOfFloors; i++) {
                FloorRequestButton floorRequestButton = new FloorRequestButton(generator.floorRequestButtonID,  buttonFloor, "up");    
                floorRequestButtonsList.Add(floorRequestButton);
                buttonFloor++;

                generator.floorRequestButtonID++;   
            }
    
        }

   
    
        




        public Column findBestColumn(int requestedFloor)
        {
            
                if (requestedFloor < 0) {
                    return this.columnsList[0];
                }
                decimal x = (decimal)requestedFloor / this.columnsList[1].servedFloors.Count;
                int columnIndex = Decimal.ToInt32(Math.Ceiling(x));

                // Console.WriteLine(this.columnsList[1].servedFloors.Count);
                // Console.WriteLine(requestedFloor);
                // Console.WriteLine(columnIndex);

                return this.columnsList[columnIndex];    
        }





        // Simulate when a user press a button at the lobby
        public (Column, Elevator) assignElevator(int requestedFloor, string direction)
        {
            Column column = findBestColumn(requestedFloor);    

            Console.WriteLine(column);

            // The floor is always 1 because that request is always made from the lobby.
            Elevator elevator = column.findElevator(1, direction);

            Console.WriteLine(elevator);

            elevator.addNewRequest(1);

            elevator.move();

            elevator.addNewRequest(requestedFloor);

            elevator.move();            

            return (column, elevator);
        }




        
    }
}









 

 







namespace Commercial_Controller
{
    //Button on a floor or basement to go back to lobby
    public class FloorRequestButton
    {
        public int ID;
        public string status = "OFF";
        public int floor;
        public string direction;

        public FloorRequestButton(int id, int _floor, string _direction)
        {
            ID = id;
            floor = _floor;
            direction = _direction;      
        }
    }
}
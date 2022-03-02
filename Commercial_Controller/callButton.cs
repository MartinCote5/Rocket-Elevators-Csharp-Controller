namespace Commercial_Controller
{
    //Button on a floor or basement to go back to lobby
    public class CallButton
    {
        public int ID;
        public string status;
        public int floor;
        public string direction;
        public CallButton(int id, int floor, string direction)
        {
            this.ID = id;
            this.floor = floor;
            this.direction = direction;

        }
    }
}
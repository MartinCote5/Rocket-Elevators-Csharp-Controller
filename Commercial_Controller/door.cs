namespace Commercial_Controller
{
    public class Door
    {
        public int ID;
        public string status = "closed";
        public Door(int id)
        {
            this.ID = id;
            // Battery.IDGenerator.doorID++;
        
        }
    }
}
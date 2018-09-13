namespace Chronique.Models
{
    public abstract class BaseModel
    {
        public BaseModel()
        {
            Id = ++pId + "";
        }

        private static int pId = 0;
        public string Id { get; set; }
    }
}

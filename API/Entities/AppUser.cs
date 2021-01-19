namespace API.Entities
{
    public class AppUser
    {
        public int Id { get; set; } 
        public string UserName { get; set; }  

        public byte[] PassowrdHash { get; set; } 
        public byte[]  PassowrdSalt { get; set; }   
    }
}
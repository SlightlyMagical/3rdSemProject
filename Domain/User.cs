namespace Domain
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Usertype { get; set; }
        public List<Booking> Bookings { get; set; }
    }
}
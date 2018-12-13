namespace Exercise.EF.DAL.Entities
{
    public class User
    {
        public int UserId { get; set; }
        public string Email { get; set; }

        public static User Create(string email)
        {
            return new User
            {
                Email = email
            };
        }
    }
}

namespace start
{
    public class User
    {
        public string Name { get; set; }
        public string Password { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            User user = obj as User;

            if (user != null)
            {
                return (this.Name == user.Name && this.Password == user.Password);
            }
            else
            {
                return false;
            }
        }
    }
}

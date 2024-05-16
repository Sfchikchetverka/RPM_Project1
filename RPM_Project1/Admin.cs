namespace RPM_Project1
{
    public class Admin
    {
        public int Id { get; set; }
        public string FIO { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Passport { get; set; }
        public Admin() { }
        public Admin(string FIO, string Login, string Password, string Email, string Phone, string Passport)
        {

            this.FIO=FIO;
            this.Login=Login;
            this.Password=Password;
            this.Email=Email;
            this.Phone=Phone;
            this.Passport = Passport;
        }

    }
}

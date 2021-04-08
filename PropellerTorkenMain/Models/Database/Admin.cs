#nullable disable

namespace PropellerTorkenMain.Models.Database
{
    public partial class Admin
    {
        public int Id { get; set; }
        public bool IsAdmin { get; set; }
        public string Password { get; set; }
        public string Username { get; set; }
    }
}
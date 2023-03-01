namespace IES_ADMIN_ACADEM_API.Entities
{
    public class portalLaboral
    {
        private string username;
        private string password;
        private string recovery_quest;
        private string recovery_ans;
        private int deskapp_access;

        public portalLaboral()
        {
        }

        public portalLaboral(string username, string password, string recovery_quest, string recovery_ans, int deskapp_access)
        {
            this.username = username;
            this.password = password;
            this.recovery_quest = recovery_quest;
            this.recovery_ans = recovery_ans;
            this.deskapp_access = deskapp_access;
        }

        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }
        public string Recovery_quest { get => recovery_quest; set => recovery_quest = value; }
        public string Recovery_ans { get => recovery_ans; set => recovery_ans = value; }
        public int Deskapp_access { get => deskapp_access; set => deskapp_access = value; }
    }
}

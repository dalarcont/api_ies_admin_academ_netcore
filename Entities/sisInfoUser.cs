using System;

namespace IES_ADMIN_ACADEM_API.Entities
{
    public class sisInfoUser
    {
        private string user;
        private string appcode;
        private bool permission;
        private string appname;
        private string appdescr;
        private int treelevel;

        public sisInfoUser()
        {
        }

        public sisInfoUser(string user, string appcode, bool permission, string appname, string appdescr, int treelevel)
        {
            this.user = user;
            this.appcode = appcode;
            this.permission = permission;
            this.appname = appname;
            this.appdescr = appdescr;
            this.treelevel = treelevel;
        }

        public string User { get => user; set => user = value; }
        public string Appcode { get => appcode; set => appcode = value; }
        public bool Permission { get => permission; set => permission = value; }
        public string Appname { get => appname; set => appname = value; }
        public string Appdescr { get => appdescr; set => appdescr = value; }
        public int Treelevel { get => treelevel; set => treelevel = value; }
    }
}

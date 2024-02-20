namespace IES_ADMIN_ACADEM_API.Entities
{
    public class uf_appstates
    {
        private string APP_CODE;
        private string APP_STATE;
        private string APP_ST_MSG;
        private string APP_STATE_NOM;

        public uf_appstates() {}

        public uf_appstates(string app_code, string app_state, string app_st_msg, string app_state_nom)
        {
            APP_CODE         = app_code;
            APP_STATE        = app_state;
            APP_ST_MSG       = app_st_msg;
            APP_STATE_NOM    = app_state_nom;
        }

        //Getters and setters
        public string app_CODE      { get => APP_CODE;       set => APP_CODE      = value; }
        public string app_STATE     { get => APP_STATE;      set => APP_STATE     = value; }
        public string app_ST_MSG    { get => APP_ST_MSG;     set => APP_ST_MSG    = value; }
        public string app_STATE_NOM { get => APP_STATE_NOM;  set => APP_STATE_NOM = value; }
    }
}

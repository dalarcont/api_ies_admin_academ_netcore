namespace IES_ADMIN_ACADEM_API.Entities
{
    public class uf_personas
    {
        //Properties as DDBB properties
        private int    PRSN_REG;
        private string PRSN_FEC_REG;
        private string PRSN_ID;
        private string PRSN_NOM;
        private string PRSN_APE;
        private string PRSN_USUARIO;
        private string PRSN_GEN;
        private string PRSN_EMAIL_PERSONAL;
        private string PRSN_EMAIL_LABORAL;
        private string PRSN_ORIGEN_PAIS;
        private string PRSN_ORIGEN_CIUDAD;
        private string PRSN_RESIDE_PAIS;
        private string PRSN_RESIDE_CIUDAD;
        private string PRSN_ESCOLARIDAD;
        private string PRSN_PKEY;
        private string PRSN_RECOVERY_QUEST;
        private string PRSN_RECOVERY_ANS;

        //Custom properties created by the original properties with its codes given
        private string PRSN_GEN_NOM;
        private string PRSN_ORIGEN_PAIS_NOM;
        private string PRSN_RESIDE_PAIS_NOM;
        private string PRSN_ESCOLARIDAD_NOM;

        public uf_personas() { }

        public uf_personas(int prsn_reg, string prsn_fec_reg, string prsn_id, string prsn_nom, string prsn_ape, string prsn_usuario, string prsn_gen, string prsn_email_personal, string prsn_email_laboral, string prsn_origen_pais, string prsn_origen_ciudad, string prsn_reside_pais, string prsn_reside_ciudad, string prsn_escolaridad, string prsn_pkey, string prsn_recovery_quest, string prsn_recovery_ans, string prsn_gen_nom, string prsn_origen_pais_nom, string prsn_reside_pais_nom, string prsn_escolaridad_nom)
        {
            PRSN_REG             = prsn_reg;
            PRSN_FEC_REG         = prsn_fec_reg;
            PRSN_ID              = prsn_id;
            PRSN_NOM             = prsn_nom;
            PRSN_APE             = prsn_ape;
            PRSN_USUARIO         = prsn_usuario;
            PRSN_GEN             = prsn_gen;
            PRSN_EMAIL_PERSONAL  = prsn_email_personal;
            PRSN_EMAIL_LABORAL   = prsn_email_laboral;
            PRSN_ORIGEN_PAIS     = prsn_origen_pais;
            PRSN_ORIGEN_CIUDAD   = prsn_origen_ciudad;
            PRSN_RESIDE_PAIS     = prsn_reside_pais;
            PRSN_RESIDE_CIUDAD   = prsn_reside_ciudad;
            PRSN_ESCOLARIDAD     = prsn_escolaridad;
            PRSN_PKEY            = prsn_pkey;
            PRSN_RECOVERY_QUEST  = prsn_recovery_quest;
            PRSN_RECOVERY_ANS    = prsn_recovery_ans;
            PRSN_GEN_NOM         = prsn_gen_nom;
            PRSN_ORIGEN_PAIS_NOM = prsn_origen_pais_nom;
            PRSN_RESIDE_PAIS_NOM = prsn_reside_pais_nom;
            PRSN_ESCOLARIDAD_NOM = prsn_escolaridad_nom;
        }

        public int    prsn_REG              { get => PRSN_REG;              set => PRSN_REG              = value; }
        public string prsn_FEC_REG          { get => PRSN_FEC_REG;          set => PRSN_FEC_REG          = value; }
        public string prsn_ID               { get => PRSN_ID;               set => PRSN_ID               = value; }
        public string prsn_NOM              { get => PRSN_NOM;              set => PRSN_NOM              = value; }
        public string prsn_APE              { get => PRSN_APE;              set => PRSN_APE              = value; }
        public string prsn_USUARIO          { get => PRSN_USUARIO;          set => PRSN_USUARIO          = value; }
        public string prsn_GEN              { get => PRSN_GEN;              set => PRSN_GEN              = value; }
        public string prsn_EMAIL_PERSONAL   { get => PRSN_EMAIL_PERSONAL;   set => PRSN_EMAIL_PERSONAL   = value; }
        public string prsn_EMAIL_LABORAL    { get => PRSN_EMAIL_LABORAL;    set => PRSN_EMAIL_LABORAL    = value; }
        public string prsn_ORIGEN_PAIS      { get => PRSN_ORIGEN_PAIS;      set => PRSN_ORIGEN_PAIS      = value; }
        public string prsn_ORIGEN_CIUDAD    { get => PRSN_ORIGEN_CIUDAD;    set => PRSN_ORIGEN_CIUDAD    = value; }
        public string prsn_RESIDE_PAIS      { get => PRSN_RESIDE_PAIS;      set => PRSN_RESIDE_PAIS      = value; }
        public string prsn_RESIDE_CIUDAD    { get => PRSN_RESIDE_CIUDAD;    set => PRSN_RESIDE_CIUDAD    = value; }
        public string prsn_ESCOLARIDAD      { get => PRSN_ESCOLARIDAD;      set => PRSN_ESCOLARIDAD      = value; }
        public string prsn_PKEY             { get => PRSN_PKEY;             set => PRSN_PKEY             = value; }
        public string prsn_RECOVERY_QUEST   { get => PRSN_RECOVERY_QUEST;   set => PRSN_RECOVERY_QUEST   = value; }
        public string prsn_RECOVERY_ANS     { get => PRSN_RECOVERY_ANS;     set => PRSN_RECOVERY_ANS     = value; }
        public string prsn_GEN_NOM          { get => PRSN_GEN_NOM;          set => PRSN_GEN_NOM          = value; }
        public string prsn_ORIGEN_PAIS_NOM  { get => PRSN_ORIGEN_PAIS_NOM;  set => PRSN_ORIGEN_PAIS_NOM  = value; }
        public string prsn_RESIDE_PAIS_NOM  { get => PRSN_RESIDE_PAIS_NOM;  set => PRSN_RESIDE_PAIS_NOM  = value; }
        public string prsn_ESCOLARIDAD_NOM  { get => PRSN_ESCOLARIDAD_NOM;  set => PRSN_ESCOLARIDAD_NOM  = value; }
    }
}

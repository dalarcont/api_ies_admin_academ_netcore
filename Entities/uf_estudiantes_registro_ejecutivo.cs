namespace IES_ADMIN_ACADEM_API.Entities
{
    public class uf_estudiantes_registro_ejecutivo
    {
        private int    REG_NUM;
        private string COD_ESTUDIANTE;
        private string FEC_REG;
        private string REG_APPSET;
        private string REG_ACTION_DESCR;
        //Public constructor
        public uf_estudiantes_registro_ejecutivo() { }

        //Class constructor with values
        public uf_estudiantes_registro_ejecutivo(int reg_num, string cod_estudiante, string fec_reg, string reg_appset, string reg_action_descr)
        {
            REG_NUM          = reg_num;
            COD_ESTUDIANTE   = cod_estudiante;
            FEC_REG          = fec_reg;
            REG_APPSET       = reg_appset;
            REG_ACTION_DESCR = reg_action_descr;
        }

        //Getters and setters
        public int    reg_NUM            { get => REG_NUM;           set => REG_NUM          = value; }
        public string cod_ESTUDIANTE     { get => COD_ESTUDIANTE;    set => COD_ESTUDIANTE   = value; }
        public string fec_REG            { get => FEC_REG;           set => FEC_REG          = value; }
        public string reg_APPSET         { get => REG_APPSET;        set => REG_APPSET       = value; }
        public string reg_ACTION_DESCR   { get => REG_ACTION_DESCR;  set => REG_ACTION_DESCR = value; }

    }
}

namespace IES_ADMIN_ACADEM_API.Entities
{
    public class uf_registro_ejecutivo
    {
        private int REG_NUM;
        private string COD_EMPLEADO;
        private string FEC_REG;
        private string REG_APPSET;
        private string REG_ACTION_DESCR;
        //Public constructor
        public uf_registro_ejecutivo() { }

        //Class constructor with values
        public uf_registro_ejecutivo(int REG_NUM, string COD_EMPLEADO, string FEC_REG, string REG_APPSET, string REG_ACTION_DESCR)
        {
            this.REG_NUM          = REG_NUM;
            this.COD_EMPLEADO     = COD_EMPLEADO;
            this.FEC_REG          = FEC_REG;
            this.REG_APPSET       = REG_APPSET;
            this.REG_ACTION_DESCR = REG_ACTION_DESCR;
        }

        //Getters and setters
        public int    reg_NUM          { get => REG_NUM;          set => REG_NUM          = value; }
        public string cod_EMPLEADO     { get => COD_EMPLEADO;     set => COD_EMPLEADO     = value; }
        public string fec_REG          { get => FEC_REG;          set => FEC_REG          = value; }
        public string reg_APPSET       { get => REG_APPSET;       set => REG_APPSET       = value; }
        public string reg_ACTION_DESCR { get => REG_ACTION_DESCR; set => REG_ACTION_DESCR = value; }

    }
}

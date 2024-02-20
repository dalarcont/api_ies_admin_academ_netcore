using System;

namespace IES_ADMIN_ACADEM_API.Entities
{
    public class uf_personas_empleado : uf_personas
    {
        private string COD_UNIDAD;
        private string COD_AREA;
        private string COD_CARGO;
        private string COD_TIPO_PERSONAL;
        private string ESTADO_DISCIPLINARIO;
        private string MCA_VACACIONES;
        private bool   MCA_CARGO_PRINCIPAL;
        private bool   PERMISO_ACCESO;
        private string FEC_ULTIMO_ACCESO;

        //Custom properties created by the original properties with its codes given
        private string NOM_UNIDAD;
        private string NOM_AREA;
        private string NOM_CARGO;
        private string NOM_CARGO_NIVEL;
        private string NOM_TIPO_PERSONAL;
        private string NOM_ESTADO_DISCIPLINARIO;
        private string NOM_MCA_VACACIONES;

        public uf_personas_empleado() { }

        public uf_personas_empleado(string cod_unidad, string cod_area, string cod_cargo, string cod_tipo_personal, string estado_disciplinario, string mca_vacaciones, bool mca_cargo_principal, bool permiso_acceso, string fec_ultimo_acceso, string nom_unidad, string nom_area, string nom_cargo, string nom_cargo_nivel, string nom_tipo_personal, string nom_estado_disciplinario, string nom_mca_vacaciones)
        {
            COD_UNIDAD               = cod_unidad;
            COD_AREA                 = cod_area;
            COD_CARGO                = cod_cargo;
            COD_TIPO_PERSONAL        = cod_tipo_personal;
            ESTADO_DISCIPLINARIO     = estado_disciplinario;
            MCA_VACACIONES           = mca_vacaciones;
            MCA_CARGO_PRINCIPAL      = mca_cargo_principal;
            PERMISO_ACCESO           = permiso_acceso;
            FEC_ULTIMO_ACCESO        = fec_ultimo_acceso;
            NOM_UNIDAD               = nom_unidad;
            NOM_AREA                 = nom_area;
            NOM_CARGO                = nom_cargo;
            NOM_CARGO_NIVEL          = nom_cargo_nivel;
            NOM_TIPO_PERSONAL        = nom_tipo_personal;
            NOM_ESTADO_DISCIPLINARIO = nom_estado_disciplinario;
            NOM_MCA_VACACIONES       = nom_mca_vacaciones;
        }

        public string cod_UNIDAD                 { get => COD_UNIDAD;                set => COD_UNIDAD               = value; }
        public string cod_AREA                   { get => COD_AREA;                  set => COD_AREA                 = value; }
        public string cod_CARGO                  { get => COD_CARGO;                 set => COD_CARGO                = value; }
        public string cod_TIPO_PERSONAL          { get => COD_TIPO_PERSONAL;         set => COD_TIPO_PERSONAL        = value; }
        public string estado_DISCIPLINARIO       { get => ESTADO_DISCIPLINARIO;      set => ESTADO_DISCIPLINARIO     = value; }
        public string mca_VACACIONES             { get => MCA_VACACIONES;            set => MCA_VACACIONES           = value; }
        public bool   mca_CARGO_PRINCIPAL        { get => MCA_CARGO_PRINCIPAL;       set => MCA_CARGO_PRINCIPAL      = value; }
        public bool   permiso_ACCESO             { get => PERMISO_ACCESO;            set => PERMISO_ACCESO           = value; }
        public string fec_ULTIMO_ACCESO          { get => FEC_ULTIMO_ACCESO;         set => FEC_ULTIMO_ACCESO        = value; }
        public string nom_UNIDAD                 { get => NOM_UNIDAD;                set => NOM_UNIDAD               = value; }
        public string nom_AREA                   { get => NOM_AREA;                  set => NOM_AREA                 = value; }
        public string nom_CARGO                  { get => NOM_CARGO;                 set => NOM_CARGO                = value; }
        public string nom_CARGO_NIVEL            { get => NOM_CARGO_NIVEL;           set => NOM_CARGO_NIVEL          = value; }
        public string nom_TIPO_PERSONAL          { get => NOM_TIPO_PERSONAL;         set => NOM_TIPO_PERSONAL        = value; }
        public string nom_ESTADO_DISCIPLINARIO   { get => NOM_ESTADO_DISCIPLINARIO;  set => NOM_ESTADO_DISCIPLINARIO = value; }
        public string nom_MCA_VACACIONES         { get => NOM_MCA_VACACIONES;        set => NOM_MCA_VACACIONES       = value; }
    }
}

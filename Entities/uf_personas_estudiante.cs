using System;

namespace IES_ADMIN_ACADEM_API.Entities
{
    public class uf_personas_estudiante : uf_personas
    {
        private string FEC_PRIMER_MATRICULA;
        private string FEC_ULTIMA_MATRICULA;
        private int    COD_ULTIMO_PROGRAMA_MATRICULADO;
        private string ESTADO_DISCIPLINARIO;
        private string ESTADO_ACADEMICO_GENERAL;
        private bool   PERMISO_ACCESO;
        private string FEC_ULTIMO_ACCESO;

        //Custom properties created by the original properties with its codes given
        private string NOM_ESTADO_DISCIPLINARIO;
        private string NOM_ESTADO_ACADEMICO_GENERAL;

        public uf_personas_estudiante() { }

        public uf_personas_estudiante(string fec_primer_matricula, string fec_ultima_matricula, int cod_ultimo_programa_matriculado, string estado_disciplinario, string estado_academico_general, bool permiso_acceso, string fec_ultimo_acceso, string nom_estado_disciplinario, string nom_estado_academico_general)
        {
            FEC_PRIMER_MATRICULA            = fec_primer_matricula;
            FEC_ULTIMA_MATRICULA            = fec_ultima_matricula;
            COD_ULTIMO_PROGRAMA_MATRICULADO = cod_ultimo_programa_matriculado;
            ESTADO_DISCIPLINARIO            = estado_disciplinario;
            ESTADO_ACADEMICO_GENERAL        = estado_academico_general;
            PERMISO_ACCESO                  = permiso_acceso;
            FEC_ULTIMO_ACCESO               = fec_ultimo_acceso;
            NOM_ESTADO_DISCIPLINARIO        = nom_estado_disciplinario;
            NOM_ESTADO_ACADEMICO_GENERAL    = nom_estado_academico_general;
        }

        public string fec_PRIMER_MATRICULA              { get => FEC_PRIMER_MATRICULA;            set => FEC_PRIMER_MATRICULA            = value; }
        public string fec_ULTIMA_MATRICULA              { get => FEC_ULTIMA_MATRICULA;            set => FEC_ULTIMA_MATRICULA            = value; }
        public int    cod_ULTIMO_PROGRAMA_MATRICULADO   { get => COD_ULTIMO_PROGRAMA_MATRICULADO; set => COD_ULTIMO_PROGRAMA_MATRICULADO = value; }
        public string estado_DISCIPLINARIO              { get => ESTADO_DISCIPLINARIO;            set => ESTADO_DISCIPLINARIO            = value; }
        public string estado_ACADEMICO_GENERAL          { get => ESTADO_ACADEMICO_GENERAL;        set => ESTADO_ACADEMICO_GENERAL        = value; }
        public bool   permiso_ACCESO                    { get => PERMISO_ACCESO;                  set => PERMISO_ACCESO                  = value; }
        public string fec_ULTIMO_ACCESO                 { get => FEC_ULTIMO_ACCESO;               set => FEC_ULTIMO_ACCESO               = value; }
        public string nom_ESTADO_DISCIPLINARIO          { get => NOM_ESTADO_DISCIPLINARIO;        set => NOM_ESTADO_DISCIPLINARIO        = value; }
        public string nom_ESTADO_ACADEMICO_GENERAL      { get => NOM_ESTADO_ACADEMICO_GENERAL;    set => NOM_ESTADO_ACADEMICO_GENERAL    = value; }
    }
}

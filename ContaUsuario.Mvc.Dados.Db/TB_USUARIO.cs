namespace ContaUsuario.Mvc.Dados.Db
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TB_USUARIO
    {
        [StringLength(14)]
        public string CPF { get; set; }

        [StringLength(128)]
        public string EMAIL { get; set; }

        [StringLength(128)]
        public string NOME { get; set; }

        [StringLength(128)]
        public string SENHA { get; set; }

        [StringLength(128)]
        public string CONFIRMA_SENHA { get; set; }

        public int ID { get; set; }
    }
}

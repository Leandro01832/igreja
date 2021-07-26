using database.banco;
using System.Collections.Generic;
using System.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlClient;
using System;

using database;

namespace business.classes.Ministerio
{
    [Table("Supervisor_Ministerio_Treinamento")]
    public class Supervisor_Ministerio_Treinamento : Abstrato.Ministerio
    {
        [Display(Name = "Máximo de celulas para supervisionar")]
        public int Maximo_celula { get; set; }

        public Supervisor_Ministerio_Treinamento() : base()
        {
            this.Maximo_celula = 5;
        }

        public Supervisor_Ministerio_Treinamento(int m) : base(m) { }

        public override string alterar(int id)
        {
            base.alterar(id);
            UpdateProperties(null, id);
            Update_padrao += BDcomum.addNaLista;
            bd.Editar(this);
            return Update_padrao;
        }

        public override string excluir(int id)
        {
            Delete_padrao += base.excluir(id);
            bd.Excluir(this);
            return Delete_padrao;
        }

        public override bool recuperar(int id)
        {
            if (SetProperties(GetType()))
            {
                base.recuperar(id); T = GetType(); return true;
            }
            return false;
        }
        
        public override string salvar()
        {
            base.salvar();
            GetProperties(null);
            Insert_padrao += BDcomum.addNaLista;
            bd.SalvarModelo(this);
            return Insert_padrao;
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using database;
using database.banco;

namespace business.classes.Ministerio
{
    [Table("Lider_Ministerio")]
    public class Lider_Ministerio : Abstrato.Ministerio
    {
        public Lider_Ministerio() : base()
        {
        }

        public Lider_Ministerio(int m) : base(m) { }

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

using database;
using System;
using System.Collections.Generic;

namespace business
{
    public class Permissao : modelocrud
    {
        public Permissao():base()
        {
            if (!EntityCrud)
            {
                Categoria = new Categoria();
                PermissaoPessoa = new List<PermissaoPessoa>();
            }
        }

        private string nome;
        public string Nome
        {
            get
            {
                if (string.IsNullOrEmpty(nome)) throw new Exception("Nome é um campo obrigatório");
                return nome;
            }
            set { nome = value; }
        }
        public virtual List<PermissaoPessoa> PermissaoPessoa { get; set; }

        public virtual Categoria Categoria { get; set; }

        public override string ToString()
        {
            return this.Id + " - " + this.Nome;
        }
    }
}
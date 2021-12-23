using business.classes.Abstrato;
using business.contrato;
using database;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace business.implementacao
{
    [Table("MudancaEstado")]
    public class MudancaEstado : modelocrud, IMudancaEstado
    {
        public string velhoEstado { get; set; }
        public string novoEstado { get; set; }
        public DateTime Data { get; set; }
        public int Codigo { get; set; }

        public MudancaEstado() : base()
        {
            this.Data = DateTime.Now;
        }

        public void MudarEstado(int idVelhoEstado, modelocrud m)
        {
            string estado = "";

            modelocrud p = null;

            if (m is Pessoa)
                p = buscarConcreto(typeof(Pessoa), idVelhoEstado);
            if (m is Ministerio)
                p = buscarConcreto(typeof(Ministerio), idVelhoEstado);
            estado = p.GetType().Name;

            p.excluir(idVelhoEstado, "", true, 4);

            var propsList = m.GetType().GetProperties().Where(pro => pro.PropertyType.Name == "List`1").ToList();

            foreach (var item in propsList)
                item.SetValue(m, item.GetValue(p));
            m.Id = 0;
            try
            {
                m.salvar("", true, 4);
            }
            catch (Exception ex)
            {
                p.Insert_padrao += "92sfgg  75293845";
                p.salvar("", true, 4);
                throw new Exception(ex.Message);
            }

            new MudancaEstado
            {
                novoEstado = m.GetType().Name,
                velhoEstado = estado,
                Data = DateTime.Now,
                Codigo = (int) m.GetType().GetProperty("Codigo").GetValue(m)
            }.salvar();

        }

        public override string ToString()
        {
            return "ID da mudança: " + Id.ToString() + $" ID da entidade {modelocrud.ReturnBase(GetType()).Name}: " +
            this.Codigo;
        }
    }
}

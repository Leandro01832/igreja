using System;

namespace WindowsFormsApp1
{
    public class OpcoesButtonBase : Attribute
    {
        public string Tipo { get; set; }
        public bool Dados { get; set; }
        public bool Formatar { get; set; }
    }
}
using System;
using System.Reflection;

namespace business.contrato
{
    interface IPropertiesCrud 
    {
        bool   SetProperties(Type tipo);
        string DeleteProperties(Type tipo);
        void   GetProperties(Type tipo);
        void   UpdateProperties(Type tipo);
    }
}

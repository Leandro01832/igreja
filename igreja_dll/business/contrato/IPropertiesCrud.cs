using System;
using System.Reflection;

namespace business.contrato
{
    interface IPropertiesCrud 
    {
        bool   SetProperties(Type tipo);
        string DeleteProperties(Type tipo);
        string VerficaPropertyClassDeleteProperties(Type type);
        void   VerficaPropertyClassSetProperties(Type tipo);
        void   GetProperties(Type tipo);
        void   VerficaPropertyClassInsertProperties(Type type);
        void   UpdateProperties(Type tipo);
        void   VerficaPropertyClassUpdateProperties(Type type, int id);
        string VerificaProperties(string values, PropertyInfo property, string classe, object objeto);
        string VerificaUpdateProperties(PropertyInfo property, object objeto);
    }
}

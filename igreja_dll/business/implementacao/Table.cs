using business.contrato;
using database;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;

namespace business.implementacao
{
    class Table : ITable
    {
        public void CreateTable(Type tipo)
        {
            string comando = $"CREATE TABLE {tipo.Name} (";
            foreach (var item in tipo.GetProperties())
            {

                if(item.Name == "Id" && tipo.BaseType == typeof(modelocrud))
                comando += $" {item.Name} INT IDENTITY (1, 1) NOT NULL,  ";
                if (item.Name == "Id" && tipo.BaseType == typeof(modelocrud))
                comando += $" {item.Name} INT NOT NULL,  ";
                else if(item.PropertyType == typeof(string))
                comando += $" {item.Name} NVARCHAR (MAX) NULL,  ";
                else if(item.PropertyType == typeof(int?))
                comando += $" {item.Name} INT NULL, ";
                else if (item.PropertyType == typeof(int))
                comando += $" {item.Name} INT NOT NULL, ";
                else if(item.PropertyType == typeof(long))
                comando += $" {item.Name} BIGINT NOT NULL, ";
                else if (item.PropertyType == typeof(long?))
                comando += $" {item.Name} BIGINT NULL, ";
                else if (item.PropertyType == typeof(double))
                comando += $" {item.Name} FLOAT (53) NOT NULL, ";
                else if (item.PropertyType == typeof(double?))
                comando += $" {item.Name} FLOAT (53) NULL, ";
                else if (item.PropertyType == typeof(DateTime))
                comando += $" {item.Name} DATETIME NOT NULL, ";
                else if (item.PropertyType == typeof(DateTime?))
                comando += $" {item.Name} DATETIME NULL, ";
                else if (item.PropertyType == typeof(TimeSpan))
                comando += $" {item.Name} TIME (7) NOT NULL, ";
                else if (item.PropertyType == typeof(TimeSpan?))
                comando += $" {item.Name} TIME (7) NULL, ";
                else if (item.PropertyType == typeof(bool))
                comando += $" {item.Name} BIT NOT NULL, ";

                ForeignKeyAttribute opcForeignKey = (ForeignKeyAttribute)item.GetCustomAttribute(typeof(ForeignKeyAttribute));
                if (opcForeignKey != null)
                {
                    PropertyInfo prop = null;
                    foreach (var i in tipo.GetProperties())
                    if (i.Name.Contains(item.Name))
                    prop = i;
                comando += $"CONSTRAINT [FK_dbo.{tipo.Name}_dbo.{item.Name}_{prop.Name}] FOREIGN KEY ([{prop.Name}]) " +
                        $" REFERENCES [dbo].[{item.Name}] ([Id]) ";
                }
                
                if (tipo.BaseType == typeof(modelocrud))
                comando += $" CONSTRAINT [FK_dbo.{tipo.Name}_dbo.{tipo.BaseType.Name}_Id]" +
                    $" FOREIGN KEY ([Id]) REFERENCES [dbo].[{tipo.BaseType.Name}] ([Id]), ";

                comando += $"CONSTRAINT [PK_dbo.{tipo.Name}] PRIMARY KEY CLUSTERED ([Id] ASC)";

                comando += " ); ";

                OpcoesBase opc = (OpcoesBase)item.GetCustomAttribute(typeof(OpcoesBase));
                if(opc != null && opc.Index)
                {
                    comando += $"GO CREATE UNIQUE NONCLUSTERED INDEX [{item.Name}] ON {tipo.Name} ([{item.Name}] ASC);";
                }
            }
        }

        public void DeleteTable(Type tipo)
        {
            throw new NotImplementedException();
        }
    }
}

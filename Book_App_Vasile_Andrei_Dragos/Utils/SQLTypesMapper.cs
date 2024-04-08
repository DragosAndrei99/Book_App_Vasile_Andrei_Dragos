using System.Data;
using System;
using System.Collections.Generic;


namespace Book_App_Vasile_Andrei_Dragos.Utils
{
    public class SQLTypesMapper
    {
        private Dictionary<Type, SqlDbType> typeMap;

        public SQLTypesMapper()
        {
            InitializeTypeMap();
        }

        private void InitializeTypeMap()
        {
            typeMap = new Dictionary<Type, SqlDbType>();

            typeMap[typeof(int)] = SqlDbType.Int;
            typeMap[typeof(string)] = SqlDbType.NVarChar;
            typeMap[typeof(DateTime)] = SqlDbType.DateTime;
            typeMap[typeof(float)] = SqlDbType.Float;
            typeMap[typeof(double)] = SqlDbType.Float;
            typeMap[typeof(decimal)] = SqlDbType.Decimal;
            typeMap[typeof(bool)] = SqlDbType.Bit;
            typeMap[typeof(byte[])] = SqlDbType.VarBinary;
            typeMap[typeof(Guid)] = SqlDbType.UniqueIdentifier;
        }

        public SqlDbType MapToSqlType(Type type)
        {
            if (typeMap.ContainsKey(type))
            {
                return typeMap[type];
            }
            else
            {
                throw new ArgumentException($"Type {type.FullName} has no mapping to SqlDbType.");
            }
        }
    }
}

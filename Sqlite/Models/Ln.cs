using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Web;

namespace Sqlite.Models
{
    public class Ln
    {
        public Cliente FindClient(string ruc)
        {
            Cliente cliente = null;
            using (var d = SqliteData.GetInstance())
            {
                var sql = String.Format("select * from Cliente where Ruc={0}", ruc);
                using (var command = new SQLiteCommand(sql, d))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            cliente = new Cliente();
                            cliente.Ruc = reader["Ruc"].ToString();
                            cliente.Logo = reader["Logo"].ToString();
                            cliente.Firma = reader["Firma"].ToString();
                        }
                    }

                }
            }
            return cliente;
        }

        public void RegisterClient(Cliente cliente)
        {
            var c=FindClient(cliente.Ruc);
            if (c == null) { AddClient(cliente); return; }
            UpdateClient(cliente);

        }
        void AddClient(Cliente cliente) {
            using (var d = SqliteData.GetInstance())
            {
                var sql = String.Format(@"insert into Cliente(Ruc,Logo,Firma)
                                        values('{0}','{1}','{2}')",cliente.Ruc,cliente.Logo,cliente.Firma);
                using (var command = new SQLiteCommand(sql, d))
                {
                    command.ExecuteReader();
                }
            }

        }
        void UpdateClient(Cliente cliente) {
            using (var d = SqliteData.GetInstance())
            {
                var sql = String.Format(@"update Cliente set Logo='{0}',Firma='{1}'
                                        where Ruc='{2}'",cliente.Logo, cliente.Firma, cliente.Ruc);
                using (var command = new SQLiteCommand(sql, d))
                {
                    command.ExecuteReader();
                }
            }
        }
    }
}
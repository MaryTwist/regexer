using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using General;

namespace RegExer.API.Models
{

    public class DbHelperConfigException : Exception
    {
        public DbHelperConfigException(Exception ex)
            : base("Не удалось считать файл конфигурации", ex)
        { }
    }

    public static class DbHelper
    {
        private static string ConnString;

        static DbHelper()
        {
            try
            {
                ConnString = ConfigurationManager.ConnectionStrings["DbContext"].ConnectionString;
            }
            catch (Exception ex)
            {
                throw new DbHelperConfigException(ex);
            }
        }

        public static IEnumerable<Script> GetScripts()
        {
            var dbc = new SqlDbClient(ConnString);

            return dbc.GetQuery(cmd =>
            {
                cmd.CommandText = "sp_getScripts";
                cmd.CommandType = CommandType.StoredProcedure;
            })
            .AsEnumerable()
            .Select(s => new Script(s));
        }

        public static Script GetScript(int scriptId)
        {
            var dbc = new SqlDbClient(ConnString);

            return dbc.GetQuery(cmd =>
            {
                cmd.CommandText = "sp_getScript";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@scriptId", scriptId));
            })
            .AsEnumerable()
            .Select(s => new Script(s))
            .FirstOrDefault();
        }

        public static int AddScript(Script s)
        {
            var dbc = new SqlDbClient(ConnString);

            return dbc.GetScalar<int>(cmd =>
            {
                cmd.CommandText = "sp_AddScript";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@name", s.Name));
                cmd.Parameters.Add(new SqlParameter("@description", s.Description));
                cmd.Parameters.Add(new SqlParameter("@searchPattern", s.SearchPattern));
                cmd.Parameters.Add(new SqlParameter("@replacePattern", s.ReplacePattern));
            });
        }

        public static void UpdateScript(int id, Script s)
        {
            var dbc = new SqlDbClient(ConnString);

            dbc.GetNonQuery(cmd =>
            {
                cmd.CommandText = "sp_updateScript";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@scriptId", id));
                cmd.Parameters.Add(new SqlParameter("@name", s.Name));
                cmd.Parameters.Add(new SqlParameter("@description", s.Description));
                cmd.Parameters.Add(new SqlParameter("@searchPattern", s.SearchPattern));
                cmd.Parameters.Add(new SqlParameter("@replacePattern", s.ReplacePattern));
            });
        }

        public static void DeleteScript(int scriptId)
        {
            var dbc = new SqlDbClient(ConnString);

            dbc.GetNonQuery(cmd =>
            {
                cmd.CommandText = "sp_deleteScript";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@scriptId", scriptId));
            });
        }
    }
}
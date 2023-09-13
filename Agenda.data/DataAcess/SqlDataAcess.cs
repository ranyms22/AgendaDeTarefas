using Microsoft.Extensions.Configuration;
using Dapper;
using System.Data;
using System.Collections.Generic;
using System.Threading.Tasks;
using Npgsql;
using System;
using System.Drawing;

namespace Agenda.data.DataAcess
{
    public class SqlDataAcess : ISqlDataAccess
    {
        private readonly IConfiguration _config;

        public SqlDataAcess(IConfiguration config)
        {
            _config = config;
        }

        public async Task<IEnumerable<T>> GetData<T, P>(string sqlCommand, P parameters, string connectionId = "conn")
        {
            try
            {
                using IDbConnection connection = new NpgsqlConnection(_config.GetConnectionString(connectionId));

                return await connection.QueryAsync<T>(sqlCommand, parameters, commandType: CommandType.Text);
            }
            catch(Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message.ToString());
            }

            return null;
        }

        public async Task SaveData<T>(string spName, T parameters, string connectionId = "conn") 
        {
            try
            {
                using IDbConnection connection = new NpgsqlConnection(_config.GetConnectionString(connectionId));
                await connection.ExecuteAsync(spName, parameters, commandType: CommandType.Text);
            }
            catch(Exception ex) 
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(ex.Message.ToString());
            }
        }
    }
}
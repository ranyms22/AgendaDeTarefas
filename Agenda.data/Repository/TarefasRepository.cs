
using Agenda.data.DataAcess;
using Agenda.data.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Agenda.data.Repository

{
    
    public class TarefasRepository : ITarefasRepository
    {
        private readonly ISqlDataAccess _db;


        public TarefasRepository(ISqlDataAccess db)
        {
            _db = db;
        }

        public async Task<bool> CriarAsync(Tarefas tarefas)
        {
            try
            {
                string query = "INSERT INTO tarefas (titulo, descricao, Data, prioridade, finalizada, hora_inicio, hora_fim) " +
                               "VALUES (@titulo, @descricao, @Data, @prioridade, @finalizada, @hora_inicio, @hora_fim)";

                await _db.SaveData(query, new
                {
                    tarefas.Titulo,
                    tarefas.Descricao,
                    tarefas.Data,
                    tarefas.Prioridade,
                    tarefas.Finalizada,
                    tarefas.hora_inicio,
                    tarefas.hora_fim
                });

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> EditarAsync(Tarefas tarefas)
        {
            try
            {
                await _db.SaveData("UPDATE tarefas SET titulo = @titulo,descricao = @descricao,data = @data, prioridade = @prioridade,finalizada = @finalizada,hora_inicio = @hora_inicio,hora_fim = @hora_fim WHERE id = @id;", tarefas);
                return true;
            }

            catch (Exception ex)
            {
                return false;
            }

        }

        public async Task<bool> DeletarAsync(int id)
        {
            try
            {
                await _db.SaveData(" DELETE FROM tarefas t WHERE t.id = @id;", new {Id= id});
                return true;
            }

            catch (Exception ex)
            {
                return false;
            }

        }

        public async Task<Tarefas?> GetTarefasAsync(int id)
        {
            IEnumerable<Tarefas> result = await _db.GetData<Tarefas, dynamic>
                ("select * from tarefas where id = @id", new { Id = id });
            return result.FirstOrDefault();
        }

    public async Task<IEnumerable<Tarefas>> ListarAsync()
        {
            string query = "SELECT * FROM tarefas";
            var tarefas = await _db.GetData<Tarefas, dynamic>(query, new { });
            
            return tarefas;
        }


    }
}

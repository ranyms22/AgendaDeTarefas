using Agenda.data.Models.Domain;
using Agenda.data.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Agenda.Controllers
{
    public class AgendaController : Controller
    {
        private readonly ITarefasRepository _tarefasRepo;
        public AgendaController(ITarefasRepository tarefasRepo) 
        {
            _tarefasRepo = tarefasRepo;
        }

        #region Create


        public async Task<IActionResult> Criar()
        {
            return View();
        }

        public async Task<IActionResult> Estatistica()
        {
            {
                var tasks = await _tarefasRepo.ListarAsync();

                return View(tasks.OrderByDescending(x => x.Data));
            }
        }


        [HttpPost]
        public async Task<IActionResult> SalvarTarefa(Tarefas tarefas)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View(tarefas);

                if (tarefas.Data.Year < DateTime.Now.Year || tarefas.Data.Month < DateTime.Now.Month || tarefas.Data.Day < DateTime.Now.Day)
                    throw new Exception("Data inválida");

                    if (tarefas.hora_inicio > tarefas.hora_fim)
                    throw new Exception("Hora inválida");

                if (tarefas.hora_fim.Hour - tarefas.hora_inicio.Hour > 5)
                    throw new Exception("Tarefa deve ter menos de 5 hora de duração");
              
                bool criarTarefa = await _tarefasRepo.CriarAsync(tarefas);
                if (criarTarefa)
                    TempData["msg"] = "Tarefa adicionada com sucesso";
                else
                   TempData["msg"] = "Tarefa não adicionada";
            }
            catch (Exception ex)
            {
                TempData["msg"] = 
                     ex.Message;
            }
            return RedirectToAction(nameof(Listar));
        }
        #endregion

        #region Read
        public async Task<IActionResult> Listar()
        
        {
            var tasks = await _tarefasRepo.ListarAsync();

            return View(tasks.OrderByDescending(x => x.Data));
        }
        #endregion

        #region Update
        public async Task<IActionResult> Editar(int id)
        {
            if (id == 0)
            {
                TempData["msg"] = "Tarefa não encontrada.";

                return RedirectToAction("Listar");
            }

            var task = await _tarefasRepo.GetTarefasAsync(id);
            return View(task);
        }

        [HttpPost]
        public async Task<IActionResult> EditarTarefa(Tarefas tarefas)
        { 
           try
           {   
                if (!ModelState.IsValid)
                    return RedirectToAction("Editar", tarefas.Id);

                if (tarefas.Data.Year < DateTime.Now.Year || tarefas.Data.Month < DateTime.Now.Month || tarefas.Data.Day < DateTime.Now.Day)
                    throw new Exception("Data inválida");

                if (tarefas.hora_inicio > tarefas.hora_fim)
                    throw new Exception("Hora inválida");

                if (tarefas.hora_fim.Hour - tarefas.hora_inicio.Hour > 5)
                    throw new Exception("Tarefa deve ter menos de 5 hora de duração");

               var tarefaEditada = await _tarefasRepo.EditarAsync(tarefas);
                    if (tarefaEditada)
                        TempData["msg"] = "Editada com sucesso";
                    else
                        TempData["msg"] = "Não pode ser editada";

           }
           catch (Exception ex)
           {
                TempData["msg"] = ex.Message;
           }
           
            return RedirectToAction("Listar");
        }
        #endregion

        #region Delete
        public async Task<IActionResult> Excluir(int id)
        {
            var deleteTask = await _tarefasRepo.DeletarAsync(id);
            return RedirectToAction(nameof(Listar));
        }
        #endregion

    }
}

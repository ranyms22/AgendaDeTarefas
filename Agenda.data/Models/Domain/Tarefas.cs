

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Agenda.data.Models.Domain
{
    public class Tarefas
    {
        [Required]
        public int Id { get; set; }
        
        [Required]
        public string Titulo { get; set; }

        [Required]
        public string Descricao { get; set; }

        [Required]
        public DateTime Data { get; set; }

        [Required]
        public DateTime hora_inicio { get; set; }

        [Required]
        public DateTime hora_fim { get; set; }

        [Required]
        public PrioridadeEnum Prioridade { get; set; }

        [Required]
        public bool Finalizada { get; set; }

        public string FinalizadaComoTexto
        {
            get { return Finalizada ? "Sim" : "Não"; }
        }
        public enum PrioridadeEnum 
        {
            Alta = 1,
            Média = 2,
            Baixa = 3
        }
    }
}

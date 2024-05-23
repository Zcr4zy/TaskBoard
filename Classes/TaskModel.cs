using System;
using System.ComponentModel.DataAnnotations;

namespace Classes
{
    public record TaskModel
    {
        [Key]
        public int TaskId { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime? DataLimite { get; set; }
        public bool IsComplete { get; set; }
        public NivelPrioridade Prioridade { get; set; }
    }
}

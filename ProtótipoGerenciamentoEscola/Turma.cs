using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtótipoGerenciamentoEscola
{
    public enum Turno { Manha, Tarde, Noite }
    internal class Turma
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public Turno? Turno { get; set; }
        public short? Capacidade { get; set; }
        public int? DisciplinaId { get; set; }
        public string DisciplinaNome { get; set; }
        public List<int> ProfessoresIds { get; set; } = new();
        public override string ToString() => Codigo;
    }
}

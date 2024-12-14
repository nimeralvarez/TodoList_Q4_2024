using SQLite;

namespace TodoList_Q4_2024.Models
{
    public class Tarea
    {
        [PrimaryKey, AutoIncrement] public int IdTarea {  get; set; }

        [NotNull] public string Nombre { get; set; }

        [NotNull] public string FechaLimite { get; set; }

        public string EstadoActual {  get; set; }

        public bool TareaTerminada { get; set; }

    }
}

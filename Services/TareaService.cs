
using TodoList_Q4_2024.Models;
using SQLite;

namespace TodoList_Q4_2024.Services
{
    public class TareaService
    {
        private readonly SQLiteConnection connection;

        public TareaService()
        {
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Tarea.db3");
            connection = new SQLiteConnection(dbPath);
            connection.CreateTable<Tarea>();
        }

        public List<Tarea> GetAll() { 
            var res=connection.Table<Tarea>().ToList();
            return res;
        }

        public int Insert(Tarea tarea) { 
            return connection.Insert(tarea);
        }

        public int Update(Tarea tarea) { 
            return connection.Update(tarea);
        }

        public int Delete(Tarea tarea) { 
            return connection.Delete(tarea);
        }
    }
}

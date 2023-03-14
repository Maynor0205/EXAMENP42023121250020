using EXAMENP42023.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EXAMENP42023.Controllers
{
    public class LocalizacionController
    {
        readonly SQLiteAsyncConnection _connection;
        //Constructor de clase
        public LocalizacionController(string DBPath)
        {
            _connection = new SQLiteAsyncConnection(DBPath);
            _connection.CreateTableAsync<Models.Localizacion>();
        }

        // Create / Update
        public Task<int> SaveGeo(Models.Localizacion posicion)
        {
            if (posicion.id != 0)
                return _connection.UpdateAsync(posicion);
            else
                return _connection.InsertAsync(posicion);

        }

        // Read
        public Task<Models.Localizacion> GetLocalizaciones(int pid)
        {
            return _connection.Table<Models.Localizacion>()
                .Where(i => i.id == pid)
                .FirstOrDefaultAsync();
        }

        // Read para toda la lista de empleados
        public Task<List<Models.Localizacion>> GetListLocalizaciones()
        {
            return _connection.Table<Models.Localizacion>().ToListAsync();
        }

        // Eliminar la informacion
        public Task<int> DeleteLocalizaciones(Models.Localizacion posicion)
        {
            return _connection.DeleteAsync(posicion);
        }

        // Update
        public Task<int> UpdateLocalizacion(Localizacion localizacion)
        {
            return _connection.UpdateAsync(localizacion);
        }
    }
}

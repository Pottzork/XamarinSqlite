using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace CrudUsingXamarin.Interfaces
{
    public interface ISqlite
    {
        SQLiteConnection GetConnection();
    }
}

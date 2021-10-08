using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ristori.Models
{
    public interface ISQLite
    {
        SQLiteConnection GetConnection();
    }
}

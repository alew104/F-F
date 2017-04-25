using System;
using System.Collections.Generic;
using System.Text;

namespace FandF.Helpers
{
    interface IDatabaseConnection
    {
        SQLite.SQLiteConnection DbConnection();
    }
}

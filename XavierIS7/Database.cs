using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
namespace XavierIS7
{
    public interface  Database
    {
    SQLiteAsyncConnection GetConnection();
    


    }
}

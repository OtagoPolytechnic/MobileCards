using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite;

namespace CardApp.Resources
{
    public class Database : SQLiteConnection
    {
        public Database(string path) : base(path)
        {
            CreateTable<WordRecord>();
            //DeleteAll<WordRecord>();
        }
        // select * from WordRecord
        public IEnumerable<WordRecord> QueryAllWords()
        {
            return from s in Table<WordRecord>()
                   orderby s.maoriWord
                   select s;
        }

        
    }
}
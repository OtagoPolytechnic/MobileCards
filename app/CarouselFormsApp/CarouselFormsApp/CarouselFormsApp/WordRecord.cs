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

namespace CardApp
{
    public class WordRecord
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }

        public string maoriWord { get; set; }

        public string englishWord { get; set; }

        public string description { get; set; }

        public DateTime dateUpdated { get; set; }

        public DateTime dateCreated { get; set; }

        public bool publish { get; set; }

        public override string ToString()
        {
            return string.Format("[Word: id={0}, Maori Word={1}, English Word={2}, Description={3}, DateCreated={4}, Publish={5} ]", id, maoriWord, englishWord, description, dateCreated, publish);
        }
    }
}
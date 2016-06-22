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
using CardApp.Resources;
using SQLite;

namespace CardApp
{
    public class Manager 
    {
        private Random rand;
        private Database _db;
        private List<WordRecord> wordsList;
        public List<WordRecord> WordsList
        {
            get { return wordsList; }
        }
        private int currentWord;
        public int CurrentWord
        {
            get { return currentWord; }
            set { currentWord = value; }
        }

        public Manager()
        {
            rand = new Random();
            currentWord = 0;
            wordsList = new List<WordRecord>();
            string folder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            _db = new Database(System.IO.Path.Combine(folder, "words.db"));
            makeWordList();
        }

        public void createTable()
        {
            string folder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var conn = new SQLiteConnection(System.IO.Path.Combine(folder, "Words"));
            conn.CreateTable<WordRecord>();
        }
        // add a word to the database  -- 
        public string AddWord(string mWord, string eWord, string wDescription, DateTime dCreated, bool wPublish)
        {
            var s = new WordRecord { maoriWord = mWord, englishWord = eWord, description = wDescription, dateCreated = dCreated, dateUpdated = dCreated, publish = wPublish};
            _db.Insert(s);
            return string.Format("{0} == {1}\t{2}\t{3}\t{4}\t{5}", s.id, s.maoriWord, s.englishWord, s.description, s.dateCreated, s.publish);
        }

        public IEnumerable<WordRecord> QueryWords(SQLiteConnection db, WordRecord word)
        {
            return db.Query<WordRecord>("select * from Words where id = ?", word.id);
        }
        // increment current word
        public void incrementCurrentWord()
        {
            if (currentWord < wordsList.Count)
            {
                currentWord++;
            }
            else
                Console.WriteLine("Reached end of list");
        }
        // decrement current word
        public void decrementCurrentWord()
        {
            if (currentWord != 0)
            {
                currentWord--;
            }
            else
                Console.WriteLine("Reached start of list");
        }
        // returns translated word
        public string translateWord(WordRecord obj, string sub)
        {
            if (sub == obj.maoriWord)
            {
                return obj.englishWord;
            }
            else
                return obj.maoriWord;
        }
        // reads all records in wordRecord table and fills word list all shuffled
        public void makeWordList()
        {
            foreach (var w in _db.QueryAllWords())
            {
                wordsList.Add(w);
            }
            shuffleList();
        }
        // shuffles the word list
        public void shuffleList()
        {
            for (int i = 0; i < wordsList.Count; i++)
            {
                int randItem = rand.Next(wordsList.Count);
                WordRecord temp = wordsList[i];
                wordsList[i] = wordsList[randItem];
                wordsList[randItem] = temp;
            }
        }
        // print words to console for testing
        public void printWordList()
        {
            foreach (var w in wordsList)
            {
                Console.WriteLine(w);
            }
        }
    }
}
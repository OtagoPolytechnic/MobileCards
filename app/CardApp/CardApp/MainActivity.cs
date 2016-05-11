using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.Collections.Generic;

namespace CardApp
{
    [Activity(Label = "CardApp", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity, GestureDetector.IOnGestureListener //Interface for Gesture Listener
    {
        private Manager manager; // Instance of Manager class
        private GestureDetector _gestureDetector; // Gesture Detector - used for 
        private Button btnNext; // Place holder button to go to the next word in word list
        private Button btnPre; // Place holder button to go to the previous word in word list
        private Button btnTranslate; // Place holder button to switch language of word
        private TextView tv_WordText; // TextView where words are displayed
        private List<WordRecord> wordList; // List of words 

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Create instance of Manager class
            Manager manager = new Manager();

            //DateTime dt = new DateTime();
            //manager.AddWord("maoriTest", "englishTest", "Test description", dt, true);

            _gestureDetector = new GestureDetector(this);

            // Declare Buttons, TextView, and Lists
            btnNext = FindViewById<Button>(Resource.Id.buttonNext);
            btnPre = FindViewById<Button>(Resource.Id.btn_Pre);
            btnTranslate = FindViewById<Button>(Resource.Id.btn_Translate);
            tv_WordText = FindViewById<TextView>(Resource.Id.wordText);
            wordList = manager.WordsList;
            
            // --- fling test ---
            TextView tv_flingText = (TextView)FindViewById(Resource.Id.tv_fling);
            if (wordList.Count != 0)
            {
                tv_WordText.Text = wordList[manager.CurrentWord].maoriWord;
            }       

            

            // For testing purposes. Still needs to be fixed up. Should be more modular. 
            btnNext.Click += delegate
            {
                if (manager.CurrentWord < wordList.Count - 1)
                {
                    manager.CurrentWord++;
                    tv_WordText.Text = wordList[manager.CurrentWord].maoriWord;
                }
                else
                    Console.WriteLine("Reached end of list");
            };

            btnPre.Click += delegate
            {
                if (manager.CurrentWord != 0)
                {
                    manager.CurrentWord--;
                    tv_WordText.Text = wordList[manager.CurrentWord].maoriWord;
                    Console.WriteLine("current word # = " + manager.CurrentWord);
                }
                else
                    Console.WriteLine("Reached start of list");
            };

            btnTranslate.Click += delegate
            {
                string str = manager.translateWord(wordList[manager.CurrentWord], tv_WordText.Text);
                Console.WriteLine("before:" + tv_WordText.Text + " == " + wordList[manager.CurrentWord].maoriWord);
                tv_WordText.Text = str;
                Console.WriteLine("after:" + tv_WordText.Text);
            };
            
            // Prints WordList 
            manager.printWordList();
        }

        // Below methods used for gestures

        public override bool OnTouchEvent(MotionEvent e)
        {
            _gestureDetector.OnTouchEvent(e);
            return false;
        }

        public bool OnDown(MotionEvent e)
        {
            return false;
        }

        public bool OnFling(MotionEvent e1, MotionEvent e2, float velocityX, float velocityY)
        {
            TextView tv_flingText = (TextView)FindViewById(Resource.Id.tv_fling);
            tv_flingText.Text = String.Format("Fling velocity: {0} x {1}", velocityX, velocityY);
            return true;
        }

        public void OnLongPress(MotionEvent e)
        {

        }

        public bool OnScroll(MotionEvent e1, MotionEvent e2, float distanceX, float distanceY)
        {
            return false;
        }

        public void OnShowPress(MotionEvent e)
        {

        }

        public bool OnSingleTapUp(MotionEvent e)
        {
            return false;
        }



    }
}


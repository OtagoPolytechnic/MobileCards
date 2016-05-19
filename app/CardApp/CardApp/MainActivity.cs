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
        private GestureDetector gestureDetector; // Gesture Detector - used for 
        private Button btnNext; // Place holder button to go to the next word in word list
        private Button btnPre; // Place holder button to go to the previous word in word list
        private Button btnTranslate; // Place holder button to switch language of word
        private Button btnDescription; // Place holder button to switch to Desciption screen
        private TextView tv_WordText; // TextView where words are displayed
        private List<WordRecord> wordList; // List of words 
		private TextView tv_flingText; // indicate direction of swipe
        

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Create instance of Manager class
            manager = new Manager();

            //DateTime dt = new DateTime();
            //manager.AddWord("maoriTest", "englishTest", "Test description", dt, true);

            gestureDetector = new GestureDetector(this);
            

            // Declare Buttons, TextView, and Lists
            btnNext = FindViewById<Button>(Resource.Id.buttonNext);
            btnPre = FindViewById<Button>(Resource.Id.btn_Pre);
            btnTranslate = FindViewById<Button>(Resource.Id.btn_Translate);
            tv_WordText = FindViewById<TextView>(Resource.Id.wordText);
            btnDescription = FindViewById<Button>(Resource.Id.btnDescription);
            
 
            wordList = manager.WordsList;

            // --- Notificatin test ---
           //NotificationHandler("IraCards", "New Words Added");
            
            // --- fling test ---
            tv_flingText = (TextView)FindViewById(Resource.Id.tv_fling);
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

            btnDescription.Click += delegate
            {
                

                var desMaori = wordList[manager.CurrentWord].maoriWord;
                var maoriDes = wordList[manager.CurrentWord].description;
                
                var toDesActivity = new Intent (this, typeof(DescriptionActivity));
                toDesActivity.PutExtra ("MaoriWord", desMaori);
                toDesActivity.PutExtra("MaoriDescription", maoriDes);

                StartActivity(toDesActivity);
            };

            // Prints WordList 
            manager.printWordList();
        }

        
		// Below methods used for gestures
		public override bool OnTouchEvent(MotionEvent e)
        {
            gestureDetector.OnTouchEvent(e);
            return false;
        }

        public bool OnDown(MotionEvent e)
        {
            return false;
        }

		public bool OnFling (MotionEvent e1, MotionEvent e2, float velocityX, float velocityY)
		{
			float differenceX = e1.GetX() - e2.GetX();
			float differenceY = e1.GetY() - e2.GetY();

			if (differenceX <= 30) {
				if (e1.GetY() < e2.GetY()) {
					tv_flingText.Text = "Swipe top to bottom.";
				}
				if (e1.GetY () > e2.GetY ()) {
					tv_flingText.Text = "Swipe bottom to top.";
				}
			} else if (differenceY <= 30) {				
				if (e1.GetX () < e2.GetX ()) {
					tv_flingText.Text = "Swipe left to right.";
				}
				if (e1.GetX () > e2.GetX ()) {
					tv_flingText.Text = "Swipe right to left.";
				}
			} else {
				tv_flingText.Text = "Fat fingers!";
			}


			return false;
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


		protected override void OnRestart()
        {
            
        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);
            if (resultCode == Result.Ok)
            {
               
              
            }
        }

        public void NotificationHandler(String title, String message)
        {

            Intent intent = new Intent (this, typeof(MainActivity));
            const int pendingIntentId = 0;
            PendingIntent pendingIntent =  PendingIntent.GetActivity (this, pendingIntentId, intent, PendingIntentFlags.OneShot);

            Notification.Builder builder = new Notification.Builder(this)
            .SetContentTitle(title)
            .SetContentText(message)
            .SetDefaults(NotificationDefaults.Sound | NotificationDefaults.Vibrate)
            .SetContentIntent(pendingIntent)
            .SetSmallIcon(Resource.Drawable.Icon);

            Notification notification = builder.Build();

            NotificationManager notificationManager = GetSystemService(Context.NotificationService) as NotificationManager;

            const int notificationId = 0;
            notificationManager.Notify(notificationId, notification);
        }
    }
}


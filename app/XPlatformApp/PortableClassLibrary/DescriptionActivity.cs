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

namespace CardApp
{
   


    [Activity(Label = "DescriptionActivity")]
    public class DescriptionActivity : Activity
    {

         private Button btnBack;
         private String maoriWord;
         private String wordDescription;


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.description_layout); 

            maoriWord = Intent.GetStringExtra("MaoriWord");
            wordDescription = Intent.GetStringExtra("MaoriDescription");

            if (maoriWord != null)
            {
                TextView tv_MaoriWord = FindViewById<TextView>(Resource.Id.tvMaoriWord);
                tv_MaoriWord.Text = maoriWord;

                TextView tv_WordDes = FindViewById<TextView>(Resource.Id.tvWordDescription);
                tv_WordDes.Text = wordDescription;


            }

  

             btnBack = FindViewById<Button>(Resource.Id.btnBack);

             btnBack.Click += delegate
             {
                 var toMainActivity = new Intent(this, typeof(MainActivity));

                 SetResult(Result.Ok, toMainActivity);
                 Finish();
             };


        }
        
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using Newtonsoft;
using Newtonsoft.Json;
using System.Net.Http;

using System.Threading.Tasks;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System.Threading;

namespace CardApp
{
    [Activity(Label = "SpashScreenActivity")]
    public class SpashScreenActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Splash_Screen_Layout);

            var progressDialog = ProgressDialog.Show(this, "Please wait...", "Checking server info...", true);
            new Thread(new ThreadStart(delegate
            {
                RunAsync().Wait();
                RunOnUiThread(() => Toast.MakeText(this, "Updateing Files", ToastLength.Long).Show());
                
                RunOnUiThread(() => progressDialog.Hide());
            })).Start();


                       
        }


        static async Task RunAsync()
        {
            //using (var client = new HttpClient())
            //{
                //To be added - Base address
               // client.BaseAddress = new Uri("");
                //client.DefaultRequestHeaders.Accept.Clear();
                //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // HTTP GET
               // HttpResponseMessage response = await client.GetAsync("api/words/1");
                //if (response.IsSuccessStatusCode)
               // {
                    //JsonArrayAttribute newDelEditData = await response.Content.ReadAsAsync<JsonArrayAttribute>();
                    
               // }

           
        }

    }

      
}
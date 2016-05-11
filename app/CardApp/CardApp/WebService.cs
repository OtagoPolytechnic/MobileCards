using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using System.IO;
using Android.Widget;

using System.Threading.Tasks;
using System.Net.Http;
using System.Diagnostics;


namespace CardApp
{
    public class WebService
    {

        public int Id { get; set; }
        public string Url { get; set; }
        public string Title { get; set; }

       public async void DownloadDataAsync()
       {
	        string url = "http://javatechig.com/api/get_category_posts/?dev=1&slug=android"
	
	        var httpClient = new HttpClient();
	        Task<string> downloadTask = httpClient.GetStringAsync(url);
	        string content = await downloadTask;	
	        Console.Out.WriteLine("Response: \r\n {0}", content);
}
        
    }
}
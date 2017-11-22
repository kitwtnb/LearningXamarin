using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Reactive.Linq;
using System.Text;

namespace LearningXamarin.Models
{
    public class QiitaService
    {
        private static readonly string BASE_URL = "https://qiita.com/api/v2/";
        private static readonly HttpClient client = new HttpClient();

        public IObservable<QiitaContent> FetchByQuery(string query)
        {
            return Observable.Create<QiitaContent>(observer =>
            {
                var responseString = client.GetStringAsync($"{BASE_URL}items?query={query}").Result;

                var contents = JsonConvert.DeserializeObject<List<QiitaContent>>(responseString);

                contents.ForEach(r => observer.OnNext(r));
                observer.OnCompleted();

                return () => { };
            });
        }
    }
}

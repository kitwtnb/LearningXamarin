using System;
using System.Collections.Generic;
using System.Text;

namespace LearningXamarin.Models
{
    public class QiitaModel
    {
        private readonly QiitaService service;

        public QiitaModel(QiitaService service)
        {
            this.service = service;
        }

        public IObservable<QiitaContent> FetchBy(string query)
        {
            return service.FetchByQuery(query);
        }
    }
}

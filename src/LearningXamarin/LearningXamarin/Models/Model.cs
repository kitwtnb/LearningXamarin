using System;
using System.Collections.Generic;
using System.Text;

namespace LearningXamarin.Models
{
    public class Model
    {
        public string Text { get; set; }

        public Model(IHogeInterface hoge)
        {
            Text = hoge.Text;
        }
    }
}

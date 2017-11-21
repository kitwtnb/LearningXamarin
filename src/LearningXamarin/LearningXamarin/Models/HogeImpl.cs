using System;
using System.Collections.Generic;
using System.Text;

namespace LearningXamarin.Models
{
    class HogeImpl : IHogeInterface
    {
        public string Text { get; set; } = "foobar";
    }
}

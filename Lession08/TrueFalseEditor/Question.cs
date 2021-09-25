using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lession08
{
    public class Question
    {
        public string Text { get; set; }

        public bool TrueFalse { get; set; }

        public Question()
        {

        }

        public Question(string text, bool trueFalse)
        {
            Text = text;
            TrueFalse = trueFalse;
        }

    }
}

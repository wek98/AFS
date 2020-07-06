using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace AFS.APIConsumers
{
    public class Translator
    {
        private readonly ITranslator _translator = null;
        public Translator(ITranslator translator)
        {
            _translator = translator;
        }
        public string MakeTranslation(string inputText)
        {
            return _translator.Translate(inputText);
        }
    }
}

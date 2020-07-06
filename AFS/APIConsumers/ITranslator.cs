using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AFS.APIConsumers
{
    /// <summary>
    /// Translator interface
    /// </summary>
    public interface ITranslator
    { 
        public string Translate(string InputText);
    }
}

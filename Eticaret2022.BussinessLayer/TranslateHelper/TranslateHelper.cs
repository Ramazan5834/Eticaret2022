using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GTranslate.Results;
using GTranslate.Translators;

namespace Eticaret2022.BussinessLayer.TranslateHelper
{
    public class TranslateHelper
    {
        public static async Task<string> TranslateText(string text)
        {
            ITranslationResult translateObject;
            using (var translator = new Translator())
            {
                 translateObject = await translator.TranslateAsync(text, "turkish");
            }
            string textValue =  translateObject.Result;
            return textValue;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Security.Cryptography.X509Certificates;
using AFS.APIConsumers;
using AFS.Models;

namespace AFS.Controllers
{
    public class HomeController : Controller
    {
        private readonly RecordsContext _context;
        
        public HomeController(RecordsContext context)
        {
           _context = context;
        }

        /// <summary>
        /// View of first method
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// View of second method
        /// </summary>
        /// <returns></returns>
        public IActionResult Index2()
        {
            return View();
        }

        /// <summary>
        /// Function called in second method on jquery and ajax page
        /// </summary>
        /// <param name="inputString"></param>
        /// <returns></returns>
        [HttpPost]
        public string TranslateToLeetAjax(string inputString)
        {
            LeetSpeakConsumer leetSpeakConsumer = new LeetSpeakConsumer();
            Translator translator = new Translator(leetSpeakConsumer); 
            string outputString = translator.MakeTranslation(inputString);
            RecordModel recordModel = new RecordModel(inputString, outputString);
            _context.RecordModels.Add(recordModel);
            _context.SaveChanges();
            return outputString;
        }


        /// <summary>
        /// Function that returns View with translated text in firstmethod
        /// </summary>
        /// <param name="recordModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task <IActionResult> Index(RecordModel recordModel)
        {
            string inputstring = recordModel.InputRecord;
            LeetSpeakConsumer leetSpeakConsumer = new LeetSpeakConsumer();
            //dependency injection through constructor
            Translator translator = new Translator(leetSpeakConsumer);
            recordModel.OutputRecord = translator.MakeTranslation(inputstring);
            string outputstring = recordModel.OutputRecord;
            ViewBag.output = outputstring;
            _context.RecordModels.Add(recordModel);
            await _context.SaveChangesAsync();
            return await Task.Run(() => View("Index"));
        }


        public IActionResult Privacy()
        {
            return View();
        }
    }
}

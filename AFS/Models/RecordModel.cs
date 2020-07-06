using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AFS.Models
{
    public class RecordModel
    {
        [Key]
        public int Id { get; set; }
        [DisplayName("Text to translate  ")]
        public string InputRecord { get; set; }
        [DisplayName("Translated text  ")]
        public string OutputRecord { get; set; }
        public RecordModel() { }
        public RecordModel(string inputRecord, string outputRecord)
        {
            InputRecord = inputRecord;
            OutputRecord = outputRecord;
        }

    }
}

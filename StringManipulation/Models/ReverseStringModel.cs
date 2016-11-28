using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace StringManipulation.Models
{
    public class ReverseStringModel
    {
        [Required(ErrorMessage = "Please Enter Paragraph.")]
        [Display(Name = "Original Paragraph")]
        [DataType(DataType.MultilineText)]
        public string OriginalText { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "Reverse Paragraph by Words")]
        public string ReverseText { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "Reverse Paragraph by Characters")]
        public string ReverseCharacters { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "Sort Paragraph")]
        public string SortString { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "Encrypted Paragraph")]
        public string EncryptedText { get; set; }
    }
}
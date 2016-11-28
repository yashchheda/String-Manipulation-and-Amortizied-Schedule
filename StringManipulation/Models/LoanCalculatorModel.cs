using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;


namespace StringManipulation.Models
{
    public class LoanCalculatorModel
    {
        [Required]
        [Display(Name = "Loan Amount")]
        [DataType(DataType.Currency)]
        [Range(1, double.MaxValue, ErrorMessage = "Please Enter a Valid Number")]
        public double LoanAmount { get; set; }

        [Required]
        [Display(Name = "Loan Term")]
        public string LoanTerm { get; set; }
        public List<SelectListItem> LoanTerms { get; set; }

        [Required]
        [Display(Name = "Interest Rate")]
        [Range(1, 15, ErrorMessage = "Interest Rate Out of Range")]
        public double InterestRate { get; set; }

        public List<AmortizationTableModel> outputObject { get; set; }

        public LoanCalculatorModel()
        {
            LoanTerms = new List<SelectListItem>
      {
        new SelectListItem {Value = "36", Text = "36" },
        new SelectListItem {Value = "30", Text = "30" },
        new SelectListItem {Value = "24", Text = "24" },
        new SelectListItem {Value = "18", Text = "18" },
        new SelectListItem {Value = "12", Text = "12" },
      };

            LoanTerm = "36";
        }
    }
}
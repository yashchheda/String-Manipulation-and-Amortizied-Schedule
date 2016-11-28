using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StringManipulation.Models;

namespace StringManipulation.Controllers
{
    public class LoanCalculatorController : Controller
    {
        // GET: LoanCalculator
        public ActionResult Index(LoanCalculatorModel loanObject)
        {
            try
            {
                List<AmortizationTableModel> mobjList = new List<AmortizationTableModel>();
                double decDeductBalance;
                double interestPaid;
                double decNewBalance;
                double dblTotalPayments;
                double dblInterestToDecimal;
                int intPmt = 1;
                double dblMonthlyPayment = CalculateAmortizedPayment(loanObject);
                //convert interest rate to decimal form
                dblInterestToDecimal = loanObject.InterestRate / 100;
                //calculate interest
                double dblConvertInterest = dblInterestToDecimal / 12;
                //calculate the total number of payments (n * 12)
                int intYears = int.Parse(loanObject.LoanTerm);     //years
                int intNumOfPayments = intYears;  // Only number of installments

                dblTotalPayments = intNumOfPayments * dblMonthlyPayment; //total amount
                decNewBalance = loanObject.LoanAmount; //principle amount

                while (intPmt <= intNumOfPayments)
                {
                    interestPaid = decNewBalance * dblConvertInterest;
                    decDeductBalance = dblMonthlyPayment - interestPaid;
                    decNewBalance = decNewBalance - decDeductBalance;
                    intPmt += 1;
                    //Update the table with values for each term
                    mobjList.Add(new AmortizationTableModel { PaymentAmount = Math.Round(dblMonthlyPayment, 2), PrincipalPaid = Math.Round(decDeductBalance, 2), BalanceAmount = Math.Round(decNewBalance, 2) });
                }
                loanObject.outputObject = mobjList;
                ModelState.Clear();
                return View("Index", loanObject);
            }
            catch
            {
                return View();
            }
        }
        //Calculate Monthly Payment
        public double CalculateAmortizedPayment(LoanCalculatorModel loanObject)
        {
            double monthly;
            double intRate = (loanObject.InterestRate / 100) / 12;
            monthly = (loanObject.LoanAmount * (Math.Pow((1 + intRate), int.Parse(loanObject.LoanTerm))) * intRate / (Math.Pow((1 + intRate), int.Parse(loanObject.LoanTerm)) - 1));
            return Convert.ToDouble(monthly);
        }

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
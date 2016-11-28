using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StringManipulation.Models
{
    public class AmortizationTableModel
    {
        public double PaymentAmount { get; set; }
        public double PrincipalPaid { get; set; }
        public double BalanceAmount { get; set; }        
    }
}
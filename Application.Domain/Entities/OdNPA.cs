using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Domain.Entities
{
    public class OdNPA
    {

        public string Funder { get; set; }

        public string Branch { get; set; }

        public string UnitName { get; set; }

        public string District { get; set; }

        public string State { get; set; }

        public string Center_Name { get; set; }

        public string Client_Name_Spouse_Name { get; set; }

        public long MobileNo { get; set; }

        public string Loan_No { get; set; }

        public string Single_Or_Joint { get; set; }

        public string FunderLoanNo { get; set; }

        public DateTime LoanDate { get; set; }

        public float DPD { get; set; }

        public float NPA_OD_Amount_Princ { get; set; }

        public float NPA_OD_Amount { get; set; }

        public DateTime Center_Visit_Date { get; set; }
        public TimeSpan Center_Visit_Time { get; set; }

        public float Collection_Amount { get; set; }

        public string Visitor_Id { get; set; }

        public string VisitorName { get; set; }

        public string Visitor_Designation { get; set; }

        public string TypeOfClient { get; set; }

        //public bool isXBucket { get; set; }

        //public string BH { get; set; }

        //public float OD { get; set; }

        //public float DIFF { get; set; }

        //public bool isReduction { get; set; }

        //public bool isCollection { get; set; }

        //public bool isUnique { get; set; }

    }
}

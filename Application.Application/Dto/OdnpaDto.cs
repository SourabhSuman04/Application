using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Application.Dto
{
    public class OdnpaDto
    {
        public string? Funder { get; set; }
        public string? Branch { get; set; }
        public string? UnitName { get; set; }
        public string? District { get; set; }
        public string? State { get; set; }
        public string? MemberID { get; set; }
        public string? Center_Name { get; set; }
        public string? Client_Name_Spouse_Name { get; set; }
        public double? MobileNo { get; set; }
        public string? Loan_No { get; set; }
        public string? RegularEMI { get; set; }
        public string? LastCollectionDate { get; set; }
        public string? Single_Or_Joint { get; set; }
        public string? FunderLoanNo { get; set; }
        public DateTime? LoanDate { get; set; }
        public double? DPD { get; set; }
        public double? NPA_OD_Amount_Princ { get; set; }
        public double? NPA_OD_Amount { get; set; }
        public DateTime? Center_Visit_Date { get; set; }
        public TimeSpan? Center_Visit_Time { get; set; }
        public double? Collection_Amount { get; set; }
        public string? EntryFrom { get; set; }
        public string? Visitor_Id { get; set; }
        public string? VisitorName { get; set; }
        public string? Visitor_Designation { get; set; }
        public string? TypeOfClient { get; set; }
        public string? Latitude { get; set; }
        public string? Longitude { get; set; }
        public string? GeoTaggingAddress { get; set; }
        public string? PTPDate { get; set; }
        public string? PTPReason { get; set; }
        public string? Member_Latitude { get; set; }
        public string? Member_Longitude { get; set; }
        public string? MetNotMetStatus { get; set; }
        public string? MetNotMetReason { get; set; }
        public string? Remarks { get; set; }
        public string? FollowUpDate { get; set; }
        public string? DistanceinKM { get; set; }
        public bool? isXBucket { get; set; }
        public string? BH { get; set; }
        public double? OD { get; set; }
        public double? DIFF { get; set; }
        public bool? isReduction { get; set; }
        public bool? isCollection { get; set; }
        public bool? isUnique { get; set; }
          
        }

}

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Application.Application.Dto;
using Application.Application.Helper;
using Application.Application.Interface;
using Application.Domain.Entities;
using Application.Domain.IRepository;
using ClosedXML.Excel;
using Demo.Application.Helper;
using DocumentFormat.OpenXml.Drawing;
using Microsoft.AspNetCore.Http;

namespace Application.Application.Service
{
    public class UnitWiseService : IUnitWiseService
    {
        public readonly IUnitWiseRepository unitWiseRepository;
        public UnitWiseService(IUnitWiseRepository _unitWiseRepository)
        {
            unitWiseRepository = _unitWiseRepository;
        }

        public async Task<ApiResponse<IEnumerable<UnitWise>>> getAllRecords()
        {
            try
            {
                var result = await unitWiseRepository.getAllRecords();
                return new ApiResponse<IEnumerable<UnitWise>>(true, "Success", 200, result);
            }
            catch (Exception e)
            {
                return new ApiResponse<IEnumerable<UnitWise>>(false, e.Message, 500, Enumerable.Empty<UnitWise>());
            }
        }

        public async Task<ApiResponse<IEnumerable<XBucketUnitwise>>> getXbucketAllRecords()
        {
            try
            {
                var result = await unitWiseRepository.getAllXbucketRecords();
                return new ApiResponse<IEnumerable<XBucketUnitwise>>(true, "Success", 200, result);
            }
            catch (Exception e)
            {
                return new ApiResponse<IEnumerable<XBucketUnitwise>>(false, e.Message, 500, Enumerable.Empty<XBucketUnitwise>());
            }
        }

        public async Task<object> ImportOdnpaFromExcelAsync(IFormFile file)
        {
            try
            {
                if (file == null || file.Length == 0)
                    throw new ArgumentException("No file uploaded.");

                var records = new List<OdnpaDto>();
                DateTime MinSqlDate = new DateTime(1753, 1, 1);

                using (var stream = new MemoryStream())
                {
                    await file.CopyToAsync(stream);
                    stream.Position = 0;

                    using (var workbook = new XLWorkbook(stream))
                    {
                        var worksheet = workbook.Worksheets.First();
                        int rowNumber = 1;

                        foreach (var row in worksheet.RowsUsed().Skip(1))
                        {
                            rowNumber++;
                            try
                            {
                                var record = new OdnpaDto
                                {
                                    Funder = row.Cell(1).GetString(),
                                    Branch = row.Cell(2).GetString(),
                                    UnitName = row.Cell(3).GetString(),
                                    District = row.Cell(4).GetString(),
                                    State = row.Cell(5).GetString(),
                                    MemberID=row.Cell(6).GetString(),
                                    Center_Name = row.Cell(7).GetString(),
                                    Client_Name_Spouse_Name = row.Cell(8).GetString(),
                                    MobileNo = row.Cell(9).TryGetValue(out double mobileVal) ? mobileVal : 0d,
                                    Loan_No = row.Cell(10).GetString().Trim(),
                                    RegularEMI = row.Cell(11).GetString(),
                                    LastCollectionDate = row.Cell(12).GetString(),
                                    Single_Or_Joint = row.Cell(13).GetString(),
                                    FunderLoanNo = row.Cell(14).GetString(),
                                    //LoanDate = row.Cell(14).TryGetValue(out DateTime loanDateVal) && loanDateVal.ToOADate() != 60 ? loanDateVal : DateTime.MinValue,
                                    LoanDate = row.Cell(15).TryGetValue(out DateTime loanDateVal) && loanDateVal.ToOADate() != 60 ? loanDateVal : DateTime.MinValue,

                                    DPD = row.Cell(16).TryGetValue(out double dpdVal) ? dpdVal : 0d,
                                    NPA_OD_Amount_Princ = row.Cell(17).TryGetValue(out double princVal) ? princVal : 0d,
                                    NPA_OD_Amount = row.Cell(18).TryGetValue(out double npaVal) ? npaVal : 0d,
                                    Center_Visit_Date = row.Cell(19).TryGetValue(out DateTime visitDate) && visitDate >= MinSqlDate ? visitDate : MinSqlDate,
                                    Center_Visit_Time = row.Cell(20).TryGetValue(out DateTime visitTime) ? visitTime.TimeOfDay : TimeSpan.Zero,
                                    Collection_Amount = row.Cell(21).TryGetValue(out double collVal) ? collVal : 0d,
                                    EntryFrom = row.Cell(22).GetString(),
                                    Visitor_Id = row.Cell(23).GetString(),
                                    VisitorName = row.Cell(24).GetString(),
                                    Visitor_Designation = row.Cell(25).GetString(),
                                    TypeOfClient = row.Cell(26).GetString(),
                                    Latitude = row.Cell(27).GetString(),
                                    Longitude = row.Cell(28).GetString(),
                                    GeoTaggingAddress = row.Cell(29).GetString(),
                                    PTPDate = row.Cell(30).GetString(),
                                    PTPReason = row.Cell(31).GetString(),
                                    Member_Latitude = row.Cell(32).GetString(),
                                    Member_Longitude = row.Cell(33).GetString(),
                                    MetNotMetStatus = row.Cell(34).GetString(),
                                    MetNotMetReason = row.Cell(35).GetString(),
                                    Remarks = row.Cell(36).GetString(),
                                    FollowUpDate = row.Cell(37).GetString(),
                                    DistanceinKM = row.Cell(38).GetString()
                                };

                                records.Add(record);
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"Row {rowNumber}: Failed to parse. Error: {ex.Message}");
                            }
                        }
                    }
                }

                //var entities = records.Select(dto => new OdNPA
                //{
                //    Funder = dto.Funder,
                //    Branch = dto.Branch,
                //    UnitName = dto.UnitName,
                //    District = dto.District,
                //    State = dto.State,
                //    Center_Name = dto.Center_Name,
                //    Client_Name_Spouse_Name = dto.Client_Name_Spouse_Name,
                //    MobileNo = (long)dto.MobileNo,
                //    Loan_No = dto.Loan_No,
                //    Single_Or_Joint = dto.Single_Or_Joint,
                //    FunderLoanNo = dto.FunderLoanNo,
                //    LoanDate = (DateTime)dto.LoanDate,
                //    DPD = (float)dto.DPD,
                //    NPA_OD_Amount_Princ = (float)dto.NPA_OD_Amount_Princ,
                //    NPA_OD_Amount = (float)dto.NPA_OD_Amount,
                //    Center_Visit_Date = (DateTime)dto.Center_Visit_Date,
                //    Center_Visit_Time = (TimeSpan)dto.Center_Visit_Time,
                //    Collection_Amount = (float)dto.Collection_Amount,
                //    Visitor_Id = dto.Visitor_Id,
                //    VisitorName = dto.VisitorName,
                //    Visitor_Designation = dto.Visitor_Designation,
                //    TypeOfClient = dto.TypeOfClient
                //}).ToList();

                var entities = records.Select(dto => new OdNPA
                {
                    Funder = dto.Funder,
                    Branch = dto.Branch,
                    UnitName = dto.UnitName,
                    District = dto.District,
                    State = dto.State,
                    Center_Name = dto.Center_Name,
                    Client_Name_Spouse_Name = dto.Client_Name_Spouse_Name,
                    MobileNo = (long)dto.MobileNo,
                    Loan_No = dto.Loan_No.Trim(),
                    Single_Or_Joint = dto.Single_Or_Joint,
                    FunderLoanNo = dto.FunderLoanNo,

                    // ✅ FIX: Use a valid minimum date (e.g., 1900-01-01) to avoid error
                    LoanDate = (DateTime)(dto.LoanDate < new DateTime(1900, 1, 1)
               ? new DateTime(1900, 1, 1)
               : dto.LoanDate),

                    DPD = (float)dto.DPD,
                    NPA_OD_Amount_Princ = (float)dto.NPA_OD_Amount_Princ,
                    NPA_OD_Amount = (float)dto.NPA_OD_Amount,

                    // ✅ FIX: Same for Visit Date
                    Center_Visit_Date = (DateTime)(dto.Center_Visit_Date < new DateTime(1900, 1, 1)
                        ? new DateTime(1900, 1, 1)
                        : dto.Center_Visit_Date),

                    // ✅ FIX: If TimeSpan is 0 or invalid, assign a safe default
                    Center_Visit_Time = (TimeSpan)(dto.Center_Visit_Time == TimeSpan.Zero
                        ? new TimeSpan(9, 0, 0) // 9:00 AM default
                        : dto.Center_Visit_Time),

                    Collection_Amount = (float)dto.Collection_Amount,
                    Visitor_Id = dto.Visitor_Id,
                    VisitorName = dto.VisitorName,
                    Visitor_Designation = dto.Visitor_Designation,
                    TypeOfClient = dto.TypeOfClient
                }).ToList();


                DataTable dt = CustomDataTable.Convert(entities);
                var response = await unitWiseRepository.UploadUsers(dt);

                return new ApiResponse<object>(true, "Success", 200, response);
            }
            catch (Exception ex)
            {
                return new ApiResponse<object>(false, ex.Message, 500, null);
            }
        }
    }
}

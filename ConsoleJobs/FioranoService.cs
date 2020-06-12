using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleJobs
{
    public class FioranoService
    {
        public string GetAcctDet(string endPoint, string account)
        {
            string response = string.Empty;
            try
            {
                string rootUrl = ConfigurationManager.AppSettings["fioranoBaseUrl"];
                string fullUri = $"{rootUrl}/{endPoint}/{account}";
                using (HttpClient httpClient = new HttpClient())
                {
                    httpClient.BaseAddress = new Uri(rootUrl);
                    httpClient.DefaultRequestHeaders.Accept.Clear();
                    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    response = httpClient.GetAsync(fullUri).Result.Content.ReadAsStringAsync().Result;

                    new ErrorLog($"response from GetAcctDet inquiry directly: {JsonConvert.SerializeObject(response)}");
                }
            }
            catch (Exception ex)
            {
                new ErrorLog("Error in method GetAcctDet " + ex.Message);
            }
            return response;
        }
    }
    public class AccountFullInfo
    {
        public Bankaccountfullinfo BankAccountFullInfo { get; set; }
    }

    public class Bankaccountfullinfo
    {
        public string NUBAN { get; set; }
        public string BRA_CODE { get; set; }
        public string DES_ENG { get; set; }
        public string CUS_NUM { get; set; }
        public string CUR_CODE { get; set; }
        public string LED_CODE { get; set; }
        public string CUS_SHO_NAME { get; set; }
        public string AccountGroup { get; set; }
        public string CustomerStatus { get; set; }
        public string ADD_LINE1 { get; set; }
        public string ADD_LINE2 { get; set; }
        public string MOB_NUM { get; set; }
        public string email { get; set; }
        public string ACCT_NO { get; set; }
        public string MAP_ACC_NO { get; set; }
        public string ACCT_TYPE { get; set; }
        public string ISO_ACCT_TYPE { get; set; }
        public string TEL_NUM { get; set; }
        public string DATE_OPEN { get; set; }
        public string STA_CODE { get; set; }
        public string CLE_BAL { get; set; }
        public string CRNT_BAL { get; set; }
        public string TOT_BLO_FUND { get; set; }
        public object INTRODUCER { get; set; }
        public string DATE_BAL_CHA { get; set; }
        public string NAME_LINE1 { get; set; }
        public string NAME_LINE2 { get; set; }
        public string BVN { get; set; }
        public string REST_FLAG { get; set; }
        public RESTRICTION[] RESTRICTION { get; set; }
        public string IsSMSSubscriber { get; set; }
        public string Alt_Currency { get; set; }
        public string Currency_Code { get; set; }
        public string T24_BRA_CODE { get; set; }
        public string T24_CUS_NUM { get; set; }
        public string T24_CUR_CODE { get; set; }
        public string T24_LED_CODE { get; set; }
        public string OnlineActualBalance { get; set; }
        public string OnlineClearedBalance { get; set; }
        public string OpenActualBalance { get; set; }
        public string OpenClearedBalance { get; set; }
        public string WorkingBalance { get; set; }
        public string CustomerStatusCode { get; set; }
        public string CustomerStatusDeecp { get; set; }
        public object LimitID { get; set; }
        public string LimitAmt { get; set; }
        public string MinimumBal { get; set; }
        public string UsableBal { get; set; }
        public string AccountDescp { get; set; }
        public string CourtesyTitle { get; set; }
        public string AccountTitle { get; set; }
    }

    public class RESTRICTION
    {
        public object RestrictionCode { get; set; }
        public object RestrictionDescription { get; set; }
    }
}

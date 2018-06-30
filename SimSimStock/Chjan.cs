using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimSimStock
{
    //USER_ID : mason21
    //USER_NAME : 김민수
    //ACCNO : 8106398111;8740459531;
    class Chjan
    {
        AxKHOpenAPILib.AxKHOpenAPI axKHOpenAPI;

        public Chjan(AxKHOpenAPILib.AxKHOpenAPI axKHOpenAPI)
        {
            this.axKHOpenAPI = axKHOpenAPI;
            this.axKHOpenAPI.OnReceiveTrData += AxKHOpenAPI_OnReceiveTrData;
            this.axKHOpenAPI.OnReceiveTrData += AxKHOpenAPI_OnReceiveTrData1;
        }

        private void AxKHOpenAPI_OnReceiveTrData1(object sender, AxKHOpenAPILib._DKHOpenAPIEvents_OnReceiveTrDataEvent e)
        {
            if (e.sRQName == "주식일봉차트조회")
            {
                string text = null;
                for (int nLoop = 0; nLoop < 10; nLoop++)
                {

                    text += (DateTime.Today.AddDays(nLoop * -1).ToString()) +" : ";

                    text += axKHOpenAPI.CommGetData(e.sTrCode, "", e.sRQName, nLoop, "현재가").Trim()+"/";
                    text += axKHOpenAPI.CommGetData(e.sTrCode, "", e.sRQName, nLoop, "시가").Trim()+ "/";
                    text += axKHOpenAPI.CommGetData(e.sTrCode, "", e.sRQName, nLoop, "고가").Trim() + "/";
                    text += axKHOpenAPI.CommGetData(e.sTrCode,"",e.sRQName,nLoop,"저가").Trim();
                    text += Environment.NewLine;

                }
                
                Program.writeFileOnCurrDir("주식일봉차트조회", text);
            }
            if (e.sRQName == "주식분봉차트조회")
            {
                string text = null;
                for (int nLoop = 0; nLoop < 10; nLoop++)
                {

                    text += (DateTime.Today.AddDays(nLoop * -1).ToString()) + " : ";

                    text += axKHOpenAPI.CommGetData(e.sTrCode, "", e.sRQName, nLoop, "현재가").Trim() + "/";
                    text += axKHOpenAPI.CommGetData(e.sTrCode, "", e.sRQName, nLoop, "시가").Trim() + "/";
                    text += axKHOpenAPI.CommGetData(e.sTrCode, "", e.sRQName, nLoop, "고가").Trim() + "/";
                    text += axKHOpenAPI.CommGetData(e.sTrCode, "", e.sRQName, nLoop, "저가").Trim();
                    text += Environment.NewLine;

                }

                Program.writeFileOnCurrDir("주식분봉차트조회", text);
            }

        }



        private void AxKHOpenAPI_OnReceiveTrData(object sender, AxKHOpenAPILib._DKHOpenAPIEvents_OnReceiveTrDataEvent e)
        {
            if (e.sRQName == "계좌평가현황요청")
            {

                String a = axKHOpenAPI.GetCommData(e.sTrCode, e.sRQName, 0, "예수금");
                Console.WriteLine(a);

            }
        }

        public void getbalance()
        {
            axKHOpenAPI.SetInputValue("계좌번호", "8106398111");
            axKHOpenAPI.SetInputValue("비밀번호", "");
            axKHOpenAPI.SetInputValue("상장폐지조회구분", "0");
            axKHOpenAPI.SetInputValue("비밀번호입력매체구분", "00");
            //            axKHOpenAPI.SetInputValue("조회구분", "2");

            int nRet = axKHOpenAPI.CommRqData("계좌평가현황요청", "OPW00004", 0, "6001");

        }

        public void getprice() { 
            axKHOpenAPI.SetInputValue("종목코드", "000810");
            axKHOpenAPI.SetInputValue("기준일자", DateTime.Today.ToString("yyyyMMdd"));
            axKHOpenAPI.SetInputValue("수정주가구분", "1");
            //axKHOpenAPI.CommRqData("주식일봉차트조회", "OPT10081", 0, "1010");
            axKHOpenAPI.CommRqData("주식분봉차트조회", "OPT10080", 0, "1010");
        }

    }
}



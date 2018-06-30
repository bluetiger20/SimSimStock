using System;
namespace SimSimStock
{
    public class LoginClass
    {
        AxKHOpenAPILib.AxKHOpenAPI axKHOpenAPI;
        public LoginClass(AxKHOpenAPILib.AxKHOpenAPI axKHOpenAPI)
        {
            this.axKHOpenAPI = axKHOpenAPI;
            Login();
        }

        private void Login()
        {
            axKHOpenAPI.OnEventConnect += AxKHOpenAPI1_OnEventConnect1;
            axKHOpenAPI.CommConnect();

        }

        public int CommConnect()//connect
        {
            return axKHOpenAPI.CommConnect();
        }
        private void AxKHOpenAPI1_OnEventConnect1(object sender, AxKHOpenAPILib._DKHOpenAPIEvents_OnEventConnectEvent e)
        {
            Console.WriteLine("Success!!");
            GetLoginInfo();
        }

        private string GetLoginInfo()
        {
            Console.WriteLine("USER_ID : " + axKHOpenAPI.GetLoginInfo("USER_ID"));        
            Console.WriteLine("USER_NAME : " + axKHOpenAPI.GetLoginInfo("USER_NAME"));
            Console.WriteLine("ACCNO : " + axKHOpenAPI.GetLoginInfo("ACCNO"));
            return null;
        }

    }
}
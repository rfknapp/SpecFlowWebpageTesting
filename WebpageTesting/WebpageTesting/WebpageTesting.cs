using System;

namespace SpecFlowAmazonShopping
{
    public class WebpageTesting
    {
        public string userName { get; set; }
        public string password { get; set; }

        public void login()
        {
            Console.WriteLine(userName);
        }

    }
}

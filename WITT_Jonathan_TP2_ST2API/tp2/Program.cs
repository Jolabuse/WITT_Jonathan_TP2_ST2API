using System;

namespace tp2
{
    class Program
    {
        static void Main(string[] args)
        {
            
            var p = new APIcontrol();
            MorocoWeath(p);
            OsloDay(p);
            JakartaDegree(p);
            WindComp();
            Humidity();
            Console.Write("Press any key to close the console app...");
            Console.ReadKey();


        }
        static void MorocoWeath(APIcontrol p)
        {
            
            p.GetInfo("31.791702","-7.09262");
            
            Console.WriteLine("The weather in Morocco is :" +  p.objectRes.weather[0].description);
        }
        static void OsloDay(APIcontrol p)
        {
            
            p.GetInfo("59.9138688","10.7522454");
            
            Console.WriteLine("The day lasts from "+  UnixTimeStampToDateTime(p.objectRes.sys.sunrise).ToString("HH:mm:ss")+" UTC to "+UnixTimeStampToDateTime(p.objectRes.sys.sunset).ToString("HH:mm:ss")+" UTC in Oslo " );
        }
        
        static void JakartaDegree(APIcontrol p)
        {
            
            p.GetInfo("-6.2087634","106.845599");
            
            Console.WriteLine("The Temperature in Jakarta in Celsius is " +  p.objectRes.main.temp);
        }
        static void WindComp()
        {
            var NY = new APIcontrol();
            var T = new APIcontrol();
            var P = new APIcontrol();

            
            NY.GetInfo("40.712784","-74.005941");
            T.GetInfo("35.652832","139.839478");
            P.GetInfo("48.856614","2.3522219");
       

            if (P.objectRes.wind.speed > NY.objectRes.wind.speed && P.objectRes.wind.speed > T.objectRes.wind.speed)
            {
                Console.WriteLine("Paris is the more windy out of New-York, Tokyo and Paris with a wind speed of " +  P.objectRes.wind.speed +"meter/sec");
            }
            else if (NY.objectRes.wind.speed > P.objectRes.wind.speed && NY.objectRes.wind.speed > T.objectRes.wind.speed)
            {
                Console.WriteLine("New York is the more windy out of New-York, Tokyo and Paris with a wind speed of " +  NY.objectRes.wind.speed +"meter/sec");
            }
            else
            {
                Console.WriteLine("Tokyo is the more windy out of New-York, Tokyo and Paris with a wind speed of " +  T.objectRes.wind.speed +"meter/sec");
            }
        }
        static void Humidity()
        {
            
            var K = new APIcontrol();
            var M = new APIcontrol();
            var B = new APIcontrol();
            
            K.GetInfo("50.450001","30.523333");
            M.GetInfo("55.751244","37.618423");
            B.GetInfo("52.520008","13.404954");
            Console.WriteLine("The humidity is "+K.objectRes.main.humidity +" and the pressure is "+K.objectRes.main.pressure +" at Kiev" );
            Console.WriteLine("The humidity is "+M.objectRes.main.humidity +" and the pressure is "+M.objectRes.main.pressure +" at Moscow" );
            Console.WriteLine("The humidity is "+B.objectRes.main.humidity +" and the pressure is "+B.objectRes.main.pressure +" at Berlin" );
        }
        
        public static DateTime UnixTimeStampToDateTime( double unixTimeStamp )
        {
            DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            dateTime = dateTime.AddSeconds( unixTimeStamp ).ToLocalTime();
            
            return dateTime;
        }
    }
}
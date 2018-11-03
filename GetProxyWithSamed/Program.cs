using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace GetProxyWithSamed
{
    class Program{
        // Hi, this program is allow you take proxy. My name is Samed.
        // My github,facebook,twitter,instagram = karakusnavy
        // karakusnavy@gmail.com
        static void Main(string[] args)
        {
            string proxy_password,key,selectnumber;
            Console.Write("Please enter the password: ");
            proxy_password = Console.ReadLine();
            if (proxy_password != "karakusnavy") return;
            Console.WriteLine("Welcome to proxy getter program. Please approve the rule.");
            Console.Write("All responsibility belongs to me. YES or NO : ");//karakusnavy@gmail.com
            key = Console.ReadLine();
            if (key.ToUpper() != "YES") return;            
            Console.WriteLine("Welcome to ADMİN ! Please select a option");
            Console.WriteLine("------------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Just Ultimate Mode");
            Console.WriteLine("1) Get proxy list top 5 and export the .txt format (free-proxy-list.net)");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("------------------------------------------------------");
            Console.Write("Which one? ");
            selectnumber = Console.ReadLine();//karakusnavy@gmail.com
            if (selectnumber == "1") proxygetter_1();
            else return;
            void proxygetter_1(){
                List<String> proxys = new List<string>();
                List<String> ports = new List<string>();
                List<String> proxys_ports = new List<string>();
                Uri url = new Uri("https://free-proxy-list.net/");
                WebClient client = new WebClient();
                string html = client.DownloadString(url);                
                HtmlAgilityPack.HtmlDocument dokuman = new HtmlAgilityPack.HtmlDocument();
                dokuman.LoadHtml(html);
                HtmlNodeCollection proxy_s = dokuman.DocumentNode.SelectNodes("//*[@id='proxylisttable']/tbody/tr/td[1]");
                foreach (var baslik in proxy_s)
                proxys.Add(baslik.InnerText);//karakusnavy@gmail.com
                HtmlNodeCollection port_s = dokuman.DocumentNode.SelectNodes("//*[@id='proxylisttable']/tbody/tr/td[2]");
                foreach (var baslik in port_s)
                ports.Add(baslik.InnerText);
                for (int i = 1; i < 6; i++)
                proxys_ports.Add(proxys[i]+":"+ports[i]);                
                String[] proxy_list = new String[proxys_ports.Count];
                proxys_ports.CopyTo(proxy_list, 0);
                System.IO.File.WriteAllLines("proxy_list.txt", proxy_list);
                Console.Write("Succesfull! ("+proxys_ports.Count.ToString()+" proxy getting!) check the file location. proxylist.txt");
                string selectwhich = Console.ReadLine();
                if (selectwhich.ToUpper()=="yes") Process.Start(AppDomain.CurrentDomain.BaseDirectory);//karakusnavy@gmail.com
            }
            Console.ReadKey();
        }
        // Hi, this program is allow you take proxy. My name is Samed.
        // My github,facebook,twitter,instagram = karakusnavy
        // karakusnavy@gmail.com
    }
}

using System;
using System.Dynamic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace creatFile
{
   public class Program
    {
        public static  string createUser()
        {
            return "ayala";
        }

        public static void creat()
        {
          string nameR;
         string passR;
         string fileName = System.IO.Directory.GetCurrentDirectory() + "\\file.txt";
            try
            {
                // Check if file already exists. If yes, delete it.     
                if (!File.Exists(fileName))
                {


                    // Create a new file     
                    using (FileStream fs = File.Create(fileName))
                    {
                        Random rnd = new Random();
                         nameR = System.Environment.MachineName;
                         passR = "," + rnd.Next(11111111, 33333333);
                        //check is exist user 
                        byte[] name = new UTF8Encoding(true).GetBytes(nameR);
                        fs.Write(name, 0, name.Length);
                        byte[]  pass = new UTF8Encoding(true).GetBytes(passR);
                        fs.Write(pass, 0, pass.Length);
                        File.SetAttributes(fileName, FileAttributes.Hidden);

                    }
                }
                else
                {
                    // Open the stream and read it back.    
                    using (StreamReader sr = File.OpenText(fileName))
                    {
                        string s = sr.ReadLine();
                       string[] ss= s.Split(',');
                        nameR = ss[0];
                        passR = ss[1];
                        Console.WriteLine(nameR + passR);

                    }
                }
            }
            catch (Exception Ex)
            {
                Console.WriteLine(Ex.ToString());
            }
            //return nameR + "," + passR;
        }

        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            creat();

            Console.Read();
        }
        
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StringManipulation.Models;
using System.Security.Cryptography;
using System.Text;

namespace StringManipulation.Controllers
{
    public class ReverseStringController : Controller
    {
        // GET: ReverseString
        public ActionResult Index(ReverseStringModel words)
        {
            try
            {
                if (!string.IsNullOrEmpty(words.OriginalText))
                {
                    //Reverse w.r.t. Words
                    words.ReverseText = ReverseWords(words.OriginalText);

                    // Reverse w.r.t Characters
                    words.ReverseCharacters = ReverseCharacters(words.OriginalText);

                    // Sort the String Alphabetically
                    words.SortString = SortStringAsc(words.OriginalText); 
                    
                    // Encrypt the String with SHA384
                    words.EncryptedText = Convert.ToBase64String(ComputeHash(words.OriginalText)); 
                }
                ModelState.Clear();
                return View(words);
            }
            catch
            {
                return View();
            }
        }
        public string ReverseWords(string input)
        {
            String[] words = input.Split(' ');
            int end = words.Length - 1;
            String s2 = "";
            for (int start = 0; start < end; start++)
            {
                String tempc;
                if (start < end)
                {
                    tempc = words[start];
                    words[start] = words[end];
                    words[end--] = tempc;
                }
            }
            foreach (String s1 in words)
            {
                s2 += s1 + " ";
            }
            return s2;
        }

        public String ReverseCharacters(string str)
        {
            char[] chars = str.ToCharArray();
            for (int i = 0, j = str.Length - 1; i < j; i++, j--)
            {
                chars[i] = str[j];
                chars[j] = str[i];
            }
            return new string(chars);
        }

        public string SortStringAsc(string str)
        {
            string[] splitStr = str.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            var sortStr = from s in splitStr
                       orderby s
                       select s;
            string x = string.Empty;

            foreach (var words in sortStr)
            {
                x = x + " " + words;
            }
            //Remove whitespaces
            string output = x.ToString().Remove(0, 1);
            return output;
        }
        // http://www.c-sharpcorner.com/blogs/example-for-md5-hashing-and-sh512salted-hashing
        public static byte[] ComputeHash(string plainText)
        {
            int minSaltLength = 4, maxSaltLength = 16;
            byte[] saltBytes = null;

            // For selecting random SALT
            Random r = new Random();
            int length = r.Next(minSaltLength, maxSaltLength);
            saltBytes = new byte[length];
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            rng.GetNonZeroBytes(saltBytes);
            rng.Dispose();

            byte[] plainData = ASCIIEncoding.UTF8.GetBytes(plainText);
            byte[] plainDataAndSalt = new byte[plainData.Length + saltBytes.Length];

            for (int x = 0; x < plainData.Length; x++)
                plainDataAndSalt[x] = plainData[x];
            for (int n = 0; n < saltBytes.Length; n++)
                plainDataAndSalt[plainData.Length + n] = saltBytes[n];

            byte[] hashValue = null;
            SHA384Managed sha384 = new SHA384Managed();
            hashValue = sha384.ComputeHash(plainDataAndSalt);
            sha384.Dispose();
            
            byte[] result = new byte[hashValue.Length + saltBytes.Length];
            for (int x = 0; x < hashValue.Length; x++)
                result[x] = hashValue[x];
            for (int n = 0; n < saltBytes.Length; n++)
                result[hashValue.Length + n] = saltBytes[n];

            return result;
        }

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

    }
}
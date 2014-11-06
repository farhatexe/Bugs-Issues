using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTasks.Data.Tests.Extensions
{
    public static class StringExtension
    {
        public static string Generate(int length)
        {
            string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890"; // Tu supprimes les lettres dont tu ne veux pas
            string pass = "";

            for (int x = 0; x < length; x++)
            {
                int i = new Random().Next(62);
                pass += chars.Skip(i-1).FirstOrDefault();
            }

            return pass;
        }
    }
}

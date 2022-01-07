using System;
using System.Collections.Generic;
using System.Text;

namespace IBCompSciApp.Models
{
    public class CodeGeneration
    {
        public static int code;
        public static void GenerateCode()
        {
            Random random = new Random();
            code = random.Next(1000, 8000);
        }
    }
}

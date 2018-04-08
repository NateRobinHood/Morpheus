using Composer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Morpheus
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Instantiating Morpheus Framework");
            Console.WriteLine("Instantiating the Composer");

            ComposerEngine dbContext = new ComposerEngine();
            string queryString = dbContext.RequestRecords.Sql;

            Console.WriteLine("Composer Ready");
            Console.ReadLine();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingEventsTester
{
    class Program
    {
        static void Main(string[] args)
        {
            insertApp();
        }

        private static void insertApp()
        {
            var _appObj = new CodeEventsDomain.Classes.myApp
            {
                AppDESC = "new App Desc",
                AppName = "My App ",

            };
            using (var context = new CodeEventsDomain.DataModel.CodingEventContext())
            {
                context.Database.Log = Console.WriteLine;
                context.APP_DS.Add(_appObj);
                context.SaveChanges();
            }

        }
    }
}

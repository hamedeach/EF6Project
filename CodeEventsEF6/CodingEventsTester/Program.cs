using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingEventsTester
{
    class Program
    {
        static void Main(string[] args)
        {
            Database.SetInitializer(new NullDatabaseInitializer<CodeEventsDomain.DataModel.CodingEventContext>());
            //insertApp();
            appQuery();

            Console.ReadLine(); 
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

        private static void appQuery()
        {
            using (var context = new CodeEventsDomain.DataModel.CodingEventContext())
            {
                context.Database.Log = Console.WriteLine;
                var app = context.APP_DS.ToList();
                foreach (var item in app)
                {
                    Console.WriteLine("APP Name is : \r\n" + item.AppName);

                }
              
            }
        }



    }
}

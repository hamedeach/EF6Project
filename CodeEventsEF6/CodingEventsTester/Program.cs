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
            insertApp();
            insertLayer();
            //appQuery();
            //update();
            //loadrelatedData_AppLayers();
            //delete();


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

        private static void insertLayer()
        {
            using (var context = new CodeEventsDomain.DataModel.CodingEventContext())
            {
                context.Database.Log = Console.WriteLine;
                var app = context.APP_DS.ToList().FirstOrDefault();
                app.MyAppLayers.Add(new CodeEventsDomain.Classes.APP_Layers {  LayerDESC = "new layer desc" });
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

        private static void update()
        {
            using (var context = new CodeEventsDomain.DataModel.CodingEventContext())
            {
                context.Database.Log = Console.WriteLine;
                var app = context.APP_DS.ToList().Find(a => a.Id == 1);
                app.AppDESC = "this is updated desc ";
                context.SaveChanges();

            }

        }

        private static void delete()
        {
            using (var context = new CodeEventsDomain.DataModel.CodingEventContext())
            {
                context.Database.Log = Console.WriteLine;
                var app = context.APP_DS.ToList().Find(a => a.Id == 1);
                context.APP_DS.Remove(app);
                context.SaveChanges();
            }
        }

        private static void loadrelatedData_AppLayers()
        {
            
        }


    }

}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeEventsDomain.Classes
{
   public class myApp
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string AppName { get; set; }
        public string AppDESC { get; set; }
        public string AppDesc2 { get; set; }

        public  List<APP_Layers> MyAppLayers { get; set; }

        public myApp()
        {
            this.MyAppLayers = new List<APP_Layers>();
        }
    }
}

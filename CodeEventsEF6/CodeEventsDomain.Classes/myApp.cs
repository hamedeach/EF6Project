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
        public int Id { get; set; }
        public string AppName { get; set; }
        public string AppDESC { get; set; }
        public List<APP_Layers> MyAppLayers { get; set; }
    }
}

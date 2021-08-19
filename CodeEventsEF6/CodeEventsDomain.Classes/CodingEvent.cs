using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeEventsDomain.Classes
{
    public abstract class CodingEvent
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EventID { get; set; }
        public string EventDesc { get; set; }

        [Required]
        public int LayerID { get; set; }
        [Required]
        public int AppID { get; set; }
        public int EventTypeID { get; set; }

       // [Required]
        [ForeignKey("LayerID,AppID")]
        public APP_Layers LayerObj { get; set; }
      //  [Required]
       // [ForeignKey("AppID"), Column(Order = 1)]
        //public myApp AppObj { get; set; }
    }

    public class ErrorEvent : CodingEvent
    {
        public ErrorEvent()
        {
            this.EventTypeID = 1;
        }
    }

    public class WarningEvent : CodingEvent
    {
        public WarningEvent()
        {
            this.EventTypeID = 2;
        }

    }

    public class InfoEvent : CodingEvent
    {
        public InfoEvent()
        {
            this.EventTypeID = 0;

        }

    }


}

﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeEventsDomain.Classes
{
   public class APP_Layers
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Key]
        [Column(Order =1)]
        public int AppID { get; set; }
       

        public int? Parent_Layer_ID { get; set; }
        public int? Parent_App_ID { get; set; }
        public string LayerName { get; set; }
        public string LayerDESC { get; set; }

       
        [Required]
        [ForeignKey("AppID")]
        public myApp MyApp { get; set; }

        [ForeignKey("Parent_Layer_ID,Parent_App_ID")]
        public virtual APP_Layers ParentLayer { get; set; }

        public List<CodingEvent> LayerEvents { get; set; }


    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ms_Machine.Domain.Poulina.MSmachine.Domain.Models
{
    public class Service
    {
    
        [Key]
        public Guid id_service { get; set; }
        public string label { get; set; }
        public Guid id_filiaire { get; set; }
        public Filiaire Filiaire { get; set; }
        

    }
}

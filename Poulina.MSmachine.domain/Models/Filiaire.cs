using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;


namespace Ms_Machine.Domain.Poulina.MSmachine.Domain.Models
{
    public class Filiaire
    {
        [Key]
        public Guid id_filiaire { get; set; }
        public String label { get; set; }

        public ICollection<Service> Services { get; set; }


    }
}

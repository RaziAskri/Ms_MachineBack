using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ms_Machine.Domain.Poulina.MSmachine.Domain.Models
{
    public class Fournisseur
    {
        [Key]
        public Guid id_fournisseur { get; set; }
        public string label { get; set; }
        public string adresse_fournisseur { get; set; }
        public ICollection<Machine> Machines { get; set; }

    }
}

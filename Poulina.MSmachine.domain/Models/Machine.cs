using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;





namespace Ms_Machine.Domain.Poulina.MSmachine.Domain.Models
{
    public class Machine
    {
        [Key]
        public Guid id_machine { get; set; }
        public string label { get; set; }

        public string type_machine { get; set; }
        public string etat_machine { get; set; }
        public Guid id_fournisseur { get; set; }
        public Fournisseur Fournisseur { get; set; }

       
    }
}

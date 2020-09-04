using System;
using System.Collections.Generic;
using System.Text;

namespace Ms_Machine.Domain.Poulina.MSmachine.Domain.Models.DTO
{
    public class MachineDTO
    {
        public Guid id_machine { get; set; }
        public string label { get; set; }

        public string type_machine { get; set; }
        public string etat_machine { get; set; }
        public string label_fournisseur { get; set; }

    }
}

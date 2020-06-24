using System;
using System.Collections.Generic;
using System.Text;

namespace Mahzan.Models.Entities
{
    public class Postal_Codes
    {
        public string DCodigo { get; set; }

        public string DAsenta { get; set; }

        public string DTipoAsenta { get; set; }

        public string DMnpio { get; set; }

        public string DEstado { get; set; }
        public string DCiudad { get; set; }

        public string DCp { get; set; }

        public string CEstado { get; set; }

        public string COficina { get; set; }

        public string CCP { get; set; }

        public string CTipoAsenta { get; set; }

        public string CMnpio { get; set; }

        public string IdAsentaCpcons { get; set; }

        public string dZona { get; set; }

        public string CCveCiudad { get; set; }

        public Guid countryId { get; set; }
    }
}

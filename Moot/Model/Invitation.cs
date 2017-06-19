using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Moot.Model
{
    public class Invitation
    {
        public int Id { get; set; }

        public int EventId { get; set; }

        public int ContactId { get; set; }

        public int ConfirmationStatus { get; set; }

        public bool isOrganiser { get; set; }
    }
}

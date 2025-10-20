using Exiled.API.Features;
using Exiled.Events.EventArgs.Scp096;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pluginimsiseyler.EventHandlers
{
    public static class Enrage
    {
        public static void Enraged(EnragingEventArgs ev)
        {
            Cassie.Message("O h hello.");
        }
    }
}

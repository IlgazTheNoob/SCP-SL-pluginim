using Exiled.API.Extensions;
using Exiled.API.Features;
using Exiled.Events.EventArgs.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pluginimsiseyler.EventHandlers
{
    public static class Verified
    {
        public static void OnVerified(VerifiedEventArgs ev)
        {
            
            ev.Player.ShowHint("Suncuya girdin", 8);
            Cassie.GlitchyMessage("hello how is hello", 8, 8);
        }
    }
}

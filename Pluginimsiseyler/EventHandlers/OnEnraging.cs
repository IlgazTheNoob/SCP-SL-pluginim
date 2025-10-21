using Exiled.API.Extensions;
using Exiled.API.Features;
using Exiled.Events.EventArgs.Scp096;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pluginimsiseyler.EventHandlers
{
    public static class OnEnraging
    {
        
        public static void OnEnragingStart(AddingTargetEventArgs ev)
        {
            Cassie.MessageTranslated("a n a n golf 17", "baban ama knk");

            ev.Player.SetName(ev.Player, "anan");
        }
    }
}

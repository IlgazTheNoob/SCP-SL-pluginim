using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exiled.API.Features;
using Exiled.Events.EventArgs.Player;
using Exiled.Events.EventArgs.Server;
using Exiled.Events.Features;
using LabApi.Events.Arguments.ServerEvents;


namespace Pluginimsiseyler.EventHandlers
{
    internal class RoleHandler
    {
        public static void TurBasi(RoundStartingEventArgs ev)
        {
            Cassie.MessageTranslated("Round started.", "Tur başaldı");
        }
    }
}

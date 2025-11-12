using Exiled.API.Extensions;
using Exiled.Events.EventArgs.Player;
using InventorySystem;
using PluginAPI.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pluginimsiseyler.EventHandlers
{
    internal class Escaped
    {
        public void PlayerEscaped(EscapingEventArgs player)
        {
            List<string> escaped = player.Player.Items.Select(x => x.ToString()).ToList();
            
        }
    }
}

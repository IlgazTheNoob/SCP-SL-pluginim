using Exiled.API.Features;
using Exiled.Events.EventArgs.Scp096;
using PluginAPI.Core;
using PluginAPI.Events;
using Respawning;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;

namespace Pluginimsiseyler.EventHandlers
{
    public static class Enrage
    {
        public static void Enreage(EnragingEventArgs ev)
        {
            Exiled.API.Features.Cassie.MessageTranslated($"scp a n a n successfully terminated by automatic security system",
                   $" b a b a n successfully terminated by Automatic Security System.");
            Console.WriteLine("başarılı?");
        }
        
    }
}

using Exiled.API.Features;
using Exiled.CustomItems.API.Features;
using Exiled.Events.Handlers;
using Exiled.Loader;
using LabApi.Events.Handlers;
using Pluginimsiseyler.EventHandlers;
using enrage = Exiled.Events.Handlers.Scp096;
using player = Exiled.Events.Handlers.Player;
using server = Exiled.Events.Handlers.Server;
namespace Pluginimsiseyler
{
    public class Class1 : Plugin<Config>
    {
        public static Class1 Instance;
        public override void OnEnabled()
        {
            Instance = this;
            enrage.AddingTarget += EventHandlers.OnEnraging.OnEnragingStart;
            player.Verified += EventHandlers.Verified.OnVerified;
            
            CustomItem.RegisterItems();
             base.OnEnabled();   
        }

        public override void OnDisabled()
        {
            Instance = null;
            enrage.AddingTarget -= EventHandlers.OnEnraging.OnEnragingStart;
            player.Verified -= EventHandlers.Verified.OnVerified;
            CustomItem.UnregisterItems();
            base.OnDisabled();
        }
    }
}


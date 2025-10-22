using Exiled.API.Features;
using Exiled.CustomItems.API.Features;
using Exiled.CustomRoles.API;
using Exiled.Events.Handlers;
using Exiled.Loader;
using Pluginimsiseyler.CustomRoles;
using Pluginimsiseyler.EventHandlers;
using enrage = Exiled.Events.Handlers.Scp096;
using player = Exiled.Events.Handlers.Player;
using server = Exiled.Events.Handlers.Server;
namespace Pluginimsiseyler
{
    public class Class1 : Plugin<Config>
    {
        public static Class1 Instance;
        public RoleHandler RoleHandler;
        public static KabadayıClassD KabadayiRole;
        public static KaçakçıClassD KacakciRole;
        public static CüceClassD CüceDRole;

        public override void OnEnabled()
        {
            Instance = this;
            RoleHandler = new RoleHandler();
            KabadayiRole = new KabadayıClassD();
            KabadayiRole.Register();
            KacakciRole = new KaçakçıClassD();
            KacakciRole.Register();
            CüceDRole = new CüceClassD();
            CüceDRole.Register();
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


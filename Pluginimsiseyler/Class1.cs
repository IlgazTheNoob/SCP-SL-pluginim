using Exiled.API.Features;
using Exiled.CustomItems;
using Exiled.CustomItems.API;
using Exiled.CustomItems.API.Features;
using Exiled.CustomRoles.API;
using Exiled.Events.Handlers;
using Exiled.Loader;
using Pluginimsiseyler.CustomItems;
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
        public static KorkakBilim KorkakRole;
        public static MucitBilim MucitRole;
        public static KaosClassD KaosRole;
        public static OneUseCICard CICard;
        public static AmirGuard AmirRole;
        public static KıdemliGuard KıdemliRole;
        

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
            KaosRole = new KaosClassD();
            KaosRole.Register();
            KorkakRole = new KorkakBilim();
            KorkakRole.Register();
            MucitRole = new MucitBilim();
            MucitRole.Register();        
            AmirRole = new AmirGuard();
            AmirRole.Register();
            KıdemliRole = new KıdemliGuard();
            KıdemliRole.Register();
            player.Verified += EventHandlers.Verified.OnVerified;
           




            CICard = new OneUseCICard();
            CICard.Register();
            CustomItem.RegisterItems();


            base.OnEnabled();   
        }

        public override void OnDisabled()
        {
            Instance = null;
            
            player.Verified -= EventHandlers.Verified.OnVerified;
            CustomItem.UnregisterItems();
            base.OnDisabled();
        }
    }
}


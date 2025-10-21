using Exiled.API.Features;
using Exiled.Loader;
using enrage = Exiled.Events.Handlers.Scp096;
namespace Pluginimsiseyler
{
    public class Class1 : Plugin<Config>
    {
        public static Class1 Instance;
        public override void OnEnabled()
        {
            Instance = this;
            enrage.Enraging += EventHandlers.Enrage.Enreage;
             base.OnEnabled();   
        }

        public override void OnDisabled()
        {
            Instance = null;
            enrage.Enraging -= EventHandlers.Enrage.Enreage;
            base.OnDisabled();
        }
    }
}


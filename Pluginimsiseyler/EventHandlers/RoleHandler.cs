using System.Threading.Tasks;
using Exiled.API.Features;
using Exiled.CustomRoles.API.Features;
using PlayerRoles;
using ServerEvents = Exiled.Events.Handlers.Server;
using ExPlayer = Exiled.API.Features.Player;
using Pluginimsiseyler.CustomRoles;

namespace Pluginimsiseyler.EventHandlers
{
    public class RoleHandler
    {
        public RoleHandler()
        {
            // RoundStarted event'ine bağlan
            ServerEvents.RoundStarted += OnRoundStarted;
        }

        private async void OnRoundStarted()
        {
            // 0.1 saniye gecikme, vanilla spawn için
            await Task.Delay(100);

            // Round başında tüm oyunculara bak
            foreach (ExPlayer player in ExPlayer.List)
            {
                // Sadece Class-D olanlara custom rol ver
                if (player.Role.Type == RoleTypeId.ClassD)
                {
                    CustomRole.Get(typeof(KaçakçıClassD))?.AddRole(player); ;
                    

                }
            }
        }
    }
}
//
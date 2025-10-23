using System.Threading.Tasks;
using Exiled.API.Features;
using Exiled.CustomRoles.API.Features;
using PlayerRoles;
using ServerEvents = Exiled.Events.Handlers.Server;
using ExPlayer = Exiled.API.Features.Player;
using Pluginimsiseyler.CustomRoles;
using System;
using UnityEngine;
using System.Security.Cryptography;


namespace Pluginimsiseyler.EventHandlers
{
    public class RoleHandler
    {
        public RoleHandler()
        {
            
            ServerEvents.RoundStarted += OnRoundStarted;
        }

        private async void OnRoundStarted()
        {
            
            await Task.Delay(100);

            
            foreach (ExPlayer player in ExPlayer.List)
            {
                

                if(player.Role.Type == RoleTypeId.ClassD) {
                    float randomRole = UnityEngine.Random.Range(1, 6);
                    if (randomRole == 1)
                    {              
                        CustomRole.Get(typeof(CüceClassD))?.AddRole(player);
                    }
                    if (randomRole == 2)
                    {                                      
                        CustomRole.Get(typeof(KabadayıClassD))?.AddRole(player);                   
                    }
                    if (randomRole == 3)
                    {                                       
                        CustomRole.Get(typeof(KaçakçıClassD))?.AddRole(player);
                    }
                }
                if (player.Role.Type == RoleTypeId.Scientist)
                {
                    float randomRole = UnityEngine.Random.Range(1, 4);
                    if (randomRole == 1)
                    {
                        CustomRole.Get(typeof(KorkakBilim))?.AddRole(player);
                    }
                    if (randomRole == 2)
                    {
                        CustomRole.Get(typeof(MucitBilim))?.AddRole(player);
                    }
                    
                }

            }
        }
    }
}

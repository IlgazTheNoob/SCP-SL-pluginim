using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EPlayer = Exiled.Events.Handlers.Player;
using EMap = Exiled.Events.Handlers.Map;
using Exiled.Events.EventArgs.Player;
using Exiled.API.Features;
using Exiled.API.Features.Attributes;
using Exiled.API.Features.Roles;
using PlayerRoles;
using Exiled.CustomRoles.API.Features;
using Exiled.API.Features.Items;

namespace Pluginimsiseyler.CustomRoles
{
    [CustomRole(PlayerRoles.RoleTypeId.ClassD)]
    public class KaçakçıClassD : CustomRole
    {
        
        public override string Name { get; set; } = "Kaçakçı Class-D";
        public override int MaxHealth { get; set; } = 100;
        public override string Description { get; set; } = "Oyuna bir kart ve ağrı kesici ile başladın";
        public override string CustomInfo { get; set; }
        public override uint Id { get; set; } = 3001;
        public override bool KeepPositionOnSpawn { get; set; } = true;
        public override RoleTypeId Role { get; set; } = RoleTypeId.ClassD;
        public override List<string> Inventory { get; set; } = new List<string>
        {
            "KeycardScientist",
            "Painkillers"
        };
        protected override void ShowMessage(Player player)
        {

        }
        protected override void ShowBroadcast(Player player)
        {

        }
        public override bool KeepRoleOnChangingRole { get; set; } = false;
        public override bool KeepRoleOnDeath { get; set; } = false;

        public override void AddRole(Player player)
        {
            base.AddRole(player);
            player.Broadcast(5, "<color=orange>Kaçakçı Class-D oldun.</color>");
            player.Health = MaxHealth;
            
        }
    }
}
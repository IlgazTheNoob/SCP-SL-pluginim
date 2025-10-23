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

namespace Pluginimsiseyler.CustomRoles
{
    [CustomRole(PlayerRoles.RoleTypeId.ClassD)]
    public class KabadayıClassD : CustomRole
    {
        public override string Name { get; set; } = "Kabadayı Class-D";
        public override int MaxHealth { get; set; } = 150;
        public override string Description { get; set; } = "Canın normalden daha fazla.";
        public override string CustomInfo { get; set; }
        public override uint Id { get; set; } = 3000;
        public override bool KeepPositionOnSpawn { get; set; } = true;
        public override RoleTypeId Role { get; set; } = RoleTypeId.ClassD;
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
            player.Broadcast(5, "<color=orange>Kabadayı Class-D oldun.</color>");
            player.Health = MaxHealth;
        }
        }
}

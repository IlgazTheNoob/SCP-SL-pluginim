using CustomPlayerEffects;
using Exiled.API.Features;
using Exiled.API.Features.Attributes;
using Exiled.API.Features.Items;
using Exiled.API.Features.Roles;
using Exiled.CustomRoles;
using Exiled.CustomRoles.API.Features;
using Exiled.Events.EventArgs.Player;
using PlayerRoles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using EMap = Exiled.Events.Handlers.Map;
using EPlayer = Exiled.Events.Handlers.Player;

namespace Pluginimsiseyler.CustomRoles
{
    [CustomRole(PlayerRoles.RoleTypeId.Scientist)]
    public class KorkakBilim : CustomRole
    {
        public override string Name { get; set; } = "Korkak Bilim Adamı";
        public override string Description { get; set; } = "Normal bir insandan daha hızlısın.";
        public override uint Id { get; set; } = 3004;
        public override string CustomInfo { get; set; }
        public override int MaxHealth { get; set; } = 100;
        public override RoleTypeId Role { get; set; } = RoleTypeId.Scientist;
   
        protected override void ShowMessage(Player player)
        {

        }
        protected override void ShowBroadcast(Player player)
        {

        }
        public override bool KeepRoleOnChangingRole { get; set; } = true;
        public override bool KeepRoleOnDeath { get; set; } = false;
        public override bool KeepInventoryOnSpawn { get; set; } = true;

        public override void AddRole(Player player)
        {
            base.AddRole(player);
            player.Broadcast(5, "<color=Yellow>Korkak Bilim adamı</color>  oldun.");
            player.Health = MaxHealth;
            player.EnableEffect<MovementBoost>(0, true);
            player.ChangeEffectIntensity<MovementBoost>(Class1.Instance.Config.KorkakHız, 0);
        }
    }
}

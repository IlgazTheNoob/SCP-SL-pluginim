using CustomPlayerEffects;
using Exiled.API.Features;
using Exiled.API.Features.Attributes;
using Exiled.API.Features.Items;
using Exiled.API.Features.Roles;
using Exiled.CustomRoles;
using Exiled.CustomRoles.API.Features;
using Exiled.Events.EventArgs.Player;
using InventorySystem.Items.Usables;
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
    public class MucitBilim : CustomRole
    {
        public override string Name { get; set; } = "Mucit Bilim Adamı";
        public override string Description { get; set; } = "Oyuna ekstra bir SCP-500 ve Yüzey Erişim Kartı ile başlarsın.";
        public override uint Id { get; set; } = 3005;
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

        public override bool KeepInventoryOnSpawn { get; set; } = false;
        public override List<string> Inventory { get; set; } = new List<string>
        {
            "SurfaceAccessPass",
            "Adrenaline",
            "KeycardScientist",
            "Medkit"
        };

        public override void AddRole(Player player)
        {
            base.AddRole(player);
            player.Broadcast(5, "<color=yellow>Mucit Bilim adamı</color>  oldun.");
            player.Health = MaxHealth;
            
        }
    }
}

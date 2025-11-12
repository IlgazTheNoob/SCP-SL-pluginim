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
using Exiled.API.Enums;


namespace Pluginimsiseyler.CustomRoles
{
    [CustomRole(PlayerRoles.RoleTypeId.FacilityGuard)]
    public class KıdemliGuard : CustomRole
    {
        public override string Name { get; set; } = "Kıdemli Guard";
        public override string Description { get; set; } = "Oyuna bir Crossvec ve Balistik Yelek ile başlarsın";
        public override int MaxHealth { get; set; } = 100;
        public override string CustomInfo { get; set; }
        public override uint Id { get; set; } = 3007;
        public override Dictionary<AmmoType, ushort> Ammo { get => base.Ammo; set => base.Ammo = value; }
        public override RoleTypeId Role { get; set; } = RoleTypeId.FacilityGuard;

        public override List<string> Inventory { get; set; } = new List<string>
        {
            "KeycardGuard",
            "GunCOM15",
            "GunFSP9",
            "Medkit",
            "GrenadeFlash",
            "Radio",
            "ArmorCombat"
            
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
            player.Broadcast(5, "<color=orange>Amir Tesis Görevlisi.</color> oldun.");
            player.Health = MaxHealth;
            
        }
    }
}

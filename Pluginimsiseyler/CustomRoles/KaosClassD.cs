using Exiled.API.Features;
using Exiled.API.Features.Attributes;
using Exiled.API.Features.Roles;
using Exiled.CustomItems.API.Features;
using Exiled.CustomRoles.API.Features;
using Exiled.Events.EventArgs.Player;
using PlayerRoles;
using Pluginimsiseyler.CustomItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EMap = Exiled.Events.Handlers.Map;
using EPlayer = Exiled.Events.Handlers.Player;
using Exiled.CustomItems;
using Exiled.API.Features.Items;
using InventorySystem;

namespace Pluginimsiseyler.CustomRoles
{
    [CustomRole(PlayerRoles.RoleTypeId.ClassD)]
    public class KaosClassD : CustomRole
    {
        public override string Name { get; set; } = "Kaos Ajanı Class-D";
        public override int MaxHealth { get; set; } = 100;
        public override string Description { get; set; } = "Oyuna tek kullanımlık bir kaos erişim cihazı ile başlar.";
        public override string CustomInfo { get; set; }
        public override uint Id { get; set; } = 3003;
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

        public override List<string> Inventory { get; set; } = new List<string>
        {
            "Tek kullanımlık Kaos Kartı"
        };

        public override bool KeepInventoryOnSpawn { get; set; } = true;

        protected override void RoleAdded(Player player)
        {
            base.RoleAdded(player);
            CustomItem.TryGive(player, 301);
            Log.Warn("Verilmiş olması lazım.");
        }

        
    }
}
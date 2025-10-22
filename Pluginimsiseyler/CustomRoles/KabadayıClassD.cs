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
    internal class KabadayıClassD : CustomRole
    {
        public override string Name { get; set; } = "Kabadayı Class-D";
        public override int MaxHealth { get; set; } = 150;
        public override string Description { get; set; } = "Canın normalden daha fazla.";
        public override string CustomInfo { get; set; }
        public override uint Id { get; set; } = 9;
        public override bool KeepPositionOnSpawn { get; set; } = true;
    }
}

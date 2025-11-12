using Exiled.API.Enums;
using Exiled.API.Features.Attributes;
using Exiled.API.Features.Spawn;
using Exiled.CustomItems.API.Features;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EPlayer = Exiled.Events.Handlers.Player;
using EMap = Exiled.Events.Handlers.Map;
using Exiled.Events.EventArgs.Player;
using Exiled.API.Features;
using Exiled.API.Features.Pickups;
using UnityEngine;


namespace Pluginimsiseyler.CustomItems
{
    [CustomItem(ItemType.GrenadeHE)]
    internal class ImpactGrenade : CustomGrenade
    {        
        public override string Name { get; set; } = "Impact Grenade";
        public override string Description { get; set; } = "Pimi çekilince anında patlayan bir bomba.\n Kullanıcı için ölümcüldür.";
        public override uint Id { get; set; } = 300;
        public override float Weight { get; set; } = default;
        public override bool ExplodeOnCollision { get; set; } = false;
        public override float FuseTime { get; set; } = 0;
        public override Vector3 Scale { get; set; } = new Vector3(1.2f, 1.2f, 1.2f);
        protected override void ShowPickedUpMessage(Player player)
        {
            player.ShowHint("Bir Impact Grenade aldın.", 5);
        }
        protected override void ShowSelectedMessage(Player player)
        {
            player.ShowHint("Bu bir Impact Grenade.", 5);
        }

        public override SpawnProperties SpawnProperties { get; set; } = new()
        {
            Limit = 4,
            DynamicSpawnPoints = 
            [
                new DynamicSpawnPoint
                {
                    Chance = 50,
                    Location = SpawnLocationType.Inside049Armory
                },

                new DynamicSpawnPoint
                {
                    Chance = 50,
                    Location = SpawnLocationType.InsideHczArmory
                },
                new DynamicSpawnPoint
                {
                    Chance = 100,
                    Location = SpawnLocationType.Inside096
                },
                new DynamicSpawnPoint
                {
                    Chance = 50,
                    Location = SpawnLocationType.InsideIntercom
                },
                new DynamicSpawnPoint
                {
                    Chance = 50,
                    Location = SpawnLocationType.InsideSurfaceNuke
                },
                new DynamicSpawnPoint
                {
                    Chance = 50,
                    Location = SpawnLocationType.InsideHid
                }
            ]

        };
        protected override void SubscribeEvents()
        {
            
            EPlayer.PickingUpItem += OnPickingUp;
            
            base.SubscribeEvents();
        }
        protected override void UnsubscribeEvents()
        {
            EPlayer.PickingUpItem -= OnPickingUp;
            base.UnsubscribeEvents();
        }

        private void OnPickUp(PickingUpItemEventArgs ev)
        {
            if (Check(ev.Pickup)) {
                if(Id == 1)
                {
                    ev.Player.ShowHint("Bir Frag Grenade aldın.", 8);
                }
            
            }
        }
        

    }
}

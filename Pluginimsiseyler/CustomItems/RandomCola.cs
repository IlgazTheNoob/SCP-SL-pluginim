using CustomPlayerEffects;
using Exiled.API.Enums;
using Exiled.API.Features;
using Exiled.API.Features.Attributes;
using Exiled.API.Features.Spawn;
using Exiled.CustomItems.API.Features;
using Exiled.Events.EventArgs.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pluginimsiseyler.CustomItems
{
    [CustomItem(ItemType.SCP207)]
    public class RandomCola : CustomItem
    {
        public override string Name { get; set; } = "Rasgele Kola";
        public override string Description { get; set; } = "İçildiğinde rastgele bir efekt veren kola";
        public override float Weight { get; set; } = 1;
        public override uint Id { get; set; } = 302;
        public override SpawnProperties SpawnProperties { get; set; } = new()
        {
            Limit = 2,
            DynamicSpawnPoints =
            [
                new DynamicSpawnPoint
                {
                    Chance = 100,
                    Location = SpawnLocationType.Inside049Armory
                },
                new DynamicSpawnPoint
                {
                    Chance = 100,
                    Location = SpawnLocationType.InsideSurfaceNuke
                },
            ]

        };

        protected override void ShowPickedUpMessage(Player player)
        {
            
        }
        protected override void ShowSelectedMessage(Player player)
        {
            
        }

        protected override void SubscribeEvents()
        {
            base.SubscribeEvents();
            
            
            Exiled.Events.Handlers.Player.UsingItemCompleted += OnDrink;
        }

        
        protected override void UnsubscribeEvents()
        {
            Exiled.Events.Handlers.Player.UsingItemCompleted -= OnDrink;
            base.UnsubscribeEvents();
        }


        private void OnDrink(UsingItemCompletedEventArgs ev)
        {
            if (!Check(ev.Player.CurrentItem)) return; 
            ev.Player.ShowHint("Random Kola içildi!", 3f);
            ColaEffectInvis(ev.Player);
        }

        private void ColaEffectInvis(Player player)
        {
            player.DisableEffect<MovementBoost>();
            player.EnableEffect<Invisible>(50, 50);
        }
    }
}

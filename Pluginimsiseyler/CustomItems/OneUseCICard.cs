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
    [CustomItem(ItemType.SCP207)]
    public class OneUseCICard : CustomItem
    {
        public override string Name { get; set; } = "Random Kola";
        public override string Description { get; set; } = "İçildiğinde rastgele bir efekt veren kola.";
        public override float Weight { get; set; } = 1f;
        public override uint Id { get; set; } = 301;
        public override SpawnProperties SpawnProperties { get; set; }
        protected override void ShowSelectedMessage(Player player)
        {
            player.ShowHint("Bu kart tek kullanımlık. İyi kullan!");
        }
        protected override void ShowPickedUpMessage(Player player)
        {
            
        }
        
        private Exiled.Events.Features.Event<InteractingDoorEventArgs> doorEvent;
        private Exiled.Events.Features.Event<InteractingLockerEventArgs> lockerEvent;

        protected override void SubscribeEvents()
        {
            base.SubscribeEvents();

            doorEvent = Exiled.Events.Handlers.Player.InteractingDoor;
            doorEvent += OnDoorInteracted;
            lockerEvent = Exiled.Events.Handlers.Player.InteractingLocker;
            lockerEvent += OnLockerInteracted;
        }

        protected override void UnsubscribeEvents()
        {
            doorEvent -= OnDoorInteracted;
            lockerEvent -= OnLockerInteracted;
            base.UnsubscribeEvents();
        }

        private void OnDoorInteracted(InteractingDoorEventArgs ev)
        {
            
            if (!Check(ev.Player.CurrentItem))
                return;

           
            ev.Player.RemoveItem(ev.Player.CurrentItem);
            ev.Player.ShowHint("Kart kapıyı açtı ama kırıldı!", 3);
        }
        private void OnLockerInteracted(InteractingLockerEventArgs ev)
        {
            if (!Check(ev.Player.CurrentItem))
                return;


            ev.Player.RemoveItem(ev.Player.CurrentItem);
            ev.Player.ShowHint("Kart dolabı açtı ama kırıldı!", 3);
        }
    }
}

using CommandSystem.Commands.RemoteAdmin;
using CustomPlayerEffects;
using Exiled.API.Enums;
using Exiled.API.Extensions;
using Exiled.API.Features;
using Exiled.API.Features.Attributes;
using Exiled.API.Features.Roles;
using Exiled.API.Features.Spawn;
using Exiled.CustomItems.API.Features;
using Exiled.Events.Commands.Config;
using Exiled.Events.Commands.Reload;
using Exiled.Events.EventArgs.Player;
using InventorySystem.Items.Usables.Scp244.Hypothermia;
using MEC;
using PlayerRoles;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


namespace Pluginimsiseyler.CustomItems
{
    [CustomItem(ItemType.SCP207)]
    public class RandomCola : CustomItem
    {
        public override string Name { get; set; } = "Rastgele Kola";
        public override string Description { get; set; } = "İçildiğinde rastgele bir efekt veren kola";
        public override float Weight { get; set; } = 1;
        public override uint Id { get; set; } = 301;
        public override SpawnProperties SpawnProperties { get; set; } = new()
        {
            Limit = 2,
            DynamicSpawnPoints = new List<DynamicSpawnPoint> 
            {
                new DynamicSpawnPoint
                {
                    Chance = 100,
                    Location = SpawnLocationType.Inside049Armory
                },
                new DynamicSpawnPoint
                {
                    Chance = 100,
                    Location = SpawnLocationType.InsideSurfaceNuke
                }
            }
        };

        
        protected override void ShowPickedUpMessage(Player player)
        {
            player.ShowHint("Bir Rastgele Kola aldın.", 5);
        }
        protected override void ShowSelectedMessage(Player player) 
        {
            player.ShowHint("Bu bir Rastgele Kola.", 5);
        }

        protected override void SubscribeEvents()
        {
            Exiled.Events.Handlers.Player.UsingItemCompleted += OnDrink;
            base.SubscribeEvents();
        }

        protected override void UnsubscribeEvents()
        {
            Exiled.Events.Handlers.Player.UsingItemCompleted -= OnDrink;
            base.UnsubscribeEvents();
        }

        

        private void OnDrink(UsingItemCompletedEventArgs ev)
        {

            if (!Check(ev.Item)) return;
            ev.Player.DisableEffect<Scp207>();
            ev.Player.ShowHint("Random Kola içildi!", 3f);

            int anaZar = UnityEngine.Random.Range(0, 101);

            if (anaZar == 0)
            {
                ColaEffectExplosion(ev.Player);
                return;
            }
            if (anaZar < 21)
            {
                int kötüZar = UnityEngine.Random.Range(0, 4);
                switch(kötüZar)
                {
                    case 0: ColaEffectSCPTp(ev.Player); break;
                    case 1: ColaEffectOneHP(ev.Player); break;
                    case 2: ColaEffectPocketD(ev.Player); break;
                    case 3: ColaEffectHypotermia(ev.Player); break;
                }
                return;
            }
            if (anaZar < 71)
            {
                int nötrZar = UnityEngine.Random.Range(0, 3);
                switch(nötrZar)
                {
                    case 0: ColaEffectTeamSwap(ev.Player); break;
                    case 1: ColaEffectLightsOut(ev.Player); break;
                    case 2: ColaEffectLockdown(ev.Player); break;
                }
                return;
            }
            if (anaZar < 100)
            {
                int iyiZar = UnityEngine.Random.Range(0, 4);
                switch (iyiZar)
                {
                    case 0: ColaEffectInvis(ev.Player); break;
                    case 1: ColaEffectSpectatorSpawn(ev.Player); break;
                    case 2: ColaEffectSpeed(ev.Player); break;
                    case 3: ColaEffectHp(ev.Player); break;
                }
                return;
            }

        }

        private void ColaEffectSCPTp(Player player)
        {

            List<Player> scpList = Player.List.Where(p => p.IsScp).ToList();


            if (scpList.Count == 0)
            {
                player.ShowHint("Sunucuda ışınlanacak SCP yok!", 3f);
                return;
            }

            
            int randomIndex = Random.Range(0, scpList.Count);

            Player selectedScp = scpList[randomIndex];

            if (selectedScp != null)
            {
                // SCP'yi oyuncunun yanına ışınla
                selectedScp.Teleport(player);               
                player.ShowHint($"{selectedScp.Nickname} yanına çekildi!", 5f);
            }
        } 

        private void ColaEffectInvis(Player player)
        {
            player.EnableEffect<Invisible>(50f);
            player.Broadcast(5, "50 saniyeliğine görünmez oldun!");
        } 

        private void ColaEffectTeamSwap(Player player)
        {

            Timing.CallDelayed(0.2f, () =>
            {
                RoleTypeId yeniRol = RoleTypeId.None;

                if (player.Role.Team == Team.FoundationForces || player.Role.Team == Team.Scientists)
                {
                    yeniRol = RoleTypeId.ChaosConscript;
                }
                else if (player.Role.Team == Team.ChaosInsurgency || player.Role.Team == Team.ClassD)
                {
                    yeniRol = RoleTypeId.NtfPrivate;
                }

                if (yeniRol != RoleTypeId.None)
                {
                    player.Role.Set(yeniRol, RoleSpawnFlags.None);
                    player.Broadcast(5, "Rakip takıma geçtin!");
                }
            });
        } 
            
        private void ColaEffectSpectatorSpawn(Player player) 
        {
            Player spawned1 = null;
            Player spawned2 = null;
            List<Player> spectatorList = Player.List.Where(p => p.IsDead).ToList()
                .OrderBy(p => System.Guid.NewGuid())
                .ToList();
            if (spectatorList.Count == 0)
            {
                player.ShowHint("Sunucuda doğabilicek izleyici yok!", 3f);
                return;
            }
            
            for(int i = 1; i < 3; i++)
            {
                spectatorList = Player.List.Where(p => p.IsDead).ToList()
                .OrderBy(p => System.Guid.NewGuid())
                .ToList();
                int randomIndex = Random.Range(0, spectatorList.Count);
                Player selectedSpectator = spectatorList[randomIndex];
                selectedSpectator.Role.Set(RoleTypeId.Tutorial, RoleSpawnFlags.UseSpawnpoint);
                selectedSpectator.Role.Set(player.Role, RoleSpawnFlags.None);
                selectedSpectator.Teleport(player);
                if(i==1) spawned1= selectedSpectator;
                if(i==2) spawned2 = selectedSpectator;
            }
            player.Broadcast(5, spawned1.Nickname + " ve " + spawned2.Nickname + " isimli oyuncuları canlandırdın.");
            player.Broadcast(5, player.Nickname + " isimli oyuncu seni canlandırdı!");
            player.Broadcast(5, player.Nickname + " isimli oyuncu seni canlandırdı!");
        } 

        private void ColaEffectSpeed(Player player)
        {
            player.EnableEffect<MovementBoost>(50, 0);
            player.Broadcast(5, "Biraz fazla şekerliydi galiba.");
        } 

        private void ColaEffectHp(Player player)
        {
            player.Health = 250;
            player.Broadcast(5, "Canın arttı!");
        }  

        private void ColaEffectExplosion(Player player)
        {
            player.Broadcast(2, "Burası duman mı kokuyor?");

            Timing.CallDelayed(2, () =>
            {
                player.Explode();
            });
           
        }  

        private void ColaEffectLightsOut(Player player)
        {
            
            ZoneType zone = player.Zone;
            string zoneName;
            switch (zone)
            {
                default:
                case ZoneType.LightContainment:
                    zoneName = "Light Containment Zone";
                    break;
                case ZoneType.HeavyContainment:
                    zoneName = "Heavy Containment Zone";
                    break;
                case ZoneType.Entrance:
                    zoneName = "Enterence Zone";
                    break;
                case ZoneType.Surface:
                    zoneName = "Surface Zone";
                    break;
            }

            player.Broadcast(5, "Bulunduğun bölgede elektrik kesintisi yaşandı.");

            foreach (Room room in Room.List)
            {
                
                if(room.Zone == zone)
                {
                    room.TurnOffLights(20f);                                    
                }
                
            }
            Cassie.MessageTranslated("pitch_0.2 .g4 .g4 pitch_1.0 electrical failure detected in " + zoneName, zoneName + "'da elektrik kesintisi tespit edildi.");
        } 

        private void ColaEffectLockdown(Player player)
        {
            player.CurrentRoom.LockDown(10, DoorLockType.Regular079);
            player.Broadcast(5, "Bulunduğun odada bir kapı arızası var.");
        } 

        private void ColaEffectOneHP(Player player)
        {
            player.Health = 1f;
            player.Broadcast(5, "Bu kola zehirliymiş.");
        } 

        private void ColaEffectPocketD(Player player)
        {
            Room pocketRoom = Room.Get(RoomType.Pocket);            
                
                player.EnableEffect<PocketCorroding>();
                player.Teleport(pocketRoom);
                player.Broadcast(5, "Görüşürüz. Şanslıysan...");
        } 

        private void ColaEffectHypotermia(Player player)
        {
            player.EnableEffect<Hypothermia>(50, 20f);
            player.Broadcast(5, "Klimayı kim açtı?");
        } 
    }
}
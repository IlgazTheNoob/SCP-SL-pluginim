using Exiled.API.Interfaces;
using UnityEngine;

namespace Pluginimsiseyler
{
    public class Config : IConfig
    {
        public bool IsEnabled { get; set; } = true;
        public bool Debug { get; set; }

        public Vector3 CüceBoy { get; set; } = new Vector3(1f, 0.375f, 1f);
        public byte CüceHız { get; set; } = 20;
    }
}

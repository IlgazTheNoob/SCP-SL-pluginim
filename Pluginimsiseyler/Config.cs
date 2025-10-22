using Exiled.API.Interfaces;

namespace Pluginimsiseyler
{
    public class Config : IConfig
    {
        public bool IsEnabled { get; set; } = true;
        public bool Debug { get; set; }

        
    }
}

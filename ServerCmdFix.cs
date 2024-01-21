using CounterStrikeSharp.API;
using CounterStrikeSharp.API.Core;
using CounterStrikeSharp.API.Core.Attributes;

namespace SharpTimer
{
    [MinimumApiVersion(141)]
    public partial class ServerCmdFix : BasePlugin
    {
        public override string ModuleName => "ServerCmdFix";
        public override string ModuleVersion => $"1.0 - {new DateTime(Builtin.CompileTime, DateTimeKind.Utc)}";
        public override string ModuleAuthor => "DEAFPS https://github.com/DEAFPS/";
        public override string ModuleDescription => "A Plugin to remove point_servercommand entities";

        public override void Load(bool hotReload)
        {

            RegisterListener<Listeners.OnMapStart>(OnMapStartHandler);

            Console.WriteLine("[ServerCmdFix] Plugin Loaded");
        }

        public void OnMapStartHandler(string mapName)
        {
            var pointServerCommands = Utilities.FindAllEntitiesByDesignerName<CPointServerCommand>("point_servercommand");
            foreach (var servercmd in pointServerCommands)
            {
                if (servercmd == null) continue;
                servercmd.Remove();
            }
        }
    }
}

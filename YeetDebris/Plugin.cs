using HarmonyLib;
using IPA;
using System.Reflection;

namespace YeetDebris
{

    [Plugin(RuntimeOptions.SingleStartInit)]
    public class Plugin
    {
        internal static Plugin instance { get; private set; }
        internal static string Name => "YeetDebris";

        [Init]
        public void Init()
        {
            instance = this;
            new Harmony("com.steven.yeet.debris").PatchAll(Assembly.GetExecutingAssembly());
        }
    }
}

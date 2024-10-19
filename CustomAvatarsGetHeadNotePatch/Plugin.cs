using HarmonyLib;
using IPA;
using System.Reflection;
using IPALogger = IPA.Logging.Logger;

namespace CustomAvatarsGetHeadNotePatch
{
    [Plugin(RuntimeOptions.SingleStartInit)]
    public class Plugin
    {
        internal static Plugin Instance { get; private set; }
        /// <summary>
        /// Use to send log messages through BSIPA.
        /// </summary>
        internal static IPALogger Log { get; private set; }
        public const string HARMONY_ID = "com.github.rynan4818.CustomAvatarsGetHeadNotePatch";
        private static Harmony _harmony;

        [Init]
        public Plugin(IPALogger logger)
        {
            Instance = this;
            Log = logger;
        }

        [OnStart]
        public void OnApplicationStart()
        {
            Log.Info("OnApplicationStart");
            _harmony = new Harmony(HARMONY_ID);
            _harmony.PatchAll(Assembly.GetExecutingAssembly());
        }

        [OnExit]
        public void OnApplicationQuit()
        {
            Log.Debug("OnApplicationQuit");
            _harmony.UnpatchSelf();
        }

    }
}

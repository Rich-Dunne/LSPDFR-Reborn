using LSPD_First_Response.Mod.API;
using Rage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LSPDFR_Reborn
{
    public class LSPDFRReborn : Plugin
    {
        private static bool s_onDuty = false;
        private static Version s_version = Assembly.GetEntryAssembly().GetName().Version;

        // Called when the plug-in is being initialized (LSPDFR loaded)
        public override void Initialize()
        {
            Functions.OnOnDutyStateChanged += OnOnDutyStateChangedHandler;
        }

        // Called when going on/off duty
        private static void OnOnDutyStateChangedHandler(bool OnDuty)
        {
            s_onDuty = OnDuty;

            while (true)
            {
                GameFiber.StartNew(delegate
                {
                    // Main Process
                    GameFiber.Sleep(100);
                });
            }
        }

        // Called when the plug-in is being shut off (LSPDFR unloaded)
        public override void Finally()
        {

        }


    }
}

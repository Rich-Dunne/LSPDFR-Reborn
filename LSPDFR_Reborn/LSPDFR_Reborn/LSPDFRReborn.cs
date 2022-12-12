using LSPD_First_Response.Mod.API;
using LSPDFR_Reborn.StopTheCivilian;
using LSPDFR_Reborn.Util.Processing;
using Rage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LSPDFR_Reborn
{
    public class LSPDFRReborn : Plugin
    {
        private static bool s_onDuty = false;
        private static Version s_version = Assembly.GetCallingAssembly().GetName().Version;
        private static bool _onDuty = false;

        // Called when the plug-in is being initialized (LSPDFR loaded)
        public override void Initialize()
        {
            Functions.OnOnDutyStateChanged += OnOnDutyStateChangedHandler;

            ProcessingPool.RegisterProcess(new PedastrianStop());
            ProcessingPool.RegisterProcess(new PoliceBackup.PoliceBackup());
            ProcessingPool.CanRegister = false;
        }

        // Called when going on/off duty
        private static void OnOnDutyStateChangedHandler(bool OnDuty)
        {
            s_onDuty = OnDuty;
            if (s_onDuty)
            {
                // Going on duty
                ProcessingPool.StartProcesses();

                Game.DisplayNotification("LSPDFRReborn started (DEV) " + s_version.ToString());
                //Game.DisplayNotification("web_lossantospolicedept", "web_lossantospolicedept", "LSPD:FR Reborn", $"~y~{s_version.ToString()} by VELRX-Team.", "Thanks for using.");

            } else
            {
                // Going off duty
                ProcessingPool.StopProcesses();

                Game.DisplayNotification("LSPDFRReborn stopped (DEV) " + s_version.ToString());

            }

            GameFiber.StartNew(delegate
            {
                while(s_onDuty)
                {
                    GameFiber.Yield();
                    ProcessingPool.UpdateProcesses();

                    GameFiber.Sleep(1);
                }
            });
            _onDuty = OnDuty;
        }

        // Called when the plug-in is being shut off (LSPDFR unloaded)
        public override void Finally()
        {

        }
    }
}

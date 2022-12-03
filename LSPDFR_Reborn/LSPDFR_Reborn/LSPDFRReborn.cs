using LSPD_First_Response.Mod.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LSPDFR_Reborn
{
    public class LSPDFRReborn : Plugin
    {
        // Called when the plug-in is being initialized (LSPDFR loaded)
        public override void Initialize()
        {
            Functions.OnOnDutyStateChanged += OnOnDutyStateChangedHandler;
        }

        // Called when going on/off duty
        private static void OnOnDutyStateChangedHandler(bool OnDuty)
        {
        }

        // Called when the plug-in is being shut off (LSPDFR unloaded)
        public override void Finally()
        {

        }
    }
}

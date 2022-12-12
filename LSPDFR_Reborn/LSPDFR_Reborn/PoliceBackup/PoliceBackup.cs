using LSPDFR_Reborn.Util;
using Rage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LSPDFR_Reborn.PoliceBackup
{
    internal class PoliceBackup : Process
    {
        public override void Start()
        {
            Game.DisplayNotification("Start PoliceBackup " + DateTime.Now.Millisecond);
        }

        public override void Update()
        {
            if (Game.IsKeyDown(System.Windows.Forms.Keys.B))
            {
                Game.DisplayNotification("Update (Pressing B)");
            }
        }

        public override void Finally()
        {
            Game.DisplayNotification("Stop");
        }
    }
}

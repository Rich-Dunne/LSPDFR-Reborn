using LSPDFR_Reborn.Util;
using Rage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LSPDFR_Reborn.StopTheCivilian
{
    internal class PedastrianStop : Process
    {
        public override void Start()
        {
            Game.DisplayNotification("Start " + DateTime.Now.Millisecond);
        }

        public override void Update()
        {
            if(Game.IsKeyDown(System.Windows.Forms.Keys.E))
            {
                Game.DisplayHelp("Update (Pressing E)");
            }
        }

        public override void Finally()
        {
            Game.DisplayHelp("Stop");
        }
    }
}

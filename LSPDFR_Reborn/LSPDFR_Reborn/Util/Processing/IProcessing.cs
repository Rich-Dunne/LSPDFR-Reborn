using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LSPDFR_Reborn.Util
{
    internal interface IProcessing
    {
        /// <summary>
        /// This will be called once when going on duty.
        /// </summary>
        void Start();
        /// <summary>
        /// This will be permanently called during duty for every 1ms.
        /// </summary>
        void Update();

        /// <summary>
        /// This will be called once when going off duty.
        /// </summary>
        void Finally();

    }
}

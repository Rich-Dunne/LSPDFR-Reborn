using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LSPDFR_Reborn.Util
{
    internal abstract class Process : IProcessing
    {
        public virtual void Finally()
        {
            throw new NotImplementedException();
        }

        public virtual void Start()
        {
            throw new NotImplementedException();
        }

        public virtual void Update()
        {
            throw new NotImplementedException();
        }
    }
}

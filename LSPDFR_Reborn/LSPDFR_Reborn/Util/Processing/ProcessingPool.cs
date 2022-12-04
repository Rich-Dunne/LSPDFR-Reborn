using Rage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LSPDFR_Reborn.Util.Processing
{
    internal class ProcessingPool
    {
        private static List<IProcessing> s_processes = new List<IProcessing>(); 
        public static void RegisterProcess(IProcessing process)
        {
            if(!s_processes.Contains(process))
            {
                s_processes.Add(process);
            }
        }

        public static void RemoveProcess(IProcessing process)
        {
            s_processes.Remove(process);
        }

        public static void StartProcesses()
        {
            foreach(var process in s_processes)
            {
                process.Start();
            }
        }

        public static void UpdateProcesses()
        {
            foreach (var process in s_processes)
            {
                process.Update();
            }
        }

        public static void StopProcesses()
        {
            foreach (var process in s_processes)
            {
                process.Finally();
            }
        }
    }
}

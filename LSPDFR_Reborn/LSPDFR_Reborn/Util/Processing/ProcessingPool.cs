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

        private static List<IProcessing> _processes = new List<IProcessing>(); 
        public static void RegisterProcess(IProcessing process)
        {
            if (!_processes.Contains(process) && _canRegister)
            {
                _processes.Add(process);
            }
        }

        private static bool _canRegister = true;
        public static bool CanRegister
        {
            get { return _canRegister; }
            set
            {
                _canRegister = value;
            }
        }

        public static void RemoveProcess(IProcessing process)
        {
            _processes.Remove(process);
        }

        public static void StartProcesses()
        {
            foreach(var process in _processes)
            {
                process.Start();
            }
        }

        public static void UpdateProcesses()
        {
            foreach (var process in _processes)
            {
                process.Update();
            }
        }

        public static void StopProcesses()
        {
            foreach (var process in _processes)
            {
                process.Finally();
            }
        }
    }
}

using Rage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LSPDFR_Reborn.Configuration
{
    internal class Configuration
    {
        private static InitializationFile _configurationSettings = new InitializationFile("Plugins/LSPDFR/LSPDFRReborn/Reborn.ini");

        /// <summary>
        /// Initializes the <b>Configuration File</b>.<br></br><br></br> This always <b>needs</b> to be called before accessing
        /// the values of the <b>Configuration File</b>, to avoid exceptions.
        /// </summary>
        public static void InitializeConfigurationFile()
        {

        }

        /// <summary>
        /// This method can change values in the .ini Configuration file. Use it carefully and pay attention to the datatypes!
        /// </summary>
        /// <param name="sectionName">The section where the targeted value is located. Example: <br></br><b>[Keybinds]</b> (section name)<br></br>Key = F7</param>
        /// <param name="name">The value name. Example: <b>Key</b> (name) = F7 </param>
        /// <param name="newValue">The value which will be overwritten. Example: Key = <b>F7</b> (value)</param>
        public static void Write(string sectionName, string name, string newValue)
        {
            _configurationSettings.Write(sectionName, name, newValue);
        }

    }
}

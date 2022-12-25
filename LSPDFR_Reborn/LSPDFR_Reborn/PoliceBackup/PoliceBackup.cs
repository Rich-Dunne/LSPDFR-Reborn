using LSPDFR_Reborn.Util;
using Rage;
using RAGENativeUI;
using RAGENativeUI.Elements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LSPDFR_Reborn.PoliceBackup
{
    internal class PoliceBackup : Process
    {
        private static Keys s_menuKey = Keys.B; // Only for developing purposes

        private static int s_menuXOffset = 100;
        private static int s_menuYOffset = 100;

        private static MenuPool _menuPool;
        private UIMenu _menu;

        private UIMenuListScrollerItem<string> _codeBackup;

        private List<PoliceBackupUnit> _code3Units;
        private List<PoliceBackupUnit> _code2Units;

        public override void Start()
        {
            Game.DisplayNotification("Start PoliceBackup " + DateTime.Now.Millisecond);
            _menuPool = new MenuPool();
            _menu = new UIMenu("PoliceBackup", "Call for backup!", System.Drawing.Point.Empty, "phone_wallpaper_blueshards", "phone_wallpaper_blueshards");
            _menuPool.Add(_menu);
            _menu.MouseControlsEnabled = false;

            var _filePath = @"C:\Users\adamn\source\repos\Rich-Dunne\LSPDFR-Reborn\LSPDFR_Reborn\LSPDFR_Reborn\PoliceBackup\XMLFile1.xml";
            var _policeBackupUnits = XMLSerializer.DeserializeXML<PoliceBackupUnits>(_filePath);

            _codeBackup = new UIMenuListScrollerItem<string>("Backup", "", new[] { "Code 3", "Code 2", "K9", "Partner" });
            _menu.AddItems(_codeBackup);

            _code3Units = new List<PoliceBackupUnit>();
            _code2Units = new List<PoliceBackupUnit>();

            foreach (PoliceBackupUnit _policeBackupUnit in _policeBackupUnits.PoliceBackupUnit)
            {
                try
                {
                    if (_policeBackupUnit.Code2.Equals("True"))
                    {
                        _code2Units.Add(_policeBackupUnit);
                    }
                    if (_policeBackupUnit.Code3.Equals("True"))
                    {
                        _code3Units.Add(_policeBackupUnit);
                    }
                }
                catch (Exception e)
                {
                    Game.LogTrivial(e.ToString());
                }
            }

            GameFiber.StartNew(delegate
            {
                while (true)
                {

                }
            });
        }

        public override void Update()
        {
            GameFiber.StartNew(delegate
            {
                _menuPool.ProcessMenus();

                if (Game.IsKeyDown(s_menuKey))
                {
                    _menu.Visible = true;
                }
            });
        }

        public override void Finally()
        {
            Game.DisplayNotification("Stop");
        }
    }
}

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
using LSPD_First_Response.Mod.API;
using LSPD_First_Response.Engine.Scripting;
using System.Drawing;
using Rage.Native;

namespace LSPDFR_Reborn.Backup
{
    internal class Backup : Process
    {
        private static Rage.Ped _player => Game.LocalPlayer.Character;

        private static Keys s_menuKey = Keys.B; // Only for developing purposes

        private static int s_menuXOffset = 100;
        private static int s_menuYOffset = 100;

        private static MenuPool _menuPool;
        private static UIMenu _menu;

        private static UIMenuListScrollerItem<string> _codeBackup;

        private static List<PoliceBackupUnit> s_code3Units;
        private static List<PoliceBackupUnit> s_code2Units;

        private static List<UIMenuItem> s_code3UnitMenuItems;
        private static List<UIMenuItem> s_code2UnitMenuItems;
        private static List<UIMenuItem> s_k9MenuItems;

        public override void Start()
        {
            Game.DisplayNotification("Start Backup " + DateTime.Now.Millisecond);
            _menuPool = new MenuPool();
            _menu = new UIMenu("Backup", "Call for backup!", new System.Drawing.Point(s_menuXOffset, s_menuYOffset), "phone_wallpaper_blueshards", "phone_wallpaper_blueshards");
            _menuPool.Add(_menu);
            _menu.MouseControlsEnabled = false;

            var _filePath = @"C:\Users\adamn\source\repos\Rich-Dunne\LSPDFR-Reborn\LSPDFR_Reborn\LSPDFR_Reborn\Backup\XMLFile1.xml";
            var _policeBackupUnits = XMLSerializer.DeserializeXML<PoliceBackupUnits>(_filePath);

            _codeBackup = new UIMenuListScrollerItem<string>("Backup", "", new[] { "Code 3", "Code 2", "K9", "Partner" });
            _menu.OnScrollerChange += _menu_OnScrollerChange;
            _menu.AddItems(_codeBackup);

            s_code3Units = new List<PoliceBackupUnit>();
            s_code2Units = new List<PoliceBackupUnit>();

            s_code3UnitMenuItems = new List<UIMenuItem>();
            s_code2UnitMenuItems = new List<UIMenuItem>();
            s_k9MenuItems = new List<UIMenuItem>();
            
            foreach (PoliceBackupUnit _policeBackupUnit in _policeBackupUnits.PoliceBackupUnit)
            {
                try
                {
                    if (_policeBackupUnit.Code2.Equals("True"))
                    {
                        s_code2Units.Add(_policeBackupUnit);
                    }
                    if (_policeBackupUnit.Code3.Equals("True"))
                    {
                        s_code3Units.Add(_policeBackupUnit);
                    }
                }
                catch (Exception e)
                {
                    Game.LogTrivial(e.ToString());
                }
            }

            foreach (PoliceBackupUnit _code3Unit in s_code3Units)
            {
                UIMenuItem _code3UnitItem = new UIMenuItem(_code3Unit.Name, "Press Enter to request Unit.");
                _code3UnitItem.Activated += (s, e) =>
                {
                    var _playerZone = Functions.GetZoneAtPosition(_player.Position);
                    if (_playerZone.County.Equals(EWorldZoneCounty.LosSantos))
                    {
                        string _colorString = string.Empty;
                        string _vehicleName = string.Empty;
                        _chooseVehicle(_code3Unit.LSCity.VehicleSet.Vehicles, out _colorString, out _vehicleName);
                        Rage.Vehicle _unitVehicle = new Rage.Vehicle(_vehicleName, World.GetNextPositionOnStreet(_player.Position.Around(float.Parse(_code3Unit.LSCity.VehicleSet.Spawn_distance, System.Globalization.CultureInfo.InvariantCulture.NumberFormat))), 0f);
                        if (_colorString != string.Empty)
                        {
                            Color _vehicleColor = Color.FromName(_colorString);
                            _unitVehicle.PrimaryColor = _vehicleColor;
                        }
                        Blip _unitVehicleBlip = new Blip(_unitVehicle);
                        _unitVehicleBlip.Color = Color.LightBlue;
                        List<Ped> _code3UnitPeds = new List<Ped>();
                        _choosePeds(2, _code3Unit.LSCity.VehicleSet.Peds, out _code3UnitPeds);
                        foreach (Ped _ped in _code3UnitPeds)
                        {
                            Game.LogTrivial(_ped.Model);
                            Rage.Ped _code3UnitPed = new Rage.Ped(_ped.Model, _unitVehicle.Position, 0);
                            Functions.SetPedAsCop(_code3UnitPed);
                            _setPedVariation(_ped, _code3UnitPed);
                            _setPedProps(_ped, _code3UnitPed);
                            _setPedWeapons(_code3Unit.LSCity.VehicleSet.Weapons, _code3UnitPed);
                        }
                    }
                    else if (_playerZone.County.Equals(EWorldZoneCounty.LosSantosCounty))
                    {
                        string _colorString = string.Empty;
                        string _vehicleName = string.Empty;
                        _chooseVehicle(_code3Unit.LSCounty.VehicleSet.Vehicles, out _colorString, out _vehicleName);
                        Rage.Vehicle _unitVehicle = new Rage.Vehicle(_vehicleName, World.GetNextPositionOnStreet(_player.Position.Around(float.Parse(_code3Unit.LSCounty.VehicleSet.Spawn_distance, System.Globalization.CultureInfo.InvariantCulture.NumberFormat))), 0f);
                        if (_colorString != string.Empty)
                        {
                            Color _vehicleColor = Color.FromName(_colorString);
                            _unitVehicle.PrimaryColor = _vehicleColor;
                        }
                        Blip _unitVehicleBlip = new Blip(_unitVehicle);
                        _unitVehicleBlip.Color = Color.LightBlue;
                        List<Ped> _code3UnitPeds = new List<Ped>();
                        _choosePeds(2, _code3Unit.LSCounty.VehicleSet.Peds, out _code3UnitPeds);
                        foreach (Ped _ped in _code3UnitPeds)
                        {
                            Game.LogTrivial(_ped.Model);
                            Rage.Ped _code3UnitPed = new Rage.Ped(_ped.Model, _unitVehicle.Position, 0);
                            Functions.SetPedAsCop(_code3UnitPed);
                            _setPedVariation(_ped, _code3UnitPed);
                            _setPedProps(_ped, _code3UnitPed);
                        }
                    }
                    else if (_playerZone.County.Equals(EWorldZoneCounty.BlaineCounty))
                    {
                        string _colorString = string.Empty;
                        string _vehicleName = string.Empty;
                        _chooseVehicle(_code3Unit.BCounty.VehicleSet.Vehicles, out _colorString, out _vehicleName);
                        Rage.Vehicle _unitVehicle = new Rage.Vehicle(_vehicleName, World.GetNextPositionOnStreet(_player.Position.Around(float.Parse(_code3Unit.BCounty.VehicleSet.Spawn_distance, System.Globalization.CultureInfo.InvariantCulture.NumberFormat))), 0f);
                        if (_colorString != string.Empty)
                        {
                            Color _vehicleColor = Color.FromName(_colorString);
                            _unitVehicle.PrimaryColor = _vehicleColor;
                        }
                        Blip _unitVehicleBlip = new Blip(_unitVehicle);
                        _unitVehicleBlip.Color = Color.LightBlue;
                        List<Ped> _code3UnitPeds = new List<Ped>();
                        _choosePeds(2, _code3Unit.BCounty.VehicleSet.Peds, out _code3UnitPeds);
                        foreach (Ped _ped in _code3UnitPeds)
                        {
                            Game.LogTrivial(_ped.Model);
                            Rage.Ped _code3UnitPed = new Rage.Ped(_ped.Model, _unitVehicle.Position, 0);
                            Functions.SetPedAsCop(_code3UnitPed);
                            _setPedVariation(_ped, _code3UnitPed);
                            _setPedProps(_ped, _code3UnitPed);
                        }
                    }
                    else if (_playerZone.County.Equals(EWorldZoneCounty.NorthYankton))
                    {
                        string _colorString = string.Empty;
                        string _vehicleName = string.Empty;
                        _chooseVehicle(_code3Unit.NY.VehicleSet.Vehicles, out _colorString, out _vehicleName);
                        Rage.Vehicle _unitVehicle = new Rage.Vehicle(_vehicleName, World.GetNextPositionOnStreet(_player.Position.Around(float.Parse(_code3Unit.NY.VehicleSet.Spawn_distance, System.Globalization.CultureInfo.InvariantCulture.NumberFormat))), 0f);
                        if (_colorString != string.Empty)
                        {
                            Color _vehicleColor = Color.FromName(_colorString);
                            _unitVehicle.PrimaryColor = _vehicleColor;
                        }
                        Blip _unitVehicleBlip = new Blip(_unitVehicle);
                        _unitVehicleBlip.Color = Color.LightBlue;
                        List<Ped> _code3UnitPeds = new List<Ped>();
                        _choosePeds(2, _code3Unit.NY.VehicleSet.Peds, out _code3UnitPeds);
                        foreach (Ped _ped in _code3UnitPeds)
                        {
                            Game.LogTrivial(_ped.Model);
                            Rage.Ped _code3UnitPed = new Rage.Ped(_ped.Model, _unitVehicle.Position, 0);
                            Functions.SetPedAsCop(_code3UnitPed);
                            _setPedVariation(_ped, _code3UnitPed);
                            _setPedProps(_ped, _code3UnitPed);
                        }
                    }
                    else if (_playerZone.County.Equals(EWorldZoneCounty.CayoPerico))
                    {
                        string _colorString = string.Empty;
                        string _vehicleName = string.Empty;
                        _chooseVehicle(_code3Unit.CP.VehicleSet.Vehicles, out _colorString, out _vehicleName);
                        Rage.Vehicle _unitVehicle = new Rage.Vehicle(_vehicleName, World.GetNextPositionOnStreet(_player.Position.Around(float.Parse(_code3Unit.CP.VehicleSet.Spawn_distance, System.Globalization.CultureInfo.InvariantCulture.NumberFormat))), 0f);
                        if (_colorString != string.Empty)
                        {
                            Color _vehicleColor = Color.FromName(_colorString);
                            _unitVehicle.PrimaryColor = _vehicleColor;
                        }
                        Blip _unitVehicleBlip = new Blip(_unitVehicle);
                        _unitVehicleBlip.Color = Color.LightBlue;
                        List<Ped> _code3UnitPeds = new List<Ped>();
                        _choosePeds(2, _code3Unit.CP.VehicleSet.Peds, out _code3UnitPeds);
                        foreach (Ped _ped in _code3UnitPeds)
                        {
                            Game.LogTrivial(_ped.Model);
                            Rage.Ped _code3UnitPed = new Rage.Ped(_ped.Model, _unitVehicle.Position, 0);
                            Functions.SetPedAsCop(_code3UnitPed);
                            _setPedVariation(_ped, _code3UnitPed);
                            _setPedProps(_ped, _code3UnitPed);
                        }
                    }
                };

                s_code3UnitMenuItems.Add(_code3UnitItem);
            }
            foreach (PoliceBackupUnit _code2Unit in s_code2Units)
            {
                UIMenuItem _code2UnitItem = new UIMenuItem(_code2Unit.Name, "Press Enter to request Unit.");
                s_code2UnitMenuItems.Add(_code2UnitItem);
            }

            _constructCode3UnitItems();

            GameFiber.StartNew(delegate
            {
                while (true)
                {
                    GameFiber.Yield();
                    _menuPool.ProcessMenus();
                }
            });
        }

        private void _setPedWeapons(Weapons _weapons, Rage.Ped _code3UnitPed)
        {
            foreach (NonLethal _nonLethal in _weapons.NonLethals.NonLethal)
            {
                new Weapon(_nonLethal.Text, new Vector3(0f, 0f, 0f), 500).GiveTo(_code3UnitPed);
            }

            if (_weapons.HandGuns.HandGun.Count > 1)
            {
                Random r = new Random();
                int e = r.Next(0, 100);
                var _orderedList = _weapons.HandGuns.HandGun.OrderBy(x => Math.Abs(int.Parse(x.Chance) - e)).ToList();
                Weapon _handgun = new Weapon(_orderedList.First().Text, new Vector3(0f, 0f, 0f), 500);
                _handgun.GiveTo(_code3UnitPed);
                _code3UnitPed.Inventory.AddComponentToWeapon(_handgun.Asset, _orderedList.First().Comp_1);
                _code3UnitPed.Inventory.EquippedWeapon = _handgun.Asset;
            }
        }

        private void _setPedProps(Ped _unitPed, Rage.Ped _ragePed)
        {
            if (_unitPed.Prop_hats != null)
            {
                if (_unitPed.Tex_hats == null)
                    NativeFunction.Natives.SET_PED_PROP_INDEX(_ragePed, 0, int.Parse(_unitPed.Prop_hats), 0, true, 0);
                else
                    NativeFunction.Natives.SET_PED_PROP_INDEX(_ragePed, 0, int.Parse(_unitPed.Prop_hats), int.Parse(_unitPed.Tex_hats), true, 0);
            }
            if (_unitPed.Prop_glasses != null)
            {
                if (_unitPed.Tex_glasses == null)
                    NativeFunction.Natives.SET_PED_PROP_INDEX(_ragePed, 1, int.Parse(_unitPed.Prop_glasses), 0, true, 0);
                else
                    NativeFunction.Natives.SET_PED_PROP_INDEX(_ragePed, 1, int.Parse(_unitPed.Prop_glasses), int.Parse(_unitPed.Tex_glasses), true, 0);
            }
            if (_unitPed.Prop_ears != null)
            {
                if (_unitPed.Tex_ears == null)
                    NativeFunction.Natives.SET_PED_PROP_INDEX(_ragePed, 2, int.Parse(_unitPed.Prop_ears), 0, true, 0);
                else
                    NativeFunction.Natives.SET_PED_PROP_INDEX(_ragePed, 2, int.Parse(_unitPed.Prop_ears), int.Parse(_unitPed.Tex_ears), true, 0);
            }
            if (_unitPed.Prop_watches != null)
            {
                if (_unitPed.Tex_watches == null)
                    NativeFunction.Natives.SET_PED_PROP_INDEX(_ragePed, 6, int.Parse(_unitPed.Prop_watches), 0, true, 0);
                else
                    NativeFunction.Natives.SET_PED_PROP_INDEX(_ragePed, 6, int.Parse(_unitPed.Prop_watches), int.Parse(_unitPed.Tex_watches), true, 0);
            }
        }

        private void _setPedVariation(Ped _unitPed, Rage.Ped _ragePed)
        {
            if (_unitPed.Comp_face != null)
            {
                if (_unitPed.Tex_face == null)
                    _ragePed.SetVariation(0, int.Parse(_unitPed.Comp_face), 0);
                else
                    _ragePed.SetVariation(0, int.Parse(_unitPed.Comp_face), int.Parse(_unitPed.Tex_face));
            }
            if (_unitPed.Comp_beard != null)
            {
                if (_unitPed.Tex_beard == null)
                    _ragePed.SetVariation(1, int.Parse(_unitPed.Comp_beard), 0);
                else
                    _ragePed.SetVariation(1, int.Parse(_unitPed.Comp_beard), int.Parse(_unitPed.Tex_beard));
            }
            if (_unitPed.Comp_hair != null)
            {
                if (_unitPed.Tex_hair == null)
                    _ragePed.SetVariation(2, int.Parse(_unitPed.Comp_hair), 0);
                else
                    _ragePed.SetVariation(2, int.Parse(_unitPed.Comp_hair), int.Parse(_unitPed.Tex_hair));
            }
            if (_unitPed.Comp_shirt != null)
            {
                if (_unitPed.Tex_shirt == null)
                    _ragePed.SetVariation(3, int.Parse(_unitPed.Comp_shirt), 0);
                else
                    _ragePed.SetVariation(3, int.Parse(_unitPed.Comp_shirt), int.Parse(_unitPed.Tex_shirt));
            }
            if (_unitPed.Comp_pants != null)
            {
                if (_unitPed.Tex_pants == null)
                    _ragePed.SetVariation(4, int.Parse(_unitPed.Comp_pants), 0);
                else
                    _ragePed.SetVariation(4, int.Parse(_unitPed.Comp_pants), int.Parse(_unitPed.Tex_pants));
            }
            if (_unitPed.Comp_hands != null)
            {
                if (_unitPed.Tex_decals == null)
                    _ragePed.SetVariation(5, int.Parse(_unitPed.Comp_decals), 0);
                else
                    _ragePed.SetVariation(5, int.Parse(_unitPed.Comp_decals), int.Parse(_unitPed.Tex_decals));
            }
            if (_unitPed.Comp_shoes != null)
            {
                if (_unitPed.Tex_shoes == null)
                    _ragePed.SetVariation(6, int.Parse(_unitPed.Comp_shoes), 0);
                else
                    _ragePed.SetVariation(6, int.Parse(_unitPed.Comp_shoes), int.Parse(_unitPed.Tex_shoes));
            }
            if (_unitPed.Comp_accessories != null)
            {
                if (_unitPed.Tex_accessories == null)
                    _ragePed.SetVariation(8, int.Parse(_unitPed.Comp_accessories), 0);
                else
                    _ragePed.SetVariation(8, int.Parse(_unitPed.Comp_accessories), int.Parse(_unitPed.Tex_accessories));
            }
            if (_unitPed.Comp_tasks != null)
            {
                if (_unitPed.Tex_tasks == null)
                    _ragePed.SetVariation(9, int.Parse(_unitPed.Comp_tasks), 0);
                else
                    _ragePed.SetVariation(9, int.Parse(_unitPed.Comp_tasks), int.Parse(_unitPed.Tex_tasks));
            }
            if (_unitPed.Comp_decals != null)
            {
                if (_unitPed.Tex_decals == null)
                    _ragePed.SetVariation(10, int.Parse(_unitPed.Comp_decals), 0);
                else
                    _ragePed.SetVariation(10, int.Parse(_unitPed.Comp_decals), int.Parse(_unitPed.Tex_decals));
            }
            if (_unitPed.Comp_shirtoverlay != null)
            {
                if (_unitPed.Tex_shirtoverlay == null)
                    _ragePed.SetVariation(11, int.Parse(_unitPed.Comp_shirtoverlay), 0);
                else
                    _ragePed.SetVariation(11, int.Parse(_unitPed.Comp_shirtoverlay), int.Parse(_unitPed.Tex_shirtoverlay));
            }
        }

        private void _choosePeds(int _requiredPeds, Peds _peds, out List<Ped> _returnedPeds)
        {
            /*for (int i = 0; i < _requiredPeds; i++)
            {
                Random r = new Random();
                int e = r.Next(0, 100);
                List<int> array = new List<int> { };
                foreach (Ped _ped in _peds.Ped)
                {
                    array.Add(int.Parse(_ped.Chance));
                }
                var nearest = array.OrderBy(x => Math.Abs((long)x - e)).First();
                foreach (Ped _ped in _peds.Ped)
                {
                    if (int.Parse(_ped.Chance) == nearest)
                    {
                        _returnedPeds.Add(_ped);
                    }
                }
            }*/
            _returnedPeds = new List<Ped>();

            if (_peds.Ped.Count > 1)
            {
                Random r = new Random();
                int e = r.Next(0, 100);
                Game.LogTrivial(e.ToString());
                var _orderedList = _peds.Ped.OrderBy(x => Math.Abs(int.Parse(x.Chance) - e)).ToList();
                for (int i = 0; i < _requiredPeds; i++)
                {
                    _returnedPeds.Add(_orderedList[i]);
                }
            }
            else if (_peds.Ped.Count == 1)
            {
                _returnedPeds.Add(_peds.Ped.First());
            }
            else
            {
                Game.LogTrivial("Couldn't find any peds to spawn.");
            }

            /*foreach (Ped _ped in _peds.Ped)
            {
                array.Add(int.Parse(_ped.Chance));
            }
            array.OrderBy(x => Math.Abs((long)x - e)).First();
            for (int i = 0; i < _requiredPeds; i++)
            {
                _returnedPeds.Add(_peds.Ped[array[i]]);
            }*/

            if (_returnedPeds.Count > _requiredPeds)
            {
                Game.LogTrivial(_returnedPeds.Count.ToString() + " is greater than " + _requiredPeds.ToString());
            }
        }

        private static void _chooseVehicle(Vehicles _vehicles, out string _color, out string _vehicleName)
        {
            if (_vehicles.Vehicle.Count > 1)
            {
                Random r = new Random();
                int i = r.Next(_vehicles.Vehicle.Count);
                _vehicleName = _vehicles.Vehicle[i].Text;
                if (_vehicles.Vehicle[i].Color != null)
                {
                    _color = _vehicles.Vehicle[i].Color;
                }
                else
                    _color = string.Empty;
            }
            else
            {
                _vehicleName = _vehicles.Vehicle.First().Text;
                if (_vehicles.Vehicle.First().Color != null)
                {
                    _color = _vehicles.Vehicle.First().Color;
                }
                else
                    _color = string.Empty;
            }
        }

        private void _menu_OnScrollerChange(UIMenu sender, UIMenuScrollerItem item, int oldIndex, int newIndex)
        {
            _menu.Clear();
            _menu.AddItem(_codeBackup);
            if (newIndex == 1) { _constructCode2UnitItems(); }
            if (newIndex == 0) { _constructCode3UnitItems(); }
        }

        private void _constructCode2UnitItems()
        {
            _menu.AddItems(s_code2UnitMenuItems);
        }

        private void _constructCode3UnitItems()
        {
            _menu.AddItems(s_code3UnitMenuItems);
        }

        public override void Update()
        {
            GameFiber.Yield();
            if (Game.IsKeyDown(s_menuKey))
            {
                _menu.Visible = true;
            }
        }

        public override void Finally()
        {
            Game.DisplayNotification("Stop");
        }
    }
}

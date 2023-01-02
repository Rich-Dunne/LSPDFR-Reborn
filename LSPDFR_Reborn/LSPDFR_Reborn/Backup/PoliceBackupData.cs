using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.Collections;

namespace LSPDFR_Reborn.Backup
{
    [XmlRoot(ElementName = "Vehicle")]
    public class Vehicle
    {
        [XmlAttribute(AttributeName = "color")]
        public string Color { get; set; }
        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "Vehicles")]
    public class Vehicles
    {
        [XmlElement(ElementName = "Vehicle")]
        public List<Vehicle> Vehicle { get; set; }
    }

    [XmlRoot(ElementName = "Ped")]
    public class Ped
    {
        // Chance
        [XmlAttribute(AttributeName = "chance")]
        public string Chance { get; set; }


        // Components
        [XmlAttribute(AttributeName = "comp_face")]
        public string Comp_face { get; set; }

        [XmlAttribute(AttributeName = "comp_hair")]
        public string Comp_hair { get; set; }

        [XmlAttribute(AttributeName = "comp_beard")]
        public string Comp_beard { get; set; }

        [XmlAttribute(AttributeName = "comp_decals")]
        public string Comp_decals { get; set; }

        [XmlAttribute(AttributeName = "comp_shirt")]
        public string Comp_shirt { get; set; }

        [XmlAttribute(AttributeName = "comp_pants")]
        public string Comp_pants { get; set; }

        [XmlAttribute(AttributeName = "comp_hands")]
        public string Comp_hands { get; set; }

        [XmlAttribute(AttributeName = "comp_shoes")]
        public string Comp_shoes { get; set; }

        [XmlAttribute(AttributeName = "comp_eyes")]
        public string Comp_eyes { get; set; }

        [XmlAttribute(AttributeName = "comp_accessories")]
        public string Comp_accessories { get; set; }

        [XmlAttribute(AttributeName = "comp_tasks")]
        public string Comp_tasks { get; set; }

        [XmlAttribute(AttributeName = "comp_shirtoverlay")]
        public string Comp_shirtoverlay { get; set; }


        // Textures
        [XmlAttribute(AttributeName = "tex_face")]
        public string Tex_face { get; set; }

        [XmlAttribute(AttributeName = "tex_decals")]
        public string Tex_decals { get; set; }

        [XmlAttribute(AttributeName = "tex_tasks")]
        public string Tex_tasks { get; set; }

        [XmlAttribute(AttributeName = "tex_shirtoverlay")]
        public string Tex_shirtoverlay { get; set; }

        [XmlAttribute(AttributeName = "tex_hats")]
        public string Tex_hats { get; set; }

        [XmlAttribute(AttributeName = "tex_shoes")]
        public string Tex_shoes { get; set; }

        [XmlAttribute(AttributeName = "tex_hands")]
        public string Tex_hands { get; set; }

        [XmlAttribute(AttributeName = "tex_glasses")]
        public string Tex_glasses { get; set; }

        [XmlAttribute(AttributeName = "tex_shirt")]
        public string Tex_shirt { get; set; }

        [XmlAttribute(AttributeName = "tex_pants")]
        public string Tex_pants { get; set; }
        [XmlAttribute(AttributeName = "tex_accessories")]
        public string Tex_accessories { get; set; }

        [XmlAttribute(AttributeName = "tex_ears")]
        public string Tex_ears { get; set; }

        [XmlAttribute(AttributeName = "tex_beard")]
        public string Tex_beard { get; set; }

        [XmlAttribute(AttributeName = "tex_eyes")]
        public string Tex_eyes { get; set; }

        [XmlAttribute(AttributeName = "tex_watches")]
        public string Tex_watches { get; set; }

        [XmlAttribute(AttributeName = "tex_hair")]
        public string Tex_hair { get; set; }


        // Props
        [XmlAttribute(AttributeName = "prop_hats")]
        public string Prop_hats { get; set; }

        [XmlAttribute(AttributeName = "prop_ears")]
        public string Prop_ears { get; set; }

        [XmlAttribute(AttributeName = "prop_watches")]
        public string Prop_watches { get; set; }

        [XmlAttribute(AttributeName = "prop_glasses")]
        public string Prop_glasses { get; set; }


        // Model
        [XmlText]
        public string Model { get; set; }
    }

    [XmlRoot(ElementName = "Peds")]
    public class Peds
    {
        [XmlElement(ElementName = "Ped")]
        public List<Ped> Ped { get; set; }
    }

    [XmlRoot(ElementName = "NonLethal")]
    public class NonLethal
    {
        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "NonLethals")]
    public class NonLethals
    {
        [XmlElement(ElementName = "NonLethal")]
        public List<NonLethal> NonLethal { get; set; }
    }

    [XmlRoot(ElementName = "HandGun")]
    public class HandGun
    {
        [XmlAttribute(AttributeName = "chance")]
        public string Chance { get; set; }
        [XmlAttribute(AttributeName = "comp_1")]
        public string Comp_1 { get; set; }
        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "HandGuns")]
    public class HandGuns
    {
        [XmlElement(ElementName = "HandGun")]
        public List<HandGun> HandGun { get; set; }
    }

    [XmlRoot(ElementName = "LongGun")]
    public class LongGun
    {
        [XmlAttribute(AttributeName = "chance")]
        public string Chance { get; set; }
        [XmlAttribute(AttributeName = "comp_1")]
        public string Comp_1 { get; set; }
        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "LongGuns")]
    public class LongGuns
    {
        [XmlElement(ElementName = "LongGun")]
        public List<LongGun> LongGun { get; set; }
    }

    [XmlRoot(ElementName = "Weapons")]
    public class Weapons
    {
        [XmlElement(ElementName = "NonLethals")]
        public NonLethals NonLethals { get; set; }
        [XmlElement(ElementName = "HandGuns")]
        public HandGuns HandGuns { get; set; }
        [XmlElement(ElementName = "LongGuns")]
        public LongGuns LongGuns { get; set; }
    }

    [XmlRoot(ElementName = "VehicleSet")]
    public class VehicleSet
    {
        [XmlElement(ElementName = "Vehicles")]
        public Vehicles Vehicles { get; set; }
        [XmlElement(ElementName = "Peds")]
        public Peds Peds { get; set; }
        [XmlElement(ElementName = "Weapons")]
        public Weapons Weapons { get; set; }
        [XmlAttribute(AttributeName = "spawn_distance")]
        public string Spawn_distance { get; set; }
    }

    [XmlRoot(ElementName = "LSCity")]
    public class LSCity
    {
        [XmlElement(ElementName = "VehicleSet")]
        public VehicleSet VehicleSet { get; set; }
    }

    [XmlRoot(ElementName = "LSCounty")]
    public class LSCounty
    {
        [XmlElement(ElementName = "VehicleSet")]
        public VehicleSet VehicleSet { get; set; }
    }

    [XmlRoot(ElementName = "BCounty")]
    public class BCounty
    {
        [XmlElement(ElementName = "VehicleSet")]
        public VehicleSet VehicleSet { get; set; }
    }

    [XmlRoot(ElementName = "NY")]
    public class NY
    {
        [XmlElement(ElementName = "VehicleSet")]
        public VehicleSet VehicleSet { get; set; }
    }

    [XmlRoot(ElementName = "CP")]
    public class CP
    {
        [XmlElement(ElementName = "VehicleSet")]
        public VehicleSet VehicleSet { get; set; }
    }

    [XmlRoot(ElementName = "PoliceBackupUnit")]
    public class PoliceBackupUnit
    {
        [XmlElement(ElementName = "LSCity")]
        public LSCity LSCity { get; set; }
        [XmlElement(ElementName = "LSCounty")]
        public LSCounty LSCounty { get; set; }
        [XmlElement(ElementName = "BCounty")]
        public BCounty BCounty { get; set; }
        [XmlElement(ElementName = "NY")]
        public NY NY { get; set; }
        [XmlElement(ElementName = "CP")]
        public CP CP { get; set; }
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }
        [XmlAttribute(AttributeName = "code2")]
        public string Code2 { get; set; }
        [XmlAttribute(AttributeName = "code3")]
        public string Code3 { get; set; }
        [XmlAttribute(AttributeName = "pursuit")]
        public string Pursuit { get; set; }
        [XmlAttribute(AttributeName = "traffic_stop")]
        public string Traffic_stop { get; set; }
        [XmlAttribute(AttributeName = "felony_stop")]
        public string Felony_stop { get; set; }
    }

    [XmlRoot(ElementName = "PoliceBackupUnits")]
    public class PoliceBackupUnits
    {
        [XmlElement(ElementName = "PoliceBackupUnit")]
        public List<PoliceBackupUnit> PoliceBackupUnit { get; set; }
    }
}
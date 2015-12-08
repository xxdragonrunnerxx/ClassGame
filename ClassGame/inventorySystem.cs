using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassGame
{
    public class inventorySystem
    {

// Sword Counter
        int WoodSword = 0;
        int SteelSword = 0;
        int IronSword = 0;
        int PlasticSword = 0;
        int PolymerSword = 0;
        int ChainmailSword = 0;
        int AdamantineSword = 0;
        int GoldSword = 0;
        int SilverSword = 0;
        int BoneSword = 0;
        int StoneSword = 0;
        int BronzeSword = 0;
        int CopperSword = 0;
        int ObsidianSword = 0;

        // Dagger Counter
        int WoodDagger = 0;
        int SteelDagger = 0;
        int IronDagger = 0;
        int PlasticDagger = 0;
        int PolymerDagger = 0;
        int ChainmailDagger = 0;
        int AdamantineDagger = 0;
        int GoldDagger = 0;
        int SilverDagger = 0;
        int BoneDagger = 0;
        int StoneDagger = 0;
        int BronzeDagger = 0;
        int CopperDagger = 0;
        int ObsidianDagger = 0;

// SlingShot Counter
        int WoodSlingShot = 0;
        int SteelSlingShot = 0;
        int IronSlingShot = 0;
        int PlasticSlingShot = 0;
        int PolymerSlingShot = 0;
        int ChainmailSlingShot = 0;
        int AdamantineSlingShot = 0;
        int GoldSlingShot = 0;
        int SilverSlingShot = 0;
        int BoneSlingShot = 0;
        int StoneSlingShot = 0;
        int BronzeSlingShot = 0;
        int CopperSlingShot = 0;
        int ObsidianSlingShot = 0;

//Mace Counter
        int WoodMace = 0;
        int SteelMace = 0;
        int IronMace = 0;
        int PlasticMace = 0;
        int PolymerMace = 0;
        int ChainmailMace = 0;
        int AdamantineMace = 0;
        int GoldMace = 0;
        int SilverMace = 0;
        int BoneMace = 0;
        int StoneMace = 0;
        int BronzeMace = 0;
        int CopperMace = 0;
        int ObsidianMace = 0;

//Bow count
        int WoodBow = 0;
        int SteelBow = 0;
        int IronBow = 0;
        int PlasticBow = 0;
        int PolymerBow = 0;
        int ChainmailBow = 0;
        int AdamantineBow = 0;
        int GoldBow = 0;
        int SilverBow = 0;
        int BoneBow = 0;
        int StoneBow = 0;
        int BronzeBow = 0;
        int CopperBow = 0;
        int ObsidianBow = 0;

//Whip Count
        int WoodWhip = 0;
        int SteelWhip = 0;
        int IronWhip = 0;
        int PlasticWhip = 0;
        int PolymerWhip = 0;
        int ChainmailWhip = 0;
        int AdamantineWhip = 0;
        int GoldWhip = 0;
        int SilverWhip = 0;
        int BoneWhip = 0;
        int StoneWhip = 0;
        int BronzeWhip = 0;
        int CopperWhip = 0;
        int ObsidianWhip = 0;

//DartGun Count
        int WoodDartGun = 0;
        int SteelDartGun = 0;
        int IronDartGun = 0;
        int PlasticDartGun = 0;
        int PolymerDartGun = 0;
        int ChainmailDartGun = 0;
        int AdamantineDartGun = 0;
        int GoldDartGun = 0;
        int SilverDartGun = 0;
        int BoneDartGun = 0;
        int StoneDartGun = 0;
        int BronzeDartGun = 0;
        int CopperDartGun = 0;
        int ObsidianDartGun = 0;

 //Musket Count
        int WoodMusket = 0;
        int SteelMusket = 0;
        int IronMusket = 0;
        int PlasticMusket = 0;
        int PolymerMusket = 0;
        int ChainmailMusket = 0;
        int AdamantineMusket = 0;
        int GoldMusket = 0;
        int SilverMusket = 0;
        int BoneMusket = 0;
        int StoneMusket = 0;
        int BronzeMusket = 0;
        int CopperMusket = 0;
        int ObsidianMusket = 0;

//ChainSaw Count
        int WoodUzi = 0;
        int SteelUzi = 0;
        int IronUzi = 0;
        int PlasticUzi = 0;
        int PolymerUzi = 0;
        int ChainmailUzi = 0;
        int AdamantineUzi = 0;
        int GoldUzi = 0;
        int SilverUzi = 0;
        int BoneUzi = 0;
        int StoneUzi = 0;
        int BronzeUzi = 0;
        int CopperUzi = 0;
        int ObsidianUzi = 0;

//Staff Counter
        int WoodStaff = 0;
        int SteelStaff = 0;
        int IronStaff = 0;
        int PlasticStaff = 0;
        int PolymerStaff = 0;
        int ChainmailStaff = 0;
        int AdamantineStaff = 0;
        int GoldStaff = 0;
        int SilverStaff = 0;
        int BoneStaff = 0;
        int StoneStaff = 0;
        int BronzeStaff = 0;
        int CopperStaff = 0;
        int ObsidianStaff = 0;

//Boomerang Count
        int WoodBoomerang = 0;
        int SteelBoomerang = 0;
        int IronBoomerang = 0;
        int PlasticBoomerang = 0;
        int PolymerBoomerang = 0;
        int ChainmailBoomerang = 0;
        int AdamantineBoomerang = 0;
        int GoldBoomerang = 0;
        int SilverBoomerang = 0;
        int BoneBoomerang = 0;
        int StoneBoomerang = 0;
        int BronzeBoomerang = 0;
        int CopperBoomerang = 0;
        int ObsidianBoomerang = 0;

//Trident Count
        int WoodTrident = 0;
        int SteelTrident = 0;
        int IronTrident = 0;
        int PlasticTrident = 0;
        int PolymerTrident = 0;
        int ChainmailTrident = 0;
        int AdamantineTrident = 0;
        int GoldTrident = 0;
        int SilverTrident = 0;
        int BoneTrident = 0;
        int StoneTrident = 0;
        int BronzeTrident = 0;
        int CopperTrident = 0;
        int ObsidianTrident = 0;

        //Rocket Launcherint Wood
        int WoodRocketLauncher = 0;
        int SteelRocketLauncher = 0;
        int IronRocketLauncher = 0;
        int PlasticRocketLauncher = 0;
        int PolymerRocketLauncher = 0;
        int ChainmailRocketLauncher = 0;
        int AdamantineRocketLauncher = 0;
        int GoldRocketLauncher = 0;
        int SilverRocketLauncher = 0;
        int BoneRocketLauncher = 0;
        int StoneRocketLauncher = 0;
        int BronzeRocketLauncher = 0;
        int CopperRocketLauncher = 0;
        int ObsidianRocketLauncher = 0; 




        public void showInventory()
        {
            if ( WoodSword>= 1)
            {
                Console.WriteLine("Item Name: ", WoodSword);
            }

            else if (SteelSword >= 1)
            {
                Console.WriteLine("Item Name: ", SteelSword);
            }

            else if (IronSword >= 1)
            {
                Console.WriteLine("Item Name: ", IronSword);
            }

            else if (PlasticSword >= 1)
            {
                Console.WriteLine("Item Name: ", PlasticSword);
            }

            else if (PolymerSword >= 1)
            {
                Console.WriteLine("Item Name: ", PolymerSword);
            }

            else if (ChainmailSword >= 1)
            {
                Console.WriteLine("Item Name: ", ChainmailSword);
            }

            else if (AdamantineSword >= 1)
            {
                Console.WriteLine("Item Name: ", AdamantineSword);
            }

            else if (GoldSword >= 1)
            {
                Console.WriteLine("Item Name: ", GoldSword);
            }

            else if (SilverSword >= 1)
            {
                Console.WriteLine("Item Name: ", SilverSword);
            }

            else if (BoneSword >= 1)
            {
                Console.WriteLine("Item Name: ", BoneSword);
            }

            else if (StoneSword >= 1)
            {
                Console.WriteLine("Item Name: ", StoneSword);
            }

            else if (BronzeSword >= 1)
            {
                Console.WriteLine("Item Name: ", BronzeSword);
            }

            else if (CopperSword >= 1)
            {
                Console.WriteLine("Item Name: ", CopperSword);
            }

            else if (ObsidianSword >= 1)
            {
                Console.WriteLine("Item Name: ", ObsidianSword);
            }

            else if (WoodDagger >= 1)
            {
                Console.WriteLine("Item Name: ", WoodDagger);
            }

            else if (SteelDagger >= 1)
            {
                Console.WriteLine("Item Name: ", SteelDagger);
            }

            else if (IronDagger >= 1)
            {
                Console.WriteLine("Item Name: ", IronDagger);
            }

            else if (PlasticDagger >= 1)
            {
                Console.WriteLine("Item Name: ", PlasticDagger);
            }

            else if (PolymerDagger >= 1)
            {
                Console.WriteLine("Item Name: ", PolymerDagger);
            }

            else if (ChainmailDagger >= 1)
            {
                Console.WriteLine("Item Name: ", ChainmailDagger);
            }

            else if (AdamantineDagger >= 1)
            {
                Console.WriteLine("Item Name: ", AdamantineDagger);
            }

            else if (GoldDagger >= 1)
            {
                Console.WriteLine("Item Name: ", GoldDagger);
            }

            else if (SilverDagger >= 1)
            {
                Console.WriteLine("Item Name: ", SilverDagger);
            }

            else if (BoneDagger >= 1)
            {
                Console.WriteLine("Item Name: ", BoneDagger);
            }

            else if (StoneDagger >= 1)
            {
                Console.WriteLine("Item Name: ", StoneDagger);
            }

            else if (BronzeDagger >= 1)
            {
                Console.WriteLine("Item Name: ", BronzeDagger);
            }

            else if (CopperDagger >= 1)
            {
                Console.WriteLine("Item Name: ", CopperDagger);
            }

            else if (ObsidianDagger >= 1)
            {
                Console.WriteLine("Item Name: ", ObsidianDagger);
            }

            else if (WoodSlingShot >= 1)
            {
                Console.WriteLine("Item Name: ", WoodSlingShot);
            }

            else if (SteelSlingShot >= 1)
            {
                Console.WriteLine("Item Name: ", SteelSlingShot);
            }

            else if (IronSlingShot >= 1)
            {
                Console.WriteLine("Item Name: ", IronSlingShot);
            }

            else if (PlasticSlingShot >= 1)
            {
                Console.WriteLine("Item Name: ", PlasticSlingShot);
            }

            else if (PolymerSlingShot >= 1)
            {
                Console.WriteLine("Item Name: ", PolymerSlingShot);
            }

            else if (ChainmailSlingShot >= 1)
            {
                Console.WriteLine("Item Name: ", ChainmailSlingShot);
            }

            else if (AdamantineSlingShot >= 1)
            {
                Console.WriteLine("Item Name: ", AdamantineSlingShot);
            }

            else if (GoldSlingShot >= 1)
            {
                Console.WriteLine("Item Name: ", GoldSlingShot);
            }

            else if (SilverSlingShot >= 1)
            {
                Console.WriteLine("Item Name: ", SilverSlingShot);
            }

            else if (BoneSlingShot >= 1)
            {
                Console.WriteLine("Item Name: ", BoneSlingShot);
            }

            else if (StoneSlingShot >= 1)
            {
                Console.WriteLine("Item Name: ", StoneSlingShot);
            }

            else if (BronzeSlingShot >= 1)
            {
                Console.WriteLine("Item Name: ", BronzeSlingShot);
            }

            else if (CopperSlingShot >= 1)
            {
                Console.WriteLine("Item Name: ", CopperSlingShot);
            }

            else if (ObsidianSlingShot >= 1)
            {
                Console.WriteLine("Item Name: ", ObsidianSlingShot);
            }

            else if (WoodMace >= 1)
            {
                Console.WriteLine("Item Name: ", WoodMace);
            }

            else if (SteelMace >= 1)
            {
                Console.WriteLine("Item Name: ", SteelMace);
            }

            else if (IronMace >= 1)
            {
                Console.WriteLine("Item Name: ", IronMace);
            }

            else if (PlasticMace >= 1)
            {
                Console.WriteLine("Item Name: ", PlasticMace);
            }

            else if (PolymerMace >= 1)
            {
                Console.WriteLine("Item Name: ", PolymerMace);
            }

            else if (ChainmailMace >= 1)
            {
                Console.WriteLine("Item Name: ", ChainmailMace);
            }

            else if (AdamantineMace >= 1)
            {
                Console.WriteLine("Item Name: ", AdamantineMace);
            }

            else if (GoldMace >= 1)
            {
                Console.WriteLine("Item Name: ", GoldMace);
            }

            else if (SilverMace >= 1)
            {
                Console.WriteLine("Item Name: ", SilverMace);
            }

            else if (BoneMace >= 1)
            {
                Console.WriteLine("Item Name: ", BoneMace);
            }

            else if (StoneMace >= 1)
            {
                Console.WriteLine("Item Name: ", StoneMace);
            }

            else if (BronzeMace >= 1)
            {
                Console.WriteLine("Item Name: ", BronzeMace);
            }

            else if (CopperMace >= 1)
            {
                Console.WriteLine("Item Name: ", CopperMace);
            }

            else if (ObsidianMace >= 1)
            {
                Console.WriteLine("Item Name: ", ObsidianMace);
            }

            else if (WoodBow >= 1)
            {
                Console.WriteLine("Item Name: ", WoodBow);
            }

            else if (SteelBow >= 1)
            {
                Console.WriteLine("Item Name: ", SteelBow);
            }

            else if (IronBow >= 1)
            {
                Console.WriteLine("Item Name: ", IronBow);
            }

            else if (PlasticBow >= 1)
            {
                Console.WriteLine("Item Name: ", PlasticBow);
            }

            else if (PolymerBow >= 1)
            {
                Console.WriteLine("Item Name: ", PolymerBow);
            }

            else if (ChainmailBow >= 1)
            {
                Console.WriteLine("Item Name: ", ChainmailBow);
            }

            else if (AdamantineBow >= 1)
            {
                Console.WriteLine("Item Name: ", AdamantineBow);
            }

            else if (GoldBow >= 1)
            {
                Console.WriteLine("Item Name: ", GoldBow);
            }

            else if (SilverBow >= 1)
            {
                Console.WriteLine("Item Name: ", SilverBow);
            }

            else if (BoneBow >= 1)
            {
                Console.WriteLine("Item Name: ", BoneBow);
            }

            else if (StoneBow >= 1)
            {
                Console.WriteLine("Item Name: ", StoneBow);
            }

            else if (BronzeBow >= 1)
            {
                Console.WriteLine("Item Name: ", BronzeBow);
            }

            else if (CopperBow >= 1)
            {
                Console.WriteLine("Item Name: ", CopperBow);
            }

            else if (ObsidianBow >= 1)
            {
                Console.WriteLine("Item Name: ", ObsidianBow);
            }

            else if (WoodWhip >= 1)
            {
                Console.WriteLine("Item Name: ", WoodWhip);
            }

            else if (SteelWhip >= 1)
            {
                Console.WriteLine("Item Name: ", SteelWhip);
            }

            else if (IronWhip >= 1)
            {
                Console.WriteLine("Item Name: ", IronWhip);
            }

            else if (PlasticWhip >= 1)
            {
                Console.WriteLine("Item Name: ", PlasticWhip);
            }

            else if (PolymerWhip >= 1)
            {
                Console.WriteLine("Item Name: ", PolymerWhip);
            }

            else if (ChainmailWhip >= 1)
            {
                Console.WriteLine("Item Name: ", ChainmailWhip);
            }

            else if (AdamantineWhip >= 1)
            {
                Console.WriteLine("Item Name: ", AdamantineWhip);
            }

            else if (GoldWhip >= 1)
            {
                Console.WriteLine("Item Name: ", GoldWhip);
            }

            else if (SilverWhip >= 1)
            {
                Console.WriteLine("Item Name: ", SilverWhip);
            }

            else if (BoneWhip >= 1)
            {
                Console.WriteLine("Item Name: ", BoneWhip);
            }

            else if (StoneWhip >= 1)
            {
                Console.WriteLine("Item Name: ", StoneWhip);
            }

            else if (BronzeWhip >= 1)
            {
                Console.WriteLine("Item Name: ", BronzeWhip);
            }

            else if (CopperWhip >= 1)
            {
                Console.WriteLine("Item Name: ", CopperWhip);
            }

            else if (ObsidianWhip >= 1)
            {
                Console.WriteLine("Item Name: ", ObsidianWhip);
            }

            else if (WoodDartGun >= 1)
            {
                Console.WriteLine("Item Name: ", WoodDartGun);
            }

            else if (SteelDartGun >= 1)
            {
                Console.WriteLine("Item Name: ", SteelDartGun);
            }

            else if (IronDartGun >= 1)
            {
                Console.WriteLine("Item Name: ", IronDartGun);
            }

            else if (PlasticDartGun >= 1)
            {
                Console.WriteLine("Item Name: ", PlasticDartGun);
            }

            else if (PolymerDartGun >= 1)
            {
                Console.WriteLine("Item Name: ", PolymerDartGun);
            }

            else if (ChainmailDartGun >= 1)
            {
                Console.WriteLine("Item Name: ", ChainmailDartGun);
            }

            else if (AdamantineDartGun >= 1)
            {
                Console.WriteLine("Item Name: ", AdamantineDartGun);
            }

            else if (GoldDartGun >= 1)
            {
                Console.WriteLine("Item Name: ", GoldDartGun);
            }

            else if (SilverDartGun >= 1)
            {
                Console.WriteLine("Item Name: ", SilverDartGun);
            }

            else if (BoneDartGun >= 1)
            {
                Console.WriteLine("Item Name: ", BoneDartGun);
            }

            else if (StoneDartGun >= 1)
            {
                Console.WriteLine("Item Name: ", StoneDartGun);
            }

            else if (BronzeDartGun >= 1)
            {
                Console.WriteLine("Item Name: ", BronzeDartGun);
            }

            else if (CopperDartGun >= 1)
            {
                Console.WriteLine("Item Name: ", CopperDartGun);
            }

            else if (ObsidianDartGun >= 1)
            {
                Console.WriteLine("Item Name: ", ObsidianDartGun);
            }

            else if (WoodMusket >= 1)
            {
                Console.WriteLine("Item Name: ", WoodMusket);
            }

            else if (SteelMusket >= 1)
            {
                Console.WriteLine("Item Name: ", SteelMusket);
            }

            else if (IronMusket >= 1)
            {
                Console.WriteLine("Item Name: ", IronMusket);
            }

            else if (PlasticMusket >= 1)
            {
                Console.WriteLine("Item Name: ", PlasticMusket);
            }

            else if (PolymerMusket >= 1)
            {
                Console.WriteLine("Item Name: ", PolymerMusket);
            }

            else if (ChainmailMusket >= 1)
            {
                Console.WriteLine("Item Name: ", ChainmailMusket);
            }

            else if (AdamantineMusket >= 1)
            {
                Console.WriteLine("Item Name: ", AdamantineMusket);
            }

            else if (GoldMusket >= 1)
            {
                Console.WriteLine("Item Name: ", GoldMusket);
            }

            else if (SilverMusket >= 1)
            {
                Console.WriteLine("Item Name: ", SilverMusket);
            }

            else if (BoneMusket >= 1)
            {
                Console.WriteLine("Item Name: ", BoneMusket);
            }

            else if (StoneMusket >= 1)
            {
                Console.WriteLine("Item Name: ", StoneMusket);
            }

            else if (BronzeMusket >= 1)
            {
                Console.WriteLine("Item Name: ", BronzeMusket);
            }

            else if (CopperMusket >= 1)
            {
                Console.WriteLine("Item Name: ", CopperMusket);
            }

            else if (ObsidianMusket >= 1)
            {
                Console.WriteLine("Item Name: ", ObsidianMusket);
            }

            else if (WoodUzi >= 1)
            {
                Console.WriteLine("Item Name: ", WoodUzi);
            }

            else if (SteelUzi >= 1)
            {
                Console.WriteLine("Item Name: ", SteelUzi);
            }

            else if (IronUzi >= 1)
            {
                Console.WriteLine("Item Name: ", IronUzi);
            }

            else if (PlasticUzi >= 1)
            {
                Console.WriteLine("Item Name: ", PlasticUzi);
            }

            else if (PolymerUzi >= 1)
            {
                Console.WriteLine("Item Name: ", PolymerUzi);
            }

            else if (ChainmailUzi >= 1)
            {
                Console.WriteLine("Item Name: ", ChainmailUzi);
            }

            else if (AdamantineUzi >= 1)
            {
                Console.WriteLine("Item Name: ", AdamantineUzi);
            }

            else if (GoldUzi >= 1)
            {
                Console.WriteLine("Item Name: ", GoldUzi);
            }

            else if (SilverUzi >= 1)
            {
                Console.WriteLine("Item Name: ", SilverUzi);
            }

            else if (BoneUzi >= 1)
            {
                Console.WriteLine("Item Name: ", BoneUzi);
            }

            else if (StoneUzi >= 1)
            {
                Console.WriteLine("Item Name: ", StoneUzi);
            }

            else if (BronzeUzi >= 1)
            {
                Console.WriteLine("Item Name: ", BronzeUzi);
            }

            else if (CopperUzi >= 1)
            {
                Console.WriteLine("Item Name: ", CopperUzi);
            }

            else if (ObsidianUzi >= 1)
            {
                Console.WriteLine("Item Name: ", ObsidianUzi);
            }

            else if (WoodStaff >= 1)
            {
                Console.WriteLine("Item Name: ", WoodStaff);
            }

            else if (SteelStaff >= 1)
            {
                Console.WriteLine("Item Name: ", SteelStaff);
            }

            else if (IronStaff >= 1)
            {
                Console.WriteLine("Item Name: ", IronStaff);
            }

            else if (PlasticStaff >= 1)
            {
                Console.WriteLine("Item Name: ", PlasticStaff);
            }

            else if (PolymerStaff >= 1)
            {
                Console.WriteLine("Item Name: ", PolymerStaff);
            }

            else if (ChainmailStaff >= 1)
            {
                Console.WriteLine("Item Name: ", ChainmailStaff);
            }

            else if (AdamantineStaff >= 1)
            {
                Console.WriteLine("Item Name: ", AdamantineStaff);
            }

            else if (GoldStaff >= 1)
            {
                Console.WriteLine("Item Name: ", GoldStaff);
            }

            else if (SilverStaff >= 1)
            {
                Console.WriteLine("Item Name: ", SilverStaff);
            }

            else if (BoneStaff >= 1)
            {
                Console.WriteLine("Item Name: ", BoneStaff);
            }

            else if (StoneStaff >= 1)
            {
                Console.WriteLine("Item Name: ", StoneStaff);
            }

            else if (BronzeStaff >= 1)
            {
                Console.WriteLine("Item Name: ", BronzeStaff);
            }

            else if (CopperStaff >= 1)
            {
                Console.WriteLine("Item Name: ", CopperStaff);
            }

            else if (ObsidianStaff >= 1)
            {
                Console.WriteLine("Item Name: ", ObsidianStaff);
            }

            else if (WoodBoomerang >= 1)
            {
                Console.WriteLine("Item Name: ", WoodBoomerang);
            }

            else if (SteelBoomerang >= 1)
            {
                Console.WriteLine("Item Name: ", SteelBoomerang);
            }

            else if (IronBoomerang >= 1)
            {
                Console.WriteLine("Item Name: ", IronBoomerang);
            }

            else if (PlasticBoomerang >= 1)
            {
                Console.WriteLine("Item Name: ", PlasticBoomerang);
            }

            else if (PolymerBoomerang >= 1)
            {
                Console.WriteLine("Item Name: ", PolymerBoomerang);
            }

            else if (ChainmailBoomerang >= 1)
            {
                Console.WriteLine("Item Name: ", ChainmailBoomerang);
            }

            else if (AdamantineBoomerang >= 1)
            {
                Console.WriteLine("Item Name: ", AdamantineBoomerang);
            }

            else if (GoldBoomerang >= 1)
            {
                Console.WriteLine("Item Name: ", GoldBoomerang);
            }

            else if (SilverBoomerang >= 1)
            {
                Console.WriteLine("Item Name: ", SilverBoomerang);
            }

            else if (BoneBoomerang >= 1)
            {
                Console.WriteLine("Item Name: ", BoneBoomerang);
            }

            else if (StoneBoomerang >= 1)
            {
                Console.WriteLine("Item Name: ", StoneBoomerang);
            }

            else if (BronzeBoomerang >= 1)
            {
                Console.WriteLine("Item Name: ", BronzeBoomerang);
            }

            else if (CopperBoomerang >= 1)
            {
                Console.WriteLine("Item Name: ", CopperBoomerang);
            }

            else if (ObsidianBoomerang >= 1)
            {
                Console.WriteLine("Item Name: ", ObsidianBoomerang);
            }

            else if (WoodTrident >= 1)
            {
                Console.WriteLine("Item Name: ", WoodTrident);
            }

            else if (SteelTrident >= 1)
            {
                Console.WriteLine("Item Name: ", SteelTrident);
            }

            else if (IronTrident >= 1)
            {
                Console.WriteLine("Item Name: ", IronTrident);
            }

            else if (PlasticTrident >= 1)
            {
                Console.WriteLine("Item Name: ", PlasticTrident);
            }

            else if (PolymerTrident >= 1)
            {
                Console.WriteLine("Item Name: ", PolymerTrident);
            }

            else if (ChainmailTrident >= 1)
            {
                Console.WriteLine("Item Name: ", ChainmailTrident);
            }

            else if (AdamantineTrident >= 1)
            {
                Console.WriteLine("Item Name: ", AdamantineTrident);
            }

            else if (GoldTrident >= 1)
            {
                Console.WriteLine("Item Name: ", GoldTrident);
            }

            else if (SilverTrident >= 1)
            {
                Console.WriteLine("Item Name: ", SilverTrident);
            }

            else if (BoneTrident >= 1)
            {
                Console.WriteLine("Item Name: ", BoneTrident);
            }

            else if (StoneTrident >= 1)
            {
                Console.WriteLine("Item Name: ", StoneTrident);
            }

            else if (BronzeTrident >= 1)
            {
                Console.WriteLine("Item Name: ", BronzeTrident);
            }

            else if (CopperTrident >= 1)
            {
                Console.WriteLine("Item Name: ", CopperTrident);
            }

            else if (ObsidianTrident >= 1)
            {
                Console.WriteLine("Item Name: ", ObsidianTrident);
            }

            else if (WoodRocketLauncher >= 1)
            {
                Console.WriteLine("Item Name: ", WoodRocketLauncher);
            }

            else if (SteelRocketLauncher >= 1)
            {
                Console.WriteLine("Item Name: ", SteelRocketLauncher);
            }

            else if (IronRocketLauncher >= 1)
            {
                Console.WriteLine("Item Name: ", IronRocketLauncher);
            }

            else if (PlasticRocketLauncher >= 1)
            {
                Console.WriteLine("Item Name: ", PlasticRocketLauncher);
            }

            else if (PolymerRocketLauncher >= 1)
            {
                Console.WriteLine("Item Name: ", PolymerRocketLauncher);
            }

            else if (ChainmailRocketLauncher >= 1)
            {
                Console.WriteLine("Item Name: ", ChainmailRocketLauncher);
            }

            else if (AdamantineRocketLauncher >= 1)
            {
                Console.WriteLine("Item Name: ", AdamantineRocketLauncher);
            }

            else if (GoldRocketLauncher >= 1)
            {
                Console.WriteLine("Item Name: ", GoldRocketLauncher);
            }

            else if (SilverRocketLauncher >= 1)
            {
                Console.WriteLine("Item Name: ", SilverRocketLauncher);
            }

            else if (BoneRocketLauncher >= 1)
            {
                Console.WriteLine("Item Name: ", BoneRocketLauncher);
            }

            else if (StoneRocketLauncher >= 1)
            {
                Console.WriteLine("Item Name: ", StoneRocketLauncher);
            }

            else if (BronzeRocketLauncher >= 1)
            {
                Console.WriteLine("Item Name: ", BronzeRocketLauncher);
            }

            else if (CopperRocketLauncher >= 1)
            {
                Console.WriteLine("Item Name: ", CopperRocketLauncher);
            }

            else if (ObsidianRocketLauncher >= 1)
            {
                Console.WriteLine("Item Name: ", ObsidianRocketLauncher);
            }
        }
    }
}
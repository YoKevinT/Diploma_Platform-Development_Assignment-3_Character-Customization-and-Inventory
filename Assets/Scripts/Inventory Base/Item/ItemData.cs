using UnityEngine;

public static class ItemData
{
    public static Item CreateItem(int itemID)
    {
        string _name = "";
        string _description = "";
        int _amount = 0;
        int _value = 0;

        ItemType _type = ItemType.Food;
        string _icon = "";
        string _itemMesh = "";

        int _damage = 0;
        int _armour = 0;
        int _heal = 0;

        switch (itemID)
        {
            #region Ingredient 0 - 99
            case 0:
                _name = "Acorn";
                _description = "The acorn, is the nut of the oaks";
                _amount = 1;
                _value = 1;
                _type = ItemType.Ingredient;
                _icon = "Ingredient/Acorn";
                _itemMesh = "Ingredient/Acorn";
                _damage = 0;
                _armour = 0;
                _heal = 0;
                break;
            case 1:
                _name = "Mushroom";
                _description = "The mushroom, is the mushroom of the kaos";
                _amount = 1;
                _value = 2;
                _type = ItemType.Ingredient;
                _icon = "Ingredient/Mushroom";
                _itemMesh = "Ingredient/Mushroom";
                _damage = 0;
                _armour = 0;
                _heal = 0;
                break;
            case 2:
                _name = "Leaf";
                _description = "The leaf, is the leaf of the soak";
                _amount = 1;
                _value = 3;
                _type = ItemType.Ingredient;
                _icon = "Ingredient/Leaf";
                _itemMesh = "Ingredient/Leaf";
                _damage = 0;
                _armour = 0;
                _heal = 0;
                break;
            #endregion
            #region Potion 100 - 199
            case 100:
                _name = "Mana";
                _description = "The mana, is the mana of the oni";
                _amount = 1;
                _value = 1;
                _type = ItemType.Potion;
                _icon = "Potion/Mana";
                _itemMesh = "Potion/Mana";
                _damage = 0;
                _armour = 0;
                _heal = 0;
                break;
            case 101:
                _name = "Energy";
                _description = "The energy, is the energy of the ino";
                _amount = 1;
                _value = 2;
                _type = ItemType.Potion;
                _icon = "Potion/Energy";
                _itemMesh = "Potion/Energy";
                _damage = 0;
                _armour = 0;
                _heal = 0;
                break;
            case 102:
                _name = "Blood";
                _description = "The blood, is the energy of the noi";
                _amount = 1;
                _value = 3;
                _type = ItemType.Potion;
                _icon = "Potion/Blood";
                _itemMesh = "Potion/Blood";
                _damage = 0;
                _armour = 0;
                _heal = 0;
                break;
            #endregion
            #region Scroll 200 - 299
            case 200:
                _name = "Old";
                _description = "The old, is the energy of the faena";
                _amount = 1;
                _value = 1;
                _type = ItemType.Scroll;
                _icon = "Scroll/Old";
                _itemMesh = "Scroll/Old";
                _damage = 0;
                _armour = 0;
                _heal = 0;
                break;
            case 201:
                _name = "Green";
                _description = "The blood, is the energy of the eanaf";
                _amount = 1;
                _value = 2;
                _type = ItemType.Scroll;
                _icon = "Scroll/Green";
                _itemMesh = "Scroll/Green";
                _damage = 0;
                _armour = 0;
                _heal = 0;
                break;
            case 202:
                _name = "Magic";
                _description = "The blood, is the energy of the anaef";
                _amount = 1;
                _value = 3;
                _type = ItemType.Scroll;
                _icon = "Scroll/Magic";
                _itemMesh = "Scroll/Magic";
                _damage = 0;
                _armour = 0;
                _heal = 0;
                break;
            #endregion
            #region Food 300 - 399
            case 300:
                _name = "Tentacles";
                _description = "The tentacle, is the tentacle of the bongo";
                _amount = 1;
                _value = 1;
                _type = ItemType.Food;
                _icon = "Food/Tentacles";
                _itemMesh = "Food/Tentacles";
                _damage = 0;
                _armour = 0;
                _heal = 5;
                break;
            case 301:
                _name = "Pizza";
                _description = "The pizza, is the energy of the ognob";
                _amount = 1;
                _value = 2;
                _type = ItemType.Food;
                _icon = "Food/Pizza";
                _itemMesh = "Food/Pizza";
                _damage = 0;
                _armour = 0;
                _heal = 10;
                break;
            case 302:
                _name = "Shrimp";
                _description = "The shrimp, is the energy of the nogob";
                _amount = 1;
                _value = 3;
                _type = ItemType.Food;
                _icon = "Food/Shrimp";
                _itemMesh = "Food/Shrimp";
                _damage = 0;
                _armour = 0;
                _heal = 15;
                break;
            #endregion
            #region Armour 400 - 499
            case 400:
                _name = "Bracer";
                _description = "The bracer, is the energy of the hippy";
                _amount = 1;
                _value = 1;
                _type = ItemType.Armour;
                _icon = "Armour/Bracer";
                _itemMesh = "Armour/Bracer";
                _damage = 0;
                _armour = 10;
                _heal = 0;
                break;
            case 401:
                _name = "Helmet";
                _description = "The helmet, is the energy of the yppih";
                _amount = 1;
                _value = 2;
                _type = ItemType.Armour;
                _icon = "Armour/Helmet";
                _itemMesh = "Armour/Helmet";
                _damage = 0;
                _armour = 20;
                _heal = 0;
                break;
            case 402:
                _name = "Skin";
                _description = "The skin, is the energy of the pipyh";
                _amount = 1;
                _value = 3;
                _type = ItemType.Armour;
                _icon = "Armour/Skin";
                _itemMesh = "Armour/Skin";
                _damage = 0;
                _armour = 30;
                _heal = 0;
                break;
            #endregion
            #region Weapon 500 - 599
            case 500:
                _name = "Sword";
                _description = "The sword, is the energy of the karma";
                _amount = 1;
                _value = 1;
                _type = ItemType.Weapon;
                _icon = "Weapon/Sword";
                _itemMesh = "Weapon/Sword";
                _damage = 10;
                _armour = 0;
                _heal = 0;
                break;
            case 501:
                _name = "Axe";
                _description = "The axe, is the energy of the rakam";
                _amount = 1;
                _value = 2;
                _type = ItemType.Weapon;
                _icon = "Weapon/Axe";
                _itemMesh = "Weapon/Axe";
                _damage = 20;
                _armour = 0;
                _heal = 0;
                break;
            case 502:
                _name = "Staff";
                _description = "The staff, is the energy of the arkam";
                _amount = 1;
                _value = 3;
                _type = ItemType.Weapon;
                _icon = "Weapon/Staff";
                _itemMesh = "Weapon/Staff";
                _damage = 30;
                _armour = 0;
                _heal = 0;
                break;
            #endregion
            #region Craftable 600 - 699
            case 600:
                _name = "Wood";
                _description = "The wood, is the energy of the lepta";
                _amount = 10;
                _value = 1;
                _type = ItemType.Craftable;
                _icon = "Craftable/Wood";
                _itemMesh = "Craftable/Wood";
                _damage = 0;
                _armour = 0;
                _heal = 0;
                break;
            case 601:
                _name = "Rock";
                _description = "The rock, is the energy of the atpel";
                _amount = 10;
                _value = 2;
                _type = ItemType.Craftable;
                _icon = "Craftable/Rock";
                _itemMesh = "Craftable/Rock";
                _damage = 0;
                _armour = 0;
                _heal = 0;
                break;
            case 602:
                _name = "Screw";
                _description = "The screw, is the energy of the eptal";
                _amount = 10;
                _value = 3;
                _type = ItemType.Craftable;
                _icon = "Craftable/Screw";
                _itemMesh = "Craftable/Screw";
                _damage = 0;
                _armour = 0;
                _heal = 0;
                break;
            #endregion
            #region Money 700 - 799
            case 700:
                _name = "Basic";
                _description = "The basic, is the energy of the macle";
                _amount = 1;
                _value = 10;
                _type = ItemType.Money;
                _icon = "Money/Basic";
                _itemMesh = "Money/Basic";
                _damage = 0;
                _armour = 0;
                _heal = 0;
                break;
            case 701:
                _name = "Coin";
                _description = "The coin, is the energy of the elcam";
                _amount = 1;
                _value = 20;
                _type = ItemType.Money;
                _icon = "Money/Coin";
                _itemMesh = "Money/Coin";
                _damage = 0;
                _armour = 0;
                _heal = 0;
                break;
            case 702:
                _name = "Gem";
                _description = "The gem, is the energy of the lecam";
                _amount = 1;
                _value = 30;
                _type = ItemType.Money;
                _icon = "Money/Gem";
                _itemMesh = "Money/Gem";
                _damage = 0;
                _armour = 0;
                _heal = 0;
                break;
            #endregion
            #region Quest 800 - 899
            case 800:
                _name = "Loop";
                _description = "The loop, is the energy of the morph";
                _amount = 1;
                _value = 0;
                _type = ItemType.Quest;
                _icon = "Quest/Loop";
                _itemMesh = "Quest/Loop";
                _damage = 0;
                _armour = 0;
                _heal = 0;
                break;
            case 801:
                _name = "Horn";
                _description = "The horn, is the energy of the hormp";
                _amount = 1;
                _value = 0;
                _type = ItemType.Quest;
                _icon = "Quest/Horn";
                _itemMesh = "Quest/Horn";
                _damage = 0;
                _armour = 0;
                _heal = 0;
                break;
            case 802:
                _name = "Wing";
                _description = "The wing, is the energy of the pormh";
                _amount = 1;
                _value = 0;
                _type = ItemType.Quest;
                _icon = "Quest/Wing";
                _itemMesh = "Quest/Wing";
                _damage = 0;
                _armour = 0;
                _heal = 0;
                break;
            #endregion
            #region Misc 900 - 999
            case 900:
                _name = "Spring";
                _description = "The spring, is the energy of the perky";
                _amount = 1;
                _value = 1;
                _type = ItemType.Misc;
                _icon = "Misc/Spring";
                _itemMesh = "Misc/Spring";
                _damage = 0;
                _armour = 0;
                _heal = 0;
                break;
            case 901:
                _name = "Flute";
                _description = "The flute, is the energy of the ykrep";
                _amount = 1;
                _value = 2;
                _type = ItemType.Misc;
                _icon = "Misc/Flute";
                _itemMesh = "Misc/Flute";
                _damage = 0;
                _armour = 0;
                _heal = 0;
                break;
            case 902:
                _name = "Nine";
                _description = "The nine, is the energy of the epyrk";
                _amount = 1;
                _value = 3;
                _type = ItemType.Misc;
                _icon = "Misc/Nine";
                _itemMesh = "Misc/Nine";
                _damage = 0;
                _armour = 0;
                _heal = 0;
                break;
            #endregion
            #region Default 0 - 0
            default:
                itemID = 0;
                _name = "Acorn";
                _description = "The acorn, is the nut of the oaks";
                _amount = 1;
                _value = 1;
                _type = ItemType.Ingredient;
                _icon = "Ingredient/Acorn";
                _itemMesh = "Ingredient/Acorn";
                _damage = 0;
                _armour = 0;
                _heal = 0;
                break;
                #endregion
        }

        Item temp = new Item
        {
            ID = itemID,
            NAME = _name,
            DESCRIPTION = _description,
            AMOUNT = _amount,
            VALUE = _value,
            TYPE = _type,
            ICON = Resources.Load("Icons/"+_icon) as Texture2D,
            ITEMMESH = Resources.Load("ItemMesh/"+_itemMesh) as GameObject,
            DAMAGE = _damage,
            ARMOUR = _armour,
            HEAL = _heal,
        };
        return temp;
    }
}
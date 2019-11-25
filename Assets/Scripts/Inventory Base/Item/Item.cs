using UnityEngine;

public class Item
{
    #region Private Variables
    private int _id;
    private string _name;
    private int _amount;
    private string _description;
    private int _value;

    private ItemType _type;
    private Texture2D _icon;
    private GameObject _itemMesh;

    private int _damage;
    private int _armour;
    private int _heal;
    #endregion
    #region Public Properties
    public int ID
    {
        get { return _id; } //Read
        set { _id = value; } //Write 
    }
    public string NAME
    {
        get { return _name; }
        set { _name = value; }
    }
    public int AMOUNT
    {
        get { return _amount; }
        set { _amount = value; }
    }
    public string DESCRIPTION
    {
        get { return _description; }
        set { _description = value; }
    }
    public int VALUE
    {
        get { return _value; }
        set { _value = value; }
    }
    public ItemType TYPE
    {
        get { return _type; }
        set { _type = value; }
    }
    public Texture2D ICON
    {
        get { return _icon; }
        set { _icon = value; }
    }
    public GameObject ITEMMESH
    {
        get { return _itemMesh; }
        set { _itemMesh = value; }
    }
    public int DAMAGE
    {
        get { return _damage; }
        set { _damage = value; }
    }
    public int ARMOUR
    {
        get { return _armour; }
        set { _armour = value; }
    }
    public int HEAL
    {
        get { return _heal; }
        set { _heal = value; }
    }
    #endregion
}

public enum ItemType
{
    Ingredient,
    Potion,
    Food,
    Scroll,
    Armour,
    Weapon,
    Craftable,
    Money,
    Quest,
    Misc
}
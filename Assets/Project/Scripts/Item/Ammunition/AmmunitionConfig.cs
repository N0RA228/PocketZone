using ItemSystem;
using UnityEngine;

[CreateAssetMenu(menuName = "Items/Ammunition", fileName = "New AmmunitionConfig")]
public class AmmunitionConfig : ItemConfig
{
    public override Item GetItem() => new Ammunition(ID, _name, _sprite, _maxInSlot);
}

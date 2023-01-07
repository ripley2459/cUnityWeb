using UnityEngine;

public class CharacterAttributes : MonoBehaviour
{
    protected Armor _armor;
    protected EnergyShield _energyShield;
    protected Life _life;
    protected Dexterity _dexterity;
    protected Intelligence _intelligence;
    protected Strength _strength;

    private void Awake()
    {
        _armor = new Armor(0f, 0f, 0f);
        _energyShield = new EnergyShield(0f, 0f, 0f);
        _life = new Life(0f, 50f, 50f);
        
        _dexterity = new Dexterity(15f);
        _intelligence = new Intelligence(15f);
        _strength = new Strength(15f);
    }
}
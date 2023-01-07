public class EnergyShield : Vitality
{
    public EnergyShield(float minValue, float baseValue, float maxValue) : base(minValue, baseValue, maxValue)
    {
    }
    
    public override void Regenerate()
    {
        throw new System.NotImplementedException();
    }
}
public class Life : Vitality
{
    public Life(float minValue, float baseValue, float maxValue) : base(minValue, baseValue, maxValue)
    {
    }

    public override void Regenerate()
    {
        throw new System.NotImplementedException();
    }
}
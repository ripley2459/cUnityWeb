public abstract class Vitality : AttributeClamped
{
    public Vitality(float minValue, float baseValue, float maxValue) : base(minValue, baseValue, maxValue)
    {
    }

    #region Methods

    public abstract void Regenerate();

    #endregion Methods
}
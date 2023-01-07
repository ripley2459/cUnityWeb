public class Modifier
{
    #region Properties

    public float Adder { get; }

    public float Multiplicator { get; }

    #endregion Properties

    public Modifier(float adder, float multiplicator)
    {
        Adder = adder;
        Multiplicator = multiplicator;
    }
}
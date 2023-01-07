using System;
using System.Collections.Generic;

public class Attribute
{
    #region Fields

    protected bool _dirty = true;
    protected List<Modifier> _modifiers;
    protected float _value;
    public float BaseValue { get; }

    #endregion Fields

    #region Events

    public Action<float> OnValueChanged;

    #endregion Events

    public Attribute(float baseValue)
    {
        BaseValue = baseValue;
    }

    #region Properties

    public float Value
    {
        get
        {
            if (_dirty) UpdateValue();
            return _value;
        }
    }

    #endregion Properties

    #region Methods

    /// <summary>
    ///     Value = (BaseValue + mod1 + ... + modX) * mult1 * ... * multX
    /// </summary>
    protected virtual void UpdateValue()
    {
        _value = BaseValue;

        _modifiers.ForEach(x => _value += x.Adder);
        _modifiers.ForEach(x => _value *= x.Multiplicator);

        OnValueChanged?.Invoke(_value);

        _dirty = false;
    }

    public void AddModifier(Modifier modifier)
    {
        _dirty = true;
        _modifiers.Add(modifier);
        UpdateValue();
    }

    public void RemoveModifier(Modifier modifier)
    {
        _dirty = true;
        _modifiers.Remove(modifier);
        UpdateValue();
    }

    #endregion Properties
}
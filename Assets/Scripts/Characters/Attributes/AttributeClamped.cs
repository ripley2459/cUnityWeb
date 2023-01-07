using System;
using UnityEngine;

public class AttributeClamped : Attribute
{
    #region Fields

    private float _maxValue;
    private float _minValue;

    #endregion Fields

    #region Events

    public Action<float> OnMaxValueChanged;
    public Action<float> OnMinValueChanged;

    #endregion Events

    public AttributeClamped(float minValue, float baseValue, float maxValue) : base(baseValue)
    {
        BaseMinValue = minValue;
        BaseMaxValue = maxValue;
    }

    #region Properties

    public float BaseMinValue { get; }
    public float BaseMaxValue { get; }


    public float MinValue()
    {
        if (_dirty) UpdateValue();
        return _minValue;
    }

    public float MaxValue()
    {
        if (_dirty) UpdateValue();
        return _maxValue;
    }

    #endregion Properties

    #region Methods

    protected override void UpdateValue()
    {
        _minValue = BaseMaxValue;
        _maxValue = BaseMaxValue;

        _modifiers.ForEach(x => _minValue += x.Adder);
        _modifiers.ForEach(x => _minValue *= x.Multiplicator);
        _modifiers.ForEach(x => _maxValue += x.Adder);
        _modifiers.ForEach(x => _maxValue *= x.Multiplicator);

        _value = Mathf.Clamp(_value, _minValue, _maxValue);

        OnMinValueChanged?.Invoke(_minValue);
        OnValueChanged?.Invoke(_value);
        OnMaxValueChanged?.Invoke(_maxValue);

        _dirty = false;
    }

    #endregion Methods
}
using UnityEngine;

[CreateAssetMenu]
public class FloatOS : ScriptableObject
{
    [SerializeField] private float _value;

    public float Value
    {
        get => _value;
        set => _value = value;
    }
}
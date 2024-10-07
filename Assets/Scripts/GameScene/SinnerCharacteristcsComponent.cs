using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SinnerCharacteristcsComponent : MonoBehaviour
{
    public enum SinType
    {
        Lust,
        Gluttony,
        Greed,
        Wrath,
        Heresy,
        Violence,
        Fraud,
        Treachery
    }

    private List<string> names = new List<string>()
    {
        "Alexander",
        "Dmitry",
        "Irene",
        "Sergey",
        "Nicholas",
        "Maxim",
        "Andrew",
        "Eugene",
        "Victor",
        "Artem",
        "Vasily",
    };

    public string name;
    public SinType sin;
    private void Awake()
    {
        name = names[Random.Range(0, names.Count)];
        sin = (SinType)Random.Range(0, Enum.GetValues(typeof(SinType)).Length);
    }
}
using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SinnerCharacteristcsComponent : MonoBehaviour
{
    private List<string> sins = new List<string>()
    {
        "Wasteful",
        "Profligate",
        "Slothful",
        "False Teacher",
        "Blasphemer",
        "Suicide",
        "Lustful",
        "Glutton",
        "Greedy",
        "Wrathful",
        "Heretic",
        "Tyrant",
        "Deceiver",
        "Betrayer"
    };

    private List<string> names = new List<string>()
    {
        "Alexander",
        "Dmitry",
        "Irene",
        "Anna",
        "Sergey",
        "Catherine",
        "Nicholas",
        "Olga",
        "Maxim",
        "Tatiana",
        "Andrew",
        "Natalia",
        "Eugene",
        "Maria",
        "Victor",
        "Svetlana",
        "Artem",
        "Ksenia",
        "Vasily",
        "Julia"
    };

    public string name;
    public string sin;

    private void Awake()
    {
        name = names[Random.Range(0, names.Count)];
        sin = sins[Random.Range(0, sins.Count)];
    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SetSinnerInformation : MonoBehaviour
{
    [SerializeField] private GameObject sinner;

    private void Start()
    {
        var sinnerCharacteristic = sinner.GetComponent<SinnerCharacteristcsComponent>();
        var sinnerText = this.GetComponent<Text>();

        sinnerText.text = "Sinner:\n" +
                          $"Name - {sinnerCharacteristic.name}\n" +
                          $"Sin - {sinnerCharacteristic.sin.ToString()}";
    }
}
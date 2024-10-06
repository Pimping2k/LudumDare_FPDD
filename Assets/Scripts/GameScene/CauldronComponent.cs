using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class CauldronComponent : MonoBehaviour
{
    [SerializeField] private CauldronNumber _cauldronNumber;
    [SerializeField] private SinnersCounterController sinnersCounterController;
    [SerializeField] private TextMeshPro cauldronName;

    enum CauldronNumber
    {
        Lust = 1,
        Gluttony,
        Greed,
        Wrath,
        Heresy,
        Violence,
        Fraud,
        Treachery
    }

    private void Start()
    {
        var cauldronTextColor = this.GetComponentInChildren<TextMeshPro>();
        cauldronName.text = ((int)_cauldronNumber).ToString();
        cauldronTextColor.color = GetColorForCauldron(_cauldronNumber);
    }

    private void OnTriggerEnter(Collider other)
    {
        var sinnerCharacteristics = other.GetComponent<SinnerCharacteristcsComponent>();

        if (other.CompareTag(Container.SINNER))
        {
            Container.sinnerCounter--;
            sinnersCounterController.UpdateSinnerInformation(Container.sinnerCounter);

            if (!IsMatchingSinToCauldron(sinnerCharacteristics.sin))
            {
                //Decreasing satan pleasure component
                //TO DO, Camera Shake(effect) and some sound
                Debug.Log("Not Good");
            }
            else
            {
                Debug.Log("Good");
            }

            Destroy(other.gameObject);
        }
    }

    public bool IsMatchingSinToCauldron(SinnerCharacteristcsComponent.SinType sinType)
    {
        switch (_cauldronNumber)
        {
            case CauldronNumber.Lust:
                return sinType == SinnerCharacteristcsComponent.SinType.Lust;
            case CauldronNumber.Gluttony:
                return sinType == SinnerCharacteristcsComponent.SinType.Gluttony;
            case CauldronNumber.Greed:
                return sinType == SinnerCharacteristcsComponent.SinType.Greed;
            case CauldronNumber.Wrath:
                return sinType == SinnerCharacteristcsComponent.SinType.Wrath;
            case CauldronNumber.Heresy:
                return sinType == SinnerCharacteristcsComponent.SinType.Heresy;
            case CauldronNumber.Violence:
                return sinType == SinnerCharacteristcsComponent.SinType.Violence;
            case CauldronNumber.Fraud:
                return sinType == SinnerCharacteristcsComponent.SinType.Fraud;
            case CauldronNumber.Treachery:
                return sinType == SinnerCharacteristcsComponent.SinType.Treachery;
            default:
                return false;
        }
    }
    
    private Color GetColorForCauldron(CauldronNumber cauldron)
    {
        switch (cauldron)
        {
            case CauldronNumber.Lust:
                return new Color(139f / 255f, 0f / 255f, 0f / 255f);
            case CauldronNumber.Gluttony:
                return new Color(189f / 255f, 183f / 255f, 107f / 255f);
            case CauldronNumber.Greed:
                return new Color(139f / 255f, 69f / 255f, 19f / 255f);
            case CauldronNumber.Wrath:
                return new Color(255f / 255f, 0f / 255f, 89 / 255f);
            case CauldronNumber.Heresy:
                return new Color(85f / 255f, 26f / 255f, 139f / 255f);
            case CauldronNumber.Violence:
                return new Color(72f / 255f, 61f / 255f, 139f / 255f);
            case CauldronNumber.Fraud:
                return new Color(112f / 255f, 128f / 255f, 144f / 255f);
            case CauldronNumber.Treachery:
                return new Color(0f / 255f, 0f / 255f, 139f / 255f);
            default:
                return Color.white;
        }
    }

}
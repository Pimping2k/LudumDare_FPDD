using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SinnersCounterController : MonoBehaviour
{
    private TextMeshPro sinnerCounterText;
    private void Start()
    {
        sinnerCounterText = this.GetComponent<TextMeshPro>();
        UpdateSinnerInformation(1);
    }

    public void UpdateSinnerInformation(int SinnerCount)
    {
        sinnerCounterText.text = $"{SinnerCount}";
    }
}

using System;
using UnityEngine;
using UnityEngine.UI;

public class DragSinner : MonoBehaviour
{
    [SerializeField] private Text sinnerInfo;
    [SerializeField] private Image sinnerInfoBg;
    private Vector3 offset;
    private float mZCoord;
    
    private void OnMouseDown()
    {
        mZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        UpdateSinnerInformation();
        ShowInfo();
        offset = gameObject.transform.position - GetMouseWorldPosition();
    }

    private void OnMouseDrag()
    {
        gameObject.transform.position = GetMouseWorldPosition() + offset;
    }

    private void OnMouseUp()
    {
        HideInfo();
    }

    Vector3 GetMouseWorldPosition()
    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = mZCoord;

        return Camera.main.ScreenToWorldPoint(mousePoint);
    }

    void ShowInfo()
    {
        sinnerInfo.gameObject.SetActive(true);
        sinnerInfoBg.gameObject.SetActive(true);
    }
    
    void HideInfo()
    {
        sinnerInfo.gameObject.SetActive(false);
        sinnerInfoBg.gameObject.SetActive(false);
    }

    void UpdateSinnerInformation()
    {
        var sinnerInfoComponent = this.GetComponent<SinnerCharacteristcsComponent>();
        sinnerInfo.text = "Sinner:\n" +
                          $"Name - {sinnerInfoComponent.name}\n" +
                          $"Sin - {sinnerInfoComponent.sin}";
    }
}
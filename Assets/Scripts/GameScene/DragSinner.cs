using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class DragSinner : MonoBehaviour
{
    [SerializeField] private Text sinnerInfo;
    [SerializeField] private Image sinnerInfoBg;
    private Vector3 offset;
    private float mZCoord;
    private float liftHeight = 1f;
    private float speed = 20f;
    private GameObject currentCauldron = null;
    private LayerMask cauldronLayerMask;
    private Coroutine liftCoroutine;

    private void Start()
    {
        cauldronLayerMask = LayerMask.GetMask("Cauldron");
    }

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

        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, Mathf.Infinity, cauldronLayerMask))
        {
            if (hit.collider.CompareTag(Container.CAULDRON))
            {
                GameObject cauldron = hit.collider.gameObject;

                if (currentCauldron != cauldron)
                {
                    if (currentCauldron != null)
                    {
                        StopCurrentLiftCoroutine();
                        StartCoroutine(LiftDown(currentCauldron));
                    }

                    currentCauldron = cauldron;
                    StartCoroutine(LiftUp(currentCauldron));
                }
            }
        }
        else
        {
            if (currentCauldron != null)
            {
                StopCurrentLiftCoroutine();
                StartCoroutine(LiftDown(currentCauldron));
                currentCauldron = null;
            }
        }
    }

    private void OnMouseUp()
    {
        HideInfo();
        if (currentCauldron != null)
        {
            StopCurrentLiftCoroutine();
            StartCoroutine(LiftDown(currentCauldron));
            currentCauldron = null;
        }
    }

    private void StopCurrentLiftCoroutine()
    {
        if (liftCoroutine != null)
        {
            StopCoroutine(liftCoroutine);
            liftCoroutine = null;
        }
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

    IEnumerator LiftUp(GameObject go)
    {
        var startPosition = go.transform.position;
        var targetPosition = new Vector3(startPosition.x, startPosition.y + liftHeight, startPosition.z);

        while (go.transform.position.y < targetPosition.y)
        {
            go.transform.position = Vector3.MoveTowards(go.transform.position, targetPosition, speed * Time.deltaTime);
            yield return null;
        }

        go.transform.position = targetPosition;
        liftCoroutine = null;
    }

    IEnumerator LiftDown(GameObject go)
    {
        var startPosition = go.transform.position;
        var targetPosition = new Vector3(startPosition.x, startPosition.y - liftHeight, startPosition.z);

        while (go.transform.position.y > targetPosition.y)
        {
            go.transform.position = Vector3.MoveTowards(go.transform.position, targetPosition, speed * Time.deltaTime);
            yield return null;
        }

        go.transform.position = targetPosition;
        liftCoroutine = null;
    }
}

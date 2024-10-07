using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class SinnerSpawner : MonoBehaviour
{
    [SerializeField] private GameObject sinnerPrefab;
    [SerializeField] private SinnersCounterController _sinnersCounterController;
    [SerializeField] private SatanPleasureComponent _satanPleasureComponent;
    
    private int maxSinner = 52;

    private Vector3 targetPosition;

    private void Start()
    {
        StartCoroutine(SpawnSinner());
    }

    IEnumerator SpawnSinner()
    {
        while (Container.sinnerCounter < maxSinner)
        {
            targetPosition = new Vector3(Random.Range(-15, -8), 17, 9);
            GameObject sinner = Instantiate(sinnerPrefab, targetPosition, new Quaternion(0,180,0,0));
        
            Container.sinnerCounter++;
            _sinnersCounterController.UpdateSinnerInformation(Container.sinnerCounter);
        
            StartCoroutine(CheckAndDestroy(sinner));
            yield return new WaitForSeconds(5f);
        }
    }


    IEnumerator CheckAndDestroy(GameObject sinner)
    {
        while (sinner != null)
        {
            if (sinner.transform.position.y < -3)
            {
                SatanPleasureComponent.Instance.TakeDamage(3f);
    
                if (Container.sinnerCounter > 0)
                {
                    Container.sinnerCounter--;
                    _sinnersCounterController.UpdateSinnerInformation(Container.sinnerCounter);
                }

                Destroy(sinner);
            }
            yield return null;
        }
    }
}
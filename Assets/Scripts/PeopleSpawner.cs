using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;


public class PeopleSpawner : MonoBehaviour
{
    [SerializeField] private GameObject peoplePrefab;

    private void Start()
    {
        StartCoroutine(SpawnPeople());
    }

    IEnumerator SpawnPeople()
    {
        while (true)
        {
            Vector3 peoplePosition = new Vector3(Random.Range(-20, 20), Random.Range(20, 25), Random.Range(-2, 40));
            
            GameObject spawnedPeople = Instantiate(peoplePrefab, peoplePosition, Quaternion.identity);

            StartCoroutine(CheckAndDestroy(spawnedPeople));

            yield return new WaitForSeconds(Random.Range(6f, 10f));
        }
    }

    IEnumerator CheckAndDestroy(GameObject spawnedPeople)
    {
        while (spawnedPeople != null)
        {
            if (spawnedPeople.transform.position.y <= -3)
            {
                Destroy(spawnedPeople);
            }
            yield return null; 
        }
    }
}
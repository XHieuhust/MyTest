using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnThings : MonoBehaviour
{
    [SerializeField] float disRoad;
    [SerializeField] List<GameObject> ListDoChoi;
    [SerializeField] List<GameObject> ListObsacles;
    [SerializeField] float TimeSpawnObsacle;
    [SerializeField] float TimeSpawnToy;
    [SerializeField] GameObject thief;

    public static SpawnThings ins;
    void Start()
    {
        ins = this;
    }

    public IEnumerator RandomSpawnToys()
    {
        while (true)
        {
            FallToys();
            yield return new WaitForSeconds(TimeSpawnToy);
        }
    }

    public IEnumerator RandomSpawnObsalce()
    {
        while (true)
        {
            yield return new WaitForSeconds(TimeSpawnObsacle);
            FallObsalces();
        }

    }

    int cntObsacles;
    void FallObsalces()
    {
        if (thief.transform.position.y > transform.position.y)
        {
            Vector3 ObsaclePosition = new Vector3(transform.position.x, transform.position.y - Random.Range(0, 2) * disRoad, transform.position.z);
            Instantiate(ListObsacles[cntObsacles++ % 3], ObsaclePosition, Quaternion.identity);
        }
        else if (thief.transform.position.y == transform.position.y)
        {
            Vector3 ObsaclePosition = new Vector3(transform.position.x, transform.position.y - (Random.Range(0, 2) == 0 ? 1 : -1) * disRoad, transform.position.z);
            Instantiate(ListObsacles[cntObsacles++ % 3], ObsaclePosition, Quaternion.identity);
        }
        else if (thief.transform.position.y < transform.position.y)
        {
            Vector3 ObsaclePosition = new Vector3(transform.position.x, transform.position.y + Random.Range(0, 2) * disRoad, transform.position.z);
            Instantiate(ListObsacles[cntObsacles++ % 3], ObsaclePosition, Quaternion.identity);
        }
    }

    int cntToys;
    void FallToys()
    {
        Vector3 fallPosition = new Vector3(thief.transform.position.x - 1f, thief.transform.position.y + 2f, thief.transform.position.z);
        Instantiate(ListDoChoi[(cntToys++) % 6], fallPosition, Quaternion.identity);
    }

    public void StopToSpawn()
    {
        StopAllCoroutines();
    }

    public void StartToSpawn()
    {
        StartCoroutine(nameof(RandomSpawnToys));
        StartCoroutine(nameof(RandomSpawnObsalce));
    }
}

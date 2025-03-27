using UnityEngine;

public class EngelSpawn : MonoBehaviour
{
    public float MaxTime = 1;
    public float Timer = 0;
    public GameObject engel;
    public float high;
    void Start()
    {
        GameObject newengel = Instantiate(engel);
        newengel.transform.position = transform.position + new Vector3(0, Random.Range(-high, high), 0);
    }

    // Update is called once per frame
    void Update()
    {
        if(Timer>MaxTime)
        {
            GameObject newengel = Instantiate(engel);
            newengel.transform.position = transform.position + new Vector3(0, Random.Range(-high, high), 0);
            Destroy(newengel, 15);
            Timer = 0;
        }
        Timer += Time.deltaTime;
    }
}

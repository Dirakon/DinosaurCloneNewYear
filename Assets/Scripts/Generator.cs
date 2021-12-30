using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float minDistBetweenGens,maxDistBetweenGens;
    [SerializeField] GameObject[] gensPrefabs;
    public float nextSpawn = 10f;
    public Transform player;
    public float playerOffset = 10f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player.position.x + playerOffset >= nextSpawn){
            Instantiate(gensPrefabs[Random.Range(0,gensPrefabs.Length)],new Vector3(nextSpawn,transform.position.y,transform.position.z),Quaternion.identity);

            nextSpawn += Random.Range(minDistBetweenGens, maxDistBetweenGens);
        }
    }
}

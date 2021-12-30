using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Remover : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
     private void OnCollisionEnter2D(Collision2D other) {
        Debug.Log("destroyed");
        Destroy(other.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

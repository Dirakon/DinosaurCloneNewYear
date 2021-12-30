using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMer : MonoBehaviour
{
    static BGMer singleton;
    void Start()
    {
      if (singleton == null){
          singleton = this;
          DontDestroyOnLoad(gameObject);
      }  else{
          Destroy(gameObject);
      }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

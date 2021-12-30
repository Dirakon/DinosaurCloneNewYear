using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CameraFollower : MonoBehaviour
{
    [SerializeField] Transform target;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Hero.IsDead)
        {
            if (Input.GetKeyDown(KeyCode.Space)||Mathf.Abs(Input.GetAxis("Vertical"))>0.000001f){
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex,LoadSceneMode.Single);
            }
        }
        else
        {
            var newPosition = new Vector3(target.position.x, transform.position.y, transform.position.z);
            transform.position = newPosition;
        }
    }
}

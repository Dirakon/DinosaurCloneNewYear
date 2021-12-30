using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoScroller : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float startingX = 0.29f, endingX = -24;
    [SerializeField] float speed = 10f;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!Hero.IsDead)
        {
            transform.Translate(-transform.right * speed * Time.deltaTime);
            if (transform.localPosition.x <= endingX)
            {
                transform.localPosition = new Vector3(startingX, transform.localPosition.y, transform.localPosition.z);
            }
        }
    }
}

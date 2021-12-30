using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class TimerAbove : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        tmpro = GetComponent<TextMeshProUGUI>();
    }
    int curTime = 0;
    float curForSecond = SECOND;
    static float SECOND = 0.1f;
    public GameObject afterDeathObject;
    public TextMeshProUGUI tmpro;

    // Update is called once per frame
    void Update()
    {
        if (Hero.IsDead)
        {
            afterDeathObject.SetActive(true);
            Destroy(this);
        }
        else
        {
            curForSecond -= Time.deltaTime;
            if (curForSecond <= 0)
            {
                curTime++;
                curForSecond = SECOND;
            }
            tmpro.text = curTime.ToString();
        }
    }
}

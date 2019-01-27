using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountdownTimer : MonoBehaviour
{
    public GameObject manager;
    public GameManager gM;
    public Text timer;

    // Start is called before the first frame update
    void Start()
    {
        gM = manager.GetComponent<GameManager>();
        timer = gameObject.GetComponentInChildren<Text>();
     }

    // Update is called once per frame
    void Update()
    {
        if (gM.m_exploreTimer >= 0)
        {
            timer.text = "time left: " + gM.m_exploreTimer.ToString("F2");
        }
        else
        {
            timer.text = "time left: " + gM.m_returnTimer.ToString("F2");
        }
    }
}

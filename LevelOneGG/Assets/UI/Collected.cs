using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collected : MonoBehaviour
{
    public string[] items_Collected = {"BCap","Guitar","GBottle" };
    private Collected_Enable[] ggl;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //gameObject.GetComponentInChildren<Collected_Enable>().onOpen();
    }
    public void opened() {
        gameObject.GetComponentInChildren<Collected_Enable>();
        foreach (Collected_Enable item in ggl)
        {
            ggl.onOpen();
        }
      }
}

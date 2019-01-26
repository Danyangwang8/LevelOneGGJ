using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collected : MonoBehaviour
{
    public int ggg = 0;
    public string[] items_Collected = { "BCap", "Guitar", "GBottle" };
    private Component ggl;

    // Start is called before the first frame update
    void Start()
    {
        ggl = gameObject.GetComponentInChildren<Collected_Enable>();
    }

    // Update is called once per frame
    void Update()
    {
        //gameObject.GetComponentInChildren<Collected_Enable>().onOpen();
    }
    public void opened()
    {

       // foreach (Collected_Enable item in ggl)
       // {
       //     ggl.onOpen();
       // }
    }
}

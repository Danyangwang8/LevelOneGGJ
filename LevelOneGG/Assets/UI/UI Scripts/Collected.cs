using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collected : MonoBehaviour
{
    public int ggg = 0;
    public string[] items_Collected = { "BCap", "Guitar", "GBottle", "BBox","SkateB","BBottle" };
    private Collected_Enable[] ggl;

    // Start is called before the first frame update
    void Start()
    {
        ggl = gameObject.GetComponentsInChildren<Collected_Enable>();
        foreach (Collected_Enable collected in ggl)
        {
            collected.gameObject.SetActive(false);
        }
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

    public void AddItem(Sprite sprite)
    {
        foreach (Collected_Enable collected in ggl)
        {
            if (collected.isActiveAndEnabled)
            {
                continue;
            }
            collected.AddItem(sprite);
            break;
        }
    }


    public void ResetInventory()
    {
        foreach (Collected_Enable collected in ggl)
        {
            collected.gameObject.SetActive(false);
        }
    }
}

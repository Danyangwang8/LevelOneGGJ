using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collected_Enable : MonoBehaviour
{
    public Collected coll;
    //public GameObject folder;
    public int itemnumber;
    // Start is called before the first frame update
    void Start()
    {
        coll = GetComponentInParent<Collected>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void onOpen() 
    {
        Debug.Log(coll.items_Collected[itemnumber]);
        gameObject.GetComponent<Image>().sprite = Resources.Load<Sprite>(coll.items_Collected[itemnumber]);
    }

}

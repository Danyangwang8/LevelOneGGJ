using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collected_Enable : MonoBehaviour
{
    public Collected coll;
    public AnimationPopup AP;
    //public GameObject folder;
    public int itemnumber;
    // Start is called before the first frame update
    void Start()
    {
        coll = GetComponentInParent<Collected>();
        AP = GetComponentInParent<AnimationPopup>();
    }

    // Update is called once per frame
    void Update()
    {
        if(AP.collectionImageActivate == true){ gameObject.GetComponent<Image>().enabled = true; }
        if (AP.collectionImageActivate == false) { gameObject.GetComponent<Image>().enabled = false; }
    }
    public void onOpen() 
    {
        //Debug.Log(coll.items_Collected[itemnumber]);
        //gameObject.GetComponent<Image>().sprite = Resources.Load<Sprite>(coll.items_Collected[itemnumber]);
    }

    public void AddItem(Sprite sprite)
    {
        gameObject.SetActive(true);
        gameObject.GetComponent<Image>().sprite = sprite;
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour
{
    public GameObject img_Anime;
    public AnimationPopup SA;
    // Start is called before the first frame update
    void Start()
    {
        SA = img_Anime.GetComponent <AnimationPopup> ();
    }

    // Update is called once per frame
    void Update()
    {
        if (SA.collectionImageActivate == true)
        {
            gameObject.GetComponent<Image>().sprite = Resources.Load<Sprite>("OpenBag");
        }
        else if (SA.collectionImageActivate == false) 
        {
            gameObject.GetComponent<Image>().sprite = Resources.Load<Sprite>("ClosedBag");
        }
    }
}

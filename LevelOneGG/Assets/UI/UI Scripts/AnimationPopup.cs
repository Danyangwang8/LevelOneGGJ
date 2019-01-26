using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimationPopup : MonoBehaviour
{

    public bool collectionImageActivate = false;
    public bool nintendo;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void enableOnClick() {
        nintendo = gameObject.GetComponent<Animator>().GetBool("Active");
        gameObject.GetComponent<Animator>().SetBool("Active", !nintendo);
    }
    public void collectionEnabled() { collectionImageActivate = !collectionImageActivate; }
}

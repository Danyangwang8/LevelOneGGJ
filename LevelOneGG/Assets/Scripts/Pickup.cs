using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{

    public float Value = 5;
    
    private void Awake()
    {
        //ContentType = TileContentType.Pickup;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PickupObject()
    {
        gameObject.SetActive(false);
    }
}

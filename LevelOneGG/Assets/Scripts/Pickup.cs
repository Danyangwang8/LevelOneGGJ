using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{

    public float Value = 5;

    public List<Sprite> sprites;

    [HideInInspector]
    public bool isPickup = false;
    private TileManager tileManager;

    private int spritesNum;

    public int pickupNums;

    private void Awake()
    {
        //ContentType = TileContentType.Pickup;
    }
    void Start()
    {
        gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
    }

    // Update is called once per frame
    void Update()
    {
        //for (int j = 0; j < pickupNums;j++)
        //{
            //CreatObjectWithDifSprite();
        //}
       
        //PickupObject();
    }
    public void CreatObjectWithDifSprite()
    {
      
        //make pickups has different sprites
        spritesNum = sprites.Count;
 
        int i = Random.Range(0, spritesNum);
        gameObject.GetComponent<SpriteRenderer>().sprite = sprites[i];
    }

    public void PickupObject()
    {
        isPickup = true;
        gameObject.SetActive(false);
        pickupNums--;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PickupObject();
    }
}

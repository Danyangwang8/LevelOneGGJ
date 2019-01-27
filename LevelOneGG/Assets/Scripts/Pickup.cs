using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{

    public float Value = 5;
    private GameObject pickups;

    [HideInInspector]
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
        pickups.GetComponent<BoxCollider2D>().isTrigger = true;
        sprites = new List<Sprite>();
        sprites.Add(Resources.Load<Sprite>("BBottle"));
        sprites.Add(Resources.Load<Sprite>("BBox"));
        sprites.Add(Resources.Load<Sprite>("BCap"));
        sprites.Add(Resources.Load<Sprite>("ClosedBag"));
        sprites.Add(Resources.Load<Sprite>("Gbottle"));
        sprites.Add(Resources.Load<Sprite>("Guitar"));
        sprites.Add(Resources.Load<Sprite>("Layer 21"));
        sprites.Add(Resources.Load<Sprite>("OpenBag"));
        sprites.Add(Resources.Load<Sprite>("SkateB"));
    }

    // Update is called once per frame
    void Update()
    {
        for (int j = 0; j < pickupNums;j++)
        {
            CreatObjectWithDifSprite();
        }
       
        PickupObject();
    }
    public void CreatObjectWithDifSprite()
    {
      
        //make pickups has different sprites
        spritesNum = sprites.Count;
 
        int i = Random.Range(0, spritesNum);
        pickups.GetComponent<SpriteRenderer>().sprite = sprites[i];
        tileManager.ShowUpItems();
    }

    public void PickupObject()
    {
        isPickup = true;
        pickups.SetActive(false);
        pickupNums--;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PickupObject();
    }
}

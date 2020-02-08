using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hunter : MonoBehaviour
{

    // public GameObject rightPointerObject;
    // public Camera camera;
    // public float rayLength;

    // https://www.youtube.com/watch?v=_QajrabyTJc
    // https://docs.unity3d.com/ScriptReference/Physics.Raycast.html

    
    private GameObject winMessageObject;
    private GameObject inventoryMessageObject;
    private GameObject scoreMessageObject;
    public TextMesh winMessage;
    public TextMesh inventoryMessage;
    public TextMesh scoreMessage;

    // public GameObject leftPointerObject;
    // public GameObject rightPointerObject;

    public Camera oculusCam;

    int coinPointValue;
    int treasureChestPointValue;
    int diamondPointValue;

    int score = 0;

    private Inventory inventory;
    private bool inventoryMessageOn;
    private bool scoreMessageOn;

    private int numberOfObjectsCollected;

    private Treasure coin;
    private Treasure treasureChest;
    private Treasure diamond;

   
   

    // int layerMask = 1 << 8;
 
    void Start()
    {
        GameObject coinObj = GameObject.Find("Coin 1");
        GameObject treasureChestObj = GameObject.Find("Treasure Chest 1");
        GameObject diamondObj = GameObject.Find("Diamond 1");

        coin = coinObj.GetComponent<Treasure>();
        treasureChest = treasureChestObj.GetComponent<Treasure>();
        diamond = diamondObj.GetComponent<Treasure>();

        coinPointValue = coin.pointValue;
        treasureChestPointValue = treasureChest.pointValue;
        diamondPointValue = diamond.pointValue;

        // Debug.Log("Coin: " + coinPointValue);
        // Debug.Log("Treasure Chest: " + treasureChestPointValue);
        // Debug.Log("Diamond: " + diamondPointValue);
        // Debug.Log("Treasure Chest: " + treausureChest.pointValue);
        // Debug.Log("Diamond: " + diamond.pointValue);

        GameObject hunter = GameObject.Find("OVRPlayerController");
        inventory = hunter.GetComponent<Inventory>();
        

        scoreMessage.text = "Halie\r\nScore: " + score;

        winMessageObject = GameObject.Find("Win Message");
        // winMessage = winMessageObject.GetComponent<TextMesh>();
        winMessage.text = "You Win! You have collected all 20 collectibles";
        winMessageObject.SetActive(false);
        winMessage.color = Color.green;

        inventoryMessageObject = GameObject.Find("Inventory Message");
        inventoryMessage.text = "Inventory Text!";
        inventoryMessageObject.SetActive(false);
        inventoryMessage.color = Color.black;

        inventoryMessageOn = false;
        scoreMessageOn = false;

        scoreMessageObject = GameObject.Find("Score Message");
        scoreMessageObject.SetActive(false);

        // set all messages to be off origninally
        // inventoryMessageObject = GameObject.Find("Inventory Message");
        // inventoryMessageObject.setActive(false);
   
        // inventoryMessageObject = GameObject.Find("Inventory Message");
        // inventoryMessage.text = "Total Items";
        // // inventoryMessageObject.setActive(false);
        // inventoryMessage.color = Color.black;
        
        
    }

    
    void Update() {


    // checks to see if 20 objects have been collected (not sure if this works yet)
    int total = 0;
    foreach (int numOfCollectible in inventory.count) {
        total += numOfCollectible;
    }

    // number of collectibles in scene: 20
    if (total == 20) {
      winMessageObject.SetActive(true);
    }

    RaycastHit hit;
        // if(Input.GetKeyDown("1")) {
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity )) {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.red);
            // Debug.Log("Did Hit");
            //  Debug.Log("Object hit: " + hit.collider.gameObject);
        } else {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.white);
            // Debug.Log("Did not Hit" );
        }

        if (Input.GetKeyDown("1")) {

            // check to see hit object is coin object, if it is then add it to the first index of the array, etc
            // or can just do it have an array of 20, add whatever object to the array, then when counting go through the entire array
            Debug.Log("Key Pressed: 1");
            Debug.Log("Object hit: " + hit.collider.gameObject);

            GameObject hitObject = hit.collider.gameObject;
            Destroy(hitObject);

            Treasure obj = (hit.collider.gameObject).GetComponent<Treasure>();
            // Debug.Log("Object's Point Value: " + obj.pointValue);

            // Debug.Log("here: " + obj.pointValue);

            score = score + obj.pointValue;
            // Debug.Log("score: " + score);
            scoreMessage.text = "Halie\r\nScore: " + score;


            switch(obj.pointValue) {
                case 1:
                    // Debug.Log("coin was hit");
                    inventory.collectibles[0] = coin;
                    inventory.count[0] += 1;
                    break;
                case 10:
                    // Debug.Log("Treasure Chest was hit");
                    inventory.collectibles[1] = treasureChest;
                    inventory.count[1] += 1;
                    break;
                case 100:
                    // Debug.Log("Diamond was hit");
                    inventory.collectibles[2] = diamond;
                    inventory.count[2] += 1;
                    break;
                default:
                    // Debug.Log("DEFAULT"); 
                    break;
            }

            // if (obj.pointValue == coinPointValue) {
            //     Debug.Log("coin");
            // } else (obj.pointValue == treasureChestPointValue)
            //     Debug.Log("treasure chest");
            // } else (obj.pointValue == )
        updateInventory();

        }

        if (Input.GetKeyDown("2")) {
            Debug.Log("Key Pressed: 2");
            updateInventory();
         
            // inventoryMessageObject.setActive(inventoryMessageOn);
            inventoryMessageOn = !inventoryMessageOn;
            inventoryMessageObject.SetActive(inventoryMessageOn);
        }

        if(Input.GetKeyDown("3")) {
            Debug.Log("Key Pressed: 3");
            scoreMessageOn = !scoreMessageOn;
            scoreMessageObject.SetActive(scoreMessageOn);
        }

        

       

        }

        void updateInventory() {
            inventoryMessage.text = 
            "Inventory:" + "\r\nCoin: " + inventory.count[0] + "\r\nTreasure Chest: " + inventory.count[1] + "\r\nDiamond: " + inventory.count[2];
            return;
        }

         
        

}

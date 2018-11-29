using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour {

    private Rigidbody rb;
    private int count;
    public Text countText;
    public Text WinText;
    public GameObject MenuFinal;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
        count = 0;
        countText.text = "Count = " + count;
        WinText.text = "";

    }



    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Book_Prefab"))
        {
            other.gameObject.SetActive(false);
            count++;
            countText.text = "Count = " + count;

            if (count >= 5)
            {
                MenuFinal.active = true;
                gameObject.active = false;
                WinText.text = "You Win !!";
            }
        }
        
    }


}

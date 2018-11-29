using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuInicio : MonoBehaviour {


    public GameObject player;
    public GameObject btn1; //FFCECE
    public GameObject btn2;

    private int BotonSelected;


    // Use this for initialization
    void Start () {
        player.active = false;
        BotonSelected = 1;
        btn2.active = false;
        btn1.active = true;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetAxis("Horizontal")>0 )
            {

            BotonSelected = 1;
            btn2.active = false;
            btn1.active = true;
        }
        if (Input.GetAxis("Vertical") > 0)
        {
            btn1.active = false;
            btn2.active = true;
            BotonSelected = 2;
        }

        if (Input.GetAxis("Jump") > 0 && BotonSelected == 1)
        {
            player.active = true;
            gameObject.active = false;

        }


    }
}

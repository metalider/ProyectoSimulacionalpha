using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileControll : MonoBehaviour {

    public GameObject firepoint;

    public GameObject a;
    public GameObject b;


    public List<GameObject> vfx = new List<GameObject>();

    private GameObject proyectiles;
    private float timeToFire = 0;

    // Use this for initialization
    void Start () {
        proyectiles = vfx[0];
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetAxis("Fire1")!= 0 && Time.time >= timeToFire)
        {
            timeToFire = Time.time + 1 / proyectiles.GetComponent<ProjectileMove>().fireRate;
            SpawnVFX();

        }
    }

    private void SpawnVFX()
    {
        GameObject vfx;

        if (firepoint != null)
        {
            vfx = Instantiate(proyectiles, firepoint.transform.position, Quaternion.identity);
            vfx.transform.localRotation = Quaternion.Lerp(a.transform.rotation,b.transform.rotation, 0);
        }
        else
        {
            Debug.Log("No fire point");
        }
    }



}

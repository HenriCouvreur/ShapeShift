using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Gun : MonoBehaviour
{
    public float gunPower;
    public Material[] colors = new Material[4];
    public GameObject[] shapes = new GameObject[3];
    public int maxAmmo;

    int ammo;
    int scrollsInARow;

    void Start ()
    {
        ammo = maxAmmo;
    }

    void Update ()
    {
        if (Input.GetButtonDown("Fire1"))
            if (ammo > 0)
                Shoot();
            else
                Reload();
        
        if (Input.GetButtonDown("Reload"))
            Reload();

        if (Input.GetAxis("Mouse ScrollWheel") != 0)
            scrollsInARow += 1;
        else
            scrollsInARow = 0;
        if (scrollsInARow == 3)
        {
            Reload();
        }
    }

    void Shoot()
    {
        GameObject bullet = (GameObject)Instantiate(shapes[Random.Range(0, 3)], transform.position, Random.rotation);
        bullet.GetComponent<Renderer>().material = colors[Random.Range(0, 4)];
        bullet.GetComponent<Rigidbody>().AddForce(transform.forward * gunPower);
        bullet.transform.parent = GameObject.Find("Bullets").transform;
        ammo--;
        Debug.Log(ammo);
    }

    void Reload()
    {
        UnfreezeBlocks();
        ammo = maxAmmo;
    }


    void UnfreezeBlocks()
    {
        GameObject bulletHolder = GameObject.Find("Bullets");
        foreach (Transform b in bulletHolder.transform)
        {
            b.GetComponent<Bullet>().Unfreeze();
        }
    }
}

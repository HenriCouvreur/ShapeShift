using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
    public bool alive;

    void Update ()
    {
        //GetComponent<NavMeshAgent>().destination = GameObject.FindGameObjectWithTag("Player").transform.position;
    }

    void OnCollisionEnter (Collision col)
    {
        if (col.gameObject.GetComponent<Bullet>())
        {
            alive = false;
            StartCoroutine(CLIGNOTER());
        }
    }

    IEnumerator CLIGNOTER ()
    {
        while (true)
        {
            Color coul;
            float coul1 = Random.Range(1f, 255f)/255;
            float seed = Random.Range(1, 6);
            if (seed == 1) coul = new Color(0, coul1, 255);
            else if (seed == 2) coul = new Color(0, 255, coul1);
            else if (seed == 3) coul = new Color(coul1, 0, 255);
            else if (seed == 3) coul = new Color(coul1, 255, 0);
            else if (seed == 4) coul = new Color(255, 0, coul1);
            else coul = new Color(255, coul1, 0);
            GetComponent<Renderer>().material.color = coul;
            yield return new WaitForSeconds(Random.value * Random.value * Random.value);
        }
    }
}

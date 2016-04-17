using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{
    public bool sticky;
    [Range (1,20)]
    public int sizeSmall;
    public float deInflateSpeed;

    void OnCollisionEnter (Collision col)
    {
        if (sticky == true)
            Destroy(GetComponent<Rigidbody>());
    }

    public void Unfreeze ()
    {

        sticky = false;
        if (!GetComponent<Rigidbody>())
        {
            gameObject.AddComponent<Rigidbody>();
            StartCoroutine(DeInflate());
        }
    }

    IEnumerator DeInflate ()
    {
        float targetScale = transform.localScale.x / sizeSmall;
        while (transform.localScale.x > targetScale)
        {
            transform.localScale -= new Vector3(deInflateSpeed, deInflateSpeed, deInflateSpeed)*Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
    }

}

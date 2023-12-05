using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public GameObject vfxTouch;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        string tag = collision.gameObject.tag;
        switch(tag)
        {
            case "Dead":
                //GameManager.instance.GameEnd();
                break;

            case "Bouncer":
                //GameManager.instance.UpdateScore(10, 1);
                break;

            case "Point":
                //GameManager.instance.UpdateScore(20, 1);
                GameObject vfx = Instantiate(vfxTouch, transform.position, Quaternion.identity) as GameObject;
                Destroy(vfx, 1f);
                break;

            case "Side":
                //GameManager.instance.UpdateScore(10, 0);
                break;

            case "Flipper":
                //GameManager.instance.multiplier = 1;
                break;

            default:
                break;
        }
    }
}

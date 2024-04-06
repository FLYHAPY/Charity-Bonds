using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodCourt : MonoBehaviour
{
    public NewBehaviourScript nbs;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Debug.Log("colided");
            nbs.playerFood = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            nbs.playerFood = false;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    GameObject Canvas;
    UI scriptUI;
    private bool trig = false;
    private bool coll = false;
    // Start is called before the first frame update
    void Start()
    {
        Canvas = GameObject.FindGameObjectWithTag("Canvas");
        scriptUI = Canvas.GetComponent<UI>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player") && (scriptUI != null) && (coll == false))
        {
            scriptUI.subtractScore();
            Debug.Log("OnCollisionEnter substractScore");
            coll = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && (scriptUI != null) && (trig == false))
        {
            scriptUI.addScore();
            Debug.Log("OnCollisionEnter addScore");
            trig = true;
        }
        
    }
}

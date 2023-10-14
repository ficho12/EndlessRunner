using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    GameObject Canvas;
    UI scriptUI;
    // Start is called before the first frame update
    void Start()
    {
        Canvas = GameObject.FindGameObjectWithTag("Canvas");
        scriptUI = Canvas.GetComponent<UI>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player") && (scriptUI != null))
        {
            scriptUI.subtractScore();
            Debug.Log("OnCollisionEnter substractScore");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && (scriptUI != null))
        {
            scriptUI.addScore();
            Debug.Log("OnCollisionEnter addScore");
        }
        
    }
}

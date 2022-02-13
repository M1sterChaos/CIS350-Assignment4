using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTriggerEnterAddScore : MonoBehaviour
{

    private UIManager UIM;

    private bool triggered = false;
    // Start is called before the first frame update
    void Start()
    {
        UIM = GameObject.FindObjectOfType<UIManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player") && !triggered)
        {
            triggered = true;
            UIM.score++;
        }
    }
}

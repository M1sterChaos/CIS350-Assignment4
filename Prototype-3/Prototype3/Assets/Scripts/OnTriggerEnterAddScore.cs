/*
 * (Austin Buck)
 * (Assignment 4)
 * (Adds score when player jumps above obstacle)
 */
using UnityEngine;

public class OnTriggerEnterAddScore : MonoBehaviour
{

    private UIManager UIM;

    private bool triggered = false;
    // Start is called before the first frame update
    void Start()
    {
        UIM = GameObject.FindGameObjectWithTag("UIM").GetComponent<UIManager>();
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

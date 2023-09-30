using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class opendoor1 : MonoBehaviour
{
    private Animator anim;
    [SerializeField] private GameObject door;
    public SoundManager sound;



    void Start()
    {
        anim = door.GetComponent<Animator>();
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("door") && GetComponent<key>().hasKey == true)
        {
            sound.OpenDoor();
            anim.SetTrigger("doorOpen");
            GetComponent<key>().hasKey = false;
        }
    }
}

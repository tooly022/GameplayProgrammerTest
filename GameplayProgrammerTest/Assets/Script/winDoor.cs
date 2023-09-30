using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class winDoor : MonoBehaviour
{
    private Animator anim;
    [SerializeField] private GameObject door;
    public SoundManager sound;
    [SerializeField] private GameObject ui;


    // Start is called before the first frame update
    void Start()
    {
        anim = door.GetComponent<Animator>();

    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("door") && GetComponent<key>().hasKey == true&& GetComponent<pushCube>().isClick1== true&&GetComponent<pushCube>().isClick2==true )
        {
            sound.OpenDoor();
            anim.SetTrigger("win");
            GetComponent<key>().hasKey = false;
            ui.SetActive(true);
        }
    }
}

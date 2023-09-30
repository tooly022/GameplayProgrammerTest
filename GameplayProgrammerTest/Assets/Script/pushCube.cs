using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pushCube : MonoBehaviour
{
    private Animator anim;
    private Animator anim2;

    [SerializeField] private GameObject click;
    [SerializeField] private GameObject click2;

    public bool isClick1 = false;
    public bool isClick2 = false;

    [SerializeField] private GameObject light1;
    [SerializeField] private GameObject light2;




    private void Start()
    {
        anim = click.GetComponent<Animator>();
        anim2 = click2.GetComponent<Animator>();

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("cube"))
        {
            anim.SetTrigger("click1");
            isClick1 = true;
            light1.SetActive(true);
        }
        if (other.gameObject.CompareTag("cube2"))
        {
            anim2.SetTrigger("click2");
            isClick2 = true;
            light2.SetActive(true);

        }
    }
}

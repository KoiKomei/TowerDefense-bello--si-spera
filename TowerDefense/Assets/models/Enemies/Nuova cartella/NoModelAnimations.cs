using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]

public class NoModelAnimations : MonoBehaviour {

    private Animator animator;
    private CharacterController _charController;



    // Use this for initialization
    void Start()
    {
        _charController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        float horInput = Input.GetAxis("Horizontal");
        float vertInput = Input.GetAxis("Vertical");
        BlendMove(horInput, vertInput);


    }

    /* NON TOCCARE PER NESSUNA QUESTIONE AL MONDO, SERVONO PER LE ANIMAZIONI*/
    private void BlendMove(float x, float y)
    {
        animator.SetFloat("VelX", x);
        animator.SetFloat("VelY", y);
    }

}

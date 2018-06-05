using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Animator))]

public class IKController : MonoBehaviour {


    

    protected Animator animator;

    public static bool ikActive = true;
    public Transform leftHandObj = null;
    public GameObject obj1 = null;
    public Transform leftHandObj2 = null;
    public Transform lookObj = null;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void OnAnimatorIK()
    {
        if (animator)
        {

            //Se l'ik è attiva
            if (ikActive)
            {

                // Si specifica l'oggetto a cui ci deve essere l'ik
                if (lookObj != null)
                {
                    animator.SetLookAtWeight(1);
                    animator.SetLookAtPosition(lookObj.position);
                }

                // Dà una posizione ed una rotazione a ciò che si deve agganciare
                if (leftHandObj != null)
                {
                    animator.SetIKPositionWeight(AvatarIKGoal.LeftHand, 1);
                    animator.SetIKRotationWeight(AvatarIKGoal.LeftHand, 1);
                    animator.SetIKPosition(AvatarIKGoal.LeftHand, leftHandObj.position);
                    animator.SetIKRotation(AvatarIKGoal.LeftHand, leftHandObj.rotation);
                }

            }

            //Se l'ik non è attiva ritorna tutto al normale
            else
            {
                animator.SetIKPositionWeight(AvatarIKGoal.LeftHand, 0);
                animator.SetIKRotationWeight(AvatarIKGoal.LeftHand, 0);
                animator.SetLookAtWeight(0);
            }
            

        }
    }
}

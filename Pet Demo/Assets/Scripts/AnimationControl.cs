using UnityEngine;

public class AnimationControl : MonoBehaviour
{
    Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float horz = Input.GetAxis("Horizontal");
        float vert = Input.GetAxis("Vertical");

        if (Input.GetKeyDown(KeyCode.Space))
        {
            //spacebar (jump)
            animator.SetTrigger("jump");
            animator.SetBool("isAttack", false);
            animator.SetBool("isWalk", false);
        }
        else if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            //left shift (attack)
            animator.SetBool("isAttack", true);
            animator.SetBool("isWalk", false);
        }
        else if (Mathf.Abs(horz) > 0 || Mathf.Abs(vert) > 0)
        {
            //movement (wakl)
            animator.SetBool("isAttack", false);
            animator.SetBool("isWalk", true);
        }
        else
        {
            animator.SetBool("isWalk", false);
            if (animator.GetBool("isAttack") == true && animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1.0f)
            {
                animator.SetBool("isAttack", false);
            }

        }
    }
}

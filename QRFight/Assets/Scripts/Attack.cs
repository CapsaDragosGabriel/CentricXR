using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject enemy=null;
    [SerializeField] float minDamage = 1, maxDamage=3;
     float attackSpeed = 1.5f;

    private Animator mAnimator;

    private void Start()
    {

        mAnimator = GetComponent<Animator>();
    }

    public float attackTimer=0;
    public void SetEnemy(GameObject e)
    {
        enemy = e;
        if (e!=null)
        {
          
        }
        else
        {
        }
    }

    private void OnCollisionStay(Collision collision)
    {

        // Abort if we already attacked recently.
        if (Time.time - attackTimer < attackSpeed) {  return; }

        // CompareTag is cheaper than .tag ==
        if (collision.gameObject == enemy)
        {
            if (collision.gameObject)
            if (collision.gameObject.GetComponent<ObjectStats>() != null)
            {
                collision.gameObject.GetComponent<ObjectStats>().TakeDamage(this.gameObject, Random.Range(minDamage, maxDamage));
                if (mAnimator != null && !this.gameObject.GetComponent<ObjectStats>().dead)

                {
                    mAnimator.SetTrigger("Attack");
                  }

            }
            // Remember that we recently attacked.
            attackTimer = Time.time;

        }
    }
      
    void Update()
    {
       
    }
}

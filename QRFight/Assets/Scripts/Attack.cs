using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject enemy=null;
    [SerializeField] float minDamage = 1, maxDamage=3;
     float attackSpeed = 1.5f;
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
        if (Time.time - attackTimer < attackSpeed) return;

        // CompareTag is cheaper than .tag ==
        if (collision.gameObject == enemy)
        {
            if (collision.gameObject.GetComponent<ObjectStats>() != null)
                collision.gameObject.GetComponent<ObjectStats>().TakeDamage(Random.Range(minDamage, maxDamage));

            // Remember that we recently attacked.
            attackTimer = Time.time;

        }
    }
            /*
    private IEnumerator PeriodicDamage()
    {
        if (enemy != null)
        {
            if (true)
            {
                float dmg = Random.Range(minDamage, maxDamage);
                enemy.GetComponent<ObjectStats>().TakeDamage(dmg);
                
            }
            else
            {
                if (attackTimer >= attackSpeed) attackTimer = 0;
            }
        }
        else
        {
            StopCoroutine(PeriodicDamage());
        }

        yield return new WaitForSeconds(attackSpeed);
    }
        */
    // Update is called once per frame
    void Update()
    {
        
    }
}

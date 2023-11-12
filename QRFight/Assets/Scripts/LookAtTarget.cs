using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtTarget : MonoBehaviour
{
    public Transform Target;
   
    private void OnCollisionEnter(Collision collision)
    {
        

        if (collision.gameObject != this.gameObject)
        {
            Target = collision.gameObject.transform;
            StartCoroutine(ForceLookAt());
            this.GetComponent<Attack>().SetEnemy(collision.gameObject);
        }
    }
   
    private void OnCollisionExit(Collision collision)
    {
        Target = null;
        this.GetComponent<Attack>().SetEnemy(null);
        StopCoroutine(ForceLookAt());

    }
    private IEnumerator ForceLookAt()
    {
        if (Target!=null)
        this.transform.LookAt(Target);
        
        yield return new WaitForSeconds(.025f);
    }
    
}

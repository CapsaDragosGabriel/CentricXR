using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationAggro : MonoBehaviour
{
    [SerializeField]
    private BoxCollider myCollider;

    public Transform Target;

    public float RotationAmount = 2f;
    public bool pause = true;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Rotate");
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject != this.gameObject)
        {
            pause = false;
            Target = collision.gameObject.GetComponent<Transform>();

        }
    }
    private void OnCollisionExit(Collision collision)
    {
        pause = false;
        Target = null;
    }
    private IEnumerator Rotate()
    {
        WaitForSeconds Wait=new WaitForSeconds(1f / 60) ;
        while (true)
        {
            if (!pause)
            {
                transform.Rotate(Vector3.up * RotationAmount);
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}

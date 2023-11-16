using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ObjectStats : MonoBehaviour
{
    // Start is called before the first frame update
   [SerializeField]private float maxLife = 100f,  life = 10f;
    private Animator mAnimator;
    public bool dead = false;


    public void setMaxLife(float value) { maxLife = value; }
    public void setLife(float value) {
        dead = false;
        life = value;
        healthbar.UpdateHealthBar(life, maxLife);
    }

    public float getLife() { return life ; }
    public float getMaxLife() { return maxLife; }

    [SerializeField] private Healthbar healthbar;
    void Start()
    {
        mAnimator = GetComponentInChildren<Animator>();

        healthbar = GetComponentInChildren<Healthbar>();
        StartCoroutine(DPS());
    }

    public void TakeDamage(GameObject dealer, float damage)
    {
        if (!dead)
        {
            life -= damage;
            healthbar.UpdateHealthBar(life, maxLife);
            if (life <= 0)
            {
                Debug.Log("ded");

                if (this.gameObject.CompareTag("Another"))
                {
                    TextMeshProUGUI enemyScore = GameObject.FindGameObjectWithTag("Main Score").GetComponent<TextMeshProUGUI>();
                    int myInt;
                    int.TryParse(enemyScore.text, out myInt);


                    enemyScore.text = (myInt + 1).ToString();
                    GameObject.FindGameObjectWithTag("GameController").GetComponent<RespawnScript>().CheckScore();
                }
                else
                {
                    TextMeshProUGUI enemyScore = GameObject.FindGameObjectWithTag("Another Score").GetComponent<TextMeshProUGUI>();
                    int myInt;
                    int.TryParse(enemyScore.text, out myInt);

                    enemyScore.text = (myInt + 1).ToString();
                    GameObject.FindGameObjectWithTag("GameController").GetComponent<RespawnScript>().CheckScore();

                }
                 dealer.GetComponent<Animator>().SetBool("Alert", false);

                dead = true;

                if (mAnimator != null)

                {
                    mAnimator.SetTrigger("Death");
                }

            }
        }
    }
    private IEnumerator DPS()
    {
        /* while (true)
         {
             TakeDamage(1);
             yield return new WaitForSeconds(1f);
         }*/
        yield return null;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}

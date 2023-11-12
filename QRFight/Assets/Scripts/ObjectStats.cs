using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ObjectStats : MonoBehaviour
{
    // Start is called before the first frame update
   [SerializeField]private float maxLife = 10f,  life = 10f;

    public void setMaxLife(float value) { maxLife = value; }
    public void setLife(float value) { life = value;
        healthbar.UpdateHealthBar(life, maxLife);
    }

    public float getLife() { return life ; }
    public float getMaxLife() { return maxLife; }

    [SerializeField] private Healthbar healthbar;
    void Start()
    {
        healthbar = GetComponentInChildren<Healthbar>();
        StartCoroutine(DPS());
    }

    public void TakeDamage( float damage)
    {
       life -= damage;
        healthbar.UpdateHealthBar(life, maxLife);
        if (life <= 0)
        {   Debug.Log("ded");
            if(this.gameObject.CompareTag("Another"))
            {
               TextMeshProUGUI enemyScore= GameObject.FindGameObjectWithTag("Main Score").GetComponent<TextMeshProUGUI>();
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
            this.gameObject.SetActive(false);
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

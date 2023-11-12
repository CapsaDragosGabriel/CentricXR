using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RespawnScript : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject playerOne;
    private GameObject playerTwo;
    [SerializeField]
    private GameObject winPrompt;
    [SerializeField] private GameObject popUp;
    // Start is called before the first frame update
    private void Start()
    {
        playerOne = GameObject.FindGameObjectWithTag("Main");
        playerTwo = GameObject.FindGameObjectWithTag("Another");
        winPrompt = GameObject.FindGameObjectWithTag("WinPrompt");
    }
    public void CheckScore()
    {
        TextMeshProUGUI scoreOne = GameObject.FindGameObjectWithTag("Main Score").GetComponent<TextMeshProUGUI>();
        TextMeshProUGUI scoreTwo = GameObject.FindGameObjectWithTag("Another Score").GetComponent<TextMeshProUGUI>();
        int iScoreOne;
        int.TryParse(scoreOne.text, out iScoreOne);

        int iScoreTwo;
        int.TryParse(scoreTwo.text, out iScoreTwo);


        if (iScoreOne==3||iScoreTwo==3)
        {
            popUp.SetActive(true);

            if (iScoreOne > iScoreTwo)
            {
                winPrompt.GetComponent<TextMeshProUGUI>().text = "P1 WINS!";

            }
            else if (iScoreOne<iScoreTwo)
            {
                winPrompt.GetComponent<TextMeshProUGUI>().text = "P2 WINS!";

            }
            else
            {
                winPrompt.GetComponent<TextMeshProUGUI>().text = "WE HAVE A DRAW!";
            }

        }



    }
    public void Restart()
    {

        ResetScore();
        ResetRound();
        popUp.SetActive(false);
    }
    public void ResetScore()
    {
        TextMeshProUGUI score = GameObject.FindGameObjectWithTag("Main Score").GetComponent<TextMeshProUGUI>();
        score.text = 0.ToString();

        score= GameObject.FindGameObjectWithTag("Another Score").GetComponent<TextMeshProUGUI>();
        score.text = 0.ToString();
    }

    public void ResetRound()
    {
        var maxLife = playerOne.GetComponent<ObjectStats>().getMaxLife();
        playerOne.GetComponent<ObjectStats>().setLife(maxLife);
        playerOne.SetActive(true);

         maxLife = playerTwo.GetComponent<ObjectStats>().getMaxLife();
        playerTwo.GetComponent<ObjectStats>().setLife(maxLife);
        playerTwo.SetActive(true);
    }
    public void RespawnPlayerOne()
    {
        if (playerOne.activeSelf==false)
        {

        var maxLife = playerOne.GetComponent<ObjectStats>().getMaxLife();
        playerOne.GetComponent<ObjectStats>().setLife(maxLife);
        playerOne.SetActive(true);
        }

    }
    public void RespawnPlayerTwo()
    {
        if (playerTwo.activeSelf == false)
        {
            var maxLife = playerTwo.GetComponent<ObjectStats>().getMaxLife();
            playerTwo.GetComponent<ObjectStats>().setLife(maxLife);
            playerTwo.SetActive(true);
        }
    }
}

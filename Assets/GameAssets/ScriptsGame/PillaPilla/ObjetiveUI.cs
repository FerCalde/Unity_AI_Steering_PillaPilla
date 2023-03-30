using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjetiveUI : MonoBehaviour
{
    Text m_scoreText;
    [TextArea] string objetivo = "Huye del enemigo";
    int m_playerScore;
    int m_aiScore;

    // Start is called before the first frame update
    void Start()
    {
        m_scoreText = GetComponent<Text>();
        ((GameManager)GameManager.Instance).OnAddPlayerScore += ObjetivoHuir;
        ((GameManager)GameManager.Instance).OnAddAIScore += ObjetivoPerseguir;
        //((GameManager)GameManager.Instance).OnResetScore += SetScore;

        SetScore();
    }


    void ObjetivoHuir()
    {
        objetivo = "Huye del enemigo";
        SetScore();
    }
    void ObjetivoPerseguir()
    {
        objetivo = "Persigue al enemigo";
        SetScore();
    }
    void SetScore()
    {
        m_playerScore = ((GameManager)GameManager.Instance).m_playerScore;
        m_aiScore = ((GameManager)GameManager.Instance).m_aiScore;

        m_scoreText.text = "Player " + m_playerScore + " - Enemy " + m_aiScore + "\n" + objetivo;
    }

}

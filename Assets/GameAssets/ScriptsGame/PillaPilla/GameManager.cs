using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    Transform playerPos, enemyPos;
    Vector3 playerStartPos, enemyStartPos;

    [HideInInspector] public int m_playerScore;
    [HideInInspector] public int m_aiScore;

    //Eventos
    public delegate void OnStart();
    public event OnStart OnResetEstados;
    public event OnStart OnAddPlayerScore;
    public event OnStart OnAddAIScore;
    public event OnStart OnResetScore;

    public static GameManager Instance
    {
        get;
        private set;
    }

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {        
        //Coge Referencias
        playerPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        enemyPos = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Transform>();
       
        //Guardo posiciones iniciales de Participantes
        playerStartPos = playerPos.position;
        enemyStartPos = enemyPos.position;
        
        //Coloco a los Participantes
        ResetPositions();
        
        //ResetScore(); Proxima implementacion
    }

    public void ResetPositions() //Pa que no haga el chicle
    {
        playerPos.position = playerStartPos;
        enemyPos.position = enemyStartPos;
    }

    void ResetEstados()
    {
        ResetPositions();
        OnResetEstados();
    }


    public void PlayerCazado()
    {
        m_aiScore++;
        OnAddAIScore();
        ResetEstados();
    }

    public void EnemigoCazado()
    {
        m_playerScore++;
        OnAddPlayerScore();
        ResetEstados();
    }

   /* public void ResetScore()
    {
        m_playerScore = 0;
        m_aiScore = 0;
        OnResetScore();
    }*/
}

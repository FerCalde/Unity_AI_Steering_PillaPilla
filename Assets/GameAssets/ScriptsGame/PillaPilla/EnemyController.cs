using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UI; ANTIGUA MANERA

namespace UnityMovementAI
{

    public class EnemyController : MonoBehaviour
    {
        //StateMachine
        enum EstadoEnemigo
        {
            PerseguirPlayer,
            EscaparPlayer
        }

        [SerializeField] EstadoEnemigo estadoActual;
        
        //Componentes Comportamiento
        PursueUnit cmpPursueUnit;
        FleeUnit cmpFleeUnit;

        //Feedback
        [SerializeField] Material[] materialsColor;
        
        //Variables de ANTIGUA MANERA
        //GameManager gm;
        //Text textObjetive;

        void Awake()
        {
            cmpPursueUnit = GetComponent<PursueUnit>();
            cmpFleeUnit = GetComponent<FleeUnit>();
            estadoActual = EstadoEnemigo.PerseguirPlayer;
        }

        void Start()
        {
            //Suscribe al evento que cambia estados
            ((GameManager)GameManager.Instance).OnResetEstados += SetearEstado; 
            
            //Chequeo Metodo 
            CheckEstado();

            //gm = GameObject.FindObjectOfType<GameManager>(); ANTIGUA MANERA
            //textObjetive = GameObject.FindObjectOfType<Text>(); ANTIGUA MANERA
        }

        void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {                
                if (estadoActual == EstadoEnemigo.PerseguirPlayer) //Se encuentra en estado Perseguir
                {
                    ((GameManager)GameManager.Instance).PlayerCazado(); //HE TOCADO AL PLAYER
                }
                else if (estadoActual == EstadoEnemigo.EscaparPlayer) //Se encuentra en estado Escapar
                {
                    ((GameManager)GameManager.Instance).EnemigoCazado(); //PLAYER ME HA TOCADO
                }                
            }
        }

        //Este metodo identifica el estado actual del enemigo y lo cambia por el turno contrario. Es invocado mediante el evento OnResetEstados que controla el GameManager
        void SetearEstado() 
        {
            if (estadoActual == EstadoEnemigo.PerseguirPlayer) //Se encuentra en estado Perseguir
            {
                //CambioEstado
                estadoActual = EstadoEnemigo.EscaparPlayer;
                CheckEstado();
            }
            else if (estadoActual == EstadoEnemigo.EscaparPlayer) //Se encuentra en estado Escapar
            {
                //CambioEstado
                estadoActual = EstadoEnemigo.PerseguirPlayer;
                CheckEstado();
            }
        }

        //Metodo que activa los componentes necesarios para hacer funcionar la IA
        void CheckEstado()
        {
            if (estadoActual == EstadoEnemigo.PerseguirPlayer) //Se encuentra en estado Perseguir
            {
                //Cambio
                //ComponentesNecesarios
                cmpPursueUnit.enabled = true;
                cmpFleeUnit.enabled = false;

                //Cambios Feedback
                GetComponent<MeshRenderer>().material = materialsColor[0];

                //textObjetive.text = "Escapa del Enemigo"; ANTIGUA MANERA
            }
            else if (estadoActual == EstadoEnemigo.EscaparPlayer)
            {
                //Cambio
                //ComponentesNecesarios
                cmpFleeUnit.enabled = true;
                cmpPursueUnit.enabled = false;
                //Cambio Color
                GetComponent<MeshRenderer>().material = materialsColor[1];
                
                //textObjetive.text = "Persigue Al Enemigo"; ANTIGUA MANERA
            }
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnColetavel : MonoBehaviour
{
   public Scripts scScripts;

   public List<GameObject> posicoes;
   public GameObject coletavel;
   public GameObject localColetavel;
   public GameObject instanceColetavel;
   public GameObject fixColetavel;

   private float count = 2f;

   public bool respawn;

   public bool waiting;

   public bool estaNaArea;



   // Start is called before the first frame update
   void Start()
   {
      respawn = true;
      int randomPosicao = Random.Range(0, 11);
      instanceColetavel = Instantiate(coletavel, posicoes[randomPosicao].transform.position, Quaternion.identity);
      instanceColetavel.transform.position = localColetavel.transform.position;
   }

   // Update is called once per frame
   void Update()
   {
      if ((!scScripts.scGerenciar.scColetorTM1.estaNaBase && !scScripts.scGerenciar.scColetorTM2.estaNaBase) && (!scScripts.scGerenciar.scAtacanteTM1 && !scScripts.scGerenciar.scAtacanteTM2.estaNaBase))
      {
         waiting = true;
      }
      else
      {
         waiting = false;
      }

      if (respawn && !waiting)
      {
         count -= Time.deltaTime;

         if (count <= 0)
         {
            StartCoroutine(respawnColetavel());
         }
      }
      else
      {
         StopCoroutine(respawnColetavel());

      }




   }

   public IEnumerator respawnColetavel()
   {
      respawn = false;

      yield return new WaitForSeconds(1);

      int randomPosicao = Random.Range(0, 11);
      instanceColetavel.transform.position = posicoes[randomPosicao].transform.position;
      instanceColetavel.transform.SetParent(fixColetavel.transform);
      yield return new WaitForSeconds(1);

      
         if (scScripts.scGerenciar.scColetorTM1.alvo != scScripts.scGerenciar.scColetorTM1.portao)
         {
            scScripts.scGerenciar.scColetorTM1.alvo = scScripts.scGerenciar.scColetorTM1.portao.gameObject;
         }
         if (scScripts.scGerenciar.scColetorTM2.alvo != scScripts.scGerenciar.scColetorTM2.portao)
         {
            scScripts.scGerenciar.scColetorTM2.alvo = scScripts.scGerenciar.scColetorTM2.portao.gameObject;
         }


         StopCoroutine(respawnColetavel());
      
     


      count = 2f;
   }

}

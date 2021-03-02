using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HUD : MonoBehaviour
{
   public Scripts scScripts;

   public int pontosTM1 = 0;
   public int pontosTM2 = 0;
   public float timer = 100;
   private float countTimer = 1;

   public Text textPontosTM1;
   public Text textTimer;
   public Text textPontosTM2;
   public Text textWinner;

   private void Start()
   {
      textWinner.enabled = false;
   }

   // Update is called once per frame
   void Update()
   {
      atualizarHUD();

      if (timer > 0)
      {
         cronometro();
      }
   }

   void atualizarHUD()
   {
      textTimer.text = timer + "";
      textPontosTM1.text = pontosTM1 + "";
      textPontosTM2.text = pontosTM2 + "";
   }
   void cronometro()
   {
      countTimer -= Time.deltaTime;

      if (countTimer < 0)
      {
         timer--;
         countTimer = 1;
      }
      if (timer <= 0)
      {
         StartCoroutine(finish());
      }
   }


   IEnumerator finish()
   {

      if (pontosTM1 > pontosTM2)
      {
         textWinner.text = "Time Roxo Venceu";
         textWinner.color = textPontosTM1.color;
      }
      else if (pontosTM2 > pontosTM1)
      {
         textWinner.text = "Time Laranja Venceu";
         textWinner.color = textPontosTM2.color;
      }
      else
      {
         textWinner.text = "Empate";
      }
      textWinner.enabled = true;
      yield return new WaitForSeconds(2);
      SceneManager.LoadScene("SampleScene");
   }
}

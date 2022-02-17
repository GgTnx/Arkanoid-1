using TMPro;
using UnityEngine;

public class HUD : MonoBehaviour
{
   #region Variables

   public TextMeshProUGUI ScoreLable;

   #endregion

   #region Unity lifecycle

   private void Update()
   {
      ScoreLable.text = $"Score:{GameManager.Instanse.Score}";
   }

   #endregion
   
}

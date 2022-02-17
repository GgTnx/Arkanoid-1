using UnityEngine;

public class AudioManager : SingletoneMonobehaveor<AudioManager>
{
   #region Veriables

    public AudioSource Source;

   #endregion
   
   #region Public Methods

   public void PlayOnShot(AudioClip clip)
   {
       Source.PlayOneShot(clip);
   }

   #endregion

}

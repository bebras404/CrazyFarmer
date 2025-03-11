using UnityEngine;
using UnityEngine.UI;

public class SoundScript : MonoBehaviour
{
    




    public void MuteToggle(bool muted)
    {
        if (muted)
        {
            AudioListener.volume = 0;
        }
        else if(!muted)
        {
            AudioListener.volume = 1;
        }
        else
        {
            AudioListener.volume = 1;
        }




    }

}

using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField]
    private AudioSource menuBGScoreSource;
    [SerializeField]
    private AudioSource buttonClickSource;
    [SerializeField]
    private AudioSource playerJumpSource;
    [SerializeField]
    private AudioSource playerDeathSource;

    private AudioClip menuBGScoreClip;
    private AudioClip buttonClickClip;
    private AudioClip playerJumpClip;
    private AudioClip playerDeathClip;
    public static AudioManager instance {get ; private set;}

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void MakeJumpSound()
    {
        if(playerJumpSource != null && playerJumpClip != null) {
            playerJumpSource.PlayOneShot(playerJumpClip);
        }
    }
    
}

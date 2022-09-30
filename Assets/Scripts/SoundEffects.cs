using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundEffects : MonoBehaviour
{
    [SerializeField] private AudioClip cardClick;
    [SerializeField] private AudioClip cardKill;
    [SerializeField] private AudioClip gameWin;
    [SerializeField] private AudioClip gameLose;

    private AudioSource _source;

    private void Awake()
    {
        _source = GetComponent<AudioSource>();
    }

    public void ClickEffectPlay() 
    {
        _source.PlayOneShot(cardClick);
    }

    public void KillEffectPlay()
    {
        _source.PlayOneShot(cardKill);
    }

    public void GameEndEffect(bool win)
    {
        if(win)
            _source.PlayOneShot(gameWin);
        else
            _source.PlayOneShot(gameLose);
    }


}

using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [Header("Events")]
    [SerializeField] private AudioObject_SO coughSound;
    
    [SerializeField] private AudioObject_SO ecoloVictorySound;
    [SerializeField] private AudioObject_SO polluterVictorySound;
    [SerializeField] private AudioObject_SO ticTacSound;


    [Header("Abilities")]
    [SerializeField] private AudioObject_SO fireSound;
    [SerializeField] private AudioObject_SO funnelSound;
    [SerializeField] private AudioObject_SO forestSound;
    [SerializeField] private AudioObject_SO monsoonSound;
    [SerializeField] private AudioObject_SO factorySound;
    [SerializeField] private AudioObject_SO livestockSound;
    [SerializeField] private AudioObject_SO farmSound;
    
    [SerializeField] private AudioObject_SO rainSound;


    [SerializeField] private GameObject soundPrefab;


    public void PlayFireSound()
    {
        AudioObject audio = Instantiate(soundPrefab, this.transform.position, Quaternion.identity).GetComponent<AudioObject>();
        audio.PlaySound(fireSound);
    }

    public void PlayFunnelSound()
    {
        AudioObject audio = Instantiate(soundPrefab, this.transform.position, Quaternion.identity).GetComponent<AudioObject>();
        audio.PlaySound(funnelSound);
    }

    public void PlayForestSound()
    {
        AudioObject audio = Instantiate(soundPrefab, this.transform.position, Quaternion.identity).GetComponent<AudioObject>();
        audio.PlaySound(forestSound);
    }

    public void PlayMonsoonSound()
    {
        AudioObject audio = Instantiate(soundPrefab, this.transform.position, Quaternion.identity).GetComponent<AudioObject>();
        audio.PlaySound(monsoonSound);
    }

    public void PlayFactorySound()
    {
        AudioObject audio = Instantiate(soundPrefab, this.transform.position, Quaternion.identity).GetComponent<AudioObject>();
        audio.PlaySound(factorySound);
    }

    public void PlayLivestockSound()
    {
        AudioObject audio = Instantiate(soundPrefab, this.transform.position, Quaternion.identity).GetComponent<AudioObject>();
        audio.PlaySound(livestockSound);
    }

    public void PlayFarmSound()
    {
        AudioObject audio = Instantiate(soundPrefab, this.transform.position, Quaternion.identity).GetComponent<AudioObject>();
        audio.PlaySound(farmSound);
    }

    public void PlayCoughSound()
    {
        AudioObject audio = Instantiate(soundPrefab, this.transform.position, Quaternion.identity).GetComponent<AudioObject>();
        audio.PlaySound(coughSound);
    }

    public void PlayRainSound()
    {
        AudioObject audio = Instantiate(soundPrefab, this.transform.position, Quaternion.identity).GetComponent<AudioObject>();
        audio.PlaySound(rainSound);
    }

    public void PlayPolluterVictorySound()
    {
        AudioObject audio = Instantiate(soundPrefab, this.transform.position, Quaternion.identity).GetComponent<AudioObject>();
        audio.PlaySound(polluterVictorySound);
    }

    public void PlayEcoloVictorySound()
    {
        AudioObject audio = Instantiate(soundPrefab, this.transform.position, Quaternion.identity).GetComponent<AudioObject>();
        audio.PlaySound(ecoloVictorySound);
    }

    public void PlayTicTacSound()
    {
        AudioObject audio = Instantiate(soundPrefab, this.transform.position, Quaternion.identity).GetComponent<AudioObject>();
        audio.PlaySound(ticTacSound);
    }
}

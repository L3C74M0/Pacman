using UnityEngine;
using UnityEngine.Audio;

public class PelletAudio : MonoBehaviour {
    public AudioSource normal;
    public AudioSource power;

    public void PelletSound(Pellet pellet) {
        normal.Play();
    }

    public void PowerSound(PowerPellet powerPellet) {
        power.Play();
    }    
}

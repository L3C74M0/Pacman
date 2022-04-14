using UnityEngine;
using UnityEngine.Audio;
using System.Threading.Tasks;

public class GeneralAudio : MonoBehaviour {
    public AudioSource beginning;
    public AudioSource other;

    public void Start() {
        beginning.Play();
        Other();
    }

    protected async void Other() {
        await Task.Delay(4000);
        other.Play();
    }

    public void Stop() {
        other.Pause();
    }
}

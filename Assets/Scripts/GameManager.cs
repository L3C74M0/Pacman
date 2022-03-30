using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
    public Ghost[] ghosts; 
    public Pacman pacman;
    public Transform pellets;
    
    public int score { get; private set; }

    public int lives { get; private set; }

    private void Start() {
        NewGame();
    }

    private void Update() {
        if (this.lives <=0 && Input.anyKey) {
            NewGame();
        }
    }

    private void NewGame() {
        SetScore(0);
        SetLives(3);
        NewRound();
    }

    private async void NewRound(){
        foreach (Transform pellet in pellets) {
            pellet.gameObject.SetActive(true);
        }

        ResetState();
    }

    private void ResetState(){
        for( int i = 0 ; i < ghosts.Length; i++) {
            ghosts[i].gameObject.SetActive(true);
        }

        pacman.gameObject.SetActive(true);
    }

    private void GameOver() {
        for( int i = 0 ; i < this.ghosts.Length; i++) {
            this.ghosts[i].gameObject.SetActive(false);
        }

        this.pacman.gameObject.SetActive(true);
    }


    private void SetScore (int score) {
        this.score = score;
    }

    private void SetLives (int lives) {
        this.lives = lives;
    }

    public void GhostEaten (Ghost ghost) {
        SetScore(this.score + ghost.points);
    }

    public void PacmanEaten () {
        this.pacman.gameObject.SetActive(false);

        SetLives(this.lives--);

        if(this.lives > 0){
            Invoke(nameof(ResetState), 3.0f);
        } else {
            GameOver();
        }
    }
}

using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
    public Ghost[] ghosts; 
    public Pacman pacman;
    public Transform pellets;

    public int ghostMultiplayer { get; private set; } = 1;
    
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
        foreach (Transform pellet in this.pellets) {
            pellet.gameObject.SetActive(true);
        }

        ResetState();
    }
         
    private void ResetState(){

        ResetGhostMultiplayer();

        for( int i = 0 ; i < this.ghosts.Length; i++) {
            this.ghosts[i].ResetState();
        }

        this.pacman.ResetState(); 
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

    public void GhostEaten(Ghost ghost) {
        int points = ghost.points * this.ghostMultiplayer;
        SetScore(this.score + points);
        SetScore(this.score + ghost.points);
    }

    public void PacmanEaten () {
        this.pacman.gameObject.SetActive(false);

        SetLives(this.lives-1);

        if(this.lives > 0){
            Invoke(nameof(ResetState), 3.0f);
        } else {
            GameOver();
        }

    }

    public void PelletEaten(Pellet pellet)    {
        pellet.gameObject.SetActive(false);

        SetScore(this.score + pellet.points);

        if (!HasRemainingPellets())
        {
            this.pacman.gameObject.SetActive(false);
            Invoke(nameof(NewRound), 3.0f);
        }
    }
    public void PowerPelletEaten (PowerPellet pellet)
    {


        // TODO: changing ghost state        
        PelletEaten(pellet);
        CancelInvoke();
        Invoke(nameof(ResetGhostMultiplayer), pellet.duration);
    }

    private bool HasRemainingPellets()    {
        foreach (Transform pellet in this.pellets)
        {
            if (pellet.gameObject.activeSelf)
            {
                return true;
            }
            
        }
        return false;
    }

    private void ResetGhostMultiplayer()
    {
        this.ghostMultiplayer = 1;
    }
}

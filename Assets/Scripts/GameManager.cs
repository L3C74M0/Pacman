using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameManager : MonoBehaviour {
    public Ghost[] ghosts; 
    public Pacman pacman;
    public Transform pellets;

    public int ghostMultiplayer { get; private set; } = 1;
    
    public int score { get; private set; }
    public int highScore { get; private set; }
    public int lives { get; private set; }

    public Text currentScore;
    public Text highScoreText;

    protected ArrayList highScores;
    public HighScores high;
    public const string pathData = "SaveGames";
    public const string nameFile = "HighScores";

    private void Start() {
        NewGame();
    }

    private void Update() {
        if (this.lives <=0 && Input.anyKey) {
            NewGame();
        }
        currentScore.text = "" + score;
    }

    private void NewGame() {
        var dataFound = LoadAndSaveData.LoadData<HighScores>(pathData,nameFile);
        if (dataFound != null) {
            high = dataFound;
            highScores = new ArrayList();
            highScores.Add(high.top1);
            highScores.Add(high.top2);
            highScores.Add(high.top3);
            highScores.Add(high.top4);
            highScores.Add(high.top5);
            highScores.Add(high.top6);
            highScores.Add(high.top7);
            highScores.Add(high.top8);
            highScores.Add(high.top9);
            highScores.Add(high.top10);
            updateHighScore();
        } else {
            high = new HighScores();
            saveScores();
        }

        SetScore(0);
        SetLives(3);
        NewRound();
    }

    private void updateHighScore() {
        highScoreText.text = "HIGH SCORE\n" + high.top1;
    }

    private async void NewRound(){
        foreach (Transform pellet in this.pellets) {
            pellet.gameObject.SetActive(true);
        }

        ResetState();
    }
         
    private void ResetState() {
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

        FindObjectOfType<GeneralAudio>().Stop();
        saveScores();
        SceneManager.LoadScene("MainMenu");
    }

    protected void saveScores() {
        if (score > (int) highScores[0]) {
            highScores[9] = highScores[8];
            highScores[8] = highScores[7];
            highScores[7] = highScores[6];
            highScores[6] = highScores[5];
            highScores[5] = highScores[4];
            highScores[4] = highScores[3];
            highScores[3] = highScores[2];
            highScores[2] = highScores[1];
            highScores[1] = highScores[0];
            highScores[0] = score;
            Debug.LogError("Se guarda " + score + "En la posicion " + 0);
        } else if (score > (int) highScores[1]) {
            highScores[9] = highScores[8];
            highScores[8] = highScores[7];
            highScores[7] = highScores[6];
            highScores[6] = highScores[5];
            highScores[5] = highScores[4];
            highScores[4] = highScores[3];
            highScores[3] = highScores[2];
            highScores[2] = highScores[1];
            highScores[1] = score;
            Debug.LogError("Se guarda " + score + "En la posicion " + 1);
        } else if (score > (int) highScores[2]) {
            highScores[9] = highScores[8];
            highScores[8] = highScores[7];
            highScores[7] = highScores[6];
            highScores[6] = highScores[5];
            highScores[5] = highScores[4];
            highScores[4] = highScores[3];
            highScores[3] = highScores[2];
            highScores[2] = score;
            Debug.LogError("Se guarda " + score + "En la posicion " + 2);
        } else if (score > (int) highScores[3]) {
            highScores[9] = highScores[8];
            highScores[8] = highScores[7];
            highScores[7] = highScores[6];
            highScores[6] = highScores[5];
            highScores[5] = highScores[4];
            highScores[4] = highScores[3];
            highScores[3] = score;
            Debug.LogError("Se guarda " + score + "En la posicion " + 3);
        } else if (score > (int) highScores[4]) {
            highScores[9] = highScores[8];
            highScores[8] = highScores[7];
            highScores[7] = highScores[6];
            highScores[6] = highScores[5];
            highScores[5] = highScores[4];
            highScores[4] = score;
            Debug.LogError("Se guarda " + score + "En la posicion " + 4);
        } else if (score > (int) highScores[5]) {
            highScores[9] = highScores[8];
            highScores[8] = highScores[7];
            highScores[7] = highScores[6];
            highScores[6] = highScores[5];
            highScores[5] = score;
            Debug.LogError("Se guarda " + score + "En la posicion " + 5);
        } else if (score > (int) highScores[6]) {
            highScores[9] = highScores[8];
            highScores[8] = highScores[7];
            highScores[7] = highScores[6];
            highScores[6] = score;
            Debug.LogError("Se guarda " + score + "En la posicion " + 6);
        } else if (score > (int) highScores[7]) {
            highScores[9] = highScores[8];
            highScores[8] = highScores[7];
            highScores[7] = score;
            Debug.LogError("Se guarda " + score + "En la posicion " + 7);
        } else if (score > (int) highScores[8]) {
            highScores[9] = highScores[8];
            highScores[8] = score;
            Debug.LogError("Se guarda " + score + "En la posicion " + 8);
        } else if (score > (int) highScores[9]) {
            highScores[9] = score;
            Debug.LogError("Se guarda " + score + "En la posicion " + 9);
        } else {
            Debug.LogError("NO Se guarda ");
        }

        high.top1 = (int) highScores[0];
        high.top2 = (int) highScores[1];
        high.top3 = (int) highScores[2];
        high.top4 = (int) highScores[3];
        high.top5 = (int) highScores[4];
        high.top6 = (int) highScores[5];
        high.top7 = (int) highScores[6];
        high.top8 = (int) highScores[7];
        high.top9 = (int) highScores[8];
        high.top10 = (int) highScores[9];

        Debug.LogError("0 " + high.top1);
        Debug.LogError("1 " + high.top2);
        Debug.LogError("2 " + high.top3);
        Debug.LogError("3 " + high.top4);
        Debug.LogError("4 " + high.top5);
        Debug.LogError("5 " + high.top6);
        Debug.LogError("6 " + high.top7);
        Debug.LogError("7 " + high.top8);
        Debug.LogError("8 " + high.top9);
        Debug.LogError("9 " + high.top10);

        LoadAndSaveData.SaveData(high, pathData, nameFile);
    }


    private void SetScore (int score) {
        this.score = score;
    }

    public int GetScore() {
        return this.score;
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

        if (!HasRemainingPellets()) {
            this.pacman.gameObject.SetActive(false);
            Invoke(nameof(NewRound), 3.0f);
        }
    }

    public void PowerPelletEaten (PowerPellet pellet) {
        for(int i=0; i<this.ghosts.Length; i++) {
            this.ghosts[i].frightened.Enable(pellet.duration);
        }

        // TODO: changing ghost state        
        PelletEaten(pellet);
        CancelInvoke();
        Invoke(nameof(ResetGhostMultiplayer), pellet.duration);
    }

    private bool HasRemainingPellets()    {
        foreach (Transform pellet in this.pellets) {
            if (pellet.gameObject.activeSelf) {
                return true;
            }
        }
        return false;
    }

    private void ResetGhostMultiplayer() {
        this.ghostMultiplayer = 1;
    }
}

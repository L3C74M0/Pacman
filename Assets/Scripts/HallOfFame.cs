using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HallOfFame : MonoBehaviour {
    public Text scores;
    public Text nicks;
    public const string pathData = "SaveGames";
    public const string nameFile = "HighScores";
    public HighScores high;
    protected ArrayList highScores;
    protected ArrayList names;

    private void Start() {
        updateScores();
    }

    public void updateScores() {
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

            names = new ArrayList();
            names.Add(high.str1);
            names.Add(high.str2);
            names.Add(high.str3);
            names.Add(high.str4);
            names.Add(high.str5);
            names.Add(high.str6);
            names.Add(high.str7);
            names.Add(high.str8);
            names.Add(high.str9);
            names.Add(high.str10);

            nicks.text = "";
            scores.text = "";
            for (int i = 0; i < highScores.Count; i++) {
                scores.text += "" + (int) highScores[i] + "\n";
                nicks.text += "" + (string) names[i] + "\n";
            }
        }
    }
}

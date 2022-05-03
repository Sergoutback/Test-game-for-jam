using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int totalKilled = 0;
    private int totalStunned = 0;

    public void UpKill() {
        totalKilled++;
    }

    public void UpStun() {
        totalStunned++;
    }

    public int getStunned() {
        return totalStunned;
    }

    public int getKilled() {
        return totalKilled;
    }

    public void saveKills() {
        PlayerPrefs.SetInt("totalKills", totalKilled);
    }

    public void saveStuns() {
        PlayerPrefs.SetInt("totalStuns", totalStunned);
    }

    public int loadKills() {
        return PlayerPrefs.GetInt("totalKills");
    }

    public int loadStuns() {
        return PlayerPrefs.GetInt("totalStuns");
    }

}

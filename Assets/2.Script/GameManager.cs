using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header ("#GameObject")]
    public GameObject menuCam;
    public GameObject gameCam;
    public Player player;
    public Boss boss;
    public int stage;
    public float playTime;
    public bool isBattle;
    public int enemyCntA;
    public int enemyCntB;
    public int enemyCntC;

    [Header ("#UI")]
    public GameObject menuPanel;
    public GameObject gamePanel;
    public Text maxScoreText;

    [Header ("#InGameUI")]
    public Text scoreText;
    public Text stageText;
    public Text playTimeText;
    public Text playerHealthText;
    public Text playerAmmoText;
    public Text playerCoinText;
    public Image weapon1Image;
    public Image weapon2Image;
    public Image weapon3Image;
    public Image weaponRImage;
    public Text enemyAText;
    public Text enemyBText;
    public Text enemyCText;
    public RectTransform bossHealthGroup;
    public RectTransform bossHealthBar;

    private void Awake()
    {
        maxScoreText.text = string.Format("{0:n0}", PlayerPrefs.GetInt("MaxScore"));
    }

    public void GameStart()
    {
        menuCam.SetActive(false);
        gameCam.SetActive(true);

        menuPanel.SetActive(false);
        gamePanel.SetActive(true);

        player.gameObject.SetActive(true);
    }

    private void Update()
    {
        if(isBattle)
        {
            playTime += Time.deltaTime;
        }
    }

    private void LateUpdate()
    {
        scoreText.text = string.Format("{0:n0}", player.score);
        stageText.text = "STAGE " + stage;

        int hour = (int)(playTime / 3600);
        int min = (int)(playTime - hour * 3600 / 60);
        int second = (int)(playTime % 60);
        playTimeText.text = string.Format("{0:00}", hour) + ":" + string.Format("{0:00}", min) + ":" + string.Format("{0:00}", second);

        playerHealthText.text = player.health + " / " + player.maxHealth;
        playerCoinText.text = string.Format("{0:n0}", player.coin);
        if(player.equipWeapon == null)
        {
            playerAmmoText.text = "- / " + player.ammo;
        }
        else if(player.equipWeapon.type == Weapon.Type.Melee)
        {
            playerAmmoText.text = "- / " + player.ammo;
        }
        else
        {
            playerAmmoText.text = player.equipWeapon.curAmmo + " / " + player.ammo;
        }

        weapon1Image.color = new Color(1, 1, 1, player.hasWeapons[0] ? 1 : 0);
        weapon2Image.color = new Color(1, 1, 1, player.hasWeapons[1] ? 1 : 0);
        weapon3Image.color = new Color(1, 1, 1, player.hasWeapons[2] ? 1 : 0);
        weaponRImage.color = new Color(1, 1, 1, player.hasGrenades > 0 ? 1 : 0);

        enemyAText.text = enemyCntA.ToString();
        enemyBText.text = enemyCntB.ToString();
        enemyCText.text = enemyCntC.ToString();

        bossHealthBar.localScale = new Vector3((float)boss.curHealth / boss.maxHealth, 1, 1);
    }
}

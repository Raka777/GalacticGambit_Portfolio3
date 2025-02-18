using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;
using UnityEngine.TextCore.Text;

    
public class gamemanager : MonoBehaviour
    {
        public static gamemanager instance;

        [Header("--- Player Components ---")]
        public GameObject player;
        public playerController playerScript;
        public GameObject playerSpawnPos;
        public List<gun> gunList;
        [SerializeField] int experienceToNextLevel;
        public topDownPlayerController topDownPlayerController;

        //[Header("--- UI Components ---")]
        public List<Image> inventoryItems;
        public interactionMenu interactionMenu;
        //public List<Image> abilitySlots;
        //public Item coin;
        public GameObject activeMenu;
        //public Image playerHPBar;
        //public Image playerStaminaBar;
        //[SerializeField] Image levelBar;
        [SerializeField] GameObject pauseMenu;
        [SerializeField] GameObject fullMainMenu;
        //public GameObject loseMenu;
        [SerializeField] GameObject storeMenu;
        [SerializeField] GameObject mainMenu;
        //[SerializeField] GameObject playerDamageFlash;
        //public TMP_Text stanimaText;
        //public TMP_Text experienceText;
        //public TMP_Text healthPointsText;

        [Header("--- Store Components ---")]
        public List<Item> storeItems;
        public List<GameObject> storeCards;
        [SerializeField] List<Item> possibleItems;

        [Header("--- Enemy Components ---")]
        [SerializeField] int enemiesRemain;



        //Variable definitions:
        public bool isPaused;
        bool pickup;
        private int experience;
        private int level;
        private bool characterSelected;
        //
        //
        //
        void Awake()
        {
            instance = this;
            player = GameObject.FindGameObjectWithTag("Player");
            //playerScript = player.GetComponent<playerController>();
            playerSpawnPos = GameObject.FindGameObjectWithTag("Player Spawn Pos");
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
        }


        public void toggleInteractionMenu(bool state)
        {
            if (state) {
                interactionMenu.gameObject.SetActive(state);
            }
            else
            {
                interactionMenu.gameObject.SetActive(state);
            }
        }

        public void updateInteractionMenu(string value)
        {
            interactionMenu.updateInteractionText(value);
        }

        public void togglePlayerMovement(bool state)
        {
        Debug.Log("Toggle movement");
            playerScript.toggleMovement(state);
        }
        //    private void Start()
        //    {
        //        addExperience(0);
        //
        //    }
        //
        void Update()
        {
            if (!characterSelected)
            {
                toggleFullMainMenu(true);
                characterSelected = true;
            }
            if (Input.GetButtonDown("Cancel") && activeMenu == null)
               {
                   statePause();
                   activeMenu = pauseMenu;
                   activeMenu.SetActive(isPaused);
               }
        }
           //Enter pause state
           public void statePause()
           {
               Time.timeScale = 0;
               Cursor.visible = true;
               Cursor.lockState = CursorLockMode.Confined;
               isPaused = !isPaused;
           }
           //Exit pause state
           public void stateUnpause()
           {
               Time.timeScale = 1;
               Cursor.visible = false;
               Cursor.lockState = CursorLockMode.Locked;
               isPaused = !isPaused;
               activeMenu.SetActive(isPaused);
               activeMenu = null;
           }
            //Toggle store menu and pause/unpause game.
            public void toggleStore(bool state)
            {
                if (state)
                {
                    storeMenu.SetActive(state);
                    activeMenu = storeMenu;
                    statePause();
        
                }
                else
                {
                    stateUnpause();
                }
            }

        public void toggleFullMainMenu(bool state)
        {
            if (state)
            {
                activeMenu = fullMainMenu;
                fullMainMenu.SetActive(state);
                statePause();

            }
            else
            {
                stateUnpause();
            }
    
        }
    //    //Toggle character selection menu on start, unpause game once false
    //    public void toggleCharacterSection(bool state)
    //    {
    //        if (state)
    //        {
    //            characterSelectionMenu.SetActive(state);
    //            fullMainMenu.SetActive(state);
    //            activeMenu = characterSelectionMenu;
    //            statePause();
    //        }
    //        else
    //        {
    //            stateUnpause();
    //            activeMenu = fullMainMenu;
    //            toggleFullMainMenu(false);
    //        }
    //    }
    //    //Deactivate main menu gameobject entirely.
    //    public void toggleFullMainMenu(bool state)
    //    {
    //        if (state)
    //        {
    //            activeMenu = fullMainMenu;
    //            fullMainMenu.SetActive(state);
    //            statePause();
    //
    //        }
    //        else
    //        {
    //            stateUnpause();
    //        }
    //
    //    }
    //Toggle main menu screen once character game is playing.
    public void toggleMainMenu(bool state)
           {
               if (state)
               {
                   mainMenu.SetActive(state);
                   activeMenu = mainMenu;
                   statePause();
               }
               else
               {
                   stateUnpause();
               }
           }
        //
        //    IEnumerator youWinMenu()
        //    {
        //        yield return new WaitForSeconds(1);
        //        statePause();
        //        activeMenu = winMenu;
        //        activeMenu.SetActive(isPaused);
        //    }
        //    public IEnumerator playerFlashDamage()
        //    {
        //        playerDamageFlash.SetActive(true);
        //        yield return new WaitForSeconds(.05f);
        //        playerDamageFlash.SetActive(false);
        //    }
        //    public void youLoseMenu()
        //    {
        //        activeMenu = loseMenu;
        //        statePause();
        //        activeMenu.SetActive(isPaused);
        //    }
        //    public void updateGameGoal(int amount)
        //    {
        //        enemiesRemain += amount;
        //
        //        //if (enemiesRemain <= 0)
        //        //{
        //        //    StartCoroutine(youWinMenu());
        //        //}
        //    }
        //    public void updateStoreMenu()
        //    {
        //        storeCards[0].SetActive(true);
        //        storeCards[1].SetActive(true);
        //        storeCards[2].SetActive(true);
        //        for (int j = 0; j < storeItems.Count; j++)
        //        {
        //            int random = Random.Range(0, possibleItems.Count);
        //            storeItems[j] = possibleItems[random];
        //        }
        //
        //        int i = 0;
        //        foreach (Item item in storeItems)
        //        {
        //            if (item != null)
        //            {
        //                storeCard card = storeCards[i].GetComponent<storeCard>();
        //                card.title.text = item.itemName;
        //                card.description.text = item.description;
        //                //card.price.text = item.price.ToString();
        //                card.sprite.sprite = item.sprite;
        //            }
        //            i++;
        //        }
        //    }
        //    public void addExperience(int amount)
        //    {
        //        experience += amount;
        //        levelBar.fillAmount = (float)experience / experienceToNextLevel;
        //        experienceText.text = experience.ToString() + " / " + experienceToNextLevel.ToString();
        //        if (experience >= experienceToNextLevel)
        //        {
        //            level++;
        //            experienceToNextLevel = (int)(experienceToNextLevel * 1.3);
        //            levelUp();
        //            experienceText.text = 0.ToString() + " / " + experienceToNextLevel.ToString();
        //        }
        //    }
        //    public void levelUp()
        //    {
        //        updateStoreMenu();
        //        toggleStore(true);
        //        experience = 0;
        //        levelBar.fillAmount = 0;
        //        playerScript.healthPoints = playerScript.startHealth;
        //        playerScript.updatePlayerUI();
        //    }
        //}
}

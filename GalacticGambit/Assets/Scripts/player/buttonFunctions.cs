using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class buttonFunctionc : MonoBehaviour
{
   // public void resume()
   // {
   //     gamemanager.instance.stateUnpause();
   // }
   // public void restart()
   // {
   //     SceneManager.LoadScene(SceneManager.GetActiveScene().name);
   //     gamemanager.instance.stateUnpause();
   // }
   //
   // public void quit()
   // {
   //     Application.Quit();
   // }
   //
   // public void givePlayerHealthPoints(int amount)
   // {
   //     gamemanager.instance.playerScript.giveHealthPoints(amount);
   // }
   //
   // public void respawn()
   // {
   //     gamemanager.instance.stateUnpause();
   //     gamemanager.instance.playerScript.spawnPlayer();
   // }
   // public void purchase(int card)
   // {
   //     playerInventory inventory = gamemanager.instance.player.GetComponent<playerInventory>();
   //     if (inventory != null)
   //     {
   //         inventory.addItem(gamemanager.instance.storeItems[card], 1);
   //         inventory.removeItem(gamemanager.instance.coin, 5);
   //         gamemanager.instance.storeCards[card].SetActive(false);
   //
   //         //Update stats
   //         gamemanager.instance.playerScript.addPlayerDamage(gamemanager.instance.storeItems[card].damage);
   //         gamemanager.instance.playerScript.addPlayerSeed(gamemanager.instance.storeItems[card].speed);
   //         gamemanager.instance.playerScript.addPlayerJumps(gamemanager.instance.storeItems[card].jumps);
   //         gamemanager.instance.playerScript.addPlayerHealth(gamemanager.instance.storeItems[card].health);
   //         gamemanager.instance.playerScript.addShootRate(gamemanager.instance.storeItems[card].attackSpeed);
   //         gamemanager.instance.playerScript.addPlayerLifesteal(gamemanager.instance.storeItems[card].lifeSteal);
   //         gamemanager.instance.playerScript.addPlayerShootDistance(gamemanager.instance.storeItems[card].shootDistance);
   //         gamemanager.instance.toggleStore(false);
   //     }
   // }
   // public void selectCharacter(int character)
   // {
   //     gamemanager.instance.playerScript.setPlayerHealth(gamemanager.instance.characterList[character].healthPoints);
   //     gamemanager.instance.playerScript.setPlayerSpeed(gamemanager.instance.characterList[character].playerSpeed);
   //     gamemanager.instance.playerScript.setPlayerJumps(gamemanager.instance.characterList[character].jumpsMax);
   //
   //     gamemanager.instance.playerScript.setGunModel(gamemanager.instance.characterList[character].gunPrefab);
   //     gamemanager.instance.toggleCharacterSection(false);
   //     gamemanager.instance.playerScript.amEnabled = true;
   // }
   // public void startGame()
   // {
   //     gamemanager.instance.toggleMainMenu(false);
   //     gamemanager.instance.toggleCharacterSection(true);
   // }
}

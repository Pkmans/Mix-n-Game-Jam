using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class characterManager : MonoBehaviour
{
    public bool rifleWeapon;
    public bool shotgunWeapon;
    public bool rocketWeapon;

    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);

    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        if (player)
            player.GetComponent<weaponChooser>().chooseWeapon(rifleWeapon, shotgunWeapon, rocketWeapon);
    }

    
}

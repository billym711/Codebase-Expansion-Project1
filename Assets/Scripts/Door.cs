using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public keyType type;
    public Player player;
    public KeyUI keyUI;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            player = collision.gameObject.GetComponent<Player>();
            if (player.commonKeysAmount > 0 && type == keyType.COMMON)
            {
                Destroy(this.transform.parent.gameObject);

                player.commonKeysAmount -= 1;
                player.keyUI.ShowKeysAmount();
            }
            if (type == keyType.BOSS)
            {
                keyUI.HideBossKey();
            }
        }


                    return;
                }            
            }

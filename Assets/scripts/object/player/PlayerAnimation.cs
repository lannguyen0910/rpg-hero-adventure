using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    Animation anim;
    PlayerStatus status;

    int[] stateSpeedX = new int[8] { 0, -1, -1, -1, 0, 1, 1, 1 };
    int[] stateSpeedY = new int[8] { -1, -1, 0, 1, 1, 1, 0, -1 };

    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animation>();
        status = gameObject.GetComponent<PlayerStatus>();
    }

    public void setMoveAnim(float speedX, float speedY)
    {
        // Chuan hoa du lieu
        int sX = (speedX > 0 ? 1 : (speedX < 0 ? -1 : 0));
        int sY = (speedY > 0 ? 1 : (speedY < 0 ? -1 : 0));

        // Neu nhan vat dung yen
        if (sX == 0 && sY == 0)
        {

        }
        else
        {
            for (int i = 0; i < 8; i++)
            {
                if (stateSpeedX[i] == sX && stateSpeedY[i] == sY)
                {
                    transitMoveAnimation(i, status.curDirection);
                    status.curDirection = i;
                    break;
                }
            }

        }

    }

    private void transitMoveAnimation(int nextDirection, int curDirection)
    {
        if (curDirection == nextDirection) return;

    }
}

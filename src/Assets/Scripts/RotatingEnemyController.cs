﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utility;

public class RotatingEnemyController : Singleton<RotatingEnemyController>
{
    public Transform[] RotatingEnemies;
    public Transform[] EnemyStopPoints;
    public float AnimationTime = 5f;
    public float PauseTime = 3f;
    public int EnemiesAlive = 4;

    private Transform[] enemyDestination;

    void Start()
    {
        //StartRotations();
    }

    public void MoveToStartPos()
    {
        for (int i = 0; i < RotatingEnemies.Length; i++)
        {
            StartCoroutine(BasicAnimator.AnimateWorldPosition(RotatingEnemies[i], RotatingEnemies[i].position, EnemyStopPoints[i].position, 2F));
        }
        Invoke("StartRotations", 4f);
    }

    public void StartRotations()
    {
        CancelRotations();

        InvokeRepeating("RotateEnemies", 0f, AnimationTime + PauseTime);
    }

    public void CancelRotations()
    {
        CancelInvoke();
    }

    void RotateEnemies()
    {
        int i;
        for (i = 0; i < RotatingEnemies.Length - 1; i++)
        {
            if (RotatingEnemies[i] != null)
            {
                // move this enemy to the next position
                StartCoroutine(BasicAnimator.AnimateWorldPosition(RotatingEnemies[i], RotatingEnemies[i].position, EnemyStopPoints[i + 1].position, AnimationTime));
            }
        }
        if (RotatingEnemies[i] != null)
        {
            // if this is the last enemy in array, move it to the first position
            StartCoroutine(BasicAnimator.AnimateWorldPosition(RotatingEnemies[i], RotatingEnemies[i].position, EnemyStopPoints[0].position, AnimationTime));
        }

        // rotate the end points for next pass
        Transform temp = EnemyStopPoints[0];
        for (i = 0; i < EnemyStopPoints.Length - 1; i++)
        {
            EnemyStopPoints[i] = EnemyStopPoints[i + 1];
        }
        EnemyStopPoints[i] = temp;
    }

    public void OnEnemyDeath()
    {
        EnemiesAlive--;

        if (EnemiesAlive < 1)
        {
            GameStateController.Instance?.OnRotatingEnemiesCleared();
        }
    }
}

﻿using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class TestSuite
    {
        [SetUp]
        public void Setup()
        {

        }

        [TearDown]
        public void Teardown()
        {

        }

        // A Test behaves as an ordinary method
        [Test]
        public void TestSuiteSimplePasses()
        {
            // Use the Assert class to test conditions

        }

        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
        [UnityTest]
        public IEnumerator test_rotating_enemies_death_on_hit()
        {
            GameObject enemyGO = new GameObject("CapsuleEnemy");
            CapsuleEnemy enemy = enemyGO.AddComponent<CapsuleEnemy>();
            enemy.TakeDamageFromEvent();

            yield return new WaitForSeconds(.51f);

            Assert.IsFalse(enemyGO.activeInHierarchy);
        }

        [UnityTest]
        public IEnumerator test_rotating_enemies_cleared()
        {
            GameObject controllerGO = new GameObject("RotatingEnemyController");
            RotatingEnemyController controller = controllerGO.AddComponent<RotatingEnemyController>();

            GameObject enemyGO1 = new GameObject("CapsuleEnemy");
            CapsuleEnemy enemy1 = enemyGO1.AddComponent<CapsuleEnemy>();
            GameObject enemyGO2 = new GameObject("CapsuleEnemy");
            CapsuleEnemy enemy2 = enemyGO2.AddComponent<CapsuleEnemy>();
            GameObject enemyGO3 = new GameObject("CapsuleEnemy");
            CapsuleEnemy enemy3 = enemyGO3.AddComponent<CapsuleEnemy>();
            GameObject enemyGO4 = new GameObject("CapsuleEnemy");
            CapsuleEnemy enemy4 = enemyGO4.AddComponent<CapsuleEnemy>();

            enemy1.TakeDamageFromEvent();
            yield return null;
            enemy2.TakeDamageFromEvent();
            yield return null;
            enemy3.TakeDamageFromEvent();
            yield return null;
            enemy4.TakeDamageFromEvent();

            yield return new WaitForSeconds(.51f);

            Assert.AreEqual(0, controller.EnemiesAlive);
        }

        
    }
}

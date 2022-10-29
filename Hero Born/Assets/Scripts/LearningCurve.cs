using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LearningCurve : MonoBehaviour
{
    private Transform camTransform;
    public GameObject lightTransform;
    private Transform particleSystem;
   
    void Start()
    {
        Character hero = new Character();
        //hero.PrintStatsInfo(); //Вывод 1
        Character hero2 = hero;
        hero2.name = "Sir Krane the Brave"; // у hero тоже поменяется name, т.к класс - ссылочного типа
        //hero.PrintStatsInfo(); //Вывод 2
        //hero2.PrintStatsInfo(); //Вывод 2
        
        

        Character heroin = new Character("Agatha");
        //heroin.PrintStatsInfo();

        Weapon huntingBow = new Weapon("Hunting Bow", 105);
        //huntingBow.PrintWeaponStats(); //Вывод 1
        Weapon warBow = huntingBow;
        warBow.name = "War Bow"; // у hunting Bow name и damage не изменятся, т.к struct - типа значение
        warBow.damage = 155;
        //warBow.PrintWeaponStats(); //Вывод 2
        //huntingBow.PrintWeaponStats(); //Вывод 1

        Paladin knight = new Paladin("Sir Arthur", huntingBow);
        //knight.PrintStatsInfo();

        camTransform = this.GetComponent<Transform>();
        //Debug.Log(camTransform.localPosition);

        //particleSystem = GameObject.Find("Particle System").GetComponent<Transform>();
        //Debug.Log(particleSystem.localPosition);

        particleSystem = this.GetComponent<Transform>();
        //Debug.Log(particleSystem.localPosition);



    }
       
    void Update()
    {

    }
     
}

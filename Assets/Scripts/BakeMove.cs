using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BakeMove : MonoBehaviour
{
   [SerializeField] private float _speed;
   private Vector2 targetPos;
   public static bool isCooking;

   private void Update()
   {
      if (Shop._isShopOpen == true)
      {
         #if UNITY_ANDROID || UNITY_IOS
         if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
         {
            targetPos = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
            Collider2D hit = Physics2D.OverlapPoint(targetPos);

            if (hit != null && hit.CompareTag("Bake"))
            {
               transform.position = Vector2.MoveTowards(transform.position, targetPos, _speed * Time.deltaTime);
               isCooking = true;
            }
            else
            {
               isCooking = false;
            }
         }
         #endif
         
         #if UNITY_EDITOR
         
         if (Input.GetMouseButtonDown(0))
         {
            targetPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Collider2D hit = Physics2D.OverlapPoint(targetPos);

            if (hit != null && hit.CompareTag("Bake"))
            {
               transform.position = Vector2.MoveTowards(transform.position, targetPos, _speed * Time.deltaTime);
               isCooking = true;
            }
            else
            {
               isCooking = false;
            }
         }
         
         #endif
      }
   }
}

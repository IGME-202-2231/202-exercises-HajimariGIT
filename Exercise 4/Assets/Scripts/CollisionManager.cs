using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class CollisionManager : MonoBehaviour
{
    [SerializeField]
    List<SpriteInfo> collideables = new List<SpriteInfo>();
    bool control=true;
    public TextMesh collisionText;
    // Start is called before the first frame update
   
    public enum Mode
    {
        Sqaure,
        Circle
    }
   

    Mode modeState=Mode.Sqaure;
   
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StateChange();
          
        }

        CheckState();



        foreach (SpriteInfo sprite in collideables)
        {
            sprite.IsColliding = false;
        }

        onTouch();

       
       


    }
    void onTouch()
    {



        for (int i = 0; i < collideables.Count - 1; i++)
        {
            for (int j = i + 1; j < collideables.Count; j++)
            {
                SpriteInfo spriteA = collideables[i];
                SpriteInfo spriteB = collideables[j];

                bool isColliding = false;

                if (control == false)
                {
                    isColliding = AABBCheck(spriteA, spriteB);
                }
                else
                {
                   isColliding= Circle(spriteA, spriteB);
                }



                if (isColliding)
                {
                    spriteA.IsColliding = true;
                    spriteB.IsColliding = true;
                }
            }
        }
    }


    bool AABBCheck(SpriteInfo spriteA, SpriteInfo spriteB)
     {
      // Check for collisions

      if(spriteB.RectMin.x < spriteA.RectMax.x &&
          spriteB.RectMax.x > spriteA.RectMin.x &&
          spriteB.RectMin.y < spriteA.RectMax.y &&
          spriteB.RectMax.y > spriteA.RectMin.y)
      {
            return true;
      }
      else
      {
            return false;
      }
        
      
     }


   bool Circle(SpriteInfo spriteA, SpriteInfo spriteB)
    {
        double x= spriteB.center.x- spriteA.center.x;
        double y= spriteB.center.y -spriteA.center.y;
        double total =Math.Sqrt(x*x + y*y);
        if(total < spriteA.Radius + spriteB.Radius)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

   

    bool CheckState()
    {
        if (modeState == Mode.Sqaure)
        {
            collisionText.text = "Sqaure";
            return control = false;
        }
        else
        {
            collisionText.text = "circle";
            return control = true;
        
        }

    }

    void StateChange()
    {
       if(modeState == Mode.Sqaure)
        {
            modeState = Mode.Circle;
            CheckState();
        }
        else
        {
            modeState= Mode.Sqaure;
            CheckState();   
        }
       
        


    }








}

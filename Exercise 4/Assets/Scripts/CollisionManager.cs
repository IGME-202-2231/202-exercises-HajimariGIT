using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionManager : MonoBehaviour
{
    //controls collidables on screen and stores
    [SerializeField]
    List<SpriteInfo> collideables = new List<SpriteInfo>();
    //contros what equation to use
    bool control=true;
    //controls text
    public TextMesh collisionText;
    // Start is called before the first frame update
   
    /// <summary>
    /// controls current mode
    /// </summary>
    public enum Mode
    {
        Sqaure,
        Circle
    }
   
    //starting state
    Mode modeState=Mode.Sqaure;
   
    // Update is called once per frame
    void Update()
    {
        //if the user presses right click 
        if (Input.GetMouseButtonDown(0))
        {
            //change the state of game to opposite equation 
            StateChange();
          
        }

        //check state/text and change accordingly

        CheckState();

        //assign a staring value of false

        foreach (SpriteInfo sprite in collideables)
        {
            sprite.IsColliding = false;
        }

        //check for collisions
        onTouch();

       
       


    }
    void onTouch()
    {


        //compare each object with each object 
        for (int i = 0; i < collideables.Count - 1; i++)
        {
            for (int j = i + 1; j < collideables.Count; j++)
            {
                //store them
                SpriteInfo spriteA = collideables[i];
                SpriteInfo spriteB = collideables[j];

                //assume they are not collding 
                bool isColliding = false;
                //if control is false
                if (control == false)
                {
                    isColliding = AABBCheck(spriteA, spriteB);

                    if (isColliding)
                    {
                        //set both to true 
                        spriteA.IsColliding = true;
                        spriteB.IsColliding = true;
                    }
                }
                else
                {
                   isColliding= Circle(spriteA, spriteB);

                    if (isColliding)
                    {
                        //set both to true 
                        spriteA.IsColliding = true;
                        spriteB.IsColliding = true;
                    }
                }

                //otherwise 

                
            }
        }
    }

    /// <summary>
    /// Equation for checking boxes
    /// </summary>
    /// <param name="spriteA"></param>
    /// <param name="spriteB"></param>
    /// <returns></returns>
    bool AABBCheck(SpriteInfo spriteA, SpriteInfo spriteB)
     {
      // Check for collisions

      if(spriteB.RectMin.x < spriteA.RectMax.x &&
          spriteB.RectMax.x > spriteA.RectMin.x &&
          spriteB.RectMin.y < spriteA.RectMax.y &&
          spriteB.RectMax.y > spriteA.RectMin.y)
      {
            //there is one 
            return true;
      }
      else
      {
            //there is not one
            return false;
      }
        
      
     }


   bool Circle(SpriteInfo spriteA, SpriteInfo spriteB)
    {
        //Pythagorean theorem
        double x= spriteB.center.x- spriteA.center.x;
        double y= spriteB.center.y -spriteA.center.y;
        double total =Math.Sqrt(x*x + y*y);
        //check if they intersect
        if(total < spriteA.Radius + spriteB.Radius)
        {
            return true;
        }
        else
        {
            return false;
        } 
    }

   /// <summary>
   /// checks words and updates control to switch equations 
   /// </summary>
   /// <returns></returns>

    bool CheckState()
    {
        if (modeState == Mode.Sqaure)
        {
            collisionText.text = "Square";
            return control = false;
        }
        else
        {
            collisionText.text = "circle";
            return control = true;
        
        }

    }
    /// <summary>
    /// switches current state 
    /// </summary>

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

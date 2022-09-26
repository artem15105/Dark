using TMPro;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Controller : MonoBehaviour
{

    [Serializable]
    public class UiText
    {
        public TextMeshProUGUI thisPlayer;
    }

    [Serializable]
    public class BonusMotion
    {
        public Transform transform;
        public int countBonus;

    }



    [Serializable]
    public class ActivePerson
    {
        public GameObject obj;
        public Animator anim;
        public Rigidbody rigidbody;

        public int thisPosition = 1;
        public int thisWay = 0;

        public bool player = false;
        public bool life = true;


    }
    [Serializable]
    public class ControllerPerson
    {
        public int playerPerson = 0;
        public Transform startTransform;


        public List<ActivePerson> arrActivePerson = new List<ActivePerson>(4);
        public List<GameObject> arrPerson;
    }

    [Serializable]
    public class ControllerDrive
    {
        public List<GameObject> arrVisualBonusObj;
        public List<Transform> arrAllTrack;
        public List<BonusMotion> arrBonusTrack;

        public double speed = 0.02;

        public Animator animDice;
        public Animator animFork;

        public List<Transform> arrTransformTrack_0;
        public List<Transform> arrTransformTrack_1;
        public List<Transform> arrTransformTrack_2;
        public List<Transform> arrTransformTrack_3;

        public List<Transform> arrFork;


        public int thisMotionPerson = 0;
        public int targetMotionPerson = 0;


        public bool motion = true;
        public bool startPusk = true;
    }


    public ControllerDrive controllerDrive;
    public ControllerPerson controllerPerson;
    public CameraRotateAround cameraRotateAround;
    public UiText uiText;

    void Start()
    {
        for (int i = 0; i < controllerPerson.arrActivePerson.Count; i++)
        {
            if(i == 0)
            {
                controllerPerson.arrActivePerson[i] = new ActivePerson() { obj = Instantiate( controllerPerson.arrPerson[controllerPerson.playerPerson] )};
                controllerPerson.arrActivePerson[i].player = true;
            }
            else
            {
                controllerPerson.arrActivePerson[i] = new ActivePerson() { obj = Instantiate( controllerPerson.arrPerson[UnityEngine.Random.Range(0, controllerPerson.arrPerson.Count)] ) };
                controllerPerson.arrActivePerson[i].player = false;
            }

            controllerPerson.arrActivePerson[i].anim = controllerPerson.arrActivePerson[i].obj.GetComponent<Animator>();
            controllerPerson.arrActivePerson[i].obj.transform.position = controllerPerson.startTransform.position;
            controllerPerson.arrActivePerson[i].rigidbody = controllerPerson.arrActivePerson[i].obj.GetComponent<Rigidbody>();

            cameraRotateAround.target.position = controllerPerson.arrActivePerson[controllerDrive.thisMotionPerson].obj.transform.position;
            

        }

        for(int i = 0; i < 15; i++)
        {
            controllerDrive.arrBonusTrack[i] = new BonusMotion { transform = controllerDrive.arrAllTrack[UnityEngine.Random.Range(1, controllerDrive.arrAllTrack.Count - 1)], countBonus = UnityEngine.Random.Range(1, 5) };
            GameObject obj = Instantiate(controllerDrive.arrVisualBonusObj[controllerDrive.arrBonusTrack[i].countBonus]);
            obj.transform.position = controllerDrive.arrBonusTrack[i].transform.position + new Vector3(0, 10, 0);
        }
    }

    
    void Update()
    {
        if (controllerDrive.motion & controllerPerson.arrActivePerson[controllerDrive.thisMotionPerson].life)
        {


            if(controllerPerson.arrActivePerson[controllerDrive.thisMotionPerson].thisPosition < controllerDrive.targetMotionPerson)
            {
                Vector3 target = new Vector3(0,0,0);
                Vector3 distance = new Vector3(0, 0, 0);

                if (controllerPerson.arrActivePerson[controllerDrive.thisMotionPerson].thisWay == 0)
                {
                    if (controllerPerson.arrActivePerson[controllerDrive.thisMotionPerson].obj.transform.position == controllerDrive.arrTransformTrack_0[controllerDrive.arrTransformTrack_0.Count - 1].position)
                    {
                        controllerDrive.motion = false;
                        Debug.Log("GameOver");
                        controllerPerson.arrActivePerson[controllerDrive.thisMotionPerson].life = false;
                    }
                    target = controllerDrive.arrTransformTrack_0[controllerPerson.arrActivePerson[controllerDrive.thisMotionPerson].thisPosition].transform.position;
                    
                }
                else if (controllerPerson.arrActivePerson[controllerDrive.thisMotionPerson].thisWay == 1)
                {
                    if (controllerPerson.arrActivePerson[controllerDrive.thisMotionPerson].obj.transform.position == controllerDrive.arrTransformTrack_1[controllerDrive.arrTransformTrack_1.Count - 1].position)
                    {
                        controllerDrive.motion = false;
                        Debug.Log("GameOver");
                        controllerPerson.arrActivePerson[controllerDrive.thisMotionPerson].life = false;
                    }
                    target = controllerDrive.arrTransformTrack_1[controllerPerson.arrActivePerson[controllerDrive.thisMotionPerson].thisPosition].transform.position;
                   
                }
                else if (controllerPerson.arrActivePerson[controllerDrive.thisMotionPerson].thisWay == 2)
                {
                    if (controllerPerson.arrActivePerson[controllerDrive.thisMotionPerson].obj.transform.position == controllerDrive.arrTransformTrack_2[controllerDrive.arrTransformTrack_2.Count - 1].position)
                    {
                        controllerDrive.motion = false;
                        Debug.Log("GameOver");
                        controllerPerson.arrActivePerson[controllerDrive.thisMotionPerson].life = false;
                    }
                    target = controllerDrive.arrTransformTrack_2[controllerPerson.arrActivePerson[controllerDrive.thisMotionPerson].thisPosition].transform.position;
                   
                }
                else if (controllerPerson.arrActivePerson[controllerDrive.thisMotionPerson].thisWay == 3)
                {
                    if (controllerPerson.arrActivePerson[controllerDrive.thisMotionPerson].obj.transform.position == controllerDrive.arrTransformTrack_3[controllerDrive.arrTransformTrack_3.Count - 1].position)
                    {
                        controllerDrive.motion = false;
                        Debug.Log("GameOver");
                        controllerPerson.arrActivePerson[controllerDrive.thisMotionPerson].life = false;
                    }
                    target = controllerDrive.arrTransformTrack_3[controllerPerson.arrActivePerson[controllerDrive.thisMotionPerson].thisPosition].transform.position;
                    
                }


                controllerPerson.arrActivePerson[controllerDrive.thisMotionPerson].obj.transform.position = Vector3.MoveTowards(controllerPerson.arrActivePerson[controllerDrive.thisMotionPerson].obj.transform.position, target, (float) controllerDrive.speed); 

                if (controllerPerson.arrActivePerson[controllerDrive.thisMotionPerson].thisWay == 0)
                    distance = controllerDrive.arrTransformTrack_0[controllerPerson.arrActivePerson[controllerDrive.thisMotionPerson].thisPosition + 1].position - controllerPerson.arrActivePerson[controllerDrive.thisMotionPerson].obj.transform.position ;
                else if (controllerPerson.arrActivePerson[controllerDrive.thisMotionPerson].thisWay == 1)
                    distance = controllerDrive.arrTransformTrack_1[controllerPerson.arrActivePerson[controllerDrive.thisMotionPerson].thisPosition + 1].position - controllerPerson.arrActivePerson[controllerDrive.thisMotionPerson].obj.transform.position;
                else if (controllerPerson.arrActivePerson[controllerDrive.thisMotionPerson].thisWay == 2)
                    distance = controllerDrive.arrTransformTrack_2[controllerPerson.arrActivePerson[controllerDrive.thisMotionPerson].thisPosition + 1].position - controllerPerson.arrActivePerson[controllerDrive.thisMotionPerson].obj.transform.position;
                else if (controllerPerson.arrActivePerson[controllerDrive.thisMotionPerson].thisWay == 3)
                    distance = controllerDrive.arrTransformTrack_3[controllerPerson.arrActivePerson[controllerDrive.thisMotionPerson].thisPosition + 1].position - controllerPerson.arrActivePerson[controllerDrive.thisMotionPerson].obj.transform.position;

                controllerPerson.arrActivePerson[controllerDrive.thisMotionPerson].obj.transform.rotation = Quaternion.FromToRotation(Vector3.forward, distance);


                if (controllerPerson.arrActivePerson[controllerDrive.thisMotionPerson].thisWay == 0)
                {
                    if (controllerPerson.arrActivePerson[controllerDrive.thisMotionPerson].obj.transform.position == controllerDrive.arrTransformTrack_0[controllerPerson.arrActivePerson[controllerDrive.thisMotionPerson].thisPosition].transform.position)
                    {
                        controllerPerson.arrActivePerson[controllerDrive.thisMotionPerson].thisPosition++;
                    }

                   


                }
                else if (controllerPerson.arrActivePerson[controllerDrive.thisMotionPerson].thisWay == 1)
                {
                    if (controllerPerson.arrActivePerson[controllerDrive.thisMotionPerson].obj.transform.position == controllerDrive.arrTransformTrack_1[controllerPerson.arrActivePerson[controllerDrive.thisMotionPerson].thisPosition].transform.position)
                    {
                        controllerPerson.arrActivePerson[controllerDrive.thisMotionPerson].thisPosition++;
                    }
                    
                }
                else if (controllerPerson.arrActivePerson[controllerDrive.thisMotionPerson].thisWay == 2)
                {
                    if (controllerPerson.arrActivePerson[controllerDrive.thisMotionPerson].obj.transform.position == controllerDrive.arrTransformTrack_2[controllerPerson.arrActivePerson[controllerDrive.thisMotionPerson].thisPosition].transform.position)
                    {
                        controllerPerson.arrActivePerson[controllerDrive.thisMotionPerson].thisPosition++;
                    }
                    
                }
                else if (controllerPerson.arrActivePerson[controllerDrive.thisMotionPerson].thisWay == 3)
                {
                    if (controllerPerson.arrActivePerson[controllerDrive.thisMotionPerson].obj.transform.position == controllerDrive.arrTransformTrack_3[controllerPerson.arrActivePerson[controllerDrive.thisMotionPerson].thisPosition].transform.position)
                    {
                        controllerPerson.arrActivePerson[controllerDrive.thisMotionPerson].thisPosition++;
                    }
                    
                }

                foreach(Transform fork in controllerDrive.arrFork)
                {
                    if(fork.position == controllerPerson.arrActivePerson[controllerDrive.thisMotionPerson].obj.transform.position)
                    {
                        if (controllerPerson.arrActivePerson[controllerDrive.thisMotionPerson].player)
                        {
                            controllerDrive.motion = false;
                            controllerDrive.animFork.SetBool("active", true);
                            
                        }
                        else
                        {
                            int i = UnityEngine.Random.Range(0, 2);
                            if (i == 0)
                                leftForkMotion();
                            else
                                RightForkMotion();

                        }

                    }
                }

                foreach(BonusMotion bonus in controllerDrive.arrBonusTrack)
                {
                    if (controllerPerson.arrActivePerson[controllerDrive.thisMotionPerson].thisWay == 0)
                    {
                        if (bonus.transform.position == controllerDrive.arrTransformTrack_0[controllerDrive.targetMotionPerson - 1].position)
                        {
                            Debug.Log("Bonus");
                            controllerDrive.targetMotionPerson += bonus.countBonus;
                        }
                    }
                    else if (controllerPerson.arrActivePerson[controllerDrive.thisMotionPerson].thisWay == 1)
                    {
                        if (bonus.transform.position == controllerDrive.arrTransformTrack_1[controllerDrive.targetMotionPerson - 1].position)
                        {
                            Debug.Log("Bonus");
                            controllerDrive.targetMotionPerson += bonus.countBonus;
                        }
                    }
                    else if (controllerPerson.arrActivePerson[controllerDrive.thisMotionPerson].thisWay == 2)
                    {
                        if (bonus.transform.position == controllerDrive.arrTransformTrack_2[controllerDrive.targetMotionPerson - 1].position)
                        {
                            Debug.Log("Bonus");
                            controllerDrive.targetMotionPerson += bonus.countBonus;
                        }
                    }
                    else if (controllerPerson.arrActivePerson[controllerDrive.thisMotionPerson].thisWay == 3)
                    {
                        if (bonus.transform.position == controllerDrive.arrTransformTrack_3[controllerDrive.targetMotionPerson - 1].position)
                        {
                            Debug.Log("Bonus");
                            controllerDrive.targetMotionPerson += bonus.countBonus;
                        }
                    }

                }



            }

           
            else
            {
                controllerDrive.motion = false;
                controllerPerson.arrActivePerson[controllerDrive.thisMotionPerson].anim.SetInteger("stage", 1);

                if (controllerDrive.thisMotionPerson < controllerPerson.arrActivePerson.Count - 1)
                    controllerDrive.thisMotionPerson++;
                
                else
                    controllerDrive.thisMotionPerson = 0;

                controllerDrive.animDice.Play("Idle");
                controllerDrive.animDice.SetInteger("status", 0);

                if (!controllerPerson.arrActivePerson[controllerDrive.thisMotionPerson].player)
                    nextMotion();

                


            }

            



        }
        else if(!controllerPerson.arrActivePerson[controllerDrive.thisMotionPerson].life)
        {
            controllerDrive.motion = false;
            controllerPerson.arrActivePerson[controllerDrive.thisMotionPerson].anim.SetInteger("stage", 1);

            if (controllerDrive.thisMotionPerson < controllerPerson.arrActivePerson.Count - 1)
                controllerDrive.thisMotionPerson++;

            else
                controllerDrive.thisMotionPerson = 0;

            controllerDrive.animDice.Play("Idle");
            controllerDrive.animDice.SetInteger("status", 0);

            if (!controllerPerson.arrActivePerson[controllerDrive.thisMotionPerson].player)
                nextMotion();

            int i = 0;
            foreach (ActivePerson person in controllerPerson.arrActivePerson)
            {
                if (!person.life)
                    i++;
            }
            if(i >= controllerPerson.arrActivePerson.Count)
            {
                Debug.Log("ALLGameOver");
            }
        }

        cameraRotateAround.target.position = Vector3.MoveTowards(cameraRotateAround.target.position, controllerPerson.arrActivePerson[controllerDrive.thisMotionPerson].obj.transform.position, 0.8f);


    }

    public void nextMotion()
    {
        
        if (!controllerDrive.motion)
        {
            

            int rand = UnityEngine.Random.Range(1, 7);

            controllerDrive.animDice.SetInteger("status", rand);

            
            controllerDrive.targetMotionPerson = controllerPerson.arrActivePerson[controllerDrive.thisMotionPerson].thisPosition + rand;
            
            //cameraRotateAround.target = controllerPerson.arrActivePerson[controllerDrive.thisMotionPerson].obj.transform;

            controllerPerson.arrActivePerson[controllerDrive.thisMotionPerson].anim.SetInteger("stage", 2);

            uiText.thisPlayer.text = $"Player_{controllerDrive.thisMotionPerson + 1}";
        }
        
    }

    public void leftForkMotion()
    {
        if (controllerPerson.arrActivePerson[controllerDrive.thisMotionPerson].thisWay == 0)
            controllerPerson.arrActivePerson[controllerDrive.thisMotionPerson].thisWay = 1;
        else if (controllerPerson.arrActivePerson[controllerDrive.thisMotionPerson].thisWay == 1)
            controllerPerson.arrActivePerson[controllerDrive.thisMotionPerson].thisWay = 0;

        else if (controllerPerson.arrActivePerson[controllerDrive.thisMotionPerson].thisWay == 2)
            controllerPerson.arrActivePerson[controllerDrive.thisMotionPerson].thisWay = 3;


        controllerDrive.motion = true;
        controllerDrive.animFork.SetBool("active", false);
    }
    public void RightForkMotion()
    {
        if (controllerPerson.arrActivePerson[controllerDrive.thisMotionPerson].thisWay == 0)
            controllerPerson.arrActivePerson[controllerDrive.thisMotionPerson].thisWay = 2;
        if (controllerPerson.arrActivePerson[controllerDrive.thisMotionPerson].thisWay == 1)
            controllerPerson.arrActivePerson[controllerDrive.thisMotionPerson].thisWay = 1;
        else if (controllerPerson.arrActivePerson[controllerDrive.thisMotionPerson].thisWay == 2)
            controllerPerson.arrActivePerson[controllerDrive.thisMotionPerson].thisWay = 2;


        controllerDrive.motion = true;
        controllerDrive.animFork.SetBool("active", false);
    }
}

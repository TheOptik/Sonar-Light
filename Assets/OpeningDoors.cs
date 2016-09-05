﻿using UnityEngine;
using System.Collections;
using System;

public class OpeningDoors : MonoBehaviour {

    CharacterInventory inventory;
    public bool opensOutward = true;
    public float rotationSpeed = 90;
    private float rotationDirection = 1;
    private float currentRotation = 0;
    private float frameRotation = 0;
    private bool opened = false;

    void Start() { 
        // this.enabled = false;
        // bool rotating = true;
        opened = true;
        inventory = CharacterInventory.Instance;
        if (opensOutward){
            rotationDirection = 1;
        }
        else{
            rotationDirection = -1;
        }
    }

    void Update(){
        frameRotation = rotationDirection * Time.deltaTime * rotationSpeed;
        if (Math.Abs(currentRotation) > 90) {
            frameRotation = 90 * rotationDirection - currentRotation;
            currentRotation = 90;
            this.enabled = false;
            opened = !opened;
            currentRotation = 0 - frameRotation;
        }
        currentRotation += frameRotation;

        if (!opened) {
            transform.Rotate(transform.up, frameRotation);
        }
        else{
            transform.Rotate(transform.up, frameRotation * -1);
        }
    }

public void activate(){
    this.enabled = true;
    //Added for Key interaction
}

    bool CheckKey(){
        if (inventory.checkIfDoorCanBeOpened(this.gameObject)){
            ScreenPromptHandler.Instance.DisplayPrompt("Door has been opened!", 5);
            return true;
        }
        return false;
    }
}

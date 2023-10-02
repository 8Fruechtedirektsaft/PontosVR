# PontosVR
This game is about controlling a submarine and picking up things with its claw.

It is configured for the Oculus Quest though other Android VR devices may work aswell.

The project uses the XR Interaction Toolkit (https://docs.unity3d.com/Packages/com.unity.xr.interaction.toolkit@2.4/manual/index.html)

Assets from the Unity Asset Store:
https://assetstore.unity.com/packages/3d/environments/low-poly-rock-pack-57874
https://assetstore.unity.com/packages/3d/characters/animals/fish/fish-polypack-202232
https://assetstore.unity.com/packages/3d/environments/historic/greek-temple-vases-149134

The water shader is also not mine (unfortunately the source was removed from YouTube)


code summary:

Assets/Scripts/ClawGrabbable
-triggers an event when an object tagged as "Claw" enters its collider

Assets/Scripts/CrankInteraction
-moves a part of the claw of the submarine
-based on the movement of an object in the scene the player can touch

Assets/Scripts/FishMovement
-lets a "fish" object move forward and change its direction randomly at random time intervals
-casts rays to check wether its movement will be obstructed and adjusts the movement direction accordingly

Assets/Scripts/KeySocket
-triggers events when a object tagged as a key enters/exits its collider

Assets/Scripts/KeySocketEventArgs
-holds string for KeySocket events

Assets/Scripts/LeverInteraction
-propells submarine in a direction
-based on the movement of an object in the scene the player can touch

Assets/Scripts/RotationInteractable
-records the change of rotation of an object the player can touch

Assets/Scripts/RungInteraction
-propells submarine up and down
-forces the submarine downwards if it moves above a set water level
-based on the movement of an object in the scene the player can touch

Assets/Scripts/SeaweedBreak
-if the joint of a "seaweed" object breaks it changes the layer of the object so that it no longer clips through the floor 

Assets/Scripts/Tempel
-listens to KeySocket events 
-moves objects so that they become visible in the scene

Assets/Scripts/TestCameraFollow
-moves a "camera" object according to the movement of another object

Assets/Scripts/TestControls
-adds force to the objects in the submarine the player can touch

Assets/Scripts/WheelInteractionVR
-adjusts the rotation of a "wheel" object to follow the movement of a XR controller

Assets/Scripts/WinMessage
-when a "trident" object is grabbed by the submarines claw a UI message for the player is displayed and the scene reloads 
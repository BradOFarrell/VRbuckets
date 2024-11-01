I was given a prompt to make a multiplayer VR game in 1-2 weeks with the following specifications:

> Requirements:

1.  _Multiplayer_ using Normcore ([https://normcore.io/documentation/guides/xr-avatars-and-voice-chat](https://normcore.io/documentation/guides/xr-avatars-and-voice-chat)). Use Normcore to create a multiplayer VR environment where players can see each other's avatars and actions in real-time. Ensure smooth synchronization of player movements and interactions. The guide also includes voice chat. 
2.  _Score Tracking_: Develop a scoring system that awards points based on the number of successful throws, with bonus points for consecutive successes or trick shots.
3.  _Physics:_ Implement realistic ball physics for throwing. The game should include mechanics for players to grab, aim, and throw the ball through a hole positioned at various distances and heights. (Hint: you can set the ball velocity at the time of release based on controller velocity) 
4.  _Haptic Feedback (optional)_: Integrate haptic feedback to enhance the throwing experience, providing tactile sensations when grabbing or releasing the ball.
5.  _Gorilla Movement (optional)_: Integrate Gorilla Tag-like movement system - [https://github.com/Another-Axiom/GorillaLocomotion](https://github.com/Another-Axiom/GorillaLocomotion)

This was my first time using Normcore or developing for VR (other than simple 360 video wrappers) so I split the task into 1 week of small test projects, then 1 week on the actual project. All of the requirements were implemented, including the optional Gorilla Movement system - interpreted as a hoop-grabbing slam dunk mechanic. 

Here's what I did 

Week 1: Planning and preparation  

*   Monday: First day with the Meta Quest 3S hardware, researched similar games.
*   Tuesday: Completed basic normcore tutorials and VR tutorials
*   Wednesday: Research (and trial/error) on the optimal project settings for Unity XRI
*   Thursday: Started project, created background with horizon (to help with motion sickness) 
*   Friday:  First build of the game, got 2 characters sharing a ball with voice chat. ([video](https://www.youtube.com/watch?v=LASIN0cJC4E))
*   Weekend: I added some stubs for the hoop tracking and scoring system.

Week 2: Execution and tuning.

*   Monday: Modeled a 3D hoop and net in Blender, imported with custom collision on hoop.
*   Tuesday:  Added "gorilla movement" by letting character grab rim. ([video](https://www.youtube.com/watch?v=rB0aKlfGw8Q))
*   Wednesday: Added jumping and basic score tracking; Fixed bug in scoring. ([video](https://youtu.be/JslNoIDooLc))
*   Thursday: Tested with another player, confirmed ball stealing mechanic works. ([video](https://www.youtube.com/watch?v=XVEqTi3zlB8))
*   Friday: Added consecutive points and trick shots. Posted to github and itch.io 

Overall I had a lot of fun. This was my first time working with both Normcore an VR and I found both of them to be pretty intuitive. The biggest issue I had was mostly related to out-of-date documentation. Many Normcore documents refer to features in Unity XR that have changed or moved, or vise versa. One issue that caused a lot of headaches was the "Add object VR Origin" no longer produced a usable object. The [official solution from Unity staff](https://discussions.unity.com/t/xr-interaction-toolkit-3-0-rc-has-missing-controllers-under-xr-origin-vr/944659) was to import the sample rig rather than creating a new rig. In doing so, I gained access to the grabbing functionality which allowed me to implement the optional gorilla movement.

This project has gotten me excited about VR and the possibilities of simple multiplayer VR games.
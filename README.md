Follow Player With Multiple Spotlights
A Unity script that enables multiple spotlights to follow and optionally orbit around a player or any specified object in the scene. Each spotlight can have individual settings, like rotation and follow speeds, orbit radius, and more.

Features:
Follow Player: Spotlights can smoothly follow a player or specified object.

Orbit Around Player: Spotlights have the option to orbit around the player with specified speed and radius.

Customizable Settings: Each spotlight can be customized individually – including follow speed, rotation speed, orbit speed, and orbit radius.

Rotation Control: Control the direction of rotation (clockwise or anti-clockwise) for each spotlight.

How to Use:
Setup:

Attach the FollowPlayerWithMultipleSpotlights script to any game object in your scene.
Assign the player's transform (or the object you want the spotlights to follow) to the player field.
Adding Spotlights:

Increase the size of the spotlights array to add multiple spotlights.
For each spotlight:
Assign the transform of the spotlight to the spotlightTransform field.
Customize the settings as needed.
Settings:

followSpeed: The speed at which the spotlight follows the player.
rotationSpeed: Speed at which the spotlight turns to face the player.
orbitSpeed: Speed for the spotlight's orbit around the player.
orbitRadius: Distance from the player at which the spotlight should orbit.
rotateClockwise: Determines the rotation direction.
shouldRotate: Toggle if the spotlight should rotate around the player or just follow.
Running the Scene:

Once set up, simply run your scene. The spotlights will follow and/or orbit the player based on the settings you've chosen.
Requirements:
Unity 2019.4 or newer.

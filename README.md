# Unity car simulation

<img src="Car_Demo.gif" width="1200" alt="Program Demo">

Created a car simulation in Unity with wheel colliders and suspension physics. The car body is a low poly model of the Honda Prelude 1983 that I modelled in Blender. Currently when steering the car, the front wheels turn at the same angle. This is not ideal as it causes slips (which is why the car drifts in the demo above). To prevent this, I will implement [Ackermann Steering](https://en.wikipedia.org/wiki/Ackermann_steering_geometry) in a future iteration. There is also a script for the camera to smoothly follow the car.

To control the car use the arrow keys:\
**UP** = Accelarate\
**DOWN** = Decelarate and reverse\
**LEFT/RIGHT** = Steer

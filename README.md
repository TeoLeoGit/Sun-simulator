# Sun simulation

## Table of contents
* [General info](#general-info)
* [Background](#background)
* [Set up](#set-up)
* [Result](#result)

## General info
This project is created to simulate the altitude and position of the sun base on the coordinates of a location on Earth at a specific time in a day of a year. 

## Background
To calculate and simulate the altitude and position of the Sun at a coordinate on Earth, we need to measure the **elevation angle** and the **azimuth angle** of the Sun.
* **Elevation angle**: The solar elevation is the angular distance between the imaginary horizontal plane on which you are standing and the sun in the sky. It is also known as the solar latitude angle and measured in degrees. In simple words, it tells at what height the sun is in the sky. In the morning and evening, the sun is low in the sky, near the horizon. So, the solar elevation is close to 0°, whereas, at solar noon, the solar elevation angle is highest since the sun is overhead.

  ![Elevation angle](https://solarsena.wpengine.com/wp-content/uploads/2021/04/solar-elevation-angle-noon-morning-evening.png)
* **Azimuth angle**: The solar azimuth angle is a way to identify the position of the sun in the sky. It defines the horizontal position of the sun on the local horizontation of solar panels.

  ![Azimuth angle](https://solarsena.wpengine.com/wp-content/uploads/2021/04/solar-azimuth-angle-direction.png)

* When we have measured these two angles, we can locate the position of the Sun.

  ![Position of the Sun](https://keisan.casio.com/keisan/lib/real/system/2006/1224682277/anglefigure.gif)

To achieve that, we need to first estimate the **hour angle**, and the **declination angle** for measuring the **solar elevation angle** and then we can be able to find the **azimuth angle**.

* The solar **hour angle** is a measure of the angular distance between the sun at the local solar time and the sun at solar noon. It is expressed in degrees or radians.

  ![Hour angle](https://solarsena.wpengine.com/wp-content/uploads/2021/04/solar-hour-angle-suns.png)
  
### Solar hour angle formula
Let LST be the local solar time in the 24-hour format. The solar hour angle (h) in degrees is as follows:

  ![Hour angle formula](https://solarsena.wpengine.com/wp-content/uploads/2021/04/solar-hour-angle-formula.svg)
 
In the above equation, the local solar time (LST) is in hours. We can convert LST in hours to LST in minutes.
  
  ![Hour angle formula - minute](https://solarsena.wpengine.com/wp-content/uploads/2021/04/solar-hour-angle-formula-min.svg)

* The solar **declination angle** is the angle between the rays of the sun and the equator of the earth. It is usually denoted by “δ.” Solar declination angle is very useful in calculating the sun elevation and the azimuth angle.
  
  ![Declination angle](https://solarsena.wpengine.com/wp-content/uploads/2021/04/declination-angle-earth-sun.png)
  
* The solar **declination angle** changes time-to-time; it is not a constant number. It will be different every single day. However, the angle restricts itself between 23.44° and −23.44°. It oscillates between these two numbers; it will never cross 23.44° or fall behind −23.44°. Thus, we can conclude, the maximum value of the solar declination angle is 23.44°, and the minimum is −23.44°.

  ![Declination angle](https://solarsena.wpengine.com/wp-content/uploads/2021/04/equinox-solstice.png)
  
### Solar declination angle formula
We can calculate the solar declination angle using the following formula:

  ![Declination angle formula](https://solarsena.wpengine.com/wp-content/uploads/2021/04/declination-angle-formula.svg)

In the above formula, d is the number of days since January 1st (UTC 00:00:00). For example, On March 3rd (UTC 00:00:00), d = 31 + 28 + 2 = 61. On December 31st (UTC 00:00:00), d = 364.

Now we can measure the **elevation angle**. 

* The solar elevation is the angular distance between the imaginary horizontal plane on which you are standing and the sun in the sky. It is also known as the solar latitude angle and measured in degrees. In simple words, it tells at what height the sun is in the sky. In the morning and evening, the sun is low in the sky, near the horizon. So, the solar elevation is close to 0°, whereas, at solar noon, the solar elevation angle is highest since the sun is overhead.

  ![Elevation angle](https://solarsena.wpengine.com/wp-content/uploads/2021/04/solar-elevation-angle-noon-morning-evening.png)

The solar elevation is the measurement of the height (or altitude) of the sun in the sky.

### Solar elevation angle formula

The solar elevation formula is as follows:

  ![Elevation angle formula](https://solarsena.wpengine.com/wp-content/uploads/2021/04/declination-angle-formula.svg)
  
Here, ɑ is the solar elevation angle, δ is the declination angle, ɸ is the latitude of your location, and h is the solar hour angle.

Therefore, we require three variables (latitude, declination, hour angle) to calculate the elevation of the sun.

Final step, measuring the **azimuth angle**.

* The **solar azimuth** angle defines the horizontal coordinates of the sun relative to the observer. It is defined as the angular distance between the projection of the sun on the imaginary horizontal plane on which the observer is standing and the reference direction. In solar technology, the reference direction is north.

### Solar azimuth angle formula

The azimuth angle is calculated using the following formula:

  ![Azimuth angle formula](https://solarsena.wpengine.com/wp-content/uploads/2021/04/azimuth-angle-formula.svg)

Here, A is the azimuth angle, δ is the declination angle, φ is the latitude, h is the hour angle, and ɑ is the solar elevation angle.

The hour angle (h) can be positive (after solar noon) and negative (before the solar noon). When h is positive, we have to subtract A from 360°.

  ![Azimuth angle formula 2](https://solarsena.wpengine.com/wp-content/uploads/2021/04/azimuth-angle-example-noon.svg)

### References
For more information, you can check the links listed below:
* Solar hour angle: https://solarsena.com/solar-hour-angle-calculator-formula/
* Solar declination angle: https://solarsena.wpengine.com/solar-declination-angle-calculator/
* Solar elevation angle: https://solarsena.wpengine.com/solar-elevation-angle-altitude/
* Solar azimuth angle:https://solarsena.com/solar-azimuth-angle-calculator-solar-panels/

## Set up

## Result


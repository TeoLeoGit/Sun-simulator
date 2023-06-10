# Sun simulation

## Table of contents
* [General info](#general-info)
* [Background](#background)
* [Implementation](#Implementation)
* [Set up](#setup)

## General info
This project is created to simulate the altitude and position of the sun base on the coordinates of a location on Earth at a specific time in a day of a year.

## Background
To calculate and simulate the altitude and position of the Sun, we need to understand some terms:
* **Elevation angle**: The solar elevation is the angular distance between the imaginary horizontal plane on which you are standing and the sun in the sky. It is also known as the solar latitude angle and measured in degrees. In simple words, it tells at what height the sun is in the sky. In the morning and evening, the sun is low in the sky, near the horizon. So, the solar elevation is close to 0°, whereas, at solar noon, the solar elevation angle is highest since the sun is overhead.

  ![Elevation angle](https://solarsena.wpengine.com/wp-content/uploads/2021/04/solar-elevation-angle-noon-morning-evening.png)
* **Azimuth angle**: The solar azimuth angle is a way to identify the position of the sun in the sky. It defines the horizontal position of the sun on the local horizontation of solar panels.

  ![Azimuth angle](https://solarsena.wpengine.com/wp-content/uploads/2021/04/solar-azimuth-angle-direction.png)

* When we have measured these two angles, we can locate the position of the Sun.

  ![Alzemith](https://keisan.casio.com/keisan/lib/real/system/2006/1224682277/anglefigure.gif)

To achieve that, we need to first estimate the **declination angle**, and **hour angle** for measuring the **solar elevation angle** and then we can be able to find the **azimuth angle**.

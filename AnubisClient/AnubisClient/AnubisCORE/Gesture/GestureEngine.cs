﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnubisClient.AnubisCORE.Gesture
{
    public class GestureEngine
    {

        Queue<double> old_velocities;
        double foot_right_old_position = 0;
        double foot_left_old_position = 0;


        public GestureEngine()
        {
            old_velocities = new Queue<double>();
        }

        public void newFrame(SkeletonRep modify, SkeletonRep kinect)
        {
            double foot_right_point_length = Math.Abs(kinect.AnkleRight.Pitch - kinect.FootRight.Pitch);
            double foot_left_point_length = Math.Abs(kinect.AnkleLeft.Pitch - kinect.FootLeft.Pitch);
            if (foot_right_point_length > 0.07)
            {
                modify.FootLeft.Pitch = 40;
            }
            if (foot_left_point_length > 0.07)
            {
                modify.FootRight.Pitch = 40;
            }



            if (foot_left_old_position != 0 && foot_right_old_position != 0)
            {
                double foot_right_velocity = Math.Abs(kinect.FootRight.Yaw - foot_right_old_position);
                double foot_left_velocity = Math.Abs(kinect.FootLeft.Yaw - foot_left_old_position);
                //Such Magic Numbers!!
                old_velocities.Enqueue(foot_right_velocity + foot_left_velocity);
            }

            if (old_velocities.Count > 15)
            {
                old_velocities.Dequeue();
            }

            if (old_velocities.Count > 0)
            {
                double velocity_sum = 0;
                foreach (double velocity in old_velocities)
                {
                    velocity_sum += velocity;
                }
                double average_velocity = velocity_sum / old_velocities.Count;
                if (average_velocity > 0.04)
                {
                    modify.FootLeft.Pitch = 40;
                    modify.FootRight.Pitch = 40;
                }
            }

            foot_left_old_position = kinect.FootLeft.Yaw;
            foot_right_old_position = kinect.FootRight.Yaw;
        }

    }
}

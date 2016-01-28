using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnubisClient
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

        public void newFrame(SkeletonRep mod)
        {
            double foot_right_point_length = Math.Abs(mod.AnkleRight.X - mod.FootRight.X);
            double foot_left_point_length = Math.Abs(mod.AnkleLeft.X - mod.FootLeft.X);

            //turn in place to the right
            if (foot_right_point_length > 0.07)
            {
                mod.FootLeft.Pitch = 40;
                mod.FootRight.Pitch = 140;
            }
            //turn in place to the left
            if (foot_left_point_length > 0.07)
            {
                mod.FootRight.Pitch = 40;
                mod.FootLeft.Pitch = 140;
            }

            //going backwards code 
            if ((Math.Abs(mod.FootRight.Z) > Math.Abs(mod.FootLeft.Z) + .35) || (Math.Abs(mod.FootLeft.Z) > Math.Abs(mod.FootRight.Z) + .35))
            {
                mod.FootLeft.Pitch = 140;
                mod.FootRight.Pitch = 140;
            }

            if (foot_left_old_position != 0 && foot_right_old_position != 0)
            {
                double foot_right_velocity = Math.Abs(mod.FootRight.Y - foot_right_old_position);
                double foot_left_velocity = Math.Abs(mod.FootLeft.Y - foot_left_old_position);
                //Such Magic Numbers!!
                old_velocities.Enqueue(foot_right_velocity + foot_left_velocity);
            }

            //The queue size is 15.  This allows for about 1/2 second of buffering
            //at 30fps.  This roughly translates to response time, so it is important
            //to keep it low.
            if (old_velocities.Count > 15)
            {
                old_velocities.Dequeue();
            }

            //calculate the average velocity and compare it to our threshhold.
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
                    mod.FootLeft.Pitch = 40;
                    mod.FootRight.Pitch = 40;
                }
            }

            foot_left_old_position = mod.FootLeft.Y;
            foot_right_old_position = mod.FootRight.Y;
        }

    }
}

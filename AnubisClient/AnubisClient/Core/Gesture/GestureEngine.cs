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
            if (!mod.Joints[SkeletonRep.JointType.AnkleLeft].Tracked || !mod.Joints[SkeletonRep.JointType.FootLeft].Tracked || !mod.Joints[SkeletonRep.JointType.AnkleRight].Tracked || !mod.Joints[SkeletonRep.JointType.FootRight].Tracked)
            {
                mod.Joints[SkeletonRep.JointType.FootLeft].Pitch = 90;
                mod.Joints[SkeletonRep.JointType.FootRight].Pitch = 90;
                old_velocities.Clear();
                return;
            }

            double foot_right_point_length = Math.Abs(mod.Joints[SkeletonRep.JointType.AnkleRight].X - mod.Joints[SkeletonRep.JointType.FootRight].X);
            double foot_left_point_length = Math.Abs(mod.Joints[SkeletonRep.JointType.AnkleLeft].X - mod.Joints[SkeletonRep.JointType.FootLeft].X);

            //turn in place to the right
            if (foot_right_point_length > 0.07)
            {
                mod.Joints[SkeletonRep.JointType.FootLeft].Pitch = 40;
                mod.Joints[SkeletonRep.JointType.FootRight].Pitch = 140;
            }
            //turn in place to the left
            if (foot_left_point_length > 0.07)
            {
                mod.Joints[SkeletonRep.JointType.FootRight].Pitch = 40;
                mod.Joints[SkeletonRep.JointType.FootLeft].Pitch = 140;
            }
            System.Diagnostics.Debug.WriteLine(foot_left_point_length.ToString() + " " + foot_right_point_length.ToString());

            //going backwards code 
            if ((Math.Abs(mod.Joints[SkeletonRep.JointType.FootRight].Z) > Math.Abs(mod.Joints[SkeletonRep.JointType.FootLeft].Z) + .35) || (Math.Abs(mod.Joints[SkeletonRep.JointType.FootLeft].Z) > Math.Abs(mod.Joints[SkeletonRep.JointType.FootRight].Z) + .35))
            {
                mod.Joints[SkeletonRep.JointType.FootLeft].Pitch = 140;
                mod.Joints[SkeletonRep.JointType.FootRight].Pitch = 140;
            }

            if (foot_left_old_position != 0 && foot_right_old_position != 0)
            {
                double foot_left_velocity = Math.Abs(mod.Joints[SkeletonRep.JointType.AnkleLeft].Y - foot_left_old_position);
                double foot_right_velocity = Math.Abs(mod.Joints[SkeletonRep.JointType.AnkleRight].Y - foot_right_old_position);
                //Such Magic Numbers!!
                old_velocities.Enqueue(foot_right_velocity + foot_left_velocity);
            }

            //The queue size is 15.  This allows for about 1/2 second of buffering
            //at 30fps.  This roughly translates to response time, so it is important
            //to keep it low.
            //calculate the average velocity and compare it to our threshhold.
            if (old_velocities.Count > 15)
            {
                double velocity_sum = 0;
                foreach (double velocity in old_velocities)
                {
                    velocity_sum += velocity;
                }
                double average_velocity = velocity_sum / old_velocities.Count;
                if (average_velocity > 0.04)
                {
                    mod.Joints[SkeletonRep.JointType.AnkleLeft].Pitch = 40;
                    mod.Joints[SkeletonRep.JointType.AnkleRight].Pitch = 40;
                }

                old_velocities.Dequeue();
            }

            foot_left_old_position = mod.Joints[SkeletonRep.JointType.AnkleLeft].Y;
            foot_right_old_position = mod.Joints[SkeletonRep.JointType.AnkleRight].Y;
        }

    }
}

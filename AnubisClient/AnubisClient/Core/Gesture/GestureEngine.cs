using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnubisClient
{
    /// <summary>
    /// Provides the ability to recognize gestures and update the current frame's Skeleton with new information accordingly
    /// </summary>
    public static class GestureEngine
    {
        //information about leg movement
        private static Queue<double> old_velocities = new Queue<double>();
        private static double foot_right_old_position = 0;
        private static double foot_left_old_position = 0;
        //setting this true tells Johnny5 to go forward
        //allows us to have different "turn on" and "turn off" conditions (we're using it to reduce sensetivity to idle noise)
        private static bool forward_noise_gate = false;

        /// <summary>
        /// Try to recognize gestures in the new frame and modify the Skeleton accordingly
        /// </summary>
        public static void NewFrame(SkeletonRep mod)
        {
            if (!mod.Joints[SkeletonRep.JointType.AnkleLeft].Tracked || !mod.Joints[SkeletonRep.JointType.FootLeft].Tracked || !mod.Joints[SkeletonRep.JointType.AnkleRight].Tracked || !mod.Joints[SkeletonRep.JointType.FootRight].Tracked)
            {
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
            else if (foot_left_point_length > 0.07)
            {
                mod.Joints[SkeletonRep.JointType.FootRight].Pitch = 40;
                mod.Joints[SkeletonRep.JointType.FootLeft].Pitch = 140;
            }
            //going backwards code 
            else if ((Math.Abs(mod.Joints[SkeletonRep.JointType.AnkleRight].Z) > Math.Abs(mod.Joints[SkeletonRep.JointType.AnkleLeft].Z) + .35) || (Math.Abs(mod.Joints[SkeletonRep.JointType.AnkleLeft].Z) > Math.Abs(mod.Joints[SkeletonRep.JointType.AnkleRight].Z) + .35))
            {
                mod.Joints[SkeletonRep.JointType.FootLeft].Pitch = 140;
                mod.Joints[SkeletonRep.JointType.FootRight].Pitch = 140;
            }
            //going forwards code
            else
            {
                if (foot_left_old_position != 0 && foot_right_old_position != 0)
                {
                    double foot_left_velocity = Math.Abs(mod.Joints[SkeletonRep.JointType.AnkleLeft].Y - foot_left_old_position);
                    double foot_right_velocity = Math.Abs(mod.Joints[SkeletonRep.JointType.AnkleRight].Y - foot_right_old_position);
                    old_velocities.Enqueue(foot_right_velocity + foot_left_velocity);
                }
                foot_left_old_position = mod.Joints[SkeletonRep.JointType.AnkleLeft].Y;
                foot_right_old_position = mod.Joints[SkeletonRep.JointType.AnkleRight].Y;

                if (old_velocities.Count >= 10)
                {
                    double velocities_past_threshold = 0;
                    foreach (double velocity in old_velocities)
                    {
                        if (velocity > 0.04) // arbitrary threshold velocities must past to be counted towards our forward signal
                            velocities_past_threshold++;
                    }
                    if (velocities_past_threshold >= (old_velocities.Count * 0.6)) // open noise gate when greater than or equal to 60% of the queue length is above our threshold
                        forward_noise_gate = true;
                    if (velocities_past_threshold <= (old_velocities.Count * 0.1)) // close noise gate when less than or equal to 20% of the queue length is above our threshold
                        forward_noise_gate = false;
                    if(forward_noise_gate)
                    {
                        mod.Joints[SkeletonRep.JointType.FootLeft].Pitch = 40;
                        mod.Joints[SkeletonRep.JointType.FootRight].Pitch = 40;
                    }
                    old_velocities.Dequeue();
                }
            }
        }

    }
}

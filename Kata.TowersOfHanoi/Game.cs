using System;
using System.Diagnostics;

namespace Kata.TowersOfHanoi
{
    public class Game
    {
        public Game(int numberOfDisks)
        {
            this.Tower1 = new Tower("A");
            this.Tower2 = new Tower("B");
            this.Tower3 = new Tower("C");

            for (int i = numberOfDisks; i > 0; i--)
            {
                this.Tower1.Disks.Push(i);
            }
        }

        public Tower Tower1 { get; set; }
        public Tower Tower2 { get; set; }
        public Tower Tower3 { get; set; }

        public bool IsValid
        {
            get
            {
                return ValidateTower(Tower1) && ValidateTower(Tower2) && ValidateTower(Tower3);
            }
        }

        public bool IsFinished
        {
            get { return IsValid && Tower1.Disks.Count == 0 && Tower2.Disks.Count == 0; }

        }

        private bool ValidateTower(Tower tower)
        {
            var previousDisk = 0;

            foreach (var disk in tower.Disks)
            {
                if (previousDisk > 0 && previousDisk > disk)
                {
                    return false;
                }
                previousDisk = disk;
            }
            return true;
        }


        public void Start()
        {
            this.MoveDiskRecursive(this.Tower1, this.Tower3, this.Tower2, this.Tower1.Disks.Count);
        }

        public void MoveDiskRecursive(Tower source, Tower target, Tower buffer, int n)
        {
            if (n == 1)
            {
                this.MoveDisk(source, target);
            }
            else
            {
                this.MoveDiskRecursive(source, buffer, target, n - 1);
                this.MoveDiskRecursive(source, target, buffer, 1);
                this.MoveDiskRecursive(buffer, target, source, n-1);
            }
        }

        public void MoveDisk(Tower from, Tower to)
        {
            Trace.WriteLine(string.Format("Move disk from {0} to {1}", from, to));
            var disk = from.Disks.Pop();
            to.Disks.Push(disk);

            if (this.ValidateTower(from) == false ||  this.ValidateTower(to) == false)
            {
                throw new Exception("Validate failed");
            }
        }
    }
}
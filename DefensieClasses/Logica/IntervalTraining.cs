using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Logica
{
    internal class IntervalTraining(string name, int sortTraining, int amount, int time, int meters) : Training
    {
        private string Name { get; set; } = name;
        private int SortTraining { get; set; } = sortTraining;
        private int Amount { get; set; } = amount;
        private int Time { get; set; } = time;
        private int Meters { get; set; } = meters;

        private string TrainingWarmupAndCoolingDown = "5-10 minuten rustig joggen.";

        public override string GetTrainingName() { return Name ; }

        public override string GetWarmCoolDown() { return TrainingWarmupAndCoolingDown; }

        public override string GetMainExercise() { return $"{Meters} meter hardlopen in {Time}.\nDaarna {Meters} rustig joggen.\nHerhaal dit {Amount} aantal keren."; }
    }
}

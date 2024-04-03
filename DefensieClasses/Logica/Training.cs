using System;

public abstract class Training
{
	private string Name {  get; set; }
    private int SortTraining { get; set; }
    private int Amount { get; set; }
    private int Time { get; set; }

    public abstract string GetTrainingName();

    public abstract string GetWarmCoolDown();

    public abstract string GetMainExercise();



}

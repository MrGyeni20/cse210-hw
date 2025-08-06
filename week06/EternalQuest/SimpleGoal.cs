class SimpleGoal : Goal
{
    private bool completed;

    public SimpleGoal(string name, string description, int points, bool completed = false)
        : base(name, description, points)
    {
        this.completed = completed;
    }

    public override int RecordEvent()
    {
        if (!completed)
        {
            completed = true;
            return Points;
        }
        return 0;
    }

    public override bool IsComplete() => completed;

    public override string GetStatus() => completed ? "[X]" : "[ ]";

    public override string Serialize() =>
        $"SimpleGoal|{Name}|{Description}|{Points}|{completed}";
}
